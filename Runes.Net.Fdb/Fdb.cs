using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Ionic.Zlib;
using Runes.Net.Shared;

namespace Runes.Net.Fdb
{
    public class Fdb : IDisposable
    {
        public bool IsOpened { get; protected set; }
        protected BinaryReader File;
        public byte FdbVersion { get; set; }
        public List<FileEntry> Entries { get; protected set; }
        public void LoadFromFile(string fileName)
        {
            IsOpened = false;
            var f = new StreamReader(fileName);
            File = new BinaryReader(f.BaseStream);
            IsOpened = true;

            FdbVersion = File.ReadByte();
            var magickey = Encoding.ASCII.GetString(File.ReadBytes(3));
            if (magickey != "BDF")
                throw new IOException("Invalid FDB file");
            var filesCount = File.ReadUInt32();
            Entries = new List<FileEntry>((int) filesCount);
            for (var i = 0; i < filesCount; ++i)
            {
                var type = (FdbFileType) File.ReadUInt32();
                FileEntry entry;
                switch (type)
                {
                    case FdbFileType.Regular:
                        entry = new FileEntry
                        {
                            FileType = type,
                            LastModificationTime = DateTime.FromFileTime(File.ReadInt64()),
                            FileBlockAddress = File.ReadUInt32()
                        };
                        break;
                    case FdbFileType.Texture:
                        entry = new TextureFileExtry()
                        {
                            FileType = type,
                            LastModificationTime = DateTime.FromFileTime(File.ReadInt64()),
                            FileBlockAddress = File.ReadUInt32()
                        };
                        break;
                    default:
                        throw new IOException("Unknown file entry type");
                }
                Entries.Add(entry);
            }
            for (var i = 0; i < filesCount; ++i)
            {
                Entries[i].FileNameSize = File.ReadUInt32();
            }
            var nameTableSize = File.ReadUInt32();
            for (var i = 0; i < filesCount; ++i)
            {
                Entries[i].FileName = File.ReadNullTerminated();
                Entries[i].FileNameSize = (uint) Entries[i].FileName.Length;
            }

            for (var i = 0; i < filesCount; ++i)
            {
                var entry = Entries[i];
                entry.Read(File);
                File.BaseStream.Position += entry.ActualDataSize;
            }

        }
        public void ExtractFile(string fileName, BinaryWriter target)
        {
            var e = this[fileName];
            if (e == null)
                throw new Exception("File not found");
            File.BaseStream.Position = e.FileDataAddress;
            var endPos = File.BaseStream.Position + e.ActualDataSize;
            switch (e.CompressionType)
            {
                default:
                    while (File.BaseStream.Position < endPos)
                    {
                        var buffer = File.ReadBytes((int) Math.Min(4096, endPos - File.BaseStream.Position));
                        target.Write(buffer);
                    }
                    break;
                case FdbCompressionType.Zlib:
                    var bytes = File.ReadBytes((int) e.ActualDataSize);
                    var bytesOut = Inflate(bytes);
                    target.Write(bytesOut, 0, bytesOut.Length);
                    break;
            }
        }
        internal static byte[] Inflate(byte[] data)
        {
            var outputSize = 1024;
            var output = new byte[outputSize];
            using (var ms = new MemoryStream())
            {
                var compressor = new ZlibCodec();
                compressor.InitializeInflate(true);
                compressor.InputBuffer = data;
                compressor.AvailableBytesIn = data.Length;
                compressor.NextIn = 0;
                compressor.OutputBuffer = output;

                foreach (var f in new [] { FlushType.None, FlushType.Finish })
                {
                    int bytesToWrite;
                    do
                    {
                        compressor.AvailableBytesOut = outputSize;
                        compressor.NextOut = 0;
                        compressor.Inflate(f);

                        bytesToWrite = outputSize - compressor.AvailableBytesOut;
                        if (bytesToWrite > 0)
                            ms.Write(output, 0, bytesToWrite);
                    }
                    while ((f == FlushType.None && (compressor.AvailableBytesIn != 0 || compressor.AvailableBytesOut == 0)) ||
                        (f == FlushType.Finish && bytesToWrite != 0));
                }

                compressor.EndInflate();

                return ms.ToArray();
            }
        }
        public IEnumerable<FileEntry> ListFilesInDirAndSubDirs(string dir = "")
        {
            if (dir != "" && !dir.EndsWith(@"\"))
                dir += @"\";
            return Entries.Where(entry => entry.FileName.StartsWith(dir));
        }
        public IEnumerable<FileEntry> ListFilesInDir(string dir = "")
        {
            if (dir != "" && !dir.EndsWith(@"\"))
                dir += @"\";
            return from e in Entries 
                   where e.FileName.StartsWith(dir) 
                   let ename = e.FileName.Substring(dir.Length) 
                   where !ename.Contains(@"\") 
                   select e;
        }
        public IEnumerable<string> ListDirectories(string dir = "")
        {
            var subfiles = ListFilesInDirAndSubDirs(dir);
            var dirs = new List<string>();
            foreach (var entry in subfiles)
            {
                var pos = entry.FileName.IndexOf(@"\", StringComparison.Ordinal);
                if (pos < 0)
                    continue;
                var dirName = entry.FileName.Substring(0, pos);
                if (dirs.Contains(dirName))
                    continue;
                dirs.Add(dirName);
            }
            return dirs;
        }


        public FileEntry this[string name]
        {
            get
            {
                var entries = Entries.Where(e => e.FileName.Equals(name, StringComparison.InvariantCultureIgnoreCase)).ToArray();
                if (!entries.Any())
                    return null;
                try
                {
                    return entries.First();
                }
                catch
                {
                    throw new Exception("Multiple files with the same name");
                }
            }
        }
        public void Close()
        {
            if (!IsOpened) return;
            File.Close();
            IsOpened = false;
        }
        public void Dispose()
        {
            Close();
        }
    }
}

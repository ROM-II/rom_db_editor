using System;
using System.IO;
using System.Text;
using Microsoft.SqlServer.Server;

namespace Runes.Net.Fdb
{
    public class FileEntry : IBinarySerialize
    {
        public uint FileBlockAddress { get; set; }
        public uint FileDataAddress { get; set; }

        public uint FileBlockSize { get; set; }
        public FdbFileType FileType { get; set; }
        public FdbCompressionType CompressionType { get; set; }
        public uint UncompressedFileSize { get; set; }
        public uint CompressedFileSize { get; set; }
        public DateTime LastModificationTime { get; set; }
        public uint FileNameSize { get; set; }
        public string FileName { get; set; }

        public uint ActualDataSize { get; set; }

        public virtual void Read(BinaryReader r)
        {
            var pos = r.BaseStream.Position;
            FileBlockSize = r.ReadUInt32();
            FileType = (FdbFileType) r.ReadUInt32();
            CompressionType = (FdbCompressionType)r.ReadUInt32();
            UncompressedFileSize = r.ReadUInt32();
            CompressedFileSize = r.ReadUInt32();
            var moddate = r.ReadUInt64();
            LastModificationTime = DateTime.FromFileTime((long) moddate);
            FileNameSize = r.ReadUInt32();
            FileName = Encoding.ASCII.GetString(r.ReadBytes((int)FileNameSize-1));
            r.ReadByte();
            FileDataAddress = (uint) r.BaseStream.Position;
            ActualDataSize = (uint)(pos + FileBlockSize - FileDataAddress);
        }

        public virtual void Write(BinaryWriter w)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return FileName + "; Size: " + ActualDataSize;
        }
    }

    public enum FdbFileType : uint
    {
        Regular = 1,
        Texture = 2
    }
    public enum FdbCompressionType : uint
    {
        None = 0,
        RLE = 1,
        Unknown = 2,
        Zlib = 3,
        Redux = 4
    }
}

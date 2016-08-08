using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Runes.Net.Shared;

namespace Runes.Net.Db
{
    public class DbFile
    {
        public bool ModifiedFlag { get; set; }
        public FieldDescriptor[] FieldNames { get; set; }
        public string FileName { get; private set; }
        private byte[] _header;
        private byte[] _footer;
        public bool Loaded { get; private set; }
        public uint StructSize { get; private set; }
        public List<BasicObject> Rows { get; private set; }

        public void LoadFromFile(string fileName)
        {
            using (var br = new BinaryReader(new StreamReader(fileName).BaseStream))
            {
                LoadFromBinary(br, fileName);
            }
        }
        public void LoadFromFdb(Fdb.Fdb fdb, string fileName)
        {
            var ms = new MemoryStream();
            fdb.ExtractFile(fileName, new BinaryWriter(ms));
            ms.Position = 0;
            using (var br = new BinaryReader(new StreamReader(ms).BaseStream))
            {
                LoadFromBinary(br, fileName);
            }
        }
        public void LoadFromBinary(BinaryReader br, string fileName)
        {
            FileName = Path.GetFileName(fileName);

            _header = br.ReadBytes(132);
            var count = br.ReadUInt32();
            StructSize = br.ReadUInt32();
            Rows = new List<BasicObject>((int)count);

            for (var rowId = 0; rowId < count; ++rowId)
            {
                var row = new BasicObject();
                row.FromBytes(br.ReadBytes((int)StructSize));
                row.FieldsProvider = FieldNames;
                row.Owner = this;
                Rows.Add(row);
            }
            _footer = br.ReadBytes((int)(br.BaseStream.Length - br.BaseStream.Position));

            br.Close();
            Loaded = true;
        }
        public void Save(string fileName)
        {
            if (!Loaded)
                throw new Exception("Nothing is loaded");
            using (var br = new BinaryWriter(new StreamWriter(fileName).BaseStream))
            {
                br.Write(_header);
                br.Write((uint) Rows.Count);
                br.Write(StructSize);
                foreach (var row in Rows.Where(r => r != null)) 
                    br.Write(row.ToBytes());
                br.Write(_footer);

                br.Close();
            }
        }
    }
}

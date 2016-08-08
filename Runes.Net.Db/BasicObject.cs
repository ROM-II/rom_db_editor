using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Runes.Net.Shared;
using Runes.Net.Shared.Html;

namespace Runes.Net.Db
{
    public class BasicObject : IByteArraySerialize, IDescribable
    {
        internal DbFile Owner { get; set; }
        public string OwnerName { get { return Owner.FileName; }}
        protected byte[] OriginalBytes { get; private set; }
        public uint Guid
        {
            get
            {
                var field = GetFieldByName("guid");
                return field == null ? 0 : OriginalBytes.GetUInt32((int) field.Offset);
            }
        }
        public FieldDescriptor[] FieldsProvider { get; internal set; }

        public BasicObject(FieldDescriptor[] p)
        {
            FieldsProvider = p;
        }
        public BasicObject(FieldDescriptor[] p, DbFile own)
        {
            FieldsProvider = p;
            Owner = own;
        }

        public BasicObject() { }

        public virtual byte[] ToBytes()
        {
            return OriginalBytes;
        }
        public virtual void FromBytes(byte[] bts)
        {
            OriginalBytes = bts;
        }

        public FieldDescriptor GetFieldByName(string name)
        {
            return FieldsProvider.FirstOrDefault(f => f.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
        public uint GetFieldAsUInt(string name)
        {
            var field = GetFieldByName(name);
            if (field == null)
                throw new KeyNotFoundException();
            if (field.Length < sizeof(uint))
                return 0;
            return OriginalBytes.GetUInt32((int) field.Offset);
        }
        public uint GetFieldAsUInt(uint offset)
        {
            if (OriginalBytes.Length < offset+4)
                return 0;
            return OriginalBytes.GetUInt32((int)offset);
        }
        public int GetFieldAsInt(uint offset)
        {
            if (OriginalBytes.Length < offset + 4)
                return 0;
            return OriginalBytes.GetInt32((int)offset);
        }
        public int GetFieldAsInt(string name)
        {
            var field = FieldsProvider.FirstOrDefault(f => f.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (field == null)
                throw new KeyNotFoundException();
            if (field.Length < sizeof (int))
                return 0;
            return OriginalBytes.GetInt32((int)field.Offset);
        }

        public string Representation
        {
            get { return string.Join("<br>", FieldsProvider.Select(f => f.Name + "=" + GetFieldAsInt(f.Name))); }
        }
        public override string ToString()
        {
            return "?Basic Object?";
        }
        public string GetDescription()
        {
            return Representation;
        }

        public void SetField(string name, uint value)
        {
            var field = GetFieldByName(name);
            if (field == null)
                throw new KeyNotFoundException();
            if (field.Length < sizeof(uint))
                throw new IndexOutOfRangeException();
            OriginalBytes.PutBytes(value, (int)field.Offset);
        }
        public void SetField(uint offset, uint value)
        {
            if (OriginalBytes.Length-4 < offset)
                throw new IndexOutOfRangeException();
            OriginalBytes.PutBytes(value, (int)offset);
        }
        public void SetField(uint offset, int value)
        {
            if (OriginalBytes.Length - 4 < offset)
                throw new IndexOutOfRangeException();
            OriginalBytes.PutBytes(value, (int)offset);
        }
        public void SetField(string name, int value)
        {
            var field = GetFieldByName(name);
            if (field == null)
                throw new KeyNotFoundException();
            if (field.Length < sizeof(uint))
                throw new IndexOutOfRangeException();
            OriginalBytes.PutBytes(value, (int)field.Offset);
        }
        public void SetField(string name, float value)
        {
            var field = GetFieldByName(name);
            if (field == null)
                throw new KeyNotFoundException();
            if (field.Length < sizeof(uint))
                throw new IndexOutOfRangeException();
            OriginalBytes.PutBytes(value, (int)field.Offset);
        }
        public void SetField(string name, string value, int len)
        {
            var field = GetFieldByName(name);
            if (field == null)
                throw new KeyNotFoundException();
            if (field.Length < len)
                throw new IndexOutOfRangeException();
            var buffer = new byte[len];
            buffer.PutBytes(Encoding.ASCII.GetBytes(value  + "\0"));
            OriginalBytes.PutBytes(buffer, (int)field.Offset);
        }
        public void SetField(uint addr, string value, int len)
        {
            var buffer = new byte[len];
            buffer.PutBytes(Encoding.ASCII.GetBytes(value + "\0"));
            OriginalBytes.PutBytes(buffer, (int)addr);
        }

        public float GetFieldAsFloat(string name)
        {
            var field = FieldsProvider.FirstOrDefault(f => f.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (field == null)
                throw new KeyNotFoundException();
            if (field.Length < sizeof(int))
                return 0;
            return OriginalBytes.GetSingle((int)field.Offset);
        }

        public string GetFieldAsStaticString(string name, int len)
        {
            var field = FieldsProvider.FirstOrDefault(f => f.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (field == null)
                throw new KeyNotFoundException();
            if (field.Length < len)
                return null;
            var bts = OriginalBytes.GetBytes((int) field.Offset, (int) field.Length);
            return bts.ReadNullTerminated(Encoding.ASCII);
        }
        public string GetFieldAsStaticString(uint addr, int len)
        {
            var bts = OriginalBytes.GetBytes((int)addr, (int)len);
            return bts.ReadNullTerminated(Encoding.ASCII);
        }

        public ulong GetFieldAsULong(string name)
        {
            var field = FieldsProvider.FirstOrDefault(f => f.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (field == null)
                throw new KeyNotFoundException();
            /*if (field.Length < sizeof(int))
                return 0;*/
            return OriginalBytes.GetUInt64((int)field.Offset);
        }
        public long GetFieldAsLong(string name)
        {
            var field = FieldsProvider.FirstOrDefault(f => f.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (field == null)
                throw new KeyNotFoundException();
            if (field.Length < sizeof(int))
                return 0;
            return OriginalBytes.GetInt64((int)field.Offset);
        }
        public void RememberModified(bool modified = true)
        {
            Owner.ModifiedFlag = modified;
        }
    }
}

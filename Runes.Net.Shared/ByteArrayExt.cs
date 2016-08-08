using System;
using System.Linq;

namespace Runes.Net.Shared
{
    public static class ByteArrayExt
    {
        public static void PutBytes(this byte[] target, byte[] source, int pos = 0)
        {
            for (var i = 0; i < source.Length; ++i)
            {
                target[i + pos] = source[i];
            }
        }
        public static void PutBytes(this byte[] target, ushort source, int pos = 0)
        {
            target.PutBytes(BitConverter.GetBytes(source), pos);
        }
        public static void PutBytes(this byte[] target, short source, int pos = 0)
        {
            target.PutBytes(BitConverter.GetBytes(source), pos);
        }
        public static void PutBytes(this byte[] target, uint source, int pos = 0)
        {
            target.PutBytes(BitConverter.GetBytes(source), pos);
        }
        public static void PutBytes(this byte[] target, int source, int pos = 0)
        {
            target.PutBytes(BitConverter.GetBytes(source), pos);
        }
        public static void PutBytes(this byte[] target, ulong source, int pos = 0)
        {
            target.PutBytes(BitConverter.GetBytes(source), pos);
        }
        public static void PutBytes(this byte[] target, long source, int pos = 0)
        {
            target.PutBytes(BitConverter.GetBytes(source), pos);
        }
        public static void PutBytes(this byte[] target, float source, int pos = 0)
        {
            target.PutBytes(BitConverter.GetBytes(source), pos);
        }
        public static void PutBytes(this byte[] target, double source, int pos = 0)
        {
            target.PutBytes(BitConverter.GetBytes(source), pos);
        }

        public static ushort GetUInt16(this byte[] b, int offset = 0)
        {
            return BitConverter.ToUInt16(b, offset);
        }
        public static short GetInt16(this byte[] b, int offset = 0)
        {
            return BitConverter.ToInt16(b, offset);
        }
        public static uint GetUInt32(this byte[] b, int offset = 0)
        {
            return BitConverter.ToUInt32(b, offset);
        }
        public static int GetInt32(this byte[] b, int offset = 0)
        {
            return BitConverter.ToInt32(b, offset);
        }
        public static ulong GetUInt64(this byte[] b, int offset = 0)
        {
            return BitConverter.ToUInt64(b, offset);
        }
        public static long GetInt64(this byte[] b, int offset = 0)
        {
            return BitConverter.ToInt64(b, offset);
        }
        public static float GetSingle(this byte[] b, int offset = 0)
        {
            return BitConverter.ToSingle(b, offset);
        }
        public static double GetDouble(this byte[] b, int offset = 0)
        {
            return BitConverter.ToDouble(b, offset);
        }
        public static byte[] GetBytes(this byte[] b, int offset, int len)
        {
            return b.Skip(offset).Take(len).ToArray();
        }
    }
}

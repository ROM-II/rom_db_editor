using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Runes.Net.Shared
{
    public static class BinaryReaderExt
    {
        public static string ReadNullTerminated(this BinaryReader r)
        {
            var bts = new List<byte>();
            while (true)
            {
                var cb = r.ReadByte();
                if (cb == 0) break;
                bts.Add(cb);
            }
            return Encoding.ASCII.GetString(bts.ToArray());
        }
        public static string ReadNullTerminated(this BinaryReader r, Encoding e)
        {
            var bts = new List<byte>();
            while (true)
            {
                var cb = r.ReadByte();
                if (cb == 0) break;
                bts.Add(cb);
            }
            return e.GetString(bts.ToArray());
        }
        public static string ReadNullTerminated(this byte[] r, Encoding e)
        {
            var bts = new List<byte>();
            var o = 0;
            while (o < r.Length)
            {
                var cb = r[o++];
                if (cb == 0) break;
                bts.Add(cb);
            }
            return e.GetString(bts.ToArray());
        }
    }
}

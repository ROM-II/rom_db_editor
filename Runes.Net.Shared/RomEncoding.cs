using System.Globalization;
using System.Text;

namespace Runes.Net.Shared
{
    public static class RomEncoding
    {
        public static string DecodePassword(string pwd, string key )
        {
            pwd = pwd.ToUpperInvariant();

            var buf = new byte[256];
            var keyLen = key.Length;
            var pwdLen = pwd.Length/2;

            for (var i = 0; i < pwdLen; i++)
            {
                var value = byte.Parse(pwd.Substring(i*2, 2), NumberStyles.HexNumber);
                buf[i] = (byte) (value ^ key[(i + 1)%keyLen]);
            }
            return Encoding.ASCII.GetString(buf, 0, pwdLen);
        }
    }
}

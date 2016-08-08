using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runes.Net.Shared
{
    public static class StringExt
    {
        public static bool ContainsIgnoreCase(this string text, string filter, CultureInfo ci)
        {
            return ci.CompareInfo.IndexOf(text, filter, CompareOptions.IgnoreCase) >= 0;//CultureInfo.InvariantCulture
        }
        public static bool ContainsIgnoreCase(this string text, string filter)
        {
            return CultureInfo.InvariantCulture.CompareInfo.IndexOf(text, filter, CompareOptions.IgnoreCase) >= 0;
        }
    }
}

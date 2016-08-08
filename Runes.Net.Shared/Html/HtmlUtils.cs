using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runes.Net.Shared.Html
{
    public static class HtmlUtils
    {
        public static string MakeTagAttribute(this string tagName, object argument)
        {
            return tagName + "=\"" + argument + "\"";
        }
        public static string ToHexString(this Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }
        public static string HtmlWrap(this string s, string tag)
        {
            return string.Format("<{0}>{1}</{0}>", tag, s);
        }
        public static string HtmlWrap(this string s, string tag, params string[] args)
        {
            var a = string.Join(" ", args);
            return string.Format("<{0} {2}>{1}</{0}>", tag, s, a);
        }
        public static string HtmlWrapItalic(this string s)
        {
            return s.HtmlWrap("i");
        }
        public static string HtmlWrapBold(this string s)
        {
            return s.HtmlWrap("b");
        }
        public static string HtmlAddHorizontalLine(this string s)
        {
            return s += "<hr>";
        }
        public static string HtmlAddBreakLine(this string s)
        {
            return s += "<br>";
        }
        public static string HtmlFont(this string s, Color color, int size, string face)
        {
            return s.HtmlWrap("font", 
                "color".MakeTagAttribute(color.ToHexString()), 
                "size".MakeTagAttribute(size),
                "face".MakeTagAttribute(face));
        }
        public static string HtmlFont(this string s, Color color, int size)
        {
            return s.HtmlWrap("font",
                "color".MakeTagAttribute(color.ToHexString()),
                "size".MakeTagAttribute(size));
        }
        public static string HtmlFont(this string s, Color color)
        {
            return s.HtmlWrap("font",
                "color".MakeTagAttribute(color.ToHexString()));
        }
        public static string HtmlFont(this string s, int size, string face)
        {
            return s.HtmlWrap("font",
                "size".MakeTagAttribute(size),
                "face".MakeTagAttribute(face));
        }
        public static string HtmlFont(this string s, Color color, string face)
        {
            return s.HtmlWrap("font",
                "color".MakeTagAttribute(color.ToHexString()),
                "face".MakeTagAttribute(face));
        }
        public static string HtmlFont(this string s, string face)
        {
            return s.HtmlWrap("font",
                "face".MakeTagAttribute(face));
        }
        public static string HtmlFont(this string s, int size)
        {
            return s.HtmlWrap("font",
                "size".MakeTagAttribute(size));
        }
    }
}

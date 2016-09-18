using System.IO;
using System.Reflection;

namespace Runes.Net.Shared
{
    public static class PathExtensions
    {
        public static string ToAbsolutePath(this string relPath, string rootPath = null)
        {
            rootPath = rootPath ?? Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return Path.Combine(rootPath, relPath);
        }
    }
}

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace RunesDataBase.SubScript
{
    public class CodeTemplate
    {
        public CodeTemplate(string relativePath, string contents)
        {
            RelativePath = relativePath;
            Contents = contents;
        }

        public string RelativePath { get; }
        public string Contents { get; }

        internal string AbsolutePath
            => Path.Combine(AppPath, RelativePath + ".cs");

        public static string AppPath
            => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Templates\\";

        public static CodeTemplate Load(string fullPath)
        {
            var content = File.ReadAllText(fullPath);
            return new CodeTemplate(fullPath.Substring(AppPath.Length).Trim('\\', '/'), content);
        }

        public void Save()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(AbsolutePath));
            File.WriteAllText(AbsolutePath, Contents);
        }

        public static IEnumerable<CodeTemplate> FindAll(string rootPath = null)
        {
            rootPath = rootPath ?? AppPath;
            var results = new List<CodeTemplate>();
            foreach (var directoryPath in Directory.EnumerateDirectories(rootPath))
            {
                results.AddRange(FindAll(directoryPath));
            }

            results.AddRange(Directory
                .EnumerateFiles(rootPath, "*.cs")
                .Select(Load));

            return results;
        }
    }
}

using System.IO;
using RazorEngine.Templating;

namespace RunesDataBase
{
    public static class RazorExtensions
    {
        public static ITemplateSource MakeTemplate(string path)
            => new LoadedTemplateSource(File.ReadAllText(path), path);
    }
}

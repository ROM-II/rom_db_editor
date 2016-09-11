using System.Text.RegularExpressions;

namespace RunesDataBase
{
    public interface IStringConverter
    {
        string Convert(string x);
    }

    public class SimpleStringConverter : IStringConverter
    {
        public string Convert(string x) => x;
        public static SimpleStringConverter Instance { get; } = new SimpleStringConverter();
    }
    public class GuidExtractor : IStringConverter
    {
        static readonly Regex Regex = new Regex(@"\[\d+\]", RegexOptions.Compiled | RegexOptions.Multiline);
        public string Convert(string x)
        {
            if (string.IsNullOrWhiteSpace(x))
                return string.Empty;

            int y;
            if (int.TryParse(x, out y))
                return x;

            foreach (var match in Regex.Matches(x))
            {
                return (match as Match)?.Value.Replace("[", "").Replace("]", "") ?? string.Empty;
            }

            return string.Empty;
        }

        public static GuidExtractor Instance { get; } = new GuidExtractor();
    }
}
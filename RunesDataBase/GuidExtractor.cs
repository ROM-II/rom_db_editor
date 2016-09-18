using System.Text.RegularExpressions;

namespace RunesDataBase
{
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

        public static uint? ExtractGuid(string s)
        {
            var sGuid = Instance.Convert(s);
            if (string.IsNullOrWhiteSpace(sGuid))
                return null;

            uint value;
            return uint.TryParse(sGuid, out value) ? value : (uint?) null;
        }

        public static GuidExtractor Instance { get; } = new GuidExtractor();
    }
}
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
}
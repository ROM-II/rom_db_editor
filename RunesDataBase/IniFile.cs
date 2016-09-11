using System.Runtime.InteropServices;
using System.Text;
using IniParser;
using IniParser.Model;

namespace RunesDataBase
{
    public class IniFile
    {
        public string Path { get; private set; }
        private FileIniDataParser Parser { get; } 
        private IniData Data { get; }
        public IniFile(string path)
        {
            Parser = new FileIniDataParser();
            Path = path;
            Parser.Parser.Configuration.AllowDuplicateKeys = true;
            Data = Parser.ReadFile(path); // todo: make (Re)Load method for this
        }

        public string this[string section, string key]
        {
            get { return Data[section][key]; }
            set { Data[section][key] = value; }
        }
        public string this[string key]
        {
            get { return Data.Global[key]; }
            set { Data.Global[key] = value; }
        }

        public void Save()
        {
            Parser.WriteFile(Path, Data);
        }
    }
}
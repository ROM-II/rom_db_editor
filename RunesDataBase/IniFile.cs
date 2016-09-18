using System;
using IniParser;
using IniParser.Model;

namespace RunesDataBase
{
    public class IniFile
    {
        public string Path { get; private set; }
        private FileIniDataParser Parser { get; } 
        private IniData Data { get; set; }

        public IniFile(string path)
        {
            Parser = new FileIniDataParser();
            Path = path;
            Parser.Parser.Configuration
                .AllowDuplicateKeys = true;
            if (!string.IsNullOrWhiteSpace(path))
                return;
            Data = new IniData();
        }

        public string this[string section, string key]
        {
            get { return Data[section]?[key] ?? ""; }
            set { SetValue(section, key, value); }
        }
        public string this[string key]
        {
            get { return Data.Global[key] ?? ""; }
            set { Data.Global[key] = value; }
        }

        public void Save(string path = null)
        {
            Parser.WriteFile(path ?? Path, Data);
        }

        public Exception Load(string filename = null)
        {
            Path = filename ?? Path;
            try
            {
                Data = Parser.ReadFile(Path);
                return null;
            }
            catch (Exception ex)
            {
                Data = new IniData();
                return ex;
            }
        }

        private void SetValue(string sectionName, string key, string value)
        {
            var section = Data.Sections[sectionName];
            if (section == null)
            {
                Data.Sections.AddSection(sectionName);
                section = Data.Sections[sectionName];
            }
            section[key] = value;
        }
    }
}
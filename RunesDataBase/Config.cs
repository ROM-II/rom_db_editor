using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace RunesDataBase
{
    public class Config
    {
        private readonly IniFile _ini;

        public Config()
        {
            DefaultPath = Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "",
                "romdb.ini");
            _ini = new IniFile(DefaultPath);
        }
        public string DefaultPath { get; }
        public string SourcePath { get; private set; }

        public string FdbPath { get; set; }
        public string DbPath { get; set; }
        public string GlobalIniPath { get; set; }
        public List<string> LastLoadedLanguages { get; private set; } = new List<string>();

        public Exception Load(string path = null)
        {
            SourcePath = path ?? DefaultPath;

            var ex = _ini.Load(SourcePath);
            if (ex != null)
                return ex;

            FdbPath = _ini["Path", "DataFdb_Path"];
            DbPath = _ini["Path", "DB_Path"];
            GlobalIniPath = _ini["Path", "GlobalIni_Path"];
            LastLoadedLanguages = (_ini["Preferences", "Languages"] ?? "")
                .Split(new []{',', ';', ' ', '\t', '\r', '\n'}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            return null;
        }
        public void Save()
        {
            _ini["Path", "DataFdb_Path"] = FdbPath;
            _ini["Path", "DB_Path"] = DbPath;
            _ini["Path", "GlobalIni_Path"] = GlobalIniPath;
            _ini["Preferences", "Languages"] = string.Join(",", LastLoadedLanguages);
            _ini.Save(DefaultPath);
            if (!SourcePath.Equals(DefaultPath, StringComparison.InvariantCultureIgnoreCase))
                _ini.Save(SourcePath);
        }
    }
}

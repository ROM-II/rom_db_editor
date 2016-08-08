using System.IO;
using System.Reflection;

namespace RunesDataBase
{
    public class Config
    {
        private readonly IniFile _ini;

        public Config()
        {
            _ini = new IniFile(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)+"\\romdb.ini");
        }

        public string FdbPath { get; set; }
        public string DbPath { get; set; }

        public void Load()
        {
            FdbPath = _ini["Path", "DataFdb_Path"];
            DbPath = _ini["Path", "DB_Path"];
        }
        public void Save()
        {
            _ini["Path", "DataFdb_Path"] = FdbPath;
            _ini["Path", "DB_Path"] = DbPath;
        }
    }
}

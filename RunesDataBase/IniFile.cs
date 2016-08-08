using System.Runtime.InteropServices;
using System.Text;

namespace RunesDataBase
{
    /// <summary>
    /// Create a New INI file to store or load data
    /// </summary>
    public class IniFile
    {
        public string Path { get; private set; }

        [DllImport("kernel32.dll")]
        private static extern long WritePrivateProfileString(string section,
            string key, string val, string filePath);
        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(string section,
            string key, string def, StringBuilder retVal,
            int size, string filePath);

        public IniFile(string path)
        {
            Path = path;
        }

        public string this[string section, string key]
        {
            get
            {
                var temp = new StringBuilder(255);
                GetPrivateProfileString(section, key, "", temp,
                    255, Path);
                return temp.ToString();
            }
            set
            {
                WritePrivateProfileString(section, key, value, Path);
            }
        }
    }
}
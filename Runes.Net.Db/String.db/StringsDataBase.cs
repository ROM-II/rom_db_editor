using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Runes.Net.Shared;

namespace Runes.Net.Db.String.db
{
    public class StringsDataBase
    {
        public bool ModifiedFlag { get; set; }
        public string FileName { get; set; }
        public string ShortName { get; set; }
        public string FullLanguageName { get; set; }
        public Dictionary<string, string> Data = new Dictionary<string, string>();

        public void LoadFromFdb(Fdb.Fdb fdb, string fileName)
        {
            var ms = new MemoryStream();
            var bw = new BinaryWriter(ms);
            fdb.ExtractFile(fileName, bw);

            FullLanguageName = Path.GetFileNameWithoutExtension(fileName) ?? "unknown"; ;
            CalculateNames();

            ms.Position = 0;
            var br = new BinaryReader(ms);
            while (br.BaseStream.Position < ms.Length)
            {
                var key = br.ReadNullTerminated();
                br.ReadBytes(67 - key.Length);
                var value = br.ReadNullTerminated(Encoding.UTF8);
                Data[key] = value;
            }
        }

        private void CalculateNames()
        {
            FileName = ShortName = FullLanguageName;
            if (ShortName.StartsWith("string_"))
            {
                ShortName = ShortName.Substring("string_".Length);
                switch (ShortName)
                {
                    case "ru":
                        FullLanguageName = "Русский";
                        break;
                    case "eneu":
                        FullLanguageName = "English (EU)";
                        break;
                    case "enus":
                        FullLanguageName = "English (US)";
                        break;
                    case "de":
                        FullLanguageName = "Deutsch";
                        break;
                    case "es":
                        FullLanguageName = "Español";
                        break;
                    case "it":
                        FullLanguageName = "Italiano";
                        break;
                    case "fr":
                        FullLanguageName = "Français";
                        break;
                    case "pl":
                        FullLanguageName = "Polski";
                        break;
                }
            }
            
        }
        public void LoadFromFile(string fileName)
        {
            FullLanguageName = Path.GetFileNameWithoutExtension(fileName) ?? "unknown";;
            CalculateNames();

            var bytes = File.ReadAllBytes(fileName);
            var ms = new MemoryStream(bytes);
            var f = new BinaryReader(ms);
            while (ms.Position < ms.Length)
            {
                var key = f.ReadNullTerminated();
                f.ReadBytes(67-key.Length);
                var value = f.ReadNullTerminated(Encoding.UTF8);
                Data[key] = value;
            }
            f.Close();
        }

        public void SaveToFile(string fileName)
        {
            var f = new StreamWriter(fileName);
            var bw = new BinaryWriter(f.BaseStream);
            var buffer = new char[64];
            foreach (var pair in Data)
            {
                var key = pair.Key + "\0";
                key.CopyTo(0, buffer, 0, Math.Min(key.Length, 64));
                bw.Write(buffer);
                var bts = Encoding.UTF8.GetBytes(pair.Value+"\0");
                bw.Write(bts.Length);
                bw.Write(bts);
            }
            f.Close();
        }

        public IEnumerable<Tuple<string, string>> WhereKeyMatches(Predicate<string> matchFunc)
        {
            return from pair in Data where matchFunc(pair.Key) select new Tuple<string, string>(pair.Key, pair.Value);
        }
        public IEnumerable<KeyValuePair<string, string>> WhereKeysOrValuesContains(string s)
        {
            return Data.Where(pair => pair.Key.ContainsIgnoreCase(s) || pair.Value.ContainsIgnoreCase(s));
        }

        public override string ToString()
        {
            return FullLanguageName;
        }

        public IEnumerable<KeyValuePair<string, string>>  NamesWhereValuesContains(string s)
        {
            return Data.Where(pair => (pair.Key.EndsWith("_name")||pair.Key.StartsWith("DIR_ZONEID_")) && pair.Value.ContainsIgnoreCase(s));
        }

        public string this[string key]
        {
            get
            {
                string r;
                return Data.TryGetValue(key, out r) ? r : null;
            }
            set { Data[key] = value; ModifiedFlag = true;}
        }
    }
}

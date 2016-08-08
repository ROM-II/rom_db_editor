using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Runes.Net.Db;
using Runes.Net.Db.String.db;
using Runes.Net.Fdb;
using Runes.Net.Shared;
using RunesDataBase.TableObjects;

namespace RunesDataBase
{
    public class DataBase
    {
        public Logger Log { get; set; }
        public string RootDir { get; set; }
        public Fdb Fdb { get; set; }
        public StringsDataBase CurrentLanguage { get; set; }
        public List<StringsDataBase> Languages = new List<StringsDataBase>();
        internal readonly List<Table> Dbs = new List<Table>();

        public StringsDataBase LanguageByName(string shortName)
        {
            var s = shortName.ToLowerInvariant();
            return Languages.FirstOrDefault(db => db.ShortName.ToLowerInvariant() == s) 
                ?? Languages.FirstOrDefault(db => db.FullLanguageName.ToLowerInvariant() == s)
                ?? Languages.FirstOrDefault(db => db.FileName.ToLowerInvariant() == s);
        }
        public Table TableByName(string name)
        {
            var s = name.ToLowerInvariant();
            return Dbs.FirstOrDefault(db => db.FileName == s);
        }
        public Table TreasureTable { get { return TableByName("treasureobject.db"); } }
        public Table NpcTable { get { return TableByName("npcobject.db"); } }
        public Table QuestNpcTable { get { return TableByName("questnpcobject.db"); } }
        public Table ItemTable { get { return TableByName("itemobject.db"); } }
        public Table WeaponTable { get { return TableByName("weaponobject.db"); } }
        public Table ArmorTable { get { return TableByName("armorobject.db"); } }
        public Table MagicTable { get { return TableByName("magicobject.db"); } }
        public Table RecipeTable { get { return TableByName("recipeobject.db"); } }
        public Table SpellTable { get { return TableByName("magiccollectobject.db"); } }
        public Table ShopTable { get { return TableByName("shopobject.db"); } }
        public Table SetsTable { get { return TableByName("suitobject.db"); } }
        public Table CardTable { get { return TableByName("cardobject.db"); } }
        public Table QuestTable { get { return TableByName("questdetailobject.db"); } }
        public Table TitleTable { get { return TableByName("titleobject.db"); } }
        public Table RuneTable { get { return TableByName("runeobject.db"); } }
        public Table StatTable { get { return TableByName("addpowerobject.db"); } }
        public Table ImageTable { get { return TableByName("imageobject.db"); } }
        public Table ZoneTable { get { return TableByName("zoneobject.db"); } }

        public IEnumerable<Tuple<StringsDataBase, IEnumerable<Tuple<string, string>>>> GetStringsByGuid(uint guid)
        {
            return Languages.Select(l => new Tuple<StringsDataBase, IEnumerable<Tuple<string, string>>>(l, GetStringsByGuid(l, guid)));
        }
        public IEnumerable<Tuple<string, string>> GetStringsByGuid(StringsDataBase language, uint guid)
        {
            var pattern = string.Format("Sys{0}_", guid);
            return language.WhereKeyMatches(s => s.StartsWith(pattern));
        }
        public IEnumerable<Tuple<string, string>> GetStringsByGuid(string language, uint guid)
        {
            return GetStringsByGuid(LanguageByName(language), guid);
        }
        public string GetStringByGuid(string language, uint guid, StringLinkKind kind = StringLinkKind.General)
        {
            return GetStringByGuid(LanguageByName(language), guid, kind);
        }
        public string GetStringByGuid(StringsDataBase language, uint guid, StringLinkKind kind = StringLinkKind.General)
        {
            var pattern = kind.ToSysString(guid);
            return language[pattern];
        }

        public string GetStringByGuid(uint guid, StringLinkKind kind = StringLinkKind.General)
        {
            var pattern = kind.ToSysString(guid);
            if (CurrentLanguage != null)
            {
                var value = CurrentLanguage[pattern];
                if (value != null)
                    return value;
            }
            return Languages.Select(language => language[pattern]).FirstOrDefault(val => val != null);
        }

        public BasicTableObject GetObjectByGuid(uint guid)
        {
            var targetDb = GetDbByGuid(guid);
            if (targetDb != null)
            {
                var result = targetDb[guid];
                if (result != null)
                    return result;
            }
            return Dbs.Select(db => db[guid]).FirstOrDefault(r => r != null);
        }

        public BasicTableObject this[uint guid]
        {
            get { return GetObjectByGuid(guid); }
        }
        public Table GetDbByGuid(uint guid)
        {
            var firstDigits = guid / 10000;
            switch (firstDigits)
            {
                default: return null;
                case 10: return NpcTable; 
                case 11: return QuestNpcTable; 
                case 20: return ItemTable; 
                case 21: return WeaponTable; 
                case 22: return ArmorTable; 
                case 42: return QuestTable; 
                case 50: return MagicTable; 
                case 49: return SpellTable; 
                case 51: return StatTable; 
                case 52: return RuneTable; 
                case 53: return TitleTable;
                case 55: return RecipeTable;
                case 57: return ImageTable;
                case 61: return SetsTable;
                case 72: return TreasureTable;
                case 75: return ZoneTable;
                case 77: return CardTable;
            }
        }

        public void LoadDbs()
        {
            var fieldsDescs = DataFieldsProvider.ReadFromFile("fields.csv");
            foreach (var dbName in new[]
            {
                "treasureobject.db", "npcobject.db", "questnpcobject.db", "itemobject.db", "weaponobject.db",
                "armorobject.db", "magicobject.db", "recipeobject.db", "magiccollectobject.db", "shopobject.db",
                "suitobject.db", "cardobject.db", "questdetailobject.db", "titleobject.db", "runeobject.db",
                "addpowerobject.db", "imageobject.db", "zoneobject.db"
            })
                LoadDb(dbName, fieldsDescs["data\\" + dbName]);
        }
        public bool LoadDb(string name, FieldDescriptor[] desc)
        {
            var db = new DbFile
            {
                FieldNames = desc
            };
            var localFile = Path.Combine(RootDir, "data", name);
            Log.WriteLine(string.Format("Trying to load {0} from {1} ...", name, localFile));
            if (File.Exists(localFile))
            {
                db.LoadFromFile(localFile);
            }
            else
            {
                Log.WriteLine("Local file does not exist, loading from fdb ...");
                db.LoadFromFdb(Fdb, "data\\" + name);
            }
            var t = new Table(db, this);
            Dbs.Add(t);
            switch (name)
            {
                case "treasureobject.db":
                    t.GuidPrefix = 72*10000;
                    break;
                case "npcobject.db":
                    t.GuidPrefix = 10*10000;
                    break;
                case "questnpcobject.db":
                    t.GuidPrefix = 11*10000;
                    break;
                case "itemobject.db":
                    t.GuidPrefix = 20*10000;
                    break;
                case "weaponobject.db":
                    t.GuidPrefix = 21*10000;
                    break;
                case "armorobject.db":
                    t.GuidPrefix = 22*10000;
                    break;
                case "magicobject.db":
                    t.GuidPrefix = 50*10000;
                    break;
                case "recipeobject.db":
                    t.GuidPrefix = 55*10000;
                    break;
                case "magiccollectobject.db":
                    t.GuidPrefix = 49*10000;
                    break;
                case "suitobject.db":
                    t.GuidPrefix = 61*10000;
                    break;
                case "cardobject.db":
                    t.GuidPrefix = 77*10000;
                    break;
                case "titleobject.db":
                    t.GuidPrefix = 53*10000;
                    break;
                case "runeobject.db":
                    t.GuidPrefix = 52*10000;
                    break;
                case "addpowerobject.db":
                    t.GuidPrefix = 51*10000;
                    break;
                case "zoneobject.db":
                    t.GuidPrefix = 75*10000;
                    break;
            }
            return true;
        }
        public bool LoadLanguage(string fileName)
        {
            var tempName = Path.GetFileName(fileName) ?? "temp";

            var localFile = Path.Combine(RootDir, "data", tempName);
            Log.WriteLine(string.Format("Trying to load {0} from {1} ...", tempName, localFile));
            var l = new StringsDataBase();
            if (File.Exists(localFile))
            {
                l.LoadFromFile(localFile);
            }
            else
            {
                Log.WriteLine("Local file does not exist, loading from fdb ...");
                l.LoadFromFdb(Fdb, fileName);
            }
            Languages.Add(l);
            
            return true;
        }

        public bool ExtractFile(string name, string nametarget)
        {
            var f = new StreamWriter(nametarget);
            var bw = new BinaryWriter(f.BaseStream);
            try
            {
                Fdb.ExtractFile(name, bw);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Failed to extract {0} from FDB", name), "Error!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                bw.Close();
                File.Delete(nametarget);
                return false;
            }
            bw.Close();
            return true;
        }
        public IEnumerable<Table> GetModifiedDataBases()
        {
            return Dbs.Where(o => o.File.ModifiedFlag);
        }
        public BasicTableObject GenerateNewTableObject(BasicTableObject template)
        {
            var o = template.OwnerTable.CloneObject(template.Guid);
            if (o is ZoneObject)
                AddKeyToAllLanguages("DIR_ZONEID_" + (o.Guid - ZoneTable.GuidPrefix));
            else
            {
                var sysname = string.Format("Sys{0}_name", o.Guid);
                AddKeyToAllLanguages(sysname);
                o.Name = sysname;
            }
            return o;
        }

        public void AddKeyToAllLanguages(string key, string value = null)
        {
            value = value ?? key;
            foreach (var l in Languages)
            {
                l.Data[key] = value;
                l.ModifiedFlag = true;
            }
        }

        public string GetZoneNameByGuid(uint guid)
        {
            guid %= 1000;
            var pattern = string.Format("DIR_ZONEID_{0:D3}", guid);
            if (CurrentLanguage != null)
            {
                var value = CurrentLanguage[pattern];
                if (value != null)
                    return value;
            }
            return Languages.Select(language => language[pattern]).FirstOrDefault(val => val != null);
        }

        public string GetNameForGuid(uint guid)
        {
            var sysname = GetDbByGuid(guid) == ZoneTable ? 
                GetZoneNameByGuid(guid) : 
                GetStringByGuid(guid, StringLinkKind.Name);
            return sysname ?? guid.ToString();
        }
    }
}

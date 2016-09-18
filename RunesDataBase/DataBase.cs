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
    public partial class DataBase 
    {
        public Logger Log { get; set; }
        public string RootDir { get; set; }
        public Fdb Fdb { get; set; }
        public StringsDataBase CurrentLanguage { get; set; }
        public List<StringsDataBase> Languages = new List<StringsDataBase>();
        internal readonly List<Table> Dbs = new List<Table>();

        public static readonly SimpleVersionProvider NameDataVersioned = new SimpleVersionProvider();

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
        public Table TreasureTable => TableByName("treasureobject.db");
        public Table NpcTable => TableByName("npcobject.db");
        public Table QuestNpcTable => TableByName("questnpcobject.db");
        public Table ItemTable => TableByName("itemobject.db");
        public Table WeaponTable => TableByName("weaponobject.db");
        public Table ArmorTable => TableByName("armorobject.db");
        public Table LearnMagicTable => TableByName("learnmagic.db");
        public Table MagicTable => TableByName("magicobject.db");
        public Table RecipeTable => TableByName("recipeobject.db");
        public Table SpellTable => TableByName("magiccollectobject.db");
        public Table ShopTable => TableByName("shopobject.db");
        public Table SetsTable => TableByName("suitobject.db");
        public Table CardTable => TableByName("cardobject.db");
        public Table QuestTable => TableByName("questdetailobject.db");
        public Table TitleTable => TableByName("titleobject.db");
        public Table RuneTable => TableByName("runeobject.db");
        public Table StatTable => TableByName("addpowerobject.db");
        public Table ImageTable => TableByName("imageobject.db");
        public Table ZoneTable => TableByName("zoneobject.db");

        public IEnumerable<Tuple<StringsDataBase, IEnumerable<Tuple<string, string>>>> GetStringsByGuid(uint guid)
        {
            return Languages.Select(l => new Tuple<StringsDataBase, IEnumerable<Tuple<string, string>>>(l, GetStringsByGuid(l, guid)));
        }
        public IEnumerable<Tuple<string, string>> GetStringsByGuid(StringsDataBase language, uint guid)
        {
            var pattern = $"Sys{guid}_";
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
            var value = CurrentLanguage?[pattern];
            if (value != null)
                return value;
            return Languages.Select(language => language[pattern]).FirstOrDefault(val => val != null);
        }

        public BasicTableObject GetObjectByGuid(uint guid)
        {
            var targetDb = GetDbByGuid(guid);
            var result = targetDb?[guid];
            return result 
                ?? Dbs
                .Select(db => db[guid])
                .FirstOrDefault(r => r != null);
        }

        public BasicTableObject this[uint guid] => GetObjectByGuid(guid);

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
                case 59: return LearnMagicTable;
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
                "addpowerobject.db", "imageobject.db", "zoneobject.db", "learnmagic.db"
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
            Log.WriteLine($"Trying to load {name} from {localFile} ...");
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
                case "learnmagic.db":
                    t.GuidPrefix = 59*10000;
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
            Log.WriteLine($"Trying to load {tempName} from {localFile} ...");
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
                MessageBox.Show($"Failed to extract {name} from FDB", "Error!",
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
                var sysname = $"Sys{o.Guid}_name";
                AddKeyToAllLanguages(sysname);
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
            var pattern = $"DIR_ZONEID_{guid:D3}";
            var value = CurrentLanguage?[pattern];
            if (value != null)
                return value;
            return Languages.Select(language => language[pattern]).FirstOrDefault(val => val != null);
        }

        public string GetNameForGuid(uint guid)
        {
            var sysname = GetDbByGuid(guid) == ZoneTable ? 
                GetZoneNameByGuid(guid) : 
                GetStringByGuid(guid, StringLinkKind.Name);
            return sysname ?? guid.ToString();
        }

        public string GetNameForGuidWithGuid(uint guid)
        {
            var sysname = GetDbByGuid(guid) == ZoneTable ?
                GetZoneNameByGuid(guid) :
                GetStringByGuid(guid, StringLinkKind.Name) + $"({guid})";
            return sysname ?? guid.ToString();
        }
        public string GetNameForGuidWithGuid2(uint guid)
        {
            return $"[{guid}] " + ((GetDbByGuid(guid) == ZoneTable
                ? GetZoneNameByGuid(guid)
                : GetStringByGuid(guid, StringLinkKind.Name)) ?? "");
        }
    }
}

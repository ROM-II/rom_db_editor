using System;
using System.Collections.Generic;
using System.Linq;
using RunesDataBase.TableObjects;

namespace RunesDataBase.SubScript
{
    internal class RunesDataBaseImpl : RunesDataBase
    {
        internal DataBase DataBase { get; set; }
        internal MainForm Form { get; set; }


        public override string DefaultLanguage
        {
            get { return DataBase.CurrentLanguage?.FileName; }
            set { DataBase.CurrentLanguage = DataBase.LanguageByName(value) ?? DataBase.Languages.FirstOrDefault(); }
        }
        public override string GetString(string key, string defaultValue = null)
        {
            string result;
            if (DataBase.CurrentLanguage != null)
            {
                result = DataBase.CurrentLanguage[key];
                if (result != null)
                    return result;
            }
            foreach (var loc in DataBase.Languages.Where(loc => loc != DataBase.CurrentLanguage))
            {
                result = loc[key];
                if (result != null)
                    return result;
            }
            return defaultValue;
        }
        public override string GetObjectName(uint guid, string defaultValue = null)
        {
            return DataBase.GetNameForGuid(guid) ?? defaultValue;
        }
        public override string GetShortNote(uint guid, string defaultValue = null)
        {
            return DataBase.GetStringByGuid(guid, StringLinkKind.ShortNote) ?? defaultValue;
        }
        public override string GetTitle(uint guid, string defaultValue = null)
        {
            return DataBase.GetStringByGuid(guid, StringLinkKind.TitleName) ?? defaultValue;
        }

        public override void SetString(string key, string value = null)
        {
            if (DataBase.CurrentLanguage == null)
                return;
            if (value == null)
                DataBase.CurrentLanguage.Data.Remove(key);
            else
                DataBase.CurrentLanguage[key] = value;
        }
        public override void SetObjectName(uint guid, string value = null)
        {
            var key = StringLinkKind.Name.ToSysString(guid);
            SetString(key, value);
        }
        public override void SetShortNote(uint guid, string value = null)
        {
            var key = StringLinkKind.ShortNote.ToSysString(guid);
            SetString(key, value);
        }
        public override void SetTitle(uint guid, string value = null)
        {
            var key = StringLinkKind.TitleName.ToSysString(guid);
            SetString(key, value);
        }

        public override BasicTableObject GetObjectByGuid(uint guid)
        {
            return DataBase.GetObjectByGuid(guid);
        }
        public override IEnumerable<KeyValuePair<string, string>> CurrentLanguageStrings
        {
            get { return DataBase.Languages.SelectMany(l => l.Data); }
        }

        public override IEnumerable<KeyValuePair<string, string>> AllStrings
            => DataBase.CurrentLanguage == null
                ? (IEnumerable<KeyValuePair<string, string>>) new SortedList<string, string>()
                : DataBase.CurrentLanguage.Data;

        public override IEnumerable<BasicTableObject> AllObjects => DataBase.Dbs.SelectMany(db => db.Objects.Values);

        public override IEnumerable<NpcObject> NPCs
        {
            get {
                foreach (var a in DataBase.NpcTable.Objects.Values.Cast<NpcObject>())
                    yield return a;
                foreach (var a in DataBase.QuestNpcTable.Objects.Values.Cast<NpcObject>())
                    yield return a;
            }
        }
        public override IEnumerable<SpellObject> Spells 
            => DataBase.SpellTable.Objects.Values.Cast<SpellObject>();

        public override IEnumerable<MagicObject> MagicEffects 
            => DataBase.MagicTable.Objects.Values.Cast<MagicObject>();

        public override IEnumerable<LearnMagicObject> LearnMagic 
            => DataBase.LearnMagicTable.Objects.Values.Cast<LearnMagicObject>();

        public override IEnumerable<ItemObject> Items
        {
            get { return new[]
            {
                DataBase.ItemTable.Objects.Values.Cast<ItemObject>(), 
                DataBase.CardTable.Objects.Values.Cast<ItemObject>(), 
                DataBase.RuneTable.Objects.Values.Cast<ItemObject>(), 
                Equipment
            }
                .SelectMany(o => o as ItemObject[] ?? o.ToArray()); }
        }
        public override IEnumerable<EquipmentObject> Equipment
        {
            get
            {
                return new[]
                {
                    DataBase.ArmorTable.Objects.Values.Cast<EquipmentObject>(),
                    Weapons
                }
                    .SelectMany(o => o as EquipmentObject[] ?? o.ToArray());
            }
        }
        public override IEnumerable<WeaponItemObject> Weapons => DataBase.WeaponTable.Objects.Values.Cast<WeaponItemObject>();
        public override IEnumerable<StatObject> Stats => DataBase.StatTable.Objects.Values.Cast<StatObject>();
        public override IEnumerable<TreasureObject> Treasures => DataBase.TreasureTable.Objects.Values.Cast<TreasureObject>();
        public override IEnumerable<ArmorItemObject> Armor => DataBase.ArmorTable.Objects.Values.Cast<ArmorItemObject>();
        public override IEnumerable<ShopObject> Shops => DataBase.ShopTable.Objects.Values.Cast<ShopObject>();

        public override void SetModified(string dataBaseName)
        {
            var b = DataBase.Dbs.FirstOrDefault(db => db.FileName == dataBaseName);
            if (b == null)
                return;
            b.File.ModifiedFlag = true;
        }

        public override void UI_ShowObjectList<T>(IEnumerable<T> objects)
        {
            Form.UI_ShowObjectList(objects);
        }

        public override void UI_ShowObjectList<T>(IEnumerable<T> objects, Func<T, string> descriptor)
        {
            Form.UI_ShowObjectList(objects, descriptor);
        }

        public override void UI_EditObject(BasicTableObject obj)
        {
            Form.UI_EditObject(obj);
        }

        public override void UI_ShowHTML(string html)
        {
            Form.UI_ShowHTML(html);
        }
    }
}
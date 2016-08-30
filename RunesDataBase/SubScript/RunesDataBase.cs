using System;
using System.Collections.Generic;
using RunesDataBase.TableObjects;

namespace RunesDataBase.SubScript
{
    public abstract class RunesDataBase
    {
        /// <summary>
        /// Gets or sets default language byt it`s filename. (for example "string_eneu.db")
        /// </summary>
        public abstract string DefaultLanguage { get; set; }
        public abstract string GetString(string key, string defaultValue = null);
        public abstract string GetObjectName(uint guid, string defaultValue = null);
        public abstract string GetShortNote(uint guid, string defaultValue = null);
        public abstract string GetTitle(uint guid, string defaultValue = null);
        /// <summary>
        /// Adds key-value pair to current languge. Value==null means deleting
        /// </summary>
        public abstract void SetString(string key, string value = null);
        public abstract void SetObjectName(uint guid, string value = null);
        public abstract void SetShortNote(uint guid, string value = null);
        public abstract void SetTitle(uint guid, string value = null);

        public abstract BasicTableObject GetObjectByGuid(uint guid);
        public abstract IEnumerable<KeyValuePair<string, string>> CurrentLanguageStrings { get; }
        public abstract IEnumerable<KeyValuePair<string, string>> AllStrings { get; }
        public abstract IEnumerable<BasicTableObject> AllObjects { get; }
        public abstract IEnumerable<NpcObject> NPCs { get; }
        public abstract IEnumerable<SpellObject> Spells { get; }
        public abstract IEnumerable<MagicObject> MagicEffects { get; }
        public abstract IEnumerable<LearnMagicObject> LearnMagic { get; }
        public abstract IEnumerable<ItemObject> Items { get; }
        public abstract IEnumerable<EquipmentObject> Equipment { get; }
        public abstract IEnumerable<WeaponItemObject> Weapons { get; }
        public abstract IEnumerable<StatObject> Stats { get; }
        public abstract IEnumerable<TreasureObject> Treasures { get; }
        public abstract IEnumerable<ArmorItemObject> Armor { get; }
        public abstract IEnumerable<ShopObject> Shops { get; }

        public abstract void SetModified(string dataBaseName);
        public abstract void UI_ShowObjectList<T>(IEnumerable<T> objects) where T : BasicTableObject;
        public abstract void UI_ShowObjectList<T>(IEnumerable<T> objects, Func<T, string> descriptor) where T : BasicTableObject;
        public abstract void UI_EditObject(BasicTableObject obj);
        public abstract void UI_ShowHTML(string html);
    }

    public delegate string DObjectAdditionalInfo(BasicTableObject obj);
}

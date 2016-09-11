using System;
using System.ComponentModel;
using System.Drawing;
using Runes.Net.Db;
using Runes.Net.Shared;
using RunesDataBase.Forms;

namespace RunesDataBase.TableObjects
{
    public class BasicTableObject : IColoredDescribable
    {
        public BasicTableObject(BasicObject obj)
        {
            if (obj == null)
                throw new NullReferenceException();
            DbObject = obj;
            NameInternal = new Outdatable<string>(DataBase.NameDataVersioned, () 
                => MainForm.Database.GetNameForGuid(Guid));
        }
        [Browsable(false)]
        public BasicObject DbObject { get; protected set; }

        [ReadOnly(true), Category("System"), DisplayName("GUID")]
        public uint Guid => DbObject.Guid;

        [ReadOnly(true), Category("System"), DisplayName("Classification")]
        public GameObjectClassification ObjectClass 
            => (GameObjectClassification) DbObject.GetFieldAsInt(0x0004);

        [Browsable(false)]
        internal Outdatable<string> NameInternal { get; }

        [ReadOnly(true)]
        [Category("System")]
        public string Name 
            => NameInternal.Value;

        [ReadOnly(true)]
        [Category("System")]
        public string ShortNote { get; internal set; }

        [ReadOnly(true)]
        [Category("System")]
        public string Title { get; internal set; }

        [Browsable(false)]
        internal Table OwnerTable { get; set; }

        public override string ToString()
        {
            if (DbObject == null)
                return "NULL";
            var sGuid = $"[{Guid}]";
            if (Name == Guid.ToString())
                return sGuid;
            return (Name ?? "") + sGuid;
        }

        public virtual Color GetColor() 
            => Color.White;

        public virtual string GetDescription() 
            => "Object of unsupported type";

        public virtual string GetIconName() 
            => "unknown";

        internal static BasicTableObject GenerateObject(BasicObject obj)
        {
            switch (obj.OwnerName)
            {
                case "treasureobject.db":
                    return new TreasureObject(obj);
                case "npcobject.db":
                    return new NpcObject(obj);
                case "questnpcobject.db":
                    return new NpcObject(obj);
                case "itemobject.db":
                    return new ItemObject(obj);
                case "weaponobject.db":
                    return new WeaponItemObject(obj);
                case "armorobject.db":
                    return new ArmorItemObject(obj);
                case "magicobject.db":
                    return new MagicObject(obj);
                case "learnmagic.db":
                    return new LearnMagicObject(obj);
                case "recipeobject.db":
                    break;
                case "magiccollectobject.db":
                    return new SpellObject(obj);
                case "shopobject.db":
                    return new ShopObject(obj);
                case "suitobject.db":
                    break;
                case "cardobject.db":
                    return new ItemObject(obj);
                case "questdetailobject.db":
                    break;
                case "titleobject.db":
                    break;
                case "runeobject.db":
                    return new RuneObject(obj);
                case "addpowerobject.db":
                    return new StatObject(obj);
                case "zoneobject.db":
                    return new ZoneObject(obj);
            }
            return new BasicTableObject(obj);
        }

        public void RememberModified(bool modified = true)
        {
            DbObject.RememberModified(modified);
        }
    }
}

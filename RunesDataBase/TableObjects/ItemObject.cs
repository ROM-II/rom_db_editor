using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using Runes.Net.Db;
using Runes.Net.Shared;

namespace RunesDataBase.TableObjects
{
    public class ItemObject : BasicVisualTableObject
    {
        public ItemObject(BasicObject obj) : base(obj) { }

        [DisplayName("Class")] [Category("Item Properties - Basic")] [ReadOnly(true)]
        public ItemClass Class
        {
            get { return (ItemClass) DbObject.GetFieldAsUInt(0x0004); }
            set { DbObject.SetField(0x0004, (uint)value); }
        }

        [DisplayName("Max Heap")] [Category("Item Properties - Basic")]
        public uint MaxHeap
        {
            get { return DbObject.GetFieldAsUInt(0x001c); }
            set { DbObject.SetField(0x001c, value); }
        }

        [Category("Item Properties - Basic")]
        public RareType Rarity
        {
            get { return (RareType)DbObject.GetFieldAsUInt("rare"); }
            set { DbObject.SetField("rare", (uint)value); }
        }

        [Category("Item Properties - Basic")]
        public ItemMode Flags
        {
            get { return (ItemMode)DbObject.GetFieldAsUInt(0x0028); }
            set { DbObject.SetField(0x0028, (uint)value); }
        }

        [Category("Item Properties - Basic")]
        public WearEqupmentSkill WearSkill
        {
            get { return (WearEqupmentSkill)DbObject.GetFieldAsUInt(0x0084); }
            set { DbObject.SetField(0x0084, (uint)value); }
        }

        [DisplayName("Price Type")] [Category("Item Properties - Trade")]
        public PriceType PriceType
        {
            get { return (PriceType)DbObject.GetFieldAsUInt("pricestype"); }
            set { DbObject.SetField("pricestype", (uint)value); }
        }

        [DisplayName("Sell Type")] [Category("Item Properties - Trade")]
        [Description("??")]
        public int SellType
        {
            get { return DbObject.GetFieldAsInt(0x0030); }
            set { DbObject.SetField(0x0030, value); }
        }

        [DisplayName("Cost")] [Category("Item Properties - Trade")]
        [Description("x10 (for gold only?)")]
        public int Cost
        {
            get { return DbObject.GetFieldAsInt(0x0034); }
            set { DbObject.SetField(0x0034, value); }
        }

        [DisplayName("Buy Units")] [Category("Item Properties - Trade")]
        [Description("How much items are sold at once (?)")]
        public int BuyUnits
        {
            get { return DbObject.GetFieldAsInt(0x0038); }
            set { DbObject.SetField(0x0038, value); }
        }

        [DisplayName("Cost (in phirius tokens)")] [Category("Item Properties - Trade")]
        public int CostPhiriusToken
        {
            get { return DbObject.GetFieldAsInt(0x0088); }
            set { DbObject.SetField(0x0088, value); }
        }

        [DisplayName("Limits")] [Category("Item Properties - Basic")]
        public LimitStruct Limits 
            => new LimitStruct(this);

        [DisplayName("Usage Type")] [Category("Item Properties - Usage")]
        public ItemUseType UseType
        {
            get { return (ItemUseType)DbObject.GetFieldAsUInt("usetype"); }
            set { DbObject.SetField("usetype", (uint)value); }
        }

        [DisplayName("Server script")] [Category("Item Properties - Usage")]
        [Description("Server LUA to run on usage (128 chars max)")]
        public string SrvScript
        {
            get { return DbObject.GetFieldAsStaticString("srvscript", 128); }
            set { DbObject.SetField("srvscript", value, 128); }
        }

        [DisplayName("Client script")] [Category("Item Properties - Usage")]
        [Description("Client LUA to run on usage (128 chars max)")]
        public string CliScript
        {
            get { return DbObject.GetFieldAsStaticString("cliscript", 128); }
            set { DbObject.SetField("cliscript", value, 128); }
        }

        [DisplayName("Check script")] [Category("Item Properties - Usage")]
        [Description("Check LUA script to run before usage (128 chars max)")]
        public string CheckScript
        {
            get { return DbObject.GetFieldAsStaticString("checkusescript", 128); }
            set { DbObject.SetField("checkusescript", value, 128); }
        }
        [DisplayName("Attributes")]
        [Category("Equipment Properties")]
        public WearStat[] Attributes
        {
            get
            {
                var a = new WearStat[10];
                for (var i = 0; i < 10; ++i)
                    a[i] = new WearStat(this, i);
                return a;
            }
        }

        [DisplayName("Stats")]
        [Category("Equipment Properties")]
        public StatDrop[] Stats
        {
            get
            {
                var a = new StatDrop[6];
                for (var i = 0; i < 6; ++i)
                    a[i] = new StatDrop(this, i);
                return a;
            }
        }

        public bool CanHaveStat(uint guid)
        {
            foreach (var entry in Stats)
            {
                if (entry.StatID == guid)
                    return true;
                var o = OwnerTable.Db[entry.StatID];
                var treasure = o as TreasureObject;
                if (treasure == null)
                    continue;
                if (treasure.Items.Any(drop => drop.ItemGUID == guid))
                    return true;
            }
            return false;
        }

        public override string GetDescription()
        {
            return Class.ToString();
        }
        public override Color GetColor()
        {
            switch (Rarity)
            {
                case RareType.Normal:
                    return Color.White;
                case RareType.Good:
                    return Color.FromArgb(0, 255, 0);
                case RareType.Magic:
                    return Color.FromArgb(0, 114, 188);
                case RareType.Legend:
                    return Color.FromArgb(200, 5, 248);
                case RareType.Epic1:
                    return Color.FromArgb(246, 142, 86);
                case RareType.Epic2:
                    return Color.FromArgb(163, 125, 80);
                case RareType.Quality6:
                    return Color.FromArgb(109, 207, 246);
                case RareType.Quality7:
                    return Color.FromArgb(237, 20, 91);
                case RareType.Shop:
                    return Color.FromArgb(168, 100, 168);
                case RareType.ShopExtra:
                    return Color.FromArgb(247, 148, 29);
                case RareType.Quality10:
                    return Color.White;
                default:
                    return Color.Red;
            }
        }
        public override string GetIconName() { return "item"; }
    }

    public class LimitStruct: StructuredField
    {
        public LimitStruct(BasicTableObject o) : base(o) { }

        public CharacterClassFlags PlayerClass
        {
            get { return (CharacterClassFlags)Object.GetFieldAsInt(0x004c); }
            set { Object.SetField(0x004c, (uint)value); }
        }
        public RaceFlags Race
        {
            get { return (RaceFlags)Object.GetFieldAsInt(0x0050); }
            set { Object.SetField(0x0050, (uint)value); }
        }
        public SexFlags Sex
        {
            get { return (SexFlags)Object.GetFieldAsInt(0x0054); }
            set { Object.SetField(0x0054, (uint)value); }
        }
        public int MinLevel
        {
            get { return Object.GetFieldAsInt(0x0058); }
            set { Object.SetField(0x0058, (uint)value); }
        }
        public int STR
        {
            get { return Object.GetFieldAsInt(0x005c); }
            set { Object.SetField(0x005c, (uint)value); }
        }
        public int STA
        {
            get { return Object.GetFieldAsInt(0x0060); }
            set { Object.SetField(0x0060, (uint)value); }
        }
        public int INT
        {
            get { return Object.GetFieldAsInt(0x0064); }
            set { Object.SetField(0x0064, (uint)value); }
        }
        public int MND
        {
            get { return Object.GetFieldAsInt(0x0068); }
            set { Object.SetField(0x0068, (uint)value); }
        }
        public int AGI
        {
            get { return Object.GetFieldAsInt(0x006c); }
            set { Object.SetField(0x006c, (uint)value); }
        }

        public override string ToString()
        {
            var constraints = new List<string>();
            if (PlayerClass != 0)
                constraints.Add($"class={PlayerClass}");
            if (Race != 0)
                constraints.Add($"race={Race}");
            if (Sex != 0)
                constraints.Add($"sex={Sex}");
            if (MinLevel != 0)
                constraints.Add($"lvl>={MinLevel}");
            if (STR != 0) constraints.Add($"str>={STR}");
            if (AGI != 0) constraints.Add($"dex>={AGI}");
            if (STA != 0) constraints.Add($"sta>={STA}");
            if (INT != 0) constraints.Add($"int>={INT}");
            if (MND != 0) constraints.Add($"wis>={MND}");
            return constraints.Any() 
                ? string.Join(", ", constraints)
                : base.ToString();
        }
    }
}

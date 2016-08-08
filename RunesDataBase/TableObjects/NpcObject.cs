using System;
using System.ComponentModel;
using System.Drawing;
using Runes.Net.Db;
using Runes.Net.Shared;

namespace RunesDataBase.TableObjects
{
    public class NpcObject : BasicVisualTableObject
    {
        public NpcObject(BasicObject obj) : base(obj) { }

        [Category("NPC Properties")]
        [DisplayName("Add Power Level")]
        [Description("???")]
        public int AddPowerLevel
        {
            get { return DbObject.GetFieldAsInt(0x04c4); }
            set { DbObject.SetField(0x04c4, value); }
        }

        [Category("NPC Properties")]
        [DisplayName("Level")]
        [Description("Base level of the NPC. [1..200]")]
        public byte Level
        {
            get { return (byte)DbObject.GetFieldAsUInt(0x00a8); }
            set { DbObject.SetField(0x00a8, value); }
        }

        [Category("NPC Properties")]
        [DisplayName("Race")]
        [Description("??? No info about it yet")]
        public Race Race
        {
            get { return (Race)DbObject.GetFieldAsUInt(0x0090); }
            set { DbObject.SetField(0x0090, (int)value); }
        }

        [Category("NPC Properties")]
        [DisplayName("Respawn Time")]
        [Description("Time (sec.) until dead NPC will respawn")]
        public int ReviveTime
        {
            get { return DbObject.GetFieldAsInt("revivetime"); }
            set { DbObject.SetField("revivetime", value); }
        }

        [Category("NPC Properties")]
        [DisplayName("XP Rate")]
        [Description("In %%. Rate of experience gained from slaying this NPC")]
        public int XpRate
        {
            get { return DbObject.GetFieldAsInt(0x00a0); }
            set { DbObject.SetField(0x00a0, value); }
        }

        [Category("NPC Properties")]
        [DisplayName("TP Rate")]
        [Description("In %%. Rate of talant point gained from slaying this NPC")]
        public int TpRate
        {
            get { return DbObject.GetFieldAsInt(0x00a4); }
            set { DbObject.SetField(0x00a4, value); }
        }

        [Category("NPC Properties")]
        [DisplayName("Move speed")]
        [Description("Movement speed (units/sec?)")]
        public int MoveSpeed
        {
            get { return DbObject.GetFieldAsInt(0x00c4); }
            set { DbObject.SetField(0x00c4, value); }
        }

        [Category("NPC Properties")]
        [DisplayName("Search range")]
        [Description("The same as aggro radius (?)")]
        public int SearchRange
        {
            get { return DbObject.GetFieldAsInt(0x00c8); }
            set { DbObject.SetField(0x00c8, value); }
        }
        [Category("NPC Properties")]
        [DisplayName("Follow range")]
        [Description("Max range of following the target.")]
        public int FollowRange
        {
            get { return DbObject.GetFieldAsInt(0x03d4); }
            set { DbObject.SetField(0x03d4, value); }
        }

        [Category("NPC Properties")]
        [DisplayName("Level range")]
        [Description("How much can actual level differ from base level")]
        public int LevelRange
        {
            get { return DbObject.GetFieldAsInt(0x00ac); }
            set { DbObject.SetField(0x00ac, value); }
        }

        [Category("NPC Properties - Spawning")]
        [DisplayName("Zone ID")]
        [Description("=(ZoneGUID-750000")]
        public int ZoneID
        {
            get { return DbObject.GetFieldAsInt("zoneid"); }
            set { DbObject.SetField("zoneid", value); }
        }
        [Category("NPC Properties - Spawning")]
        public int X
        {
            get { return DbObject.GetFieldAsInt("x"); }
            set { DbObject.SetField("x", value); }
        }
        [Category("NPC Properties - Spawning")]
        public int Y
        {
            get { return DbObject.GetFieldAsInt("y"); }
            set { DbObject.SetField("y", value); }
        }
        [Category("NPC Properties - Spawning")]
        public int Z
        {
            get { return DbObject.GetFieldAsInt("z"); }
            set { DbObject.SetField("z", value); }
        }

        [Category("NPC Properties")]
        [DisplayName("Sex and Normal/Elite/Boss")]
        [Description("Not actualy sex in most of cases")]
        public Sex Sex
        {
            get { return (Sex)DbObject.GetFieldAsInt(0x009c); }
            set { DbObject.SetField(0x009c, (int)value); }
        }

        [Category("NPC Properties")]
        [DisplayName("Class (Primary)")]
        [Description("Character class")]
        public CharacterClass Class
        {
            get { return (CharacterClass)DbObject.GetFieldAsInt(0x0094); }
            set { DbObject.SetField(0x0094, (int)value); }
        }

        [Category("NPC Properties")]
        [DisplayName("Class (Secondary)")]
        [Description("Character class")]
        public CharacterClass SubClass
        {
            get { return (CharacterClass)DbObject.GetFieldAsInt(0x0098); }
            set { DbObject.SetField(0x0098, (int)value); }
        }

        [Category("NPC Properties")]
        [DisplayName("Value: Strength")]
        [Description("Strength bonus/penalty")]
        public int Strength
        {
            get { return DbObject.GetFieldAsInt(0x00b0); }
            set { DbObject.SetField(0x00b0, value); }
        }
        [Category("NPC Properties")]
        [DisplayName("Value: Dexterity")]
        [Description("Dexterity bonus/penalty")]
        public int Dexterity
        {
            get { return (int)DbObject.GetFieldAsInt(0x00c0); }
            set { DbObject.SetField(0x00c0, (int)value); }
        }
        [Category("NPC Properties")]
        [DisplayName("Value: Stamina")]
        [Description("Stamina bonus/penalty")]
        public int Stamina
        {
            get { return (int)DbObject.GetFieldAsInt(0x00b4); }
            set { DbObject.SetField(0x00b4, (int)value); }
        }
        [Category("NPC Properties")]
        [DisplayName("Value: Inteligence")]
        [Description("Inteligence bonus/penalty")]
        public int Inteligence
        {
            get { return (int)DbObject.GetFieldAsInt(0x00b8); }
            set { DbObject.SetField(0x00b8, (int)value); }
        }
        [Category("NPC Properties")]
        [DisplayName("Value: Wisdom")]
        [Description("Wisdom bonus/penalty")]
        public int Wisdom
        {
            get { return (int)DbObject.GetFieldAsInt(0x00bc); }
            set { DbObject.SetField(0x00bc, (int)value); }
        }

        [Category("NPC Equipment")]
        [DisplayName("Main hand weapon")]
        [Description("Item GUID")]
        public int[] MainHandEq
        {
            get
            {
                var a = new int[5];
                for (var i = 0; i < 5; ++i)
                    a[i] = DbObject.GetFieldAsInt(0x017c+(uint)i);
                return a;
            }
            set
            {
                var max = Math.Min(5, value.Length);
                for (var i = 0; i < max; ++i)
                    DbObject.SetField(0x017c + (uint)i, value[i]);
            }
        }
        [Category("NPC Equipment")]
        [DisplayName("Second hand equipment")]
        [Description("Item GUID")]
        public int[] SecondHandEq
        {
            get
            {
                var a = new int[5];
                for (var i = 0; i < 5; ++i)
                    a[i] = DbObject.GetFieldAsInt(0x0190 + (uint)i);
                return a;
            }
            set
            {
                var max = Math.Min(5, value.Length);
                for (var i = 0; i < max; ++i)
                    DbObject.SetField(0x0190 + (uint)i, value[i]);
            }
        }
        [Category("NPC Equipment")]
        [DisplayName("Equipped bow")]
        [Description("Item GUID")]
        public int BowEq
        {
            get { return (int)DbObject.GetFieldAsInt(0x0478); }
            set { DbObject.SetField(0x0478, (int)value); }
        }

        [Category("NPC Drop")]
        [DisplayName("Gold drop: base")]
        [Description("Amount of money that NPC can drop")]
        public int MoneyDropBase
        {
            get { return DbObject.GetFieldAsInt(0x00cc); }
            set { DbObject.SetField(0x00cc, value); }
        }

        [Category("NPC Drop")]
        [DisplayName("Gold drop: rand")]
        [Description("Amount of (additional random) money that NPC can drop")]
        public int MoneyDropRand
        {
            get { return DbObject.GetFieldAsInt(0x00d0); }
            set { DbObject.SetField(0x00d0, value); }
        }

        [Category("NPC Properties")]
        [DisplayName("Brave")]
        [Description("No info")]
        public int Brave
        {
            get { return DbObject.GetFieldAsInt(0x0900); }
            set { DbObject.SetField(0x0900, value); }
        }
        [Category("NPC Properties")]
        [DisplayName("Camp")]
        public CampId Camp
        {
            get { return (CampId)DbObject.GetFieldAsInt("campid"); }
            set { DbObject.SetField("campid", (int)value); }
        }

        [Category("NPC Drop")]
        [DisplayName("Item drop")]
        [Description("Drop collection")]
        public ItemDrop[] ItemDrop
        {
            get
            {
                var a = new ItemDrop[15];
                for (var i = 0; i < 15; ++i)
                    a[i] = new ItemDrop(this, i);
                return a;
            }
        }

        [Category("NPC Abilities")]
        [DisplayName("Spells")]
        [Description("Spell collection")]
        public NpcSpellData[] Spells
        {
            get
            {
                var a = new NpcSpellData[8];
                for (var i = 0; i < 8; ++i)
                    a[i] = new NpcSpellData(this, i);
                return a;
            }
        }
        [Category("NPC Abilities")]
        [DisplayName("Wear stats")]
        [Description("Stats collection")]
        public WearStat[] Stats
        {
            get
            {
                var a = new WearStat[10];
                for (var i = 0; i < 10; ++i)
                    a[i] = new WearStat(this, i);
                return a;
            }
        }



        [Category("NPC Quests")]
        [DisplayName("Quest mode")]
        [Description("? no idea")]
        public int QuestMode
        {
            get { return DbObject.GetFieldAsInt(0x01a4); }
            set { DbObject.SetField(0x01a4, value); }
        }
        [Category("NPC Quests")]
        [DisplayName("Quest NPC ref id")]
        [Description("? no idea")]
        public int QuestNpcRefId
        {
            get { return DbObject.GetFieldAsInt(0x0320); }
            set { DbObject.SetField(0x0320, value); }
        }

        [Category("NPC Quests")]
        [Description("Quest list")]
        public int[] Quests
        {
            get
            {
                var a = new int[20];
                for (uint i = 0; i < 20; ++i)
                    a[i] = DbObject.GetFieldAsInt(0x01b0 + i);
                return a;
            }
            set
            {
                var max = Math.Min(20, value.Length);
                for (uint i = 0; i < max; ++i)
                    DbObject.SetField(0x01b0 + i, value[i]);
            }
        }
        [Category("NPC Quests")]
        [DisplayName("LUA Script")]
        [Description("Max 64 chars. Initialization or dialouge loading (?)")]
        public string LuaScript
        {
            get { return DbObject.GetFieldAsStaticString(0x0344, 64); }
            set { DbObject.SetField(0x0344, value, 64); }
        }
        [Category("NPC Quests")]
        [DisplayName("LUA Init Script")]
        [Description("Max 64 chars. 預設初始化劇情資料")]
        public string LuaInitScript
        {
            get { return DbObject.GetFieldAsStaticString(0x0484, 64); }
            set { DbObject.SetField(0x0484, value, 64); }
        }
        [Category("NPC Quests")]
        [DisplayName("LUA - OnAttackMagic")]
        [Description("Max 64 chars.")]
        public string LuaOnAttackMagic
        {
            get { return DbObject.GetFieldAsStaticString(0x0484 + 64+ 4, 64); }
            set { DbObject.SetField(0x0484 + 64 + 4, value, 64); }
        }
        [Category("NPC Quests")]
        [DisplayName("LUA - OnAssistMagic")]
        [Description("Max 64 chars.")]
        public string LuaOnAssistMagic
        {
            get { return DbObject.GetFieldAsStaticString(0x0484 + 64*2 + 4, 64); }
            set { DbObject.SetField(0x0484 + 64*2 + 4, value, 64); }
        }
        [Category("NPC Quests")]
        [DisplayName("LUA - OnDead")]
        [Description("Max 64 chars.")]
        public string LuaOnDead
        {
            get { return DbObject.GetFieldAsStaticString(0x0484 + 64 * 3 + 4, 64); }
            set { DbObject.SetField(0x0484 + 64 *3 + 4, value, 64); }
        }
        [Category("NPC Quests")]
        [DisplayName("LUA - OnKill")]
        [Description("Max 64 chars.")]
        public string LuaOnKill
        {
            get { return DbObject.GetFieldAsStaticString(0x0484 + 64 * 4 + 4, 64); }
            set { DbObject.SetField(0x0484 + 64 * 4 + 4, value, 64); }
        }
        [Category("NPC Quests")]
        [DisplayName("LUA - Display script")]
        [Description("Max 64 chars.")]
        public string LuaDisplayScript
        {
            get { return DbObject.GetFieldAsStaticString(0x0600, 64); }
            set { DbObject.SetField(0x0600, value, 64); }
        }

        public override string GetDescription()
        {
            var levelText = Level.ToString();
            if (LevelRange != 0)
                levelText = "[" + Level + ".." + (Level+LevelRange) + "]";


            var classText = Class.ToString();
            if (SubClass != CharacterClass.None)
                classText += "/"+SubClass;

            return string.Format("Class: {5}; Level: {0}; Sex: {4}; XP: x{1:P0}; TP x{2:P0}; Revive: {3:F1} min",
                levelText, XpRate/100.0, TpRate/100.0, ReviveTime/60.0, Sex, classText);
        }
        public override Color GetColor()
        {
            if (Sex < Sex.BigMonster)
                return Color.White;
            if (Sex < Sex.King)
                return Color.Orange;
            if (Sex < Sex.WorldKing)
                return Color.OrangeRed;
            return Color.Red;
        }
        public override string GetIconName() { return "npc"; }
    }
    public class ItemDrop : StructuredField
    {
        private readonly int _j;
        public ItemDrop(BasicTableObject npc, int i) : base(npc)
        {
            _j = i + 1;
        }
        public uint GUID
        {
            get { return Object.GetFieldAsUInt("dropid" + _j); }
            set { Object.SetField("dropid" + _j, value); }
        }
        public int Rate
        {
            get { return Object.GetFieldAsInt("droprate" + _j); }
            set { Object.SetField("droprate" + _j, value); }
        }

        public override string ToString()
        {
            var item = TableObject.OwnerTable.Db.GetNameForGuid(GUID) ?? GUID.ToString();
            item = "[" + item + "]";
            return string.Format("{0} - {1:P3}", item, Rate / 100000.0);
        }
    }
    public class NpcSpellData : StructuredField
    {
        private readonly string _j;
        [Description("When to cast?")]
        public SpellRightTime TriggeringEvent
        {
            get { return (SpellRightTime)Object.GetFieldAsUInt("spellrighttime" + _j); }
            set { Object.SetField("spellrighttime" + _j, (int)value); }
        }
        [Description("Who should be a target for a spell?")]
        public SpellTarget TargetType
        {
            get { return (SpellTarget)Object.GetFieldAsUInt("spelltarget" + _j); }
            set { Object.SetField("spelltarget" + _j, (int)value); }
        }
        [Description("How often should we cast the spell")]
        public int Priority
        {
            get { return Object.GetFieldAsInt("spellrate" + _j); }
            set { Object.SetField("spellrate" + _j, value); }
        }
        [Description("Spell GUID")]
        public uint SpellGUID
        {
            get { return Object.GetFieldAsUInt("spellmagic" + _j); }
            set { Object.SetField("spellmagic" + _j, value); }
        }
        [Description("Spell Level")]
        public int SpellLevel
        {
            get { return Object.GetFieldAsInt("spellmagiclv" + _j); }
            set { Object.SetField("spellmagiclv" + _j, value); }
        }
        [Description("String to say on cast (?)")]
        public int SpellString
        {
            get { return Object.GetFieldAsInt("spellstring" + _j); }
            set { Object.SetField("spellstring" + _j, value); }
        }	

        public NpcSpellData(BasicTableObject npc, int i) : base(npc)
        {
            _j = (i + 1).ToString();
        }

        public override string ToString()
        {
            if (SpellGUID == 0 || this.TriggeringEvent == SpellRightTime.None)
                return "[Empty]";
            var spell = (TableObject.OwnerTable.Db[SpellGUID]);
            var spellName = spell == null ? "?" : TableObject.OwnerTable.Db.GetStringByGuid(SpellGUID, StringLinkKind.Name);
            return string.Format("[{4}({0}) +{3}]; Target: {1}; Is cast on: {2}", SpellGUID, TargetType, TriggeringEvent, SpellLevel, spellName);
        }
    }
    public class WearStat : StructuredField
    {
        private int _id;
        public WearStat(BasicTableObject o, int i) : base(o)
        {
            _id = i;
        }

        public override string ToString()
        {
            if (IsEmpty)
                return base.ToString();
            return string.Format("{2}{0:D} {1}", Value, Type, Value > 0 ? "+" : "");
        }
        public WearEquipmentType Type
        {
            get { return (WearEquipmentType)Object.GetFieldAsInt("eqtype" + (_id + 1)); }
            set { Object.SetField("eqtype" + (_id + 1), (int)value); }
        }
        public int Value
        {
            get { return Object.GetFieldAsInt("eqtypevalue" + (_id + 1)); }
            set { Object.SetField("eqtypevalue" + (_id + 1), value); }
        }

        [Browsable(false)]
        public bool IsEmpty {
            get { return (Type == WearEquipmentType.None || Value == 0); }
        }
    }
}

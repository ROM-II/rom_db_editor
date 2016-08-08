using System;
using System.ComponentModel;
using System.Drawing;
using Runes.Net.Db;
using Runes.Net.Shared;

namespace RunesDataBase.TableObjects
{
    public class MagicObject : BasicVisualTableObject
    {
        [Category("Magic Properties")]
        [DisplayName("Function type")]
        [Description("Kind of magic")]
        public MagicFunc FuncType
        {
            get { return (MagicFunc)DbObject.GetFieldAsInt("magicfunc"); }
            set { DbObject.SetField("magicfunc", (int)value); }
        }

        [Category("Magic Properties")]
        [DisplayName("Magic type")]
        [Description("Kind of magic")]
        public MagicResist MagicType
        {
            get { return (MagicResist)DbObject.GetFieldAsInt("magictype"); }
            set { DbObject.SetField("magictype", (int)value); }
        }

        [Category("Magic Properties")]
        [DisplayName("Effect type")]
        [Description("Kind of magic")]
        public SpellEffectType EffectType
        {
            get { return (SpellEffectType)DbObject.GetFieldAsInt("effecttype"); }
            set { DbObject.SetField("effecttype", (int)value); }
        }

        [Category("Magic Properties")]
        [DisplayName("Duration")]
        [Description("Duration of this magic (min 0.1 (?))")]
        public float Duration
        {
            get { return DbObject.GetFieldAsFloat("effecttime"); }
            set { DbObject.SetField("effecttime", value); }
        }

        [Category("Magic Properties")] [DisplayName("Level difference -> Duration")]
        [Description("Or dlv_effecttime (0.1 sec)")]
        public float DlvDuration
        {
            get { return DbObject.GetFieldAsFloat("dlv_effecttime"); }
            set { DbObject.SetField("dlv_effecttime", value); }
        }
        
        [Category("Magic Properties")] [DisplayName("Skill level -> Duration")]
        [Description("Or effecttime_skilllvarg (0.1 sec)")]
        public float SklLvlDuration
        {
            get { return DbObject.GetFieldAsFloat("effecttime_skilllvarg"); }
            set { DbObject.SetField("effecttime_skilllvarg", value); }
        }

        [Category("Magic Properties")] [DisplayName("Hate Cost")]
        [Description("(?) Hate value (how much the value of hatred + target plus) (- targeted attacks much aggro target deceleration)")]
        public int HateCost
        {
            get { return DbObject.GetFieldAsInt("hatecost"); }
            set { DbObject.SetField("hatecost", value); }
        }

        [Category("Magic Properties")] [DisplayName("Max buff level (base)")] 
        public int MaxBuffLevel
        {
            get { return DbObject.GetFieldAsInt("maxbufflv"); }
            set { DbObject.SetField("maxbufflv", value); }
        }

        [DisplayName("Skill level -> Max level")] [Category("Magic Properties")]
        [Description("Or maxbufflv_skilllvarg (0.1 sec)")]
        public float MaxBuffLvSkillLvArg
        {
            get { return DbObject.GetFieldAsFloat("maxbufflv_skilllvarg"); }
            set { DbObject.SetField("maxbufflv_skilllvarg", value); }
        }

        [DisplayName("Dot data")] [Category("Magic Action Properties")]
        [Description("Structure, describing dot charecteristics of this magic")]
        public MagicDotData DotData 
            => new MagicDotData(this);

        [DisplayName("Attack data")] [Category("Magic Action Properties")]
        [Description("Structure, describing attack charecteristics of this magic")]
        public MagicAttackData AttackData 
            => new MagicAttackData(this);

        [DisplayName("Group set")] [Category("Magic Properties")]
        [Description("??")]
        public int GroupSet
        {
            get { return DbObject.GetFieldAsInt("magicgroupset"); }
            set { DbObject.SetField("magicgroupset", value); }
        }

        [Category("Magic Properties")]
        [DisplayName("Settings")]
        [Description("Flags")]
        public MagicSetting Settings
        {
            get { return (MagicSetting)DbObject.GetFieldAsUInt("settingflag"); }
            set { DbObject.SetField("settingflag", (uint)value); }
        }

        [DisplayName("Attack special action")] [Category("Magic Properties")]
        [Description("Flags")]
        public MagicAttackSpecialAction AttackSpecialAction
        {
            get { return (MagicAttackSpecialAction)DbObject.GetFieldAsUInt("specialaction"); }
            set { DbObject.SetField("specialaction", (uint)value); }
        }

        [DisplayName("Effect Level")] [Category("Magic Properties")]
        [Description("??")]
        public int EffectLevel
        {
            get { return DbObject.GetFieldAsInt("effectlv"); }
            set { DbObject.SetField("effectlv", value); }
        }

        [DisplayName("Effect flags")] [Category("Magic Properties")]
        public MagicEffect EffectFlags
        {
            get { return (MagicEffect)DbObject.GetFieldAsULong("effect"); }
            set { DbObject.SetField("effect", (ulong)value); }
        }

        [DisplayName("Clear time(?)")] [Category("Magic Properties")]
        [Description("??")]
        public MagicClearTime ClearTime
        {
            get { return (MagicClearTime)DbObject.GetFieldAsUInt("magicclear"); }
            set { DbObject.SetField("magicclear", (uint)value); }
        }

        [DisplayName("Ability")] [Category("Magic Properties")]
        [Description("Structure, describing dot charecteristics of this magic")]
        public WearEq Ability 
            => new WearEq(this);

        [DisplayName("Ability (Skill Level koef)")] [Category("Magic Properties")]
        public float AbilitySkillLevel
        {
            get { return DbObject.GetFieldAsFloat("ability_skilllvarg"); }
            set { DbObject.SetField("ability_skilllvarg", value); }
        }

        [Category("Magic Properties")] //[DisplayName("OnTimeMagic_Magic")]
        [Description("???")]
        public int OnTimeMagic_Magic
        {
            get { return DbObject.GetFieldAsInt("ontimemagic_magic"); }
            set { DbObject.SetField("ontimemagic_magic", value); }
        }

        [Category("Magic Properties")] //[DisplayName("OnTimeMagic_Time")]
        [Description("???")]
        public int OnTimeMagic_Time
        {
            get { return DbObject.GetFieldAsInt("ontimemagic_time"); }
            set { DbObject.SetField("ontimemagic_time", value); }
        }

        [Category("Magic Properties")] //[DisplayName("FaceOffID")]
        [Description("???")]
        public uint FaceOffID
        {
            get { return DbObject.GetFieldAsUInt("changeid"); }
            set { DbObject.SetField("changeid", value); }
        }

        [Category("Magic Properties")] //[DisplayName("RideID")]
        [Description("??? (Mount npc id?)")]
        public uint RideID
        {
            get { return DbObject.GetFieldAsUInt("rideid"); }
            set { DbObject.SetField("rideid", value); }
        }

        [Category("Magic Properties")] //[DisplayName("RideID")]
        [Description("??? Magic to do on each (normal?) attack")]
        public uint OnAttackMagicID
        {
            get { return DbObject.GetFieldAsUInt("onattackmagicid"); }
            set { DbObject.SetField("onattackmagicid", value); }
        }

        [Category("Magic Properties")] //[DisplayName("RideID")]
        [Description("??? Magic to do on buff ends")]
        public uint OnBuffTimeOutMagicID
        {
            get { return DbObject.GetFieldAsUInt("onbufftimeoutmagicid"); }
            set { DbObject.SetField("onbufftimeoutmagicid", value); }
        }

        [Category("Magic Properties")] //[DisplayName("RideID")]
        [Description("???")]
        public uint OnAttackReboundMagicID
        {
            get { return DbObject.GetFieldAsUInt("onattackreboundmagicid"); }
            set { DbObject.SetField("onattackreboundmagicid", value); }
        }

        [Category("Magic Properties")] //[DisplayName("RideID")]
        [Description("???")]
        public uint OnMagicAttackReboundMagicID
        {
            get { return DbObject.GetFieldAsUInt("onmagicattackreboundmagicid"); }
            set { DbObject.SetField("onmagicattackreboundmagicid", value); }
        }

        [Category("Magic Properties")] //[DisplayName("RideID")]
        [Description("???")]
        public uint OnDeadMagicID
        {
            get { return DbObject.GetFieldAsUInt("ondeadmagicid"); }
            set { DbObject.SetField("ondeadmagicid", value); }
        }

        [DisplayName("Summon Data")] [Category("Magic Action Properties")]
        [Description("Summoning data")]
        public MagicSummonCreature SummonCreature
        {
            get { return new MagicSummonCreature(this); }
        }

        [DisplayName("Teleport")] [Category("Magic Action Properties")]
        [Description("Teleportation data")]
        public MagicTeleport TeleportData
        {
            get { return new MagicTeleport(this); }
        }

        [DisplayName("Raise - Exp %")] [Category("Magic Action Properties")] 
        [Description("?? Either xp dept % or it`s decrement %")]
        public int RaiseExp
        {
            get { return DbObject.GetFieldAsInt("raiseexpprecnt"); }
            set { DbObject.SetField("raiseexpprecnt", value); }
        }

        [DisplayName("Summon Item - guid")]
        [Category("Magic Action Properties")]
        public uint SummonItemId
        {
            get { return DbObject.GetFieldAsUInt("siobjid"); }
            set { DbObject.SetField("siobjid", value); }
        }
        
        [DisplayName("Run item plot")] [Category("Magic Action Properties")]
        [Description("Plot data")]
        public MagicItemRunPlot PlotData
        {
            get { return new MagicItemRunPlot(this); }
        }

        [DisplayName("Run plot")] [Category("Magic Action Properties")]
        [Description("Plot data")]
        public string RunPlot
        {
            get { return DbObject.GetFieldAsStaticString("mrplotname", 64); }
            set { DbObject.SetField("mrplotname", value, 64); }
        }
        [DisplayName("Shield")] [Category("Magic Action Properties")]
        [Description("Shield behaviour")]
        public MagicShieldStruct ShieldData
        {
            get { return new MagicShieldStruct(this); }
        }

        [Category("Magic Properties")]
        [Description("?? atkcaltype")]
        public MagicAttackCalBase AttackCalBase
        {
            get { return (MagicAttackCalBase)DbObject.GetFieldAsUInt("atkcaltype"); }
            set { DbObject.SetField("atkcaltype", (uint)value); }
        }

        [Category("Magic Properties")]
        [Description("???")]
        public uint MagicGroupId
        {
            get { return DbObject.GetFieldAsUInt("magicgroupid"); }
            set { DbObject.SetField("magicgroupid", value); }
        }
        [Category("Magic Properties")]
        [Description("???")]
        public int BuffCount
        {
            get { return DbObject.GetFieldAsInt("buffcount"); }
            set { DbObject.SetField("buffcount", value); }
        }

        [Category("Magic Properties")]
        [Description("?? phyattacktype")]
        public PhysicalResist PhysAttackType
        {
            get { return (PhysicalResist)DbObject.GetFieldAsUInt("phyattacktype"); }
            set { DbObject.SetField("phyattacktype", (uint)value); }
        }

        [Category("Magic Properties")]
        [Description("??? isstandard_attack")]
        public bool IsStandardAttack
        {
            get { return DbObject.GetFieldAsUInt("isstandard_attack") != 0; }
            set { DbObject.SetField("isstandard_attack", value ? 1 : 0); }
        }

        [Category("Magic Properties")]
        [DisplayName("Scale model koef")]
        public float ModelScale
        {
            get { return DbObject.GetFieldAsFloat("modelsize"); }
            set { DbObject.SetField("modelsize", value); }
        }
        
        [Category("Magic Properties")]
        [Description("???")]
        public int AddBuffTime
        {
            get { return DbObject.GetFieldAsInt("addbufftime"); }
            set { DbObject.SetField("addbufftime", value); }
        }
        
        [Category("Magic Properties")]
        [Description("??? Magic guid to apply if victim is killed?")]
        public uint OnKillMagicId
        {
            get { return DbObject.GetFieldAsUInt("onkillmagicid"); }
            set { DbObject.SetField("onkillmagicid", value); }
        }

        [DisplayName("LUA - Check before usage")] [Category("Magic Properties")]
        [Description("? checkuselua")]
        public string CheckUseLua
        {
            get { return DbObject.GetFieldAsStaticString("checkuselua", 64); }
            set { DbObject.SetField("checkuselua", value, 64); }
        }

        [DisplayName("Event type")] [Category("Special Magic Properties")]
        [Description("? specialmagiceventtype")]
        public SpecailMagicEventType SpecialMagicEventType
        {
            get { return (SpecailMagicEventType)DbObject.GetFieldAsUInt("specialmagiceventtype"); }
            set { DbObject.SetField("specialmagiceventtype", (uint)value); }
        }

        [DisplayName("Magic GUID")]
        [Category("Special Magic Properties")]
        [Description("? onspecialmagicid")]
        public uint OnSpecialMagicId
        {
            get { return DbObject.GetFieldAsUInt("onspecialmagicid"); }
            set { DbObject.SetField("onspecialmagicid", value); }
        }

        /*
	    int								BuffTimeDesc_Type;
	    int								BuffTimeDesc_Time;

	    int								BuffSkill[ _MAX_BUFFSKILL_COUNT_ ];*/
        
        [DisplayName("LUA - On effect ends")] [Category("Magic Properties")]
        [Description("? enduselua")]
        public string EndUseLua
        {
            get { return DbObject.GetFieldAsStaticString("enduselua", 64); }
            set { DbObject.SetField("enduselua", value, 64); }
        }
        [Category("Magic Properties")]
        public int HitBackDist
        {
            get { return DbObject.GetFieldAsInt("hitbackdist"); }
            set { DbObject.SetField("hitbackdist", value); }
        }

        [DisplayName("Carry count")]
        [Category("Magic Properties")]
        [Description("??? carrycount")]
        public int CarryCount
        {
            get { return DbObject.GetFieldAsInt("carrycount"); }
            set { DbObject.SetField("carrycount", value); }
        }
        /*[Category("Magic Properties")]
        public uint MusicID
        {
            get { return DbObject.GetFieldAsUInt(""); }
            set { DbObject.SetField("", value); }
        }*/
        [Category("Magic Properties")]
        public int BuffMaxLv
        {
            get { return DbObject.GetFieldAsInt("buffmaxlv"); }
            set { DbObject.SetField("buffmaxlv", value); }
        }
        [Category("Magic Properties")]
        public uint OnBuffTimeOutMagicIDEx
        {
            get { return DbObject.GetFieldAsUInt("onbufftimeoutmagicidex"); }
            set { DbObject.SetField("onbufftimeoutmagicidex", value); }
        }

        public MagicObject(BasicObject obj) : base(obj)
        {
        }
        public override string GetDescription()
        {
            return "";
        }
        public override Color GetColor()
        {
            return Color.Magenta;
        }
        public override string GetIconName() { return "buff"; }
    }

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class MagicDotData
    {
        private BasicObject _obj;
        public MagicDotData(MagicObject o)
        {
            _obj = o.DbObject;
        }

        public int Delay
        {
            get { return _obj.GetFieldAsInt("dottime"); }
            set { _obj.SetField("dottime", value); }
        }
        public DotMagicType Type
        {
            get { return (DotMagicType)_obj.GetFieldAsInt("dottype"); }
            set { _obj.SetField("dottype", (int)value); }
        }
        public int Base
        {
            get { return _obj.GetFieldAsInt("dotbase"); }
            set { _obj.SetField("dotbase", value); }
        }
        public float DotSkillLVArg
        {
            get { return _obj.GetFieldAsFloat("dotskilllvarg"); }
            set { _obj.SetField("dotskilllvarg", value); }
        }

        public bool IsEmpty
        {
            get { return (Base == 0 || Delay <= 0); }
        }

        public override string ToString()
        {
            if (IsEmpty)
                return "<empty>";
            return string.Format("{1} {2} each {0} sec", Delay, Base, Type);
        }
    }
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class MagicAttackData
    {
        private BasicObject _obj;
        public MagicAttackData(MagicObject o)
        {
            _obj = o.DbObject;
        }

        public MagicAttackType Type
        {
            get { return (MagicAttackType)_obj.GetFieldAsInt("atk_atktype"); }
            set { _obj.SetField("atk_atktype", (int)value); }
        }

        [DisplayName("Damage Power")]
        public float DmgPower
        {
            get { return _obj.GetFieldAsFloat("atk_dmgpower"); }
            set { _obj.SetField("atk_dmgpower", value); }
        }

        [DisplayName("Damage Power (Skill Level koef)")]
        public float DmgPowerSkillLevel
        {
            get { return _obj.GetFieldAsFloat("dmgpower_skilllvarg"); }
            set { _obj.SetField("dmgpower_skilllvarg", value); }
        }

        [DisplayName("Fix value")]
        public float FixValue
        {
            get { return _obj.GetFieldAsFloat("atk_fixvalue"); }
            set { _obj.SetField("atk_fixvalue", value); }
        }

        [DisplayName("Fix type")]
        public MagicAttackCal FixType
        {
            get { return (MagicAttackCal)_obj.GetFieldAsInt("atk_fixtype"); }
            set { _obj.SetField("atk_fixtype", (int)value); }
        }

        [DisplayName("Fix damage (Skill Level koef)")]
        public float FixDamageSkillLevel
        {
            get { return _obj.GetFieldAsFloat("fixdmg_skilllvarg"); }
            set { _obj.SetField("fixdmg_skilllvarg", value); }
        }

        [DisplayName("Random damage part")]
        public float Rand
        {
            get { return _obj.GetFieldAsFloat("atk_rand"); }
            set { _obj.SetField("atk_rand", value); }
        }

        [DisplayName("Critical hit rate")]
        public int CritRate
        {
            get { return _obj.GetFieldAsInt("atk_critialrate"); }
            set { _obj.SetField("atk_critialrate", value); }
        }

        [DisplayName("Aggro rate")]
        public float HateRate
        {
            get { return _obj.GetFieldAsFloat("atk_haterate"); }
            set { _obj.SetField("atk_haterate", value); }
        }

        public override string ToString()
        {
            return "";
        }
    }
    public class WearEq : StructuredField
    {
        private BasicObject _obj;
        public WearEq(BasicTableObject o) : base(o)
        {
            _obj = o.DbObject;
        }

        public WearStat[] Stats
        {
            get
            {
                var a = new WearStat[10];
                for (var i = 0; i < 10; ++i)
                    a[i] = new WearStat(TableObject, i);
                return a;
            }
            set
            {
            }
        }
        public int OnAttackMagicRate
        {
            get { return _obj.GetFieldAsInt("eqtypeonattackmagicrate"); }
            set { _obj.SetField("eqtypeonattackmagicrate", value); }
        }
        public int OnAttackMagicRank
        {
            get { return _obj.GetFieldAsInt("eqtypeonattackmagicrank"); }
            set { _obj.SetField("eqtypeonattackmagicrank", value); }
        }
        public uint OnAttackMagicID
        {
            get { return _obj.GetFieldAsUInt("eqtypeonattackmagicid"); }
            set { _obj.SetField("eqtypeonattackmagicid", value); }
        }

        public override string ToString()
        {
            return "";
        }
    }

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class MagicSummonCreature
    {
        private BasicTableObject _tobj;
        private BasicObject _obj;
        public MagicSummonCreature(BasicTableObject o)
        {
            _tobj = o;
            _obj = _tobj.DbObject;
        }
        public uint NpcId
        {
            get { return _obj.GetFieldAsUInt("scobjid"); }
            set { _obj.SetField("scobjid", value); }
        }
        public int Level
        {
            get { return _obj.GetFieldAsInt("sclevel"); }
            set { _obj.SetField("sclevel", value); }
        }
        public int RangeLevel
        {
            get { return _obj.GetFieldAsInt("scrangelevel"); }
            set { _obj.SetField("scrangelevel", value); }
        }
        [Description("(In seconds?) -1 for infinite")]
        public int LiveTime
        {
            get { return _obj.GetFieldAsInt("sclivetime"); }
            set { _obj.SetField("sclivetime", value); }
        }
        public float SkillLvArg
        {
            get { return _obj.GetFieldAsFloat("scskilllvarg"); }
            set { _obj.SetField("scskilllvarg", value); }
        }
        public SummonCreatureType Type
        {
            get { return (SummonCreatureType)_obj.GetFieldAsInt("sctype"); }
            set { _obj.SetField("sctype", (int)value); }
        }
        public uint GroupID
        {
            get { return _obj.GetFieldAsUInt("scgroupid"); }
            set { _obj.SetField("scgroupid", value); }
        }
        public float OwnerPowerRate
        {
            get { return _obj.GetFieldAsFloat("scownerpowerrate"); }
            set { _obj.SetField("scownerpowerrate", value); }
        }
        public int[] SkillType
        {
            get
            {
                const int MAX = 3;
                var a = new int[MAX];
                for (var i = 0; i < MAX; ++i)
                    a[i] = _obj.GetFieldAsInt("scskilltype" + i);
                return a;
            }
        }
        public string InitLua
        {
            get { return _obj.GetFieldAsStaticString("scinitlua", 32); }
            set { _obj.SetField("scinitlua", value, 32); }
        }

        public override string ToString()
        {
            if (NpcId == 0)
                return "<empty>";
            var strLevel = RangeLevel == 0 ? Level.ToString() : Level + "-" + (Level + RangeLevel);
            var strLife = LiveTime < 0 ? "forever" : "for " + LiveTime + " seconds";
            return string.Format("{0} (level {1}) {2}",_tobj.Name, strLevel, strLife);
        }
    }
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class MagicTeleport
    {
        private BasicTableObject _tobj;
        private BasicObject _obj;
        public MagicTeleport(BasicTableObject o)
        {
            _tobj = o;
            _obj = o.DbObject;
        }
        public uint ZoneID
        {
            get { return _obj.GetFieldAsUInt("teleportzoneid"); }
            set { _obj.SetField("teleportzoneid", value); }
        }
        public int X
        {
            get { return _obj.GetFieldAsInt("teleportx"); }
            set { _obj.SetField("teleportx", value); }
        }
        public int Y
        {
            get { return _obj.GetFieldAsInt("teleporty"); }
            set { _obj.SetField("teleporty", value); }
        }
        public int Z
        {
            get { return _obj.GetFieldAsInt("teleportz"); }
            set { _obj.SetField("teleportz", value); }
        }
        public int Dir
        {
            get { return _obj.GetFieldAsInt("teleportdir"); }
            set { _obj.SetField("teleportdir", value); }
        }

        public override string ToString()
        {
            if (ZoneID == 0)
                return "<empty>";
            return string.Format("Zone: {0} ({1};{2};{3})", ZoneID, X, Y, Z);
        }
    }
    public class MagicItemRunPlot : StructuredField
    {
        public MagicItemRunPlot(BasicTableObject o) : base(o) { }
        public MagicItemRunPlotType PlotType
        {
            get { return (MagicItemRunPlotType)Object.GetFieldAsUInt("mitype"); }
            set { Object.SetField("mitype", (uint)value); }
        }
        public uint ObjectGuid
        {
            get { return Object.GetFieldAsUInt("miobjid"); }
            set { Object.SetField("miobjid", value); }
        }
        public string PlotName
        {
            get { return Object.GetFieldAsStaticString("miplotname", 64); }
            set { Object.SetField("miplotname", value, 64); }
        }
        public int LiveTime
        {
            get { return Object.GetFieldAsInt("milivetime"); }
            set { Object.SetField("milivetime", value); }
        }
        [Description("GUID?")]
        public uint UseMagic
        {
            get { return Object.GetFieldAsUInt("miusemagic"); }
            set { Object.SetField("miusemagic", value); }
        }
        [Description("GUID?")]
        public uint OnDeadMagic
        {
            get { return Object.GetFieldAsUInt("miondeadmagic"); }
            set { Object.SetField("miondeadmagic", value); }
        }
        public uint GroupId
        {
            get { return Object.GetFieldAsUInt("migroupid"); }
            set { Object.SetField("migroupid", value); }
        }
        public RunPlotMode Mode
        {
            get { return (RunPlotMode)Object.GetFieldAsUInt("mimode"); }
            set { Object.SetField("mimode", (uint)value); }
        }
        public MagicItemRunPlotTargetType TargetType
        {
            get { return (MagicItemRunPlotTargetType)Object.GetFieldAsUInt("mitargettype"); }
            set { Object.SetField("mitargettype", (uint)value); }
        }

        public override string ToString()
        {
            if (ObjectGuid == 0)
                return base.ToString();
            return string.Format("'{1}' on {0}", ObjectGuid, PlotName);
        }
    }
    public class MagicShieldStruct : StructuredField
    {
        public MagicShieldStruct(BasicTableObject o) : base(o) { }
        public MagicShieldType ShieldType
        {
            get { return (MagicShieldType)Object.GetFieldAsUInt("magicshield_type"); }
            set { Object.SetField("magicshield_type", (uint)value); }
        }
        public MagicShieldEffect ShieldEffect
        {
            get { return (MagicShieldEffect)Object.GetFieldAsUInt("magicshield_effect"); }
            set { Object.SetField("magicshield_effect", (uint)value); }
        }
        public int Points
        {
            get { return Object.GetFieldAsInt("magicshield_point"); }
            set { Object.SetField("magicshield_point", value); }
        }
        public float SkillLevelArg
        {
            get { return Object.GetFieldAsFloat("magicshield_skilllvarg"); }
            set { Object.SetField("magicshield_skilllvarg", value); }
        }

        public override string ToString()
        {
            if (Points == 0)
                return base.ToString();
            return string.Format("{0}", Points);
        }
    }
}

using System.ComponentModel;
using System.Drawing;
using Runes.Net.Db;
using Runes.Net.Shared;

namespace RunesDataBase.TableObjects
{
    public class SpellObject : BasicVisualTableObject
    {
        public SpellObject(BasicObject obj) : base(obj) { }

        [Category("Spell Properties")]
        [DisplayName("Magic Level")]
        [Description("Some kind of a level (?)")]
        public int MagicLv
        {
            get { return DbObject.GetFieldAsInt("magiclv"); }
            set { DbObject.SetField("magiclv", value); }
        }

        [Category("Spell Properties")]
        [DisplayName("Effect type")]
        [Description("Type of the effect, that spell does")]
        public SpellEffectType EffectType
        {
            get { return (SpellEffectType) DbObject.GetFieldAsInt("effecttype"); }
            set { DbObject.SetField("effecttype", (int) value); }
        }

        [Category("Spell Properties")]
        [DisplayName("Target type")]
        [Description("Type of the target")]
        public Relation TargetType
        {
            get { return (Relation)DbObject.GetFieldAsInt("targettype"); }
            set { DbObject.SetField("targettype", (int)value); }
        }

        [Category("Spell Properties")]
        [DisplayName("Attack distance")]
        [Description("Maxmum range between caster and target")]
        public int AttackDistance
        {
            get { return DbObject.GetFieldAsInt("attackdistance"); }
            set { DbObject.SetField("attackdistance", value); }
        }

        [Category("AOE Spell Properties")]
        [DisplayName("Effect range")]
        [Description("Maxmum range between main target and other targets (?)")]
        public int EffectRange
        {
            get { return DbObject.GetFieldAsInt("effectrange"); }
            set { DbObject.SetField("effectrange", value); }
        }

        [Category("AOE Spell Properties")]
        [DisplayName("Effect range type")]
        [Description("Type of the effect range (?)")]
        public EffectRangeType RangeType
        {
            get { return (EffectRangeType)DbObject.GetFieldAsInt("rangetype"); }
            set { DbObject.SetField("rangetype", (int)value); }
        }

        [Category("AOE Spell Properties")]
        [DisplayName("Effect selection type")]
        [Description("Describes how to select targets in range")]
        public SpellSellectType SelectType
        {
            get { return (SpellSellectType)DbObject.GetFieldAsInt("rangeselecttype"); }
            set { DbObject.SetField("rangeselecttype", (int)value); }
        }

        [Category("AOE Spell Properties")]
        [DisplayName("Targets count")]
        [Description("Maximum amount of victims of the effect")]
        public int TargetsCount
        {
            get { return DbObject.GetFieldAsInt("effectcount"); }
            set { DbObject.SetField("effectcount", value); }
        }

        [Category("Uncategorized Spell Properties")]
        [DisplayName("Hitrate function")]
        [Description("Not sure how it works")]
        public HitRateFunc HitRate
        {
            get { return (HitRateFunc)DbObject.GetFieldAsInt("hitratefunc"); }
            set { DbObject.SetField("hitratefunc", (int)value); }
        }

        [Category("Uncategorized Spell Properties")]
        [DisplayName("Hitrate function argument [0]")]
        [Description("Not sure how it works")]
        public float HitRateArg1
        {
            get { return DbObject.GetFieldAsFloat("hitratearg1"); }
            set { DbObject.SetField("hitratearg1", value); }
        }

        [Category("Uncategorized Spell Properties")]
        [DisplayName("Hitrate function argument [1]")]
        [Description("Not sure how it works")]
        public float HitRateArg2
        {
            get { return DbObject.GetFieldAsFloat("hitratearg2"); }
            set { DbObject.SetField("hitratearg2", value); }
        }

        [Category("Spell Properties")]
        [DisplayName("Cost[0]")]
        [Description("How and what it costs to cast this spell")]
        public SpellCost SpellCost1 
            => new SpellCost(this, 0);

        [Category("Spell Properties")]
        [DisplayName("Cost[1]")]
        [Description("How and what it costs to cast this spell")]
        public SpellCost SpellCost2 
            => new SpellCost(this, 1);

        [Category("Spell Properties")]
        [DisplayName("Magic")]
        [Description("Magic the spell does")]
        public SpellMagic[] Magic
        {
            get
            {
                var a = new SpellMagic[12];
                for (var i = 0; i < 12; ++i)
                    a[i] = new SpellMagic(this, i);
                return a;
            }
        }

        [Category("Spell Properties")]
        [DisplayName("Need[0]")]
        [Description("Requirements for spell")]
        public SpellNeed SpellNeed1 
            => new SpellNeed(this, 0);

        [Category("Spell Properties")]
        [DisplayName("Need[1]")]
        [Description("Requirements for spell")]
        public SpellNeed SpellNeed2 
            => new SpellNeed(this, 1);

        [Category("Cooldown")]
        [DisplayName("Cooldown class")]
        public CooldownClass CoolDownClass
        {
            get { return (CooldownClass)DbObject.GetFieldAsInt("coldownclass"); }
            set { DbObject.SetField("coldownclass", (int)value); }
        }
        [Category("Cooldown")]
        [DisplayName("Cooldown type")]
        public int CoolDownType
        {
            get { return DbObject.GetFieldAsInt("coldowntype"); }
            set { DbObject.SetField("coldowntype", value); }
        }
        [Category("Cooldown")]
        [DisplayName("Cooldown time")]
        public int CoolDownTime
        {
            get { return DbObject.GetFieldAsInt("coldowntime"); }
            set { DbObject.SetField("coldowntime", value); }
        }
        [Category("Cooldown")]
        [DisplayName("Cooldown time (global)")]
        public int CoolDownTimeAllMagic
        {
            get { return DbObject.GetFieldAsInt("coldowntimeallmagic"); }
            set { DbObject.SetField("coldowntimeallmagic", value); }
        }

        [Category("Spell Properties")]
        [DisplayName("Flags")]
        public SpellFlags Flags
        {
            get { return (SpellFlags)DbObject.GetFieldAsInt("flag"); }
            set { DbObject.SetField("flag", (int)value); }
        }

        [Category("Spell Properties")]
        [DisplayName("Cast time")]
        [Description("Requirements for spell")]
        public float SpellTime
        {
            get { return DbObject.GetFieldAsFloat("spelltime"); }
            set { DbObject.SetField("spelltime", value); }
        }

        [Category("Spell Properties")]
        [DisplayName("Magic attack delay")]
        [Description("??")]
        public float MagicAttackDelay
        {
            get { return DbObject.GetFieldAsFloat("magicattackdelay"); }
            set { DbObject.SetField("magicattackdelay", value); }
        }

        [Category("Spell Properties")]
        [DisplayName("Spell count")]
        [Description("??")]
        public int SpellCount
        {
            get { return DbObject.GetFieldAsInt("spellcount"); }
            set { DbObject.SetField("spellcount", value); }
        }

        [Category("Spell Properties")]
        [DisplayName("Limit Level")]
        [Description("Max char level?")]
        public int LimitLevel
        {
            get { return DbObject.GetFieldAsInt("limitlv"); }
            set { DbObject.SetField("limitlv", value); }
        }
        [Category("Spell Properties")]
        [DisplayName("Max spell level")]
        [Description("Max spell level")]
        public int MaxLevel
        {
            get { return DbObject.GetFieldAsInt("maxskilllv"); }
            set { DbObject.SetField("maxskilllv", value); }
        }

        [Category("Spell Properties")]
        [DisplayName("Next spell time")]
        [Description("??")]
        public float NextSpellTime
        {
            get { return DbObject.GetFieldAsFloat("nextspelltime"); }
            set { DbObject.SetField("nextspelltime", value); }
        }

        public override string GetDescription()
        {
            return ("" + ShortNote);
        }
        public override Color GetColor()
        {
            return Color.Aqua;
        }
        public override string GetIconName() { return "spell"; }
    }
    public class SpellCost : StructuredField
    {
        private int _id;

        [DisplayName("Cost type")]
        public SpellCostType CostType
        {
            get { return (SpellCostType)Object.GetFieldAsInt(_id > 0 ? "costtype1" :"costtype"); }
            set { Object.SetField(_id > 0 ? "costtype1" : "costtype", (int)value); }
        }
        [DisplayName("Value")]
        public int Value
        {
            get { return Object.GetFieldAsInt(_id > 0 ? "costvalue1" : "costvalue"); }
            set { Object.SetField(_id > 0 ? "costvalue1" : "costvalue", (int)value); }
        }

        public SpellCost(BasicTableObject o, int i) : base(o)
        {
            _id = i;
        }

        public override string ToString()
        {
            return Value + " of " + CostType;
        }
    }
    public class SpellNeed : StructuredField
    {
        private int _id;

        [DisplayName("Need type")]
        public SpellNeedType NeedType
        {
            get { return (SpellNeedType)Object.GetFieldAsInt(_id > 0 ? "needtype2" : "needtype1"); }
            set { Object.SetField(_id > 0 ? "needtype2" : "needtype1", (int)value); }
        }
        [DisplayName("Value")]
        public int Value
        {
            get { return Object.GetFieldAsInt(_id > 0 ? "needvalue2" : "needvalue1"); }
            set { Object.SetField(_id > 0 ? "needvalue2" : "needvalue1", (int)value); }
        }

        public SpellNeed(BasicTableObject o, int i) : base(o)
        {
            _id = i;
        }

        public override string ToString()
            => NeedType == SpellNeedType.None
                ? "<empty>"
                : $"{Value} of {NeedType}";
    }

    
    public class SpellMagic : StructuredField
    {
        private int _id;

        [DisplayName("Check function type")]
        public MagicCheckFunction CheckFuncType
        {
            get { return (MagicCheckFunction)Object.GetFieldAsInt("magiccheckfunctype" + (_id + 1)); }
            set { Object.SetField("magiccheckfunctype" + (_id + 1), (int)value); }
        }
        [DisplayName("Magic base GUID")]
        public int MagicBaseID
        {
            get { return Object.GetFieldAsInt("magicbaseid" + (_id + 1)); }
            set { Object.SetField("magicbaseid" + (_id + 1), value); }
        }
        [DisplayName("Argument[0]")]
        public int Arg0
        {
            get { return Object.GetFieldAsInt("magiccheckarg1" + (_id + 1)); }
            set { Object.SetField("magiccheckarg1" + (_id + 1), value); }
        }
        [DisplayName("Argument[1]")]
        public int Arg1
        {
            get { return Object.GetFieldAsInt("magiccheckarg2" + (_id+1)); }
            set { Object.SetField("magiccheckarg2" + (_id + 1), value); }
        }

        public SpellMagic(BasicTableObject o, int i) : base(o)
        {
            _id = i;
        }

        public override string ToString()
        {
            if (CheckFuncType == MagicCheckFunction.None)
                return MagicBaseID.ToString();
            return $"{MagicBaseID}, checkfunc: {CheckFuncType}({Arg0}, {Arg1})";
        }
    }

}

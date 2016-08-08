using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using Runes.Net.Db;
using Runes.Net.Shared;

namespace RunesDataBase.TableObjects
{
    public class StatObject : BasicVisualTableObject
    {
        public StatObject(BasicObject obj) : base(obj) { }

        [DisplayName("Effects")]
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

        [DisplayName("Rarity level")]
        public StatRarity Rarity
        {
            get { return (StatRarity)DbObject.GetFieldAsUInt("rarity"); }
            set { DbObject.SetField("rarity", (uint)value); }
        }

        [DisplayName("Inherent Value")]
        [Description("??")]
        public int InherentValue
        {
            get { return DbObject.GetFieldAsInt("inherentvalue"); }
            set { DbObject.SetField("inherentvalue", value); }
        }

        [DisplayName("Star Value")]
        public int StarValue
        {
            get { return DbObject.GetFieldAsInt("starvalue"); }
            set { DbObject.SetField("starvalue", value); }
        }

        [DisplayName("Standard ability level")]
        [Description("??")]
        public int StandardAbilitLevel
        {
            get { return DbObject.GetFieldAsInt("standardability_lv"); }
            set { DbObject.SetField("standardability_lv", value); }
        }

        public override Color GetColor()
        {
            switch (Stats.Count(stat=>!stat.IsEmpty))
            {
                case 1:
                    return Color.Lime;
                case 2:
                    return Color.FromArgb(255, 209, 0);
                case 3:
                    return Color.FromArgb(254, 155, 0);
                default:
                    return Color.Red;
            }
        }

        public override string GetDescription()
        {
            return Environment.NewLine+string.Join(Environment.NewLine, Stats.Where(o => !o.IsEmpty));
        }

        public override string GetIconName()
        {
            return "stat";
        }
    }
}

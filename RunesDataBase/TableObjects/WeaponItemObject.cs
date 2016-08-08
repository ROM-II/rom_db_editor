using System.ComponentModel;
using System.Linq;
using Runes.Net.Db;
using Runes.Net.Shared;
using Runes.Net.Shared.Html;

namespace RunesDataBase.TableObjects
{
    public class WeaponItemObject : EquipmentObject
    {
        public WeaponItemObject(BasicObject obj) : base(obj) { }

        [DisplayName("Weapon Type")] [Category("Weapon Properties")]
        public WeaponType Type
        {
            get { return (WeaponType)DbObject.GetFieldAsUInt("weapontype"); }
            set { DbObject.SetField("weapontype", (int)value); }
        }

        [DisplayName("Weapon Model position")] [Category("Weapon Properties")]
        public WeaponPos Pos
        {
            get { return (WeaponPos)DbObject.GetFieldAsUInt("weaponpos"); }
            set { DbObject.SetField("weaponpos", (int)value); }
        }

        [DisplayName("Attack range")] [Category("Weapon Properties")]
        public int AttackRange
        {
            get { return DbObject.GetFieldAsInt("attackrange"); }
            set { DbObject.SetField("attackrange", value); }
        }
        [DisplayName("Attack speed")] [Category("Weapon Properties")]
        public int AttackSpeed
        {
            get { return DbObject.GetFieldAsInt("attackspeed"); }
            set { DbObject.SetField("attackspeed", value); }
        }
        [DisplayName("Damage : Physical")] [Category("Weapon Properties")]
        public int DamagePhys
        {
            get { return DbObject.GetFieldAsInt("ddmg"); }
            set { DbObject.SetField("ddmg", value); }
        }
        [DisplayName("Damage : Magical")]
        [Category("Weapon Properties")]
        public int DamageMag
        {
            get { return DbObject.GetFieldAsInt("dmdmg"); }
            set { DbObject.SetField("dmdmg", value); }
        }

        public override string GetDescription()
        {
            var s = Type + ", level: " + Limits.MinLevel;
            return s;
        }

        [DisplayName("Actual damage : Physical")]
        [Category("Weapon Properties - Calculated")]
        public int ActualDamagePhys
        {
            get
            {
                var field = Attributes.FirstOrDefault(a => a.Type == WearEquipmentType.PhysDamage);
                return field == null ? DamagePhys : field.Value;
            }
        }

        [DisplayName("Actual damage : Magical")]
        [Category("Weapon Properties - Calculated")]
        public int ActualDamageMag
        {
            get
            {
                var field = Attributes.FirstOrDefault(a => a.Type == WearEquipmentType.MagicDamage);
                return field == null ? DamageMag : field.Value;
            }
        }

        [DisplayName("DPS")]
        [Category("Weapon Properties - Calculated")]
        public double ActualDPS
        {
            get
            {
                var delay = AttackSpeed/10.0;
                return ActualDamagePhys/delay;
            }
        }
    }
}

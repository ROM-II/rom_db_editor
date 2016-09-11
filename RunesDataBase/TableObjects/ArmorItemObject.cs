using System.ComponentModel;
using System.Linq;
using Runes.Net.Db;
using Runes.Net.Shared;
using RunesDataBase.Forms;

namespace RunesDataBase.TableObjects
{
    public class ArmorItemObject : EquipmentObject
    {
        public ArmorItemObject(BasicObject obj) : base(obj) { }

        [DisplayName("Armor Type")]
        [Category("Armor Properties")]
        public ArmorType Type
        {
            get { return (ArmorType)DbObject.GetFieldAsUInt("armortype"); }
            set { DbObject.SetField("armortype", (int)value); }
        }

        [DisplayName("Armor Model position")]
        [Category("Armor Properties")]
        public ArmorPos Pos
        {
            get { return (ArmorPos)DbObject.GetFieldAsUInt("armorpos"); }
            set { DbObject.SetField("armorpos", (int)value); }
        }

        
        [DisplayName("Defence : Physical")]
        [Category("Armor Properties")]
        public int DefencePhys
        {
            get { return DbObject.GetFieldAsInt("ddef"); }
            set { DbObject.SetField("ddef", value); }
        }
        [DisplayName("Defence : Magical")]
        [Category("Armor Properties")]
        public int DefenceMag
        {
            get { return DbObject.GetFieldAsInt("dmdef"); }
            set { DbObject.SetField("dmdef", value); }
        }

        public override string GetDescription()
        {
            var s = Type + ", level: " + Limits.MinLevel;
            return s;
        }

        [DisplayName("Actual defence : Physical")]
        [Category("Armor Properties - Calculated")]
        public int ActualDefencePhys
        {
            get
            {
                var field = Attributes.FirstOrDefault(a => a.Type == WearEquipmentType.PhysDefence);
                return DefencePhys + (field?.Value ?? 0);
            }
        }

        [DisplayName("Actual defence : Magical")]
        [Category("Armor Properties - Calculated")]
        public int ActualDefenceMag
        {
            get
            {
                var field = Attributes.FirstOrDefault(a => a.Type == WearEquipmentType.MagicDefence);
                return DefenceMag + (field?.Value ?? 0);
            }
        }

        public override string ToString()
            => base.ToString() + $" [P: {ActualDefencePhys:F0}; M: {ActualDefenceMag:F0}]";
    }
}

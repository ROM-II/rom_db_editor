using System.ComponentModel;
using System.Drawing;
using System.Linq;
using Runes.Net.Db;
using Runes.Net.Shared;

namespace RunesDataBase.TableObjects
{
    public class ShopObject : BasicTableObject
    {
        public ShopObject(BasicObject obj) : base(obj) { }
        public override Color GetColor() { return Color.CadetBlue; }
        public override string GetDescription()
        {
            return "Shop object";
        }
        public override string GetIconName()
        {
            return "shop";
        }

        [DisplayName("Buy rate")] [Category("Shop Properties - Basic")]
        public int RateBuy
        {
            get { return DbObject.GetFieldAsInt("buyrate"); }
            set { DbObject.SetField("buyrate", value); }
        }
        [DisplayName("Sell rate")] [Category("Shop Properties - Basic")]
        public int RateSell
        {
            get { return DbObject.GetFieldAsInt("sellrate"); }
            set { DbObject.SetField("sellrate", value); }
        }
        [DisplayName("Repairs Equipment?")] [Category("Shop Properties - Basic")]
        public bool RepairsEquipment
        {
            get { return DbObject.GetFieldAsInt("weaponrepair") != 0; }
            set { DbObject.SetField("weaponrepair", value ? 1 : 0); }
        }
        [Category("Shop Properties - Basic")]
        public SellItem[] Items
        {
            get
            {
                var a = new SellItem[30];
                foreach (var i in Enumerable.Range(0, 30))
                    a[i] = new SellItem(this, i);
                return a;
            }
        }
    }

    public class SellItem : StructuredField
    {
        private readonly string _ids;

        public SellItem(BasicTableObject o, int i) : base(o)
        {
            _ids = (i + 1).ToString();
        }
        [DisplayName("Item GUID")]
        public uint ItemGUID
        {
            get { return Object.GetFieldAsUInt("sellitemid" + _ids); }
            set { Object.SetField("sellitemid" + _ids, value); }
        }
        [DisplayName("Max items")]
        public uint MaxItems
        {
            get { return Object.GetFieldAsUInt("sellitemmax" + _ids); }
            set { Object.SetField("sellitemmax" + _ids, value); }
        }
        public int Produce
        {
            get { return Object.GetFieldAsInt("sellitemporduce" + _ids); }
            set { Object.SetField("sellitemporduce" + _ids, value); }
        }

        [DisplayName("1. Currency")]
        public PriceType CostType1
        {
            get { return (PriceType)Object.GetFieldAsInt("costtype1_" + _ids); }
            set { Object.SetField("costtype1_" + _ids, (int)value); }
        }
        [DisplayName("1. Value")]
        public int Cost1
        {
            get { return Object.GetFieldAsInt("sellcost1_" + _ids); }
            set { Object.SetField("sellcost1_" + _ids, value); }
        }
        [DisplayName("2. Currency")]
        public PriceType CostType2
        {
            get { return (PriceType)Object.GetFieldAsInt("costtype2_" + _ids); }
            set { Object.SetField("costtype2_" + _ids, (int)value); }
        }
        [DisplayName("2. Value")]
        public int Cost2
        {
            get { return Object.GetFieldAsInt("sellcost2_" + _ids); }
            set { Object.SetField("sellcost2_" + _ids, value); }
        }
        [Browsable(false)]
        public bool IsEmpty {
            get { return ItemGUID == 0; }
        }
        [Browsable(false)]
        public bool IsEmptyCost1
        {
            get { return CostType1 == PriceType.None || ActualCost1 == 0; }
        }
        [Browsable(false)]
        public bool IsEmptyCost2
        {
            get { return CostType2 == PriceType.None || ActualCost2 == 0; }
        }

        [DisplayName("1. Actual cost (?)")]
        public int ActualCost1
        {
            get
            {
                if (IsEmpty || CostType1 == PriceType.None)
                    return 0;
                var o = TableObject.OwnerTable.Db[ItemGUID];
                var item = o as ItemObject;
                if (item == null)
                    return Cost1;
                var k = ((ShopObject)TableObject).RateSell / 10.0;
                return (int)((Cost1 + (item.PriceType == CostType1 ? (item.Cost) : 0)) * k);
            }
        }
        [DisplayName("2. Actual cost (?)")]
        public int ActualCost2
        {
            get
            {
                if (IsEmpty || CostType2 == PriceType.None)
                    return 0;
                var o = TableObject.OwnerTable.Db[ItemGUID];
                var item = o as ItemObject;
                if (item == null)
                    return Cost2;
                var k = ((ShopObject)TableObject).RateSell / 10.0;
                return (int)((Cost2 + (item.PriceType == CostType2 ? (item.Cost) : 0)) * k);
            }
        }

        public override string ToString()
        {
            if (IsEmpty) return base.ToString();
            var item = TableObject.OwnerTable.Db.GetNameForGuid(ItemGUID) ?? ItemGUID.ToString();
            var c1 = IsEmptyCost1 ? "" : string.Format("{0} of {1}", ActualCost1, CostType1);
            var c2 = IsEmptyCost2 ? "" : string.Format("{0} of {1}", ActualCost2, CostType2);
            var c3 = "free(?)";
            if (string.IsNullOrWhiteSpace(c1))
                c3 = c2;
            else if (string.IsNullOrWhiteSpace(c2) || CostType2==CostType1)
                c3 = c1;
            else
                c3 = c1 + ", " + c2;
            return string.Format("[{0}] for {1}", item, c3 );
        }
    }
}

using System.ComponentModel;
using System.Linq;
using Runes.Net.Db;

namespace RunesDataBase.TableObjects
{
    public class EquipmentObject : ItemObject
    {
        public EquipmentObject(BasicObject obj) : base(obj) { }

        [DisplayName("Source recipe GUID")] [Category("Equipment Properties")]
        public uint SourceRecipeId
        {
            get { return DbObject.GetFieldAsUInt("srcrecipe"); }
            set { DbObject.SetField("srcrecipe", value); }
        }

        [DisplayName("Max stats count")] [Category("Equipment Properties")]
        public uint MaxAttrCount
        {
            get { return DbObject.GetFieldAsUInt("maxattrcount"); }
            set { DbObject.SetField("maxattrcount", value); }
        }

        [DisplayName("Max durability")] [Category("Equipment Properties")]
        public uint MaxDura
        {
            get { return DbObject.GetFieldAsUInt("durable"); }
            set { DbObject.SetField("durable", value); }
        }

        /*[DisplayName("Tier")] [Category("Equipment Properties")]
        public uint Tier
        {
            get { return DbObject.GetFieldAsUInt(0x0178); }
            set { DbObject.SetField(0x0178, value); }
        }*/

        [DisplayName("Refine Level")] [Category("Equipment Properties")]
        public uint RefineLvl
        {
            get { return DbObject.GetFieldAsUInt("refinelv"); }
            set { DbObject.SetField("refinelv", value); }
        }
        [DisplayName("Is Max Durable fixed")]
        [Category("Equipment Properties")]
        public bool IsMaxDurableFixed
        {
            get { return DbObject.GetFieldAsUInt(1141) > 0; }
            set { DbObject.SetField(1141, value ? 1 : 0); }
        }
    }

    public class StatDrop : StructuredField
    {
        [Browsable(false)]
        public bool IsEmpty => StatID < 1 || Rate < 1;

        private readonly int _id;
        public StatDrop(BasicTableObject o, int i) : base(o) { _id = i; }
        public uint StatID
        {
            get { return Object.GetFieldAsUInt("dropability" + (_id + 1)); }
            set { Object.SetField("dropability" + (_id + 1), value); }
        }
        public uint Rate
        {
            get { return Object.GetFieldAsUInt("dropabilityrate" + (_id + 1)); }
            set { Object.SetField("dropabilityrate" + (_id + 1), value); }
        }
        public override string ToString()
        {
            if (IsEmpty)
                return base.ToString();
            var item = TableObject.OwnerTable.Db.GetNameForGuid(StatID) ?? StatID.ToString();
            return $"[{item}] - {Rate/100000.0:P3}";
        }
    }
}

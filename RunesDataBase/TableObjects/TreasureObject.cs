using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using Runes.Net.Db;
using Runes.Net.Shared;
using Runes.Net.Shared.Html;

namespace RunesDataBase.TableObjects
{
    public class TreasureObject : BasicTableObject
    {
        public uint ItemCount
        {
            get { return DbObject.GetFieldAsUInt("itemcount"); }
            set
            {
                if (value > 100) value = 100;
                DbObject.SetField("itemcount", value);
            }
        }
        public TreasureItem[] Items
        {
            get
            {
                var a = new TreasureItem[ItemCount];
                for (var i = 0; i < ItemCount; ++i)
                    a[i] = new TreasureItem(this, i);
                return a;
            }
        }
        public int NeedDLv
        {
            get { return DbObject.GetFieldAsInt("needdlv"); }
            set { DbObject.SetField("needdlv", value); }
        }
        public string LuaCheckScript
        {
            get { return DbObject.GetFieldAsStaticString("luacheckscript", 64); }
            set { DbObject.SetField("luacheckscript", value, 64); }
        }

        public TreasureObject(BasicObject obj) : base(obj) { }
        public override string GetDescription()
        {
            return
                $"Treasure of {ItemCount} items. Contents:\r\n\t{string.Join(";\r\n\t", Items.Where(i => !i.IsEmpty))}";
        }
        public override Color GetColor()
        {
            return Color.FromArgb(125, 125, 250);
        }
        public override string GetIconName() { return "treasure"; }
    }

    public class TreasureItem : StructuredField, IDescribableHtml
    {
        private int _j;
        public TreasureItem(BasicTableObject o, int i) : base(o)
        {
            _j = i + 1;
        }
        
        public uint ItemGUID
        {
            get { return Object.GetFieldAsUInt("treasureitem" + _j); }
            set { Object.SetField("treasureitem" + _j, value); }
        }
        public int Rate
        {
            get { return Object.GetFieldAsInt("treasurecount" + _j); }
            set { Object.SetField("treasurecount" + _j, value); }
        }
        public int Count
        {
            get { return Object.GetFieldAsInt("treasuredropcount" + _j); }
            set { Object.SetField("treasuredropcount" + _j, value); }
        }

        [Browsable(false)]
        public bool IsEmpty => ItemGUID < 1 || Rate < 1 || Count < 1;

        public override string ToString()
        {
            if (IsEmpty)
                return base.ToString();
            var item = TableObject.OwnerTable.Db.GetNameForGuid(ItemGUID) ?? ItemGUID.ToString();
            item = "[" + item + "]";

            return Count > 1 
                ? $"{item} x{Count} - {Rate/100000.0:P3}"
                : $"{item} - {Rate/100000.0:P3}";
        }

        public string ToHtmlString()
        {
            if (IsEmpty)
                return base.ToString();
            var db = TableObject.OwnerTable.Db;
            var item = db.GetNameForGuid(ItemGUID) ?? ItemGUID.ToString();
            var obj = db[ItemGUID];
            var color = obj?.GetColor() ?? Color.White;
            item = ("[" + item + "]").HtmlFont(color);

            return Count > 1
                ? $"{item} x{Count} - {Rate/100000.0:P3}"
                : $"{item} - {Rate/100000.0:P3}";
        }
    }
}

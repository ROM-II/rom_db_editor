using System.ComponentModel;
using Runes.Net.Db;

namespace RunesDataBase.TableObjects
{
    public class BasicVisualTableObject : BasicTableObject
    {
        [Category("Object Properties")]
        [DisplayName("Image/Model")]
        [Description("A model for this NPC (imageobject guid)")]
        public uint Image
        {
            get { return DbObject.GetFieldAsUInt("imageid"); }
            set { DbObject.SetField("imageid", value); }
        }

        public BasicVisualTableObject(BasicObject obj) : base(obj) { }
    }
}

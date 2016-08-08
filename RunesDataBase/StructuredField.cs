using System.ComponentModel;
using Runes.Net.Db;
using RunesDataBase.TableObjects;

namespace RunesDataBase
{
    
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class StructuredField
    {
        [Browsable(false)]
        protected BasicTableObject TableObject { get; private set; }
        [Browsable(false)]
        protected BasicObject Object { get; private set; }
        public StructuredField(BasicTableObject o)
        {
            TableObject = o;
            Object = o.DbObject;
        }
        

        public override string ToString()
        {
            return "<empty>";
        }
    }
}

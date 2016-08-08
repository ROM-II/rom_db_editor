using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Runes.Net.Db;
using Runes.Net.Shared.Html;

namespace RunesDataBase.TableObjects
{
    public class ZoneObject : BasicTableObject
    {
        public ZoneObject(BasicObject obj) : base(obj)
        {
        }



        [Category("Zone")]
        [DisplayName("WDB")]
        public string WDB
        {
            get { return DbObject.GetFieldAsStaticString("mapfile", 40); }
            set { DbObject.SetField("mapfile", value, 40); }
        }

        [Category("Zone")]
        [DisplayName("Max players")]
        public int MaxPlayersPerRoom
        {
            get { return DbObject.GetFieldAsInt("roomplayercount"); }
            set { DbObject.SetField("roomplayercount", value); }
        }

        public override string GetDescription()
        {
            return ("" + ShortNote);
        }
        public override Color GetColor()
        {
            return Color.Yellow;
        }
        public override string GetIconName() { return "zone"; }
    }
}

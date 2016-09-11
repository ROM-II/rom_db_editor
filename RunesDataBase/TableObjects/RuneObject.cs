using System.ComponentModel;
using Runes.Net.Db;
using Runes.Net.Shared;

namespace RunesDataBase.TableObjects
{
    [TypeConverter(typeof(EntitySelectConverter<RuneObject>))]
    public class RuneObject : ItemObject
    {
        public RuneObject(BasicObject obj) : base(obj) { }

        [Browsable(false)]
        public new StatDrop[] Stats => base.Stats;

        [Browsable(false)]
        public new string SrvScript => base.SrvScript;

        [Browsable(false)]
        public new string CliScript => base.CliScript;

        [Browsable(false)]
        public new string CheckScript => base.CheckScript;

        [Browsable(false)]
        public new ItemUseType UseType => base.UseType;
    }
}

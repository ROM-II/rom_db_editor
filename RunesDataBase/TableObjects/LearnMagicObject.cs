using System.ComponentModel;
using Runes.Net.Db;
using System.Collections.Generic;
using System.Linq;
using Runes.Net.Shared;

namespace RunesDataBase.TableObjects
{
    public class LearnMagicObject : BasicTableObject
    {
        public LearnMagicObject(BasicObject obj) : base(obj) { }

        public CharacterClass CharClass => (CharacterClass) (Guid % 100);

        public int SpMagicCount
        {
            get { return DbObject.GetFieldAsInt("spmagiccount"); }
            set { DbObject.SetField("spmagiccount", value); }
        }

        public int NormalMagicCount
        {
            get { return DbObject.GetFieldAsInt("normalmagiccount"); }
            set { DbObject.SetField("normalmagiccount", value); }
        }

        public LearnMagicElement[] SpMagic
        {
            get
            {
                var a = new LearnMagicElement[200];
                for (var i = 0; i < 200; ++i)
                    a[i] = new LearnMagicElement(this, i, 0x94);
                return a;
            }
        }

        public string SpMagicFreeSlots
            => string.Join(", ", Enumerable.Range(0, 200)
                .Except(SpMagic
                    .Where(x => !x.IsEmpty)
                    .Select(x => (int) x.Slot)
                    .Distinct())
                );
        public LearnMagicElement[] NormalMagic
        {
            get
            {
                var a = new LearnMagicElement[200];
                for (var i = 0; i < 200; ++i)
                    a[i] = new LearnMagicElement(this, i, 0x1358);
                return a;
            }
        }

        public string NormalMagicFreeSlots
            => string.Join(", ", Enumerable.Range(0, 200)
                .Except(NormalMagic
                    .Where(x => !x.IsEmpty)
                    .Select(x => (int) x.Slot)
                    .Distinct())
                );

        public override string GetDescription()
            => $"[LearnMagic for {CharClass} (#{Guid})]";
    }


    public class LearnMagicElement : StructuredField
    {
        [Browsable(false)]
        public bool IsEmpty => MagicId < 1;

        private readonly int _id;
        private readonly uint _offset;
        public LearnMagicElement(BasicTableObject o, int id, uint offset) : base(o)
        {
            _id = id;
            _offset = offset;
        }

        private uint this[int id]
        {
            get { return Object.GetFieldAsUInt((uint) (_offset + _id*4*6 + id*4)); }
            set { Object.SetField((uint) (_offset + _id*4*6 + id*4), value); }
        }

        public uint MagicId
        {
            get { return this[0]; }
            set { this[0] = value; }
        }
        public uint MinLevel
        {
            get { return this[1]; }
            set { this[1] = value; }
        }
        public uint ReqFlag
        {
            get { return this[2]; }
            set { this[2] = value; }
        }
        public uint ReqSkill
        {
            get { return this[3]; }
            set { this[3] = value; }
        }
        public uint ReqUnknown0
        {
            get { return this[4]; }
            set { this[4] = value; }
        }
        public uint Slot
        {
            get { return this[5]/0x10000; }
            set { this[5] = value*0x10000; }
        }

        private string GetName(uint id)
            => TableObject.OwnerTable.Db.GetNameForGuidWithGuid(id);
        public override string ToString()
        {
            if (IsEmpty)
                return base.ToString();
            var item = GetName(MagicId);
            var requirements = new List<string>();
            if (ReqFlag > 0)
                requirements.Add($"flag({GetName(ReqFlag)})");
            if (ReqSkill > 0)
                requirements.Add($"skill({GetName(ReqSkill)})");
            if (ReqUnknown0 > 0)
                requirements.Add($"???[0]({GetName(ReqUnknown0)})");

            return $"[{item}] at {GetName(Slot)}" + (requirements.Any() ? ", requires " + string.Join(", ", requirements) : "");
        }
    }
}

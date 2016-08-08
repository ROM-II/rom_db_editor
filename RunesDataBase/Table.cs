
using System;
using System.Collections.Generic;
using System.Linq;
using Runes.Net.Db;
using RunesDataBase.TableObjects;

namespace RunesDataBase
{
    public class Table
    {
        public DataBase Db { get; set; }
        public uint GuidPrefix { get; set; }
        public DbFile File { get; private set; }
        public Dictionary<uint, BasicTableObject> Objects { get; private set; }
        private List<uint> NewObjects { get; set; }
        public string FileName { get { return File.FileName; } }

        public Table(DbFile file, DataBase db)
        {
            Db = db;
            Objects = new Dictionary<uint, BasicTableObject>();
            NewObjects = new List<uint>();
            File = file;
            foreach (var obj in File.Rows)
            {
                var guid = obj.Guid;
                if (guid < 1)
                    throw new Exception("Not a table");
                Objects[guid] = BasicTableObject.GenerateObject(obj);
                Objects[guid].OwnerTable = this;
            }
        }

        public void FixChanges()
        {
            foreach (var guid in NewObjects)
            {
                File.Rows.Add(Objects[guid].DbObject);
            }
        }

        public BasicTableObject CloneObject(uint guid)
        {
            uint newGuid;
            if (!GenerateNewGuid(out newGuid, GuidPrefix == 750000))
                return null;
            var template = Objects[guid];
            var obj = new BasicObject(template.DbObject.FieldsProvider, File);
            var bts = template.DbObject.ToBytes().Select(b => b).ToArray();
            obj.FromBytes(bts);
            obj.SetField("guid", newGuid);
            File.Rows.Add(obj);
            File.ModifiedFlag = true;
            NewObjects.Add(newGuid);
            var tobj = BasicTableObject.GenerateObject(obj);
            Objects[newGuid] = tobj;
            tobj.OwnerTable = this;
            return tobj;
        }

        private bool GenerateNewGuid(out uint guid, bool zone = false)
        {
            for (guid = (uint) (GuidPrefix + (zone ? 999 : 9999)); guid >= GuidPrefix; --guid)
                if (!Objects.ContainsKey(guid))
                    return true;
            if (zone) return false;
            for (guid = (uint)(10 * GuidPrefix); guid < (20 * GuidPrefix); ++guid)
                if (!Objects.ContainsKey(guid))
                    return true;
            return false;
        }

        public BasicTableObject this[uint guid]
        {
            get
            {
                BasicTableObject o;
                return Objects.TryGetValue(guid, out o) ? o : null;
            }
        }

        public override string ToString()
        {
            return "Table: " + FileName;
        }
    }
}

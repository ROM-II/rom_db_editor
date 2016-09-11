using System;
using System.Collections.Generic;
using System.Linq;
using RunesDataBase.Forms;
using RunesDataBase.TableObjects;

namespace RunesDataBase
{

    public partial class DataBase
    {
        public DataBase()
        {
            Cache = new DataBaseCache(this);
        }

        public DataBaseCache Cache { get; }
    }
    public class DataBaseCache
    {
        public DataBaseCache(DataBase db)
        {
            Db = db;
            Items = new Lazy<IDictionary<string, ItemObject>>(
                () => MainForm.DbApi.Items
                    .ToDictionary(x => x.Guid.ToString(), x => x));
            Stats = new Lazy<IDictionary<string, StatObject>>(
                () => MainForm.DbApi.Stats
                    .ToDictionary(x => x.Guid.ToString(), x => x));
            Runes = new Lazy<IDictionary<string, RuneObject>>(
                () => MainForm.DbApi.Runes
                    .ToDictionary(x => x.Guid.ToString(), x => x));
        }

        private DataBase Db { get; }
        public Lazy<IDictionary<string, ItemObject>> Items { get; }
        public Lazy<IDictionary<string, StatObject>> Stats { get; }
        public Lazy<IDictionary<string, RuneObject>> Runes { get; }
    }
}

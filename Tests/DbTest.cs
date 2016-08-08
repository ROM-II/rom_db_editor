using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Runes.Net.Db;
using Runes.Net.Db.String.db;

namespace Tests
{
    [TestClass]
    public class DbTest
    {
        [TestMethod]
        public void BasicTest()
        {
            var db = new DbFile();
            db.LoadFromFile(@"c:\runewaker\runes of magic\data\weaponobject.db");
            var dict = DataFieldsProvider.ReadFromFile(@"c:\runewaker\tools\fields.csv");
            var fieldsProv = dict[@"data\weaponobject.db"];
        }

        [TestMethod]
        public void TestStrings()
        {
            var stringEnEu = new StringsDataBase();
            stringEnEu.LoadFromFile(@"c:\runewaker\resource\fdb\data\string_eneu.db");
            
            Assert.IsNotNull(stringEnEu);
        }
    }
}

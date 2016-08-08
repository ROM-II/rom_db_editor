using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Runes.Net.Fdb;

namespace Tests
{
    [TestClass]
    public class FdbTest1
    {
        [TestMethod]
        public void TestLoad()
        {
            var fdb = new Fdb();
            fdb.LoadFromFile(@"c:\runewaker\resource\fdb\data.fdb");
            Assert.AreEqual(true, fdb.IsOpened);
            Assert.AreEqual(386, fdb.Entries.Count);
            fdb.Close();
            Assert.AreEqual(false, fdb.IsOpened);
        }
        [TestMethod]
        public void TestByName1()
        {
            var fdb = new Fdb();
            fdb.LoadFromFile(@"c:\runewaker\resource\fdb\data.fdb");

            Assert.IsNotNull(fdb[@"data\treasureobject.db"]);
            Assert.IsNotNull(fdb[@"data\magicobject.db"]);
            var db = fdb[@"data\magiccollectobject.db"];
            Assert.IsNotNull(db);
            Assert.AreEqual(db.ActualDataSize, (uint)11101187);

            if (fdb.ListFilesInDir().Any())
                throw new AssertFailedException();

            if (!fdb.ListFilesInDir("data").Any())
                throw new AssertFailedException();
            if (!fdb.ListFilesInDir("cliluascript").Any())
                throw new AssertFailedException();

            var dirs = fdb.ListDirectories().ToArray();

            if (dirs.Length != 2)
                throw new AssertFailedException();
            if (!dirs.Contains("data"))
                throw new AssertFailedException();
            if (!dirs.Contains("cliluascript"))
                throw new AssertFailedException();

            fdb.Close();
        }
    }
}

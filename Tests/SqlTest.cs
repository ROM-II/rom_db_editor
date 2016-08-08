using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RunesDataBase.Sql;

namespace Tests
{
    [TestClass]
    public class SqlTest
    {
        [TestMethod]
        public void TestConnect()
        {
            var sql = new RomSqlConnection
            {
                Login = "romuser",
                Password = "A0b1c2d3e4",
                ServerName = "192.168.1.3"
            };
            Assert.IsTrue(sql.SetUp());

            var records = sql.ObtainAll().ToArray();
            foreach (var record in records)
            {
                Console.WriteLine(record);
            }

            sql.Connection.Close();
        }
    }
}

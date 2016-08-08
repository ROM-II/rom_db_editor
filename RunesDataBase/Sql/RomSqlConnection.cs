using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace RunesDataBase.Sql
{
    public class RomSqlConnection
    {
        public string ServerName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string DBName = "ROM_ImportDB";
        public SqlConnection Connection { get; private set; }
        public Exception LastException { get; private set; }

        public bool SetUp()
        {
            try
            {
                var cs = new SqlConnectionStringBuilder
                {
                    DataSource = ServerName,
                    Password = Password,
                    UserID = Login,
                    NetworkLibrary = "dbmssocn"
                };
                Connection = new SqlConnection(cs.ConnectionString);
                /*string.Format(@"Data Source={0};
                            User ID={2};
                            Password={3};
                            Initial Catalog={1};
                            Integrated Security=True", ServerName, DBName, Login, Password)*/
                Connection.Open();
            }
            catch (Exception ex)
            {
                LastException = ex;
                return false;
            }

            return true;
        }

        public IEnumerable<ShopRecord> ObtainAll()
        {
            var cmd = new SqlCommand("select * from [ROM_ImportDB].[dbo].[NewShopInfo]", Connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var r = new ShopRecord();
                foreach (var p in r.GetType().GetProperties())
                {
                    var value = reader[p.Name];
                    p.SetValue(r, value);
                }
                yield return r;
            }
        }
    }
}

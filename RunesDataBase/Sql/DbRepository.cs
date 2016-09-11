using System.Data.SqlClient;
using System.Linq;
using Runes.Net.Shared;
using RunesDataBase.Forms;
using RunesDataBase.Sql.Account;
using RunesDataBase.Sql.World;
using RunesDataBase.TableObjects;

namespace RunesDataBase.Sql
{
    public class DbRepository
    {
        public static DbRepository Default { get; } = new DbRepository();
        public SqlConnection RomAccountConnection { get; private set; }
        public SqlConnection RomImportConnection { get; private set; }
        public SqlConnection RomWorldConnection { get; private set; }
        public SqlConnection RomGlobalConnection { get; private set; }

        public AccountDataContext AccountDataContext { get; private set; }
        public WorldDataContext WorldDataContext { get; private set; }

        public void Configure(Config cfg)
        {
            var globalIni = new IniFile(cfg.GlobalIniPath);
            RomAccountConnection = new SqlConnection(
                new SqlConnectionStringBuilder
                {
                    DataSource = globalIni["BOOT", "Acc_DBServer"],
                    InitialCatalog = globalIni["BOOT", "Acc_DataBase"],
                    UserID = globalIni["BOOT", "Acc_Account"],
                    Password = RomEncoding.DecodePassword(globalIni["BOOT", "Acc_Password"], globalIni["BOOT", "Acc_Account"])
                }.ConnectionString);
            AccountDataContext = new AccountDataContext(RomAccountConnection);

            RomImportConnection = new SqlConnection(
                new SqlConnectionStringBuilder
                {
                    DataSource = globalIni["BOOT", "Import_DBServer"],
                    InitialCatalog = globalIni["BOOT", "Import_DataBase"],
                    UserID = globalIni["BOOT", "Import_Account"],
                    Password = RomEncoding.DecodePassword(globalIni["BOOT", "Import_Password"], globalIni["BOOT", "Import_Account"])
                }.ConnectionString);

            RomWorldConnection = new SqlConnection(
                new SqlConnectionStringBuilder
                {
                    DataSource = globalIni["BOOT", "Game_DBServer"],
                    InitialCatalog = globalIni["BOOT", "Game_DataBase"],
                    UserID = globalIni["BOOT", "Game_Account"],
                    Password = RomEncoding.DecodePassword(globalIni["BOOT", "Game_Password"], globalIni["BOOT", "Game_Account"])
                }.ConnectionString);
            WorldDataContext = new WorldDataContext(RomWorldConnection);

            RomGlobalConnection = new SqlConnection(
                new SqlConnectionStringBuilder
                {
                    DataSource = globalIni["BOOT", "Global_DBServer"],
                    InitialCatalog = globalIni["BOOT", "Global_DataBase"],
                    UserID = globalIni["BOOT", "Global_Account"],
                    Password = RomEncoding.DecodePassword(globalIni["BOOT", "Global_Password"], globalIni["BOOT", "Global_Account"])
                }.ConnectionString);


            InitializeStandardValues();
        }

        public void InitializeStandardValues()
        {
            EntitySelectConverter<RoleData>.StandardValues =
                () => WorldDataContext.RoleData
                    .Select(x => x).ToDictionary(x => x.ToString(), x => x);

            EntitySelectConverter<ItemObject>.SetStringConverter(GuidExtractor.Instance);
            EntitySelectConverter<ItemObject>.StandardValues =
                () => MainForm.Database?.Cache.Items.Value;

            EntitySelectConverter<StatObject>.SetStringConverter(GuidExtractor.Instance);
            EntitySelectConverter<StatObject>.StandardValues =
                () => MainForm.Database?.Cache.Stats.Value;
        }
    }
}

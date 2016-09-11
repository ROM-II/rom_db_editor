using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RunesDataBase.Sql;

namespace RunesDataBase.Forms
{
    public partial class NewAccount : Form
    {
        public NewAccount()
        {
            InitializeComponent();
        }

        public string Login => uiLogin.Text;
        private string Password => uiPassword.Text;

        private void uiButtonRegister_Click(object sender, EventArgs e)
        {
            uiLogin.Text = uiLogin.Text.ToLower();
            if (!DoRegister())
                return;

            DialogResult = DialogResult.OK;
        }

        private bool DoRegister()
        {
            try
            {
                DbRepository.Default.RomAccountConnection
                    .RunCommand("INSERT INTO [ROM_Account].[dbo].[PlayerAccount] " +
                                "([Account_ID],[Password],[IsMd5Password],[IsAutoConvertMd5]) " +
                                "VALUES (@login, @password, 0, 1)",
                        new Dictionary<string, object>{
                            {"@login", Login},
                            {"@password", Password}
                        });

            }
            catch (Exception ex)
            {
                MainForm.Instance.Log.WriteLine($"Exception on {nameof(DoRegister)} - {ex}");
                MessageBox.Show($"Failed to register account\r\n{ex}", "Error");
#if DEBUG
                throw;
#endif
                return false;
            }
            return true;
        }

        public static string Call()
        {
            var f =new NewAccount();
            return f.ShowDialog() != DialogResult.OK ? null : f.Login;
        }

        private void uiLogin_TextChanged(object sender, EventArgs e)
        {
        }
    }
}

using System;
using System.Linq;
using System.Windows.Forms;
using RunesDataBase.Sql;

namespace RunesDataBase.Forms
{
    public partial class AdminPanel : Form
    {
        public static AdminPanel Instance { get; private set; }
        public AdminPanel()
        {
            InitializeComponent();
        }

        public static void Call()
        {
            if (Instance != null)
            {
                Instance.Activate();
                return;
            }

            Instance = new AdminPanel();
            Instance.Show();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            AccountBindingSource.DataSource = DbRepository.Default.AccountDataContext.PlayerAccount.Select(x => x);
            uiAccTable.DataSource = AccountBindingSource;
            uiMailProps.SelectedObject = MailProps;
        }

        private void AdminPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Instance == this)
                Instance = null;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var login = NewAccount.Call();
            if (string.IsNullOrEmpty(login))
                return;
            uiAccTable.EndEdit();
            uiAccTable.Refresh();
        }

        private void uiAccRefreshButton_Click(object sender, EventArgs e)
        {
            AccountBindingSource.DataSource = DbRepository.Default.AccountDataContext.PlayerAccount.Select(x => x);
            uiAccTable.DataSource = AccountBindingSource;
        }

        private void uiAccSubmitButton_Click(object sender, EventArgs e)
        {
            uiAccTable.EndEdit();
            DbRepository.Default.AccountDataContext.SubmitChanges();
            uiAccRefreshButton.PerformClick();
        }

        private AdminMailingProps MailProps { get; } = new AdminMailingProps();

        private void uiMailSend_Click(object sender, EventArgs e)
        {
            MailProps.Send();
        }
    }
}

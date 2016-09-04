using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Runes.Net.Db.String.db;

namespace RunesDataBase.Forms
{
    public partial class AddStringForm : Form
    {
        public string Key
        {
            get { return uiKey.Text; }
            set { uiKey.Text = value; }
        }
        public IEnumerable<StringsDataBase> Languages
        {
            get { return uiLanguages.CheckedItems.Cast<StringsDataBase>(); }
            set
            {
                uiLanguages.Items.Clear();
                foreach (var sdb in value)
                    uiLanguages.Items.Add(sdb);
            }
        }

        public AddStringForm()
        {
            InitializeComponent();
        }

        private void AddStringForm_Load(object sender, EventArgs e)
        {
            //DialogResult = DialogResult.None;
        }

        private void uiButtonAccept_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void uiButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

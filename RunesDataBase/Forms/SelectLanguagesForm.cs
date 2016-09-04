using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Runes.Net.Fdb;

namespace RunesDataBase.Forms
{
    public partial class SelectLanguagesForm : Form
    {
        public Fdb Fdb { get; set; }
        public List<string> Languages { get; set; }

        public SelectLanguagesForm()
        {
            InitializeComponent();
        }

        private void SelectLanguagesForm_Load(object sender, EventArgs ea)
        {
            if (Fdb == null)
            {
                Close();
                return;
            }
            uiLanguages.Items.Clear();
            foreach (var entry in Fdb.Entries.Where(e => e.FileName.StartsWith(@"data\string_") && e.FileName.EndsWith(@".db")))
            {
                uiLanguages.Items.Add(entry);
            }
        }

        private void uiLanguages_SelectedValueChanged(object sender, EventArgs e)
        {
        }

        private void uiOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Languages = uiLanguages.CheckedIndices.Cast<int>().Select(i => ((FileEntry) uiLanguages.Items[i]).FileName).ToList();
        }
    }
}

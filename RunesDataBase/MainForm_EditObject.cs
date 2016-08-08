using System;
using System.Windows.Forms;
using Runes.Net.Db;
using RunesDataBase.TableObjects;

namespace RunesDataBase
{
    partial class MainForm
    {
        public void NavigateToObjects(TableObjectEditLink link)
        {
            SelectTab(uiTabEditObject);
            userChanges = false;
            uiEditObject_AddTitleString.Enabled = link.Object.Title == null;
            uiEditObject_AddShortNote.Enabled = link.Object.ShortNote == null;
            uiObjectProps.SelectedObject = link.Object;
            if (!(SelectedObject is NpcObject))
                uiEditObject_AddTitleString.Enabled = false;
            userChanges = true;
        }

        private void uiEditObject_CopyObject_Click(object sender, EventArgs e)
        {
            var newObj = database.GenerateNewTableObject(SelectedObject);
            if (newObj == null)
            {
                MessageBox.Show("Failed to create new object!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            userChanges = false;
            uiObjectProps.SelectedObject = newObj;
            userChanges = true;
        }
        private BasicTableObject SelectedObject { get { return ((BasicTableObject)uiObjectProps.SelectedObject); } }
        private void uiEditObject_AddTitleString_Click(object sender, EventArgs e)
        {
            if (AddNewString("Sys" + SelectedObject.Guid + "_titlename"))
                uiEditObject_AddTitleString.Enabled = false;
        }

        private void uiEditObject_AddShortNote_Click(object sender, EventArgs e)
        {
            if (AddNewString("Sys" + SelectedObject.Guid + "_shortnote"))
                uiEditObject_AddShortNote.Enabled = false;
        }
    }
}

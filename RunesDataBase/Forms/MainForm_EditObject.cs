using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RunesDataBase.TableObjects;

namespace RunesDataBase.Forms
{
    partial class MainForm
    {
        public static Dictionary<BasicTableObject, EditObjectForm> OpenedEditObjectWindows { get; }
            = new Dictionary<BasicTableObject, EditObjectForm>();

        public static void NavigateToObjects(TableObjectEditLink link)
        {
            NavigateToObjects(link.Object);

            /*
            SelectTab(uiTabEditObject);
            userChanges = false;
            uiEditObject_AddTitleString.Enabled = link.Object.Title == null;
            uiEditObject_AddShortNote.Enabled = link.Object.ShortNote == null;
            uiObjectProps.SelectedObject = link.Object;
            if (!(SelectedObject is NpcObject))
                uiEditObject_AddTitleString.Enabled = false;
            userChanges = true;*/
        }

        public static void NavigateToObjects(BasicTableObject obj)
        {
            EditObjectForm form;
            if (OpenedEditObjectWindows.TryGetValue(obj, out form))
            {
                form.Activate();
                return;
            }

            form = new EditObjectForm(obj);
            OpenedEditObjectWindows.Add(obj, form);
            form.Show();
        }

        private void uiEditObject_CopyObject_Click(object sender, EventArgs e)
        {
            var newObj = Database.GenerateNewTableObject(SelectedObject);
            if (newObj == null)
            {
                MessageBox.Show("Failed to create new object!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            userChanges = false;
            uiObjectProps.SelectedObject = newObj;
            userChanges = true;
        }
        private BasicTableObject SelectedObject 
            => uiObjectProps.SelectedObject as BasicTableObject;

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

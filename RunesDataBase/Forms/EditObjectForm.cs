using System;
using System.Diagnostics;
using System.Windows.Forms;
using RunesDataBase.TableObjects;
using RunesDataBase.Utils;

namespace RunesDataBase.Forms
{
    public partial class EditObjectForm : Form
    {
        public BasicTableObject Object { get; }

        public EditObjectForm(BasicTableObject o)
        {
            Object = o;
            InitializeComponent();
        }

        private void EditObjectForm_Load(object sender, EventArgs e)
        {
            Text = Object.ToString();
            addTitleToolStripMenuItem.Visible = Object.Title == null;
            editTitleToolStripMenuItem.Visible = Object.Title != null;
            addShortNoteToolStripMenuItem.Visible = Object.ShortNote == null;
            editShortNoteToolStripMenuItem.Visible = Object.ShortNote != null;
            if (Object is NpcObject)
                addShortNoteToolStripMenuItem.Enabled = false;

            ObjectPropsChangesSource.MakeChanges(() =>
            {
                uiObjectProps.SelectedObject = Object;
            });
        }

        private ChangesSourceController ObjectPropsChangesSource { get; }= new ChangesSourceController();

        private void uiObjectProps_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (!ObjectPropsChangesSource.ChangesByUser)
                return;
            ((BasicTableObject)uiObjectProps.SelectedObject).RememberModified();
        }

        private void EditObjectForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.OpenedEditObjectWindows.Remove(Object);
        }

        private void cloneThisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newObj = MainForm.Database.GenerateNewTableObject(Object);
            if (newObj == null)
            {
                MessageBox.Show("Failed to create new object!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MainForm.NavigateToObjects(newObj);
        }

        private void addTitleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!MainForm.AddNewString($"Sys{Object.Guid}_titlename"))
                return;

            addTitleToolStripMenuItem.Visible = false;
            editTitleToolStripMenuItem.Visible = true;
        }

        private void addShortNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!MainForm.AddNewString($"Sys{Object.Guid}_shortnote"))
                return;

            addShortNoteToolStripMenuItem.Visible = false;
            editShortNoteToolStripMenuItem.Visible = true;
        }

        private void uiObjectProps_DoubleClick(object sender, EventArgs e)
        {
            Debug.WriteLine($"#DBLCLICK: [{e.GetType()}]: {e}");
        }

        private void uiObjectProps_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Debug.WriteLine($"#MDBLCLICK: [{e.GetType()}]: {e}");
        }

        private void uiGotoObjectByGuidMenuItem_Click(object sender, EventArgs e)
        {
            var gridItem = uiObjectProps.SelectedGridItem;
            uint? guid = null;
            if (gridItem?.Value is uint)
                guid = (uint) gridItem.Value;
            else if (gridItem?.Value is int)
                guid = (uint)(int)gridItem.Value;
            else
            {
                var str = gridItem?.Value as string;
                if (str != null)
                {
                    guid = GuidExtractor.ExtractGuid(str);
                }
                else if (gridItem?.Value != null)
                {
                    str = gridItem.Value.ToString();
                    guid = GuidExtractor.ExtractGuid(str);
                }
            }
            GotoObject.GotoAndForget(guid);
        }
    }
}

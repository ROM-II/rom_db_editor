using System;
using System.Windows.Forms;
using RunesDataBase.TableObjects;

namespace RunesDataBase.Forms
{
    public partial class GotoObject : Form
    {
        public uint Guid
        {
            get { return (uint) uiGuid.Value; }
            set { uiGuid.Value = value; }
        }

        public BasicTableObject Object
        {
            get { return MainForm.Database[Guid]; }
            set { Guid = value?.Guid ?? 0; }
        }

        public static void GotoAndForget(uint? guid = null)
        {
            if (guid.HasValue)
            {
                var obj = MainForm.Database[guid.Value];
                if (obj != null)
                {
                    MainForm.NavigateToObjects(obj);
                    return;
                }
            }
            
            var form = new GotoObject();
            form.Show();
            form.Activate();
            form.Guid = guid.HasValue && guid.Value < form.uiGuid.Maximum 
                ? guid.Value : 108074;
            form.uiGuid.Select(0, form.uiGuid.DecimalPlaces);
        }

        public GotoObject()
        {
            InitializeComponent();
        }

        private void uiAcceptButton_Click(object sender, EventArgs e)
        {
            MainForm.NavigateToObjects(Object);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void uiGuid_ValueChanged(object sender, EventArgs e)
        {
            var obj = Object;
            uiAcceptButton.Enabled = obj != null;
            if (!uiAcceptButton.Enabled)
                return;

            uiDescription.Text = $"{obj}\r\n{obj.GetDescription()}";
        }

        private void GotoObject_Load(object sender, EventArgs e)
        {
        }
    }
}

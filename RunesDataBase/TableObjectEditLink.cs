using System.Drawing;
using RunesDataBase.Forms;
using RunesDataBase.TableObjects;

namespace RunesDataBase
{
    public class TableObjectEditLink : BaseFormLink
    {
        public BasicTableObject Object;

        public TableObjectEditLink(BasicTableObject o)
        {
            Object = o;
        }

        public override string ToString()
        {
            return Object.ToString();
        }

        public override string GetDescription()
        {
            return $"({Object.Guid}) {Object.GetDescription()}";
        }

        public override Color GetColor()
        {
            return Object.GetColor();
        }

        public override void Navigate()
        {
            MainForm.NavigateToObjects(this);
        }
    }
}

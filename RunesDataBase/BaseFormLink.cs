using System.Drawing;
using Runes.Net.Shared;

namespace RunesDataBase
{
    public abstract class BaseFormLink : IColoredDescribable
    {
        public abstract override string ToString();
        public virtual Color GetColor() { return Color.White; } 
        public abstract string GetDescription();
        public abstract void Navigate(MainForm form);
    }
}

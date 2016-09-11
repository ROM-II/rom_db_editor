using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Windows.Forms.Design;

namespace RunesDataBase.Controls
{
    public class AutocompleteEditor<T> : UITypeEditor
    {
        public AutocompleteEditor(int? maxSuggests = null)
        {
            MaxSuggests = maxSuggests;
        }

        public int? MaxSuggests { get; }
        public override bool IsDropDownResizable => true;
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            var key = value as string;
            var e = provider?.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;
            if (e == null)
            {
                return base.EditValue(context, provider, value);
            }
            if (key != null)
            {
                var suggests = GetSource(context).GetSuggestionsForInput(key, MaxSuggests);
                e.DropDownControl(new AutocompleteDropdownControl(suggests.Select(x => x as object)));
            }

            return base.EditValue(context, provider, value);
        }

        private static IAutocompleteSource<T> GetSource(ITypeDescriptorContext context)
            => context.PropertyDescriptor?.Attributes.OfType<IAutocompleteSource<T>>().LastOrDefault();
    }
}

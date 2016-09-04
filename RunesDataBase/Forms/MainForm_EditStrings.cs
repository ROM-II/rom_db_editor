using System;
using System.Drawing;
using System.Text.RegularExpressions;

namespace RunesDataBase.Forms
{
    public partial class MainForm
    {
        public void NavigateToStrings(StringEditFormLink link)
        {
            SelectTab(uiTabEditStrings);

            uiEditStrings_Key.Text = link.Key;
            uiEditStrings_Language.Text = link.Language;
            uiEditStrings_Value.Text = link.Value;
        }

        private void uiEditStrings_Value_TextChanged(object sender, EventArgs e)
        {
            EditStrings_SetColorizedStringValue(uiEditStrings_Value.Text);
        }

        void EditStrings_SetColorizedStringValue(string value)
        {
            var cp = uiEditStrings_Value.SelectionStart;
            var cl = uiEditStrings_Value.SelectionLength;
            uiEditStrings_Value.Select(0, value.Length);
            var regex = new Regex(@"\[[<>| \w\-$]*\]", RegexOptions.Multiline);
            var font = new Font(uiEditStrings_Value.Font, FontStyle.Bold);
            foreach (Match match in regex.Matches(value))
            {
                uiEditStrings_Value.Select(match.Index, match.Length);
                uiEditStrings_Value.SelectionColor = Color.FromArgb(238, 215, 89);
                uiEditStrings_Value.SelectionFont = font;
            }
            uiEditStrings_Value.Select(cp, cl);
        }
        void uiButtonSaveStrings_Click(object sender, EventArgs e)
        {
            var lang = Database.LanguageByName(uiEditStrings_Language.Text);
            lang[uiEditStrings_Key.Text] = uiEditStrings_Value.Text;
            uint guid;
            string sfx;
            if (!ExtractGuidFromKey(uiEditStrings_Key.Text, out guid, out sfx))
                return;
            var obj = Database[guid];
            if (obj == null)
                return;
            switch (sfx)
            {
                case "name":
                    obj.Name = uiEditStrings_Value.Text;
                    break;
                case "shortnote":
                    obj.ShortNote = uiEditStrings_Value.Text;
                    break;
                case "titlestring":
                    obj.Title = uiEditStrings_Value.Text;
                    break;
            }
        }

        bool ExtractGuidFromKey(string s, out uint guid, out string suffix)
        {
            suffix = null;
            guid = 0;
            if (!s.StartsWith("Sys"))
                return false;
            s = s.Substring(3);
            var pos = s.IndexOf('_');
            if (pos < 0)
                return false;
            suffix = s.Substring(pos + 1);
            return uint.TryParse(s.Substring(0, pos), out guid);
        }
    }
}

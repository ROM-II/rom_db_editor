using System;
using RunesDataBase.Forms;

namespace RunesDataBase
{
    public class StringEditFormLink : BaseFormLink
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string Language { get; set; }
        public StringLinkKind Kind { get; set; }

        public StringEditFormLink(string key, string value, string langFullName)
        {
            Language = langFullName;
            Key = key;
            Value = value;
            Kind = StringLinkKindExt.SetFromString(key);
        }
        public override string ToString()
        {
            return $"{Key} = \"{Value}\"";
        }

        public override string GetDescription()
        {
            return $"{Kind} string ({Language})";
        }

        public override void Navigate()
        {
            MainForm.Instance.NavigateToStrings(this);
        }
    }

    public enum StringLinkKind
    {
        General = 0,
        Name,
        NamePlural,
        TitleName,
        ShortNote,
        QuestDesc,
        QuestCompleteDetail,
        QuestUnCompleteDetail,
        QuestAcceptDetail
    }

    public static class StringLinkKindExt
    {
        public static string ToSysStringSuffix(this StringLinkKind link)
        {
            switch (link)
            {
                case StringLinkKind.General:
                    return "";
                case StringLinkKind.Name:
                    return "name";
                case StringLinkKind.NamePlural:
                    return "name_plural";
                case StringLinkKind.TitleName:
                    return "titlename";
                case StringLinkKind.ShortNote:
                    return "shortnote";
                case StringLinkKind.QuestDesc:
                    return "szquest_desc";
                case StringLinkKind.QuestCompleteDetail:
                    return "szquest_complete_detail";
                case StringLinkKind.QuestUnCompleteDetail:
                    return "szquest_uncomplete_detail";
                case StringLinkKind.QuestAcceptDetail:
                    return "szquest_accept_detail";
                default:
                    throw new ArgumentOutOfRangeException("link", link, null);
            }
        }
        public static string ToSysString(this StringLinkKind link, uint guid)
        {
            if (link != StringLinkKind.General)
                return "Sys" + guid + "_" + link.ToSysStringSuffix();
            return guid.ToString();
        }

        public static StringLinkKind SetFromString(string fullString)
        {
            if (!fullString.StartsWith("Sys"))
                return StringLinkKind.General;

            var pos = fullString.IndexOf("_", StringComparison.Ordinal);
            if (pos < 0)
            {
                return StringLinkKind.General;
            }
            var suffix = fullString.Substring(pos + 1);
            switch (suffix)
            {
                default: return StringLinkKind.General;
                case "name":return StringLinkKind.Name;
                case "name_plural": return StringLinkKind.NamePlural;
                case "shortnote": return StringLinkKind.ShortNote;
                case "titlename": return StringLinkKind.TitleName;
                case "szquest_desc": return StringLinkKind.QuestDesc;
                case "szquest_accept_detail": return StringLinkKind.QuestAcceptDetail;
                case "szquest_complete_detail": return StringLinkKind.QuestCompleteDetail;
                case "szquest_uncomplete_detail": return StringLinkKind.QuestUnCompleteDetail;
            }
        }
    }
}

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fireball.Syntax;
using Fireball.Syntax.SyntaxDocumentParsers;
using Microsoft.CSharp;
using Runes.Net.Db.String.db;
using Runes.Net.Fdb;
using Runes.Net.Shared;
using Runes.Net.Shared.Html;
using RunesDataBase.Sql;
using RunesDataBase.SubScript;
using RunesDataBase.TableObjects;

namespace RunesDataBase.Forms
{
    public partial class MainForm : Form
    {
        public static MainForm Instance { get; private set; }
        public Logger Log;
        public bool IsFDBOpened { get; private set; }
        internal static DataBase Database = null;
        internal static SubScript.RunesDataBase DbApi { get; private set; } 
        public MainForm()
        {
            Instance = this;
            InitializeComponent(); 
            uiTabs.Enabled = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void openFDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log.WriteLine("Opening FDB ...");
            var cfgPath = Path.Combine(_cfg.FdbPath, "data.fdb");
            Log.WriteLine("cfgpath = " + cfgPath);
            if (!File.Exists(cfgPath) || 
                MessageBox.Show("Load data.fdb from '" + cfgPath + "' [yes] or select different location? [no]", 
                "data.fdb loading", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                Log.WriteLine("File not found or user want different location");
                if (uiOpenFDB.ShowDialog() != DialogResult.OK)
                    return;
                cfgPath = uiOpenFDB.FileName;
                Log.WriteLine("User have selected " + cfgPath);
            }
            _searchResults.Clear();
            uiSearchResults.Items.Clear();
            SelectTab();
            if (IsFDBOpened && Database != null && Database.Fdb != null)
            {
                IsFDBOpened = false;
                Database.Fdb.Close();
            }
            uiTabs.Enabled = false;
            Database = new DataBase
            {
                Log = Log,
                Fdb = new Fdb(),
                RootDir = Path.GetDirectoryName(Path.GetDirectoryName(cfgPath))
            };
            DataBase.NameDataVersioned.SafeInc();

            Log.WriteLine("DataBase.RootDir = " + Database.RootDir);
            Database.Fdb.LoadFromFile(cfgPath);
            var form = new SelectLanguagesForm
            {
                Fdb = Database.Fdb
            };
            if (form.ShowDialog() != DialogResult.OK)
            {
                Database.Fdb.Close();
                Database.Fdb = null;
                Database = null;
                IsFDBOpened = false;
                return;
            }
            Log.WriteLine("User loaded languages: " + string.Join("; ", form.Languages));
            IsFDBOpened = true;
            uiStatusLabel.Text = "Loading *.db ...";
            new Task(() =>
            {
                var dbList = (List<string>)form.Languages;
                foreach (var name in dbList)
                {
                    Database.LoadLanguage(name);
                }
                Database.LoadDbs();
                Action func = () =>
                {
                    uiCurrentLangugae.Items.Clear();
                    foreach (var lang in Database.Languages)
                    {
                        uiCurrentLangugae.Items.Add(lang);
                    }
                    //if (Database.Languages.Any())
                        uiCurrentLangugae.SelectedItem = Database.Languages.FirstOrDefault();
                    uiTabs.Enabled = true;
                    uiStatusLabel.Text = "Ready";
                    saveAllToolStripMenuItem.Enabled = newStringToolStripMenuItem.Enabled = true;
                };

                DbApi = new RunesDataBaseImpl
                {
                    Form = this,
                    DataBase = Database
                };
                

                DbRepository.Default.Configure(_cfg);
                uiTabs.Invoke(func);
            }).Start();
        }

        private void uiButtonDoSearch_Click(object sender, EventArgs e)
        {
            DoSearch(uiSearchTextBox.Text);
        }

        private void DoSearch(string filter)
        {
            _searchResults.Clear();
            uiSearchResults.Items.Clear();
            if (string.IsNullOrWhiteSpace(filter))
                return;
            //uiSearchResults.BeginUpdate();
            SetEnabled(false);
            new Task(() =>
            {
                uint guid;
                if (uint.TryParse(filter, out guid))
                {
                    ReportStatus("Searching by GUID...");
                    SearchByGuid(guid);
                }
                else
                {
                    ReportStatus("Searching by string...");
                    SearchByString(filter);
                }
                ReportStatus();
                SetEnabled();
            }).Start();
            //uiSearchResults.EndUpdate();
        }

        readonly List<object> _searchResults = new List<object>();
        private void SearchByGuid(uint guid)
        {
            var tobj = Database[guid];
            if (tobj != null)
                PushObjectToResults(new TableObjectEditLink(tobj), tobj.GetIconName());
            foreach (var l in Database.Languages)
            {
                foreach (var str in Database.GetStringsByGuid(l, guid))
                {
                    var link = new StringEditFormLink(str.Item1, str.Item2, l.FullLanguageName);
                    PushObjectToResults(link, "string");
                }
            }
        }
        private void SearchByString(string filter)
        {
            var li_filter = filter.ToLowerInvariant();
            if (uiNoStrings.Checked)
            {
                foreach (var l in Database.Languages)
                {
                    foreach (var str in l.NamesWhereValuesContains(li_filter))
                    {
                        var link = new StringEditFormLink(str.Key, str.Value, l.FullLanguageName);
                        TryExtractObjectFromStringLink(link);
                    }
                }  
            }
            else
            {
                foreach (var l in Database.Languages)
                {
                    foreach (var str in l.WhereKeysOrValuesContains(li_filter))
                    {
                        var link = new StringEditFormLink(str.Key, str.Value, l.FullLanguageName);
                        PushObjectToResults(link, "string");
                        TryExtractObjectFromStringLink(link);
                    }
                }
            }
        }

        void TryExtractObjectFromStringLink(StringEditFormLink link)
        {
            uint guid;
            string sfx;
            if (link.Kind != StringLinkKind.Name)
            {
                if (link.Key.StartsWith("DIR_ZONEID_"))
                {
                    if (!uint.TryParse(link.Key.Substring("DIR_ZONEID_".Length), out guid))
                        return;
                    guid += Database.ZoneTable.GuidPrefix;
                }
                else return;
            }else if (!ExtractGuidFromKey(link.Key, out guid, out sfx))
                return;
            if (_searchResults.Any(o =>
            {
                if (!(o is TableObjectEditLink))
                    return false;
                var bto = ((TableObjectEditLink)o).Object;
                return bto.Guid == guid;
            }))
                return;
            var tobj = Database[guid];
            if (tobj != null)
                PushObjectToResults(new TableObjectEditLink(tobj), tobj.GetIconName());
        }
        
        private void uiSearchResults_DoubleClick(object sender, EventArgs e)
        {
            var items = uiSearchResults.SelectedItems;
            if (items.Count < 1)
                return;
            var id = int.Parse(items[0].Name);
            if (id < 0) return;
            var obj = _searchResults[id];
            if (obj is BaseFormLink)
            {
                var link = _searchResults[id] as BaseFormLink;
                link?.Navigate();
            }
        }

        private void PushObjectToResults(IColoredDescribable o, string icon)
        {
            var tolink = o as TableObjectEditLink;
            if (tolink != null)
            {
                var obj = tolink.Object;
                if (obj.ShortNote == null)
                    obj.ShortNote = Database.GetStringByGuid(obj.Guid, StringLinkKind.ShortNote);
                if (obj.Title == null)
                    obj.Title = Database.GetStringByGuid(obj.Guid, StringLinkKind.TitleName);
            }
            var id = _searchResults.Count;
            var lvi = new ListViewItem
            {
                Name = id.ToString(),
                Text = o.ToString(),
                ImageKey = "object_" + icon + ".png",
                ForeColor = o.GetColor(),
                Tag = o.GetDescription(),
                ToolTipText =  o.GetDescription(),
                Group = uiSearchResults.Groups[icon],
            };
            AddResult(lvi);
            _searchResults.Add(o);
        }

        private void uiSearchResults_Resize(object sender, EventArgs e)
        {
            uiSRViewColumn0.Width = uiSearchResults.Width; //Math.Min(640, uiSearchResults.Width);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _cfg.Load();
            uiCfgDataFdb.Text = _cfg.FdbPath ?? uiCfgDataFdb.Text;
            uiCfgDataDb.Text = _cfg.DbPath ?? uiCfgDataDb.Text;
            uiCfgPathGlobalIni.Text = _cfg.GlobalIniPath ?? uiCfgPathGlobalIni.Text;
            DbRepository.Default.Configure(_cfg);
            foreach (TabPage p in uiTabs.TabPages)
                TabPages.Add(p);
            SelectTab();
            uiSearchResults.ShowItemToolTips = true;
            var doc = new SyntaxDocument
            {
                Text = "db.UI_ShowObjectList(db.Equipment.Where(item => item.Rarity > RareType.Legend));"
            };
            doc.Parser = new DefaultParser()
            {
                Document = doc,
                Language = Language.FromSyntaxFile("csharp.syn")
            };
            uiScript.AttachDocument(doc);
            uiScript.Update();
        }

        internal List<TabPage> TabPages = new List<TabPage>();

        private void SelectTab(TabPage p = null)
        {
            uiTabs.TabPages.Clear();
            uiTabs.TabPages.Add(uiTabSettings);
            uiTabs.TabPages.Add(uiTabSearch);
            uiTabs.TabPages.Add(uiTabAdvancedSearch);
            if (p == null)
            {
                uiTabs.SelectTab(uiTabSearch);
                return;
            }
            uiTabs.TabPages.Add(p);
            uiTabs.SelectTab(p);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox1().ShowDialog();
        }

        private void saveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportStatus("Saving ...");
            var path = Path.GetFullPath(_cfg.DbPath);
            var useCfg = false;
            if (Directory.Exists(path))
            {
                useCfg = MessageBox.Show("Save everything to " + path + " [yes] or select different location?[no]",
                    "data.fdb loading", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
                uiSaveDialog.InitialDirectory = path;
            }
            uiSaveDialog.InitialDirectory = Database.RootDir;
            foreach (var sdb in Database.Languages.Where(s=>s.ModifiedFlag))
            {
                uiSaveDialog.Title = "Save " + sdb.FileName;
                uiSaveDialog.FileName = sdb.FileName;
                if (useCfg)
                    uiSaveDialog.FileName = Path.Combine(path, sdb.FileName+".db");
                else if (uiSaveDialog.ShowDialog() != DialogResult.OK) continue;
                sdb.SaveToFile(uiSaveDialog.FileName);
                sdb.ModifiedFlag = false;
            }
            foreach (var db in Database.GetModifiedDataBases())
            {
                uiSaveDialog.Title = "Save " + db.FileName;
                uiSaveDialog.FileName = db.FileName;
                if (useCfg)
                    uiSaveDialog.FileName = Path.Combine(path, db.FileName);
                else if (uiSaveDialog.ShowDialog() != DialogResult.OK) continue;
                db.FixChanges();
                db.File.Save(uiSaveDialog.FileName);
                db.File.ModifiedFlag = false;
            }
            ReportStatus();
        }

        private bool userChanges = true;

        private void uiObjectProps_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (!userChanges)
                return;
            ((BasicTableObject) uiObjectProps.SelectedObject).RememberModified();
        }

        private void newStringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewString();
        }

        public static bool AddNewString(string key = "")
        {
            var f = new AddStringForm { Key = key, Languages = Database.Languages };
            if (f.ShowDialog() != DialogResult.OK)
                return false;
            var languages = f.Languages.ToArray();
            var langs2 = new List<StringsDataBase>();
            foreach (var lang in languages)
            {
                if (lang.WhereKeyMatches(s => s == f.Key).Any())
                {
                    var msg = $"Key '{f.Key}' is already defined in '{lang.FullLanguageName}'; it will not be changed.";
                    MessageBox.Show(msg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    continue;
                }
                langs2.Add(lang);
            }
            foreach (var sdb in langs2)
            {
                sdb.Data[f.Key] = f.Key;
                sdb.ModifiedFlag = true;
            }
            return true;
        }

        private void ReportStatus(string statusString = null)
        {
            Action func = () => { uiStatusLabel.Text = statusString ?? "Idle"; };
            if (InvokeRequired)
                Invoke(func);
            else
                func();
        }
        private void SetEnabled(bool v = true)
        {
            Action func = () =>
            {
                uiTabs.Enabled = v;
                menuStrip1.Enabled = v;
            };
            if (InvokeRequired)
                Invoke(func);
            else
                func();
        }
        private void AddResult(ListViewItem lvi)
        {
            Action func = () =>
            {
                uiSearchResults.Items.Add(lvi);
            };
            if (InvokeRequired)
                Invoke(func);
            else
                func();
        }

        private void uiCurrentLangugae_SelectedIndexChanged(object sender, EventArgs e)
        {
            var lang = uiCurrentLangugae.SelectedItem as StringsDataBase;
            if (lang == Database.CurrentLanguage)
                return;

            Database.CurrentLanguage = lang;
            DataBase.NameDataVersioned.SafeInc();

            foreach (ListViewItem searchResult in uiSearchResults.Items)
            {
                var id = int.Parse(searchResult.Name);
                var item = _searchResults[id];
                var link = item as TableObjectEditLink;
                if (link != null)
                {
                    var obj = link.Object;
                    searchResult.Text = obj.ToString();
                }
            }
        }
        private Config _cfg = new Config();
        private void uiBrowseDataFdb_Click(object sender, EventArgs e)
        {
            if (uiBrowseFolder.ShowDialog() != DialogResult.OK)
                return;
            uiCfgDataFdb.Text = uiBrowseFolder.SelectedPath;
        }

        private void uiBrowseDataDb_Click(object sender, EventArgs e)
        {
            if (uiBrowseFolder.ShowDialog() != DialogResult.OK)
                return;
            uiCfgDataDb.Text = uiBrowseFolder.SelectedPath;
        }

        private void uiCfgSaveButton_Click(object sender, EventArgs e)
        {
            _cfg.FdbPath = uiCfgDataFdb.Text;
            _cfg.DbPath = uiCfgDataDb.Text;
            _cfg.GlobalIniPath = uiCfgPathGlobalIni.Text;
            _cfg.Save();
        }

        private ListViewItem _hoveredItem;
        private void uiSearchResults_MouseMove(object sender, MouseEventArgs e)
        {
            var lvi = uiSearchResults.GetItemAt(e.X, e.Y);
            if (lvi == _hoveredItem) return;
            _hoveredItem = lvi;
            htmlToolTip1.SetToolTip(uiSearchResults,
                lvi == null ? "" : lvi.Tag.ToString().HtmlWrap("body", "bgcolor=black", "color=white"));
        }

        public void UI_ShowHTML(string html)
        {
            uiAdvSearchResults.Text = html;
        }
        public void UI_EditObject(BasicTableObject obj)
        {
            NavigateToObjects(new TableObjectEditLink(obj));
        }
        public void UI_ShowObjectList<T>(IEnumerable<T> objects) where T : BasicTableObject
        {
            UI_ShowObjectList(objects, o => "");
        }
        public void UI_ShowObjectList<T>(IEnumerable<T> objects, Func<T, string> descriptor) where T : BasicTableObject
        {
            var sb = new StringBuilder();

            sb.AppendLine("Results:".HtmlWrap("p"));
            sb.AppendLine("<table>");
            sb.AppendLine((
                "Name".HtmlWrap("td", "style = \"background-color:#222222; width: auto\"") +
                "GUID".HtmlWrap("td", "style = \"background-color:#222222; width: 128px\"") +
                "Additional info".HtmlWrap("td", "style = \"background-color:#222222\""))
                .HtmlWrap("tr"));
            foreach (var o in objects)
            {
                sb.AppendLine("<tr>");
                
                var objName = $"{o.Name}"
                    .HtmlFont(o.GetColor())
                    .HtmlWrap("a", "href=" + o.Guid, "target=romdb");
                sb.AppendLine(objName.HtmlWrap("td"));
                sb.AppendLine(o.Guid.ToString().HtmlWrap("td"));
                sb.AppendLine(descriptor(o).HtmlWrap("td"));

                sb.AppendLine("</tr>");
            }
            sb.AppendLine("</table>");

            UI_ShowHTML(DefaultHtmlWrap(sb.ToString()));
        }

        private string DefaultHtmlWrap(string content)
        {
            const string style = @"<style>
   td, p, body { 
    margin: 0; 
    padding: 0;
   }
    table {
        border-spacing: 10px 0px;
        width: 100%
    }
  </style>";
            var body = content
                .HtmlFont(Color.White, 9, "verdana")
                .HtmlWrap("body", "bgcolor=black");
            return (style + body)
                .HtmlWrap("html");
        }

        private void uiButtonRun_Click(object sender, EventArgs e)
        {
            var csc = new CSharpCodeProvider(new Dictionary<string, string> { { "CompilerVersion", "v4.0" } });
            var parameters = new CompilerParameters(new[]
            {
                "mscorlib.dll", "System.Core.dll", "romdb_editor.exe",
                "Runes.Net.Shared.dll", "Runes.Net.Db.dll"
            })
            {
                GenerateExecutable = false,
                GenerateInMemory = true
            };
            const string code0 = @"using System;
using System.Linq;
using System.Collections.Generic;
using RunesDataBase.TableObjects;
using RunesDataBase.SubScript;
using Runes.Net.Shared;
public class Main {
    public static void Run(RunesDataBase.SubScript.RunesDataBase db) {
";
            const string code1 = @"}
}";

            var results = csc.CompileAssemblyFromSource(parameters,
                code0 + uiScript.Document.Text + code1);
            if (results.Errors.HasErrors)
            {
                var sb = new StringBuilder();
                foreach (CompilerError error in results.Errors)
                {
                    var lineStr = $"[line {error.Line - 8}]"
                        .HtmlFont(error.IsWarning ? Color.DarkGoldenrod : Color.Red);
                    var errorStr = string.Format("{0} {3} {2}: {1}", lineStr, error.ErrorText, error.ErrorNumber,
                        error.IsWarning ? "Warning" : "Error");
                    sb.AppendLine(errorStr.HtmlWrap("p"));
                }
                UI_ShowHTML(DefaultHtmlWrap(sb.ToString()));
                return;
            }
            var runFunc = results.CompiledAssembly.GetType("Main").GetMethod("Run");
            try
            {
                runFunc.Invoke(null, new object[] { DbApi });
            }
            catch (Exception ex)
            {
                var sb = new StringBuilder();
                foreach (var error in ex.Message.Split(new []{Environment.NewLine}, StringSplitOptions.None))
                {
                    sb.AppendLine(error.HtmlWrap("p"));
                }
                UI_ShowHTML(DefaultHtmlWrap(sb.ToString()));
            }
        }

        private void uiAdvSearchResults_LinkClicked(object sender, TheArtOfDev.HtmlRenderer.Core.Entities.HtmlLinkClickedEventArgs e)
        {
            if (e.Attributes["target"] != "romdb")
            {
                Process.Start(e.Link);
                return;
            }
            uint guid;
            if (!uint.TryParse(e.Link, out guid))
                return;
            var obj = Database[guid];
            if (obj == null)
                return;
            UI_EditObject(obj);
        }

        private void uiBrowseGlobalIni_Click(object sender, EventArgs e)
        {
            if (uiOpenGlobalIni.ShowDialog() != DialogResult.OK)
                return;
            uiCfgPathGlobalIni.Text = uiOpenGlobalIni.FileName;
        }



        private void adminPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminPanel.Call();
        }
    }
}
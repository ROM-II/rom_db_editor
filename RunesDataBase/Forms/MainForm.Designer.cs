﻿namespace RunesDataBase.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Strings", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("NPC", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Spells", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Zones", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("?", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("Items", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup7 = new System.Windows.Forms.ListViewGroup("Buffs", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup8 = new System.Windows.Forms.ListViewGroup("Stats", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup9 = new System.Windows.Forms.ListViewGroup("Drop lists (Treasure)", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            Fireball.Windows.Forms.LineMarginRender lineMarginRender1 = new Fireball.Windows.Forms.LineMarginRender();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newStringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utilitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminPanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.uiStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.uiTabs = new System.Windows.Forms.TabControl();
            this.uiTabSettings = new System.Windows.Forms.TabPage();
            this.uiBrowseGlobalIni = new System.Windows.Forms.Button();
            this.uiCfgPathGlobalIni = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.uiCfgSaveButton = new System.Windows.Forms.Button();
            this.uiBrowseDataDb = new System.Windows.Forms.Button();
            this.uiCfgDataDb = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.uiBrowseDataFdb = new System.Windows.Forms.Button();
            this.uiCfgDataFdb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.uiTabSearch = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.uiCurrentLangugae = new System.Windows.Forms.ComboBox();
            this.uiNoStrings = new System.Windows.Forms.CheckBox();
            this.uiSearchResults = new System.Windows.Forms.ListView();
            this.uiSRViewColumn0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uiListIcons = new System.Windows.Forms.ImageList(this.components);
            this.uiButtonDoSearch = new System.Windows.Forms.Button();
            this.uiSearchTextBox = new System.Windows.Forms.TextBox();
            this.uiTabAdvancedSearch = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.uiAdvSearchResults = new TheArtOfDev.HtmlRenderer.WinForms.HtmlPanel();
            this.uiScript = new Fireball.Windows.Forms.CodeEditorControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.uiRunButton = new System.Windows.Forms.ToolStripButton();
            this.uiTabEditStrings = new System.Windows.Forms.TabPage();
            this.uiButtonSaveStrings = new System.Windows.Forms.Button();
            this.uiEditStrings_Value = new System.Windows.Forms.RichTextBox();
            this.uiEditStrings_Language = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.uiEditStrings_Key = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uiTabEditObject = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.uiEditObject_AddShortNote = new System.Windows.Forms.Button();
            this.uiEditObject_AddTitleString = new System.Windows.Forms.Button();
            this.uiEditObject_CopyObject = new System.Windows.Forms.Button();
            this.uiObjectProps = new System.Windows.Forms.PropertyGrid();
            this.uiCommonIcons = new System.Windows.Forms.ImageList(this.components);
            this.uiOpenFDB = new System.Windows.Forms.OpenFileDialog();
            this.uiSaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.uiBrowseFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.htmlToolTip1 = new TheArtOfDev.HtmlRenderer.WinForms.HtmlToolTip();
            this.syntaxDocument1 = new Fireball.Syntax.SyntaxDocument(this.components);
            this.uiOpenGlobalIni = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.uiTabs.SuspendLayout();
            this.uiTabSettings.SuspendLayout();
            this.uiTabSearch.SuspendLayout();
            this.uiTabAdvancedSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.uiTabEditStrings.SuspendLayout();
            this.uiTabEditObject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.addToolStripMenuItem,
            this.utilitiesToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(979, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFDBToolStripMenuItem,
            this.saveAllToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openFDBToolStripMenuItem
            // 
            this.openFDBToolStripMenuItem.Image = global::RunesDataBase.Properties.Resources.database_go;
            this.openFDBToolStripMenuItem.Name = "openFDBToolStripMenuItem";
            this.openFDBToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openFDBToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.openFDBToolStripMenuItem.Text = "Open FDB ...";
            this.openFDBToolStripMenuItem.Click += new System.EventHandler(this.openFDBToolStripMenuItem_Click);
            // 
            // saveAllToolStripMenuItem
            // 
            this.saveAllToolStripMenuItem.Enabled = false;
            this.saveAllToolStripMenuItem.Image = global::RunesDataBase.Properties.Resources.database_save;
            this.saveAllToolStripMenuItem.Name = "saveAllToolStripMenuItem";
            this.saveAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveAllToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.saveAllToolStripMenuItem.Text = "Save All";
            this.saveAllToolStripMenuItem.Click += new System.EventHandler(this.saveAllToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::RunesDataBase.Properties.Resources.cross;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newStringToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // newStringToolStripMenuItem
            // 
            this.newStringToolStripMenuItem.Enabled = false;
            this.newStringToolStripMenuItem.Image = global::RunesDataBase.Properties.Resources.textfield_add;
            this.newStringToolStripMenuItem.Name = "newStringToolStripMenuItem";
            this.newStringToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            this.newStringToolStripMenuItem.Text = "New String ...";
            this.newStringToolStripMenuItem.Click += new System.EventHandler(this.newStringToolStripMenuItem_Click);
            // 
            // utilitiesToolStripMenuItem
            // 
            this.utilitiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminPanelToolStripMenuItem});
            this.utilitiesToolStripMenuItem.Name = "utilitiesToolStripMenuItem";
            this.utilitiesToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.utilitiesToolStripMenuItem.Text = "Utilities";
            // 
            // adminPanelToolStripMenuItem
            // 
            this.adminPanelToolStripMenuItem.Name = "adminPanelToolStripMenuItem";
            this.adminPanelToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.adminPanelToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.adminPanelToolStripMenuItem.Text = "Admin panel ...";
            this.adminPanelToolStripMenuItem.Click += new System.EventHandler(this.adminPanelToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.aboutToolStripMenuItem.Text = "About ...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uiStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 643);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(979, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // uiStatusLabel
            // 
            this.uiStatusLabel.Name = "uiStatusLabel";
            this.uiStatusLabel.Size = new System.Drawing.Size(26, 17);
            this.uiStatusLabel.Text = "Idle";
            // 
            // uiTabs
            // 
            this.uiTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiTabs.Controls.Add(this.uiTabSettings);
            this.uiTabs.Controls.Add(this.uiTabSearch);
            this.uiTabs.Controls.Add(this.uiTabAdvancedSearch);
            this.uiTabs.Controls.Add(this.uiTabEditStrings);
            this.uiTabs.Controls.Add(this.uiTabEditObject);
            this.uiTabs.ImageList = this.uiCommonIcons;
            this.uiTabs.Location = new System.Drawing.Point(14, 31);
            this.uiTabs.Name = "uiTabs";
            this.uiTabs.SelectedIndex = 0;
            this.uiTabs.Size = new System.Drawing.Size(952, 603);
            this.uiTabs.TabIndex = 3;
            // 
            // uiTabSettings
            // 
            this.uiTabSettings.BackColor = System.Drawing.Color.Silver;
            this.uiTabSettings.Controls.Add(this.uiBrowseGlobalIni);
            this.uiTabSettings.Controls.Add(this.uiCfgPathGlobalIni);
            this.uiTabSettings.Controls.Add(this.label6);
            this.uiTabSettings.Controls.Add(this.uiCfgSaveButton);
            this.uiTabSettings.Controls.Add(this.uiBrowseDataDb);
            this.uiTabSettings.Controls.Add(this.uiCfgDataDb);
            this.uiTabSettings.Controls.Add(this.label5);
            this.uiTabSettings.Controls.Add(this.uiBrowseDataFdb);
            this.uiTabSettings.Controls.Add(this.uiCfgDataFdb);
            this.uiTabSettings.Controls.Add(this.label4);
            this.uiTabSettings.ImageKey = "cog.png";
            this.uiTabSettings.Location = new System.Drawing.Point(4, 23);
            this.uiTabSettings.Name = "uiTabSettings";
            this.uiTabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.uiTabSettings.Size = new System.Drawing.Size(944, 576);
            this.uiTabSettings.TabIndex = 3;
            this.uiTabSettings.Text = "Settings";
            // 
            // uiBrowseGlobalIni
            // 
            this.uiBrowseGlobalIni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiBrowseGlobalIni.Location = new System.Drawing.Point(881, 104);
            this.uiBrowseGlobalIni.Name = "uiBrowseGlobalIni";
            this.uiBrowseGlobalIni.Size = new System.Drawing.Size(57, 22);
            this.uiBrowseGlobalIni.TabIndex = 9;
            this.uiBrowseGlobalIni.Text = "...";
            this.uiBrowseGlobalIni.UseVisualStyleBackColor = true;
            this.uiBrowseGlobalIni.Click += new System.EventHandler(this.uiBrowseGlobalIni_Click);
            // 
            // uiCfgPathGlobalIni
            // 
            this.uiCfgPathGlobalIni.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiCfgPathGlobalIni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uiCfgPathGlobalIni.Font = new System.Drawing.Font("Consolas", 9F);
            this.uiCfgPathGlobalIni.Location = new System.Drawing.Point(6, 104);
            this.uiCfgPathGlobalIni.Name = "uiCfgPathGlobalIni";
            this.uiCfgPathGlobalIni.Size = new System.Drawing.Size(869, 22);
            this.uiCfgPathGlobalIni.TabIndex = 8;
            this.uiCfgPathGlobalIni.Text = "C:\\Runewaker\\Server\\Realm_01_Common\\Global.ini";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 14);
            this.label6.TabIndex = 7;
            this.label6.Text = "Path to Global.ini:";
            // 
            // uiCfgSaveButton
            // 
            this.uiCfgSaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiCfgSaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uiCfgSaveButton.ForeColor = System.Drawing.Color.Green;
            this.uiCfgSaveButton.Image = global::RunesDataBase.Properties.Resources.diskette;
            this.uiCfgSaveButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiCfgSaveButton.Location = new System.Drawing.Point(850, 132);
            this.uiCfgSaveButton.Name = "uiCfgSaveButton";
            this.uiCfgSaveButton.Size = new System.Drawing.Size(88, 26);
            this.uiCfgSaveButton.TabIndex = 6;
            this.uiCfgSaveButton.Text = "Save";
            this.uiCfgSaveButton.UseVisualStyleBackColor = true;
            this.uiCfgSaveButton.Click += new System.EventHandler(this.uiCfgSaveButton_Click);
            // 
            // uiBrowseDataDb
            // 
            this.uiBrowseDataDb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiBrowseDataDb.Location = new System.Drawing.Point(881, 62);
            this.uiBrowseDataDb.Name = "uiBrowseDataDb";
            this.uiBrowseDataDb.Size = new System.Drawing.Size(57, 22);
            this.uiBrowseDataDb.TabIndex = 5;
            this.uiBrowseDataDb.Text = "...";
            this.uiBrowseDataDb.UseVisualStyleBackColor = true;
            this.uiBrowseDataDb.Click += new System.EventHandler(this.uiBrowseDataDb_Click);
            // 
            // uiCfgDataDb
            // 
            this.uiCfgDataDb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiCfgDataDb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uiCfgDataDb.Font = new System.Drawing.Font("Consolas", 9F);
            this.uiCfgDataDb.Location = new System.Drawing.Point(6, 62);
            this.uiCfgDataDb.Name = "uiCfgDataDb";
            this.uiCfgDataDb.Size = new System.Drawing.Size(869, 22);
            this.uiCfgDataDb.TabIndex = 4;
            this.uiCfgDataDb.Text = "c:\\runewaker\\client\\data\\";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 14);
            this.label5.TabIndex = 3;
            this.label5.Text = "Default *.db location:";
            // 
            // uiBrowseDataFdb
            // 
            this.uiBrowseDataFdb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiBrowseDataFdb.Location = new System.Drawing.Point(881, 20);
            this.uiBrowseDataFdb.Name = "uiBrowseDataFdb";
            this.uiBrowseDataFdb.Size = new System.Drawing.Size(57, 22);
            this.uiBrowseDataFdb.TabIndex = 2;
            this.uiBrowseDataFdb.Text = "...";
            this.uiBrowseDataFdb.UseVisualStyleBackColor = true;
            this.uiBrowseDataFdb.Click += new System.EventHandler(this.uiBrowseDataFdb_Click);
            // 
            // uiCfgDataFdb
            // 
            this.uiCfgDataFdb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiCfgDataFdb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uiCfgDataFdb.Font = new System.Drawing.Font("Consolas", 9F);
            this.uiCfgDataFdb.Location = new System.Drawing.Point(6, 20);
            this.uiCfgDataFdb.Name = "uiCfgDataFdb";
            this.uiCfgDataFdb.Size = new System.Drawing.Size(869, 22);
            this.uiCfgDataFdb.TabIndex = 1;
            this.uiCfgDataFdb.Text = "c:\\runewaker\\client\\fdb\\";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "Default data.fdb location:";
            // 
            // uiTabSearch
            // 
            this.uiTabSearch.BackColor = System.Drawing.Color.Silver;
            this.uiTabSearch.Controls.Add(this.label3);
            this.uiTabSearch.Controls.Add(this.uiCurrentLangugae);
            this.uiTabSearch.Controls.Add(this.uiNoStrings);
            this.uiTabSearch.Controls.Add(this.uiSearchResults);
            this.uiTabSearch.Controls.Add(this.uiButtonDoSearch);
            this.uiTabSearch.Controls.Add(this.uiSearchTextBox);
            this.uiTabSearch.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.uiTabSearch.ImageKey = "magnifier.png";
            this.uiTabSearch.Location = new System.Drawing.Point(4, 23);
            this.uiTabSearch.Name = "uiTabSearch";
            this.uiTabSearch.Padding = new System.Windows.Forms.Padding(3);
            this.uiTabSearch.Size = new System.Drawing.Size(944, 576);
            this.uiTabSearch.TabIndex = 0;
            this.uiTabSearch.Text = "Search";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(485, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "Default language:";
            // 
            // uiCurrentLangugae
            // 
            this.uiCurrentLangugae.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiCurrentLangugae.FormattingEnabled = true;
            this.uiCurrentLangugae.Location = new System.Drawing.Point(613, 36);
            this.uiCurrentLangugae.Name = "uiCurrentLangugae";
            this.uiCurrentLangugae.Size = new System.Drawing.Size(323, 22);
            this.uiCurrentLangugae.TabIndex = 5;
            this.htmlToolTip1.SetToolTip(this.uiCurrentLangugae, "Default localization to use for naming objects");
            this.uiCurrentLangugae.SelectedIndexChanged += new System.EventHandler(this.uiCurrentLangugae_SelectedIndexChanged);
            // 
            // uiNoStrings
            // 
            this.uiNoStrings.AutoSize = true;
            this.uiNoStrings.Checked = true;
            this.uiNoStrings.CheckState = System.Windows.Forms.CheckState.Checked;
            this.uiNoStrings.Location = new System.Drawing.Point(7, 38);
            this.uiNoStrings.Name = "uiNoStrings";
            this.uiNoStrings.Size = new System.Drawing.Size(330, 18);
            this.uiNoStrings.TabIndex = 4;
            this.uiNoStrings.Text = "Don`t output string entries (For \'search by string\' only)";
            this.uiNoStrings.UseVisualStyleBackColor = true;
            // 
            // uiSearchResults
            // 
            this.uiSearchResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiSearchResults.BackColor = System.Drawing.Color.Black;
            this.uiSearchResults.BackgroundImageTiled = true;
            this.uiSearchResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.uiSRViewColumn0});
            this.uiSearchResults.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.uiSearchResults.ForeColor = System.Drawing.Color.White;
            this.uiSearchResults.FullRowSelect = true;
            listViewGroup1.Header = "Strings";
            listViewGroup1.Name = "string";
            listViewGroup2.Header = "NPC";
            listViewGroup2.Name = "npc";
            listViewGroup3.Header = "Spells";
            listViewGroup3.Name = "spell";
            listViewGroup4.Header = "Zones";
            listViewGroup4.Name = "zone";
            listViewGroup5.Header = "?";
            listViewGroup5.Name = "unknown";
            listViewGroup6.Header = "Items";
            listViewGroup6.Name = "item";
            listViewGroup7.Header = "Buffs";
            listViewGroup7.Name = "buff";
            listViewGroup8.Header = "Stats";
            listViewGroup8.Name = "stat";
            listViewGroup9.Header = "Drop lists (Treasure)";
            listViewGroup9.Name = "treasure";
            this.uiSearchResults.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4,
            listViewGroup5,
            listViewGroup6,
            listViewGroup7,
            listViewGroup8,
            listViewGroup9});
            this.uiSearchResults.LargeImageList = this.uiListIcons;
            this.uiSearchResults.Location = new System.Drawing.Point(7, 66);
            this.uiSearchResults.MultiSelect = false;
            this.uiSearchResults.Name = "uiSearchResults";
            this.uiSearchResults.ShowItemToolTips = true;
            this.uiSearchResults.Size = new System.Drawing.Size(929, 505);
            this.uiSearchResults.SmallImageList = this.uiListIcons;
            this.uiSearchResults.StateImageList = this.uiListIcons;
            this.uiSearchResults.TabIndex = 3;
            this.uiSearchResults.UseCompatibleStateImageBehavior = false;
            this.uiSearchResults.View = System.Windows.Forms.View.Details;
            this.uiSearchResults.DoubleClick += new System.EventHandler(this.uiSearchResults_DoubleClick);
            this.uiSearchResults.Resize += new System.EventHandler(this.uiSearchResults_Resize);
            // 
            // uiSRViewColumn0
            // 
            this.uiSRViewColumn0.Text = "Found entries";
            this.uiSRViewColumn0.Width = 6500;
            // 
            // uiListIcons
            // 
            this.uiListIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("uiListIcons.ImageStream")));
            this.uiListIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.uiListIcons.Images.SetKeyName(0, "object_string.png");
            this.uiListIcons.Images.SetKeyName(1, "object_npc.png");
            this.uiListIcons.Images.SetKeyName(2, "object_buff.png");
            this.uiListIcons.Images.SetKeyName(3, "object_spell.png");
            this.uiListIcons.Images.SetKeyName(4, "object_unknown.png");
            this.uiListIcons.Images.SetKeyName(5, "object_zone.png");
            this.uiListIcons.Images.SetKeyName(6, "object_item.png");
            this.uiListIcons.Images.SetKeyName(7, "object_stat.png");
            this.uiListIcons.Images.SetKeyName(8, "object_treasure.png");
            this.uiListIcons.Images.SetKeyName(9, "object_shop.png");
            // 
            // uiButtonDoSearch
            // 
            this.uiButtonDoSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiButtonDoSearch.Location = new System.Drawing.Point(794, 6);
            this.uiButtonDoSearch.Name = "uiButtonDoSearch";
            this.uiButtonDoSearch.Size = new System.Drawing.Size(142, 26);
            this.uiButtonDoSearch.TabIndex = 1;
            this.uiButtonDoSearch.Text = "Search";
            this.uiButtonDoSearch.UseVisualStyleBackColor = true;
            this.uiButtonDoSearch.Click += new System.EventHandler(this.uiButtonDoSearch_Click);
            // 
            // uiSearchTextBox
            // 
            this.uiSearchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiSearchTextBox.Location = new System.Drawing.Point(7, 6);
            this.uiSearchTextBox.Name = "uiSearchTextBox";
            this.uiSearchTextBox.Size = new System.Drawing.Size(780, 22);
            this.uiSearchTextBox.TabIndex = 0;
            this.htmlToolTip1.SetToolTip(this.uiSearchTextBox, "Filter (GUID or string to find)");
            // 
            // uiTabAdvancedSearch
            // 
            this.uiTabAdvancedSearch.BackColor = System.Drawing.Color.Silver;
            this.uiTabAdvancedSearch.Controls.Add(this.splitContainer2);
            this.uiTabAdvancedSearch.ImageKey = "script_code.png";
            this.uiTabAdvancedSearch.Location = new System.Drawing.Point(4, 23);
            this.uiTabAdvancedSearch.Name = "uiTabAdvancedSearch";
            this.uiTabAdvancedSearch.Padding = new System.Windows.Forms.Padding(3);
            this.uiTabAdvancedSearch.Size = new System.Drawing.Size(944, 576);
            this.uiTabAdvancedSearch.TabIndex = 4;
            this.uiTabAdvancedSearch.Text = "Advanced";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(3, 4);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.uiAdvSearchResults);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.uiScript);
            this.splitContainer2.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer2.Size = new System.Drawing.Size(938, 565);
            this.splitContainer2.SplitterDistance = 510;
            this.splitContainer2.TabIndex = 4;
            // 
            // uiAdvSearchResults
            // 
            this.uiAdvSearchResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiAdvSearchResults.AutoScroll = true;
            this.uiAdvSearchResults.BackColor = System.Drawing.SystemColors.Window;
            this.uiAdvSearchResults.BaseStylesheet = null;
            this.uiAdvSearchResults.Location = new System.Drawing.Point(3, 3);
            this.uiAdvSearchResults.Name = "uiAdvSearchResults";
            this.uiAdvSearchResults.Size = new System.Drawing.Size(504, 559);
            this.uiAdvSearchResults.TabIndex = 0;
            this.uiAdvSearchResults.Text = null;
            this.uiAdvSearchResults.LinkClicked += new System.EventHandler<TheArtOfDev.HtmlRenderer.Core.Entities.HtmlLinkClickedEventArgs>(this.uiAdvSearchResults_LinkClicked);
            // 
            // uiScript
            // 
            this.uiScript.ActiveView = Fireball.Windows.Forms.CodeEditor.ActiveView.BottomRight;
            this.uiScript.AutoListPosition = null;
            this.uiScript.AutoListSelectedText = "a123";
            this.uiScript.AutoListVisible = false;
            this.uiScript.CopyAsRTF = false;
            this.uiScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiScript.FontName = "Consolas";
            this.uiScript.InfoTipCount = 1;
            this.uiScript.InfoTipPosition = null;
            this.uiScript.InfoTipSelectedIndex = 1;
            this.uiScript.InfoTipVisible = false;
            lineMarginRender1.Bounds = new System.Drawing.Rectangle(19, 0, 18, 15);
            this.uiScript.LineMarginRender = lineMarginRender1;
            this.uiScript.Location = new System.Drawing.Point(0, 25);
            this.uiScript.LockCursorUpdate = false;
            this.uiScript.Name = "uiScript";
            this.uiScript.ParseOnPaste = true;
            this.uiScript.Saved = false;
            this.uiScript.ShowScopeIndicator = false;
            this.uiScript.Size = new System.Drawing.Size(424, 540);
            this.uiScript.SmoothScroll = false;
            this.uiScript.SplitviewH = -4;
            this.uiScript.SplitviewV = -4;
            this.uiScript.TabGuideColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.uiScript.TabIndex = 3;
            this.uiScript.TextDrawStyle = Fireball.Windows.Forms.CodeEditor.TextDraw.TextDrawType.DoubleBorder;
            this.uiScript.WhitespaceColor = System.Drawing.SystemColors.ControlDark;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uiRunButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(424, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // uiRunButton
            // 
            this.uiRunButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.uiRunButton.Image = global::RunesDataBase.Properties.Resources.lightning;
            this.uiRunButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiRunButton.Name = "uiRunButton";
            this.uiRunButton.Size = new System.Drawing.Size(23, 22);
            this.uiRunButton.Text = "toolStripButton1";
            this.uiRunButton.Click += new System.EventHandler(this.uiButtonRun_Click);
            // 
            // uiTabEditStrings
            // 
            this.uiTabEditStrings.BackColor = System.Drawing.Color.Silver;
            this.uiTabEditStrings.Controls.Add(this.uiButtonSaveStrings);
            this.uiTabEditStrings.Controls.Add(this.uiEditStrings_Value);
            this.uiTabEditStrings.Controls.Add(this.uiEditStrings_Language);
            this.uiTabEditStrings.Controls.Add(this.label2);
            this.uiTabEditStrings.Controls.Add(this.uiEditStrings_Key);
            this.uiTabEditStrings.Controls.Add(this.label1);
            this.uiTabEditStrings.Location = new System.Drawing.Point(4, 23);
            this.uiTabEditStrings.Name = "uiTabEditStrings";
            this.uiTabEditStrings.Padding = new System.Windows.Forms.Padding(3);
            this.uiTabEditStrings.Size = new System.Drawing.Size(944, 576);
            this.uiTabEditStrings.TabIndex = 1;
            this.uiTabEditStrings.Text = "Edit: Strings";
            // 
            // uiButtonSaveStrings
            // 
            this.uiButtonSaveStrings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiButtonSaveStrings.Location = new System.Drawing.Point(782, 6);
            this.uiButtonSaveStrings.Name = "uiButtonSaveStrings";
            this.uiButtonSaveStrings.Size = new System.Drawing.Size(156, 58);
            this.uiButtonSaveStrings.TabIndex = 5;
            this.uiButtonSaveStrings.Text = "SAVE";
            this.uiButtonSaveStrings.UseVisualStyleBackColor = true;
            this.uiButtonSaveStrings.Click += new System.EventHandler(this.uiButtonSaveStrings_Click);
            // 
            // uiEditStrings_Value
            // 
            this.uiEditStrings_Value.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiEditStrings_Value.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(32)))), ((int)(((byte)(29)))));
            this.uiEditStrings_Value.ForeColor = System.Drawing.Color.White;
            this.uiEditStrings_Value.Location = new System.Drawing.Point(9, 70);
            this.uiEditStrings_Value.Name = "uiEditStrings_Value";
            this.uiEditStrings_Value.Size = new System.Drawing.Size(929, 496);
            this.uiEditStrings_Value.TabIndex = 4;
            this.uiEditStrings_Value.Text = "";
            this.uiEditStrings_Value.TextChanged += new System.EventHandler(this.uiEditStrings_Value_TextChanged);
            // 
            // uiEditStrings_Language
            // 
            this.uiEditStrings_Language.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiEditStrings_Language.Enabled = false;
            this.uiEditStrings_Language.Location = new System.Drawing.Point(98, 38);
            this.uiEditStrings_Language.Name = "uiEditStrings_Language";
            this.uiEditStrings_Language.Size = new System.Drawing.Size(678, 22);
            this.uiEditStrings_Language.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Language:";
            // 
            // uiEditStrings_Key
            // 
            this.uiEditStrings_Key.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiEditStrings_Key.Enabled = false;
            this.uiEditStrings_Key.Location = new System.Drawing.Point(98, 6);
            this.uiEditStrings_Key.Name = "uiEditStrings_Key";
            this.uiEditStrings_Key.Size = new System.Drawing.Size(678, 22);
            this.uiEditStrings_Key.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Key string:";
            // 
            // uiTabEditObject
            // 
            this.uiTabEditObject.BackColor = System.Drawing.Color.Silver;
            this.uiTabEditObject.Controls.Add(this.splitContainer1);
            this.uiTabEditObject.Location = new System.Drawing.Point(4, 23);
            this.uiTabEditObject.Name = "uiTabEditObject";
            this.uiTabEditObject.Padding = new System.Windows.Forms.Padding(3);
            this.uiTabEditObject.Size = new System.Drawing.Size(944, 576);
            this.uiTabEditObject.TabIndex = 2;
            this.uiTabEditObject.Text = "Edit: Object";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.uiEditObject_AddShortNote);
            this.splitContainer1.Panel1.Controls.Add(this.uiEditObject_AddTitleString);
            this.splitContainer1.Panel1.Controls.Add(this.uiEditObject_CopyObject);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.uiObjectProps);
            this.splitContainer1.Size = new System.Drawing.Size(938, 570);
            this.splitContainer1.SplitterDistance = 364;
            this.splitContainer1.TabIndex = 0;
            // 
            // uiEditObject_AddShortNote
            // 
            this.uiEditObject_AddShortNote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiEditObject_AddShortNote.Location = new System.Drawing.Point(3, 71);
            this.uiEditObject_AddShortNote.Name = "uiEditObject_AddShortNote";
            this.uiEditObject_AddShortNote.Size = new System.Drawing.Size(358, 28);
            this.uiEditObject_AddShortNote.TabIndex = 2;
            this.uiEditObject_AddShortNote.Text = "Add shortnote string";
            this.uiEditObject_AddShortNote.UseVisualStyleBackColor = true;
            this.uiEditObject_AddShortNote.Click += new System.EventHandler(this.uiEditObject_AddShortNote_Click);
            // 
            // uiEditObject_AddTitleString
            // 
            this.uiEditObject_AddTitleString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiEditObject_AddTitleString.Location = new System.Drawing.Point(3, 37);
            this.uiEditObject_AddTitleString.Name = "uiEditObject_AddTitleString";
            this.uiEditObject_AddTitleString.Size = new System.Drawing.Size(358, 28);
            this.uiEditObject_AddTitleString.TabIndex = 1;
            this.uiEditObject_AddTitleString.Text = "Add title string";
            this.uiEditObject_AddTitleString.UseVisualStyleBackColor = true;
            this.uiEditObject_AddTitleString.Click += new System.EventHandler(this.uiEditObject_AddTitleString_Click);
            // 
            // uiEditObject_CopyObject
            // 
            this.uiEditObject_CopyObject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiEditObject_CopyObject.Location = new System.Drawing.Point(3, 3);
            this.uiEditObject_CopyObject.Name = "uiEditObject_CopyObject";
            this.uiEditObject_CopyObject.Size = new System.Drawing.Size(358, 28);
            this.uiEditObject_CopyObject.TabIndex = 0;
            this.uiEditObject_CopyObject.Text = "Clone this object";
            this.uiEditObject_CopyObject.UseVisualStyleBackColor = true;
            this.uiEditObject_CopyObject.Click += new System.EventHandler(this.uiEditObject_CopyObject_Click);
            // 
            // uiObjectProps
            // 
            this.uiObjectProps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiObjectProps.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.uiObjectProps.Location = new System.Drawing.Point(3, 3);
            this.uiObjectProps.Name = "uiObjectProps";
            this.uiObjectProps.Size = new System.Drawing.Size(564, 564);
            this.uiObjectProps.TabIndex = 0;
            this.uiObjectProps.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.uiObjectProps_PropertyValueChanged);
            // 
            // uiCommonIcons
            // 
            this.uiCommonIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("uiCommonIcons.ImageStream")));
            this.uiCommonIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.uiCommonIcons.Images.SetKeyName(0, "cog.png");
            this.uiCommonIcons.Images.SetKeyName(1, "magnifier.png");
            this.uiCommonIcons.Images.SetKeyName(2, "script_code.png");
            // 
            // uiOpenFDB
            // 
            this.uiOpenFDB.FileName = "data.fdb";
            this.uiOpenFDB.Filter = "FDB Files|data.fdb";
            this.uiOpenFDB.Title = "Open FDB";
            // 
            // uiSaveDialog
            // 
            this.uiSaveDialog.Filter = "DB files|*.db|Any files|*.*";
            this.uiSaveDialog.Title = "Save";
            // 
            // uiBrowseFolder
            // 
            this.uiBrowseFolder.SelectedPath = "c:\\runewaker\\resource";
            // 
            // htmlToolTip1
            // 
            this.htmlToolTip1.AllowLinksHandling = true;
            this.htmlToolTip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(32)))), ((int)(((byte)(29)))));
            this.htmlToolTip1.BaseStylesheet = null;
            this.htmlToolTip1.ForeColor = System.Drawing.Color.White;
            this.htmlToolTip1.MaximumSize = new System.Drawing.Size(0, 0);
            this.htmlToolTip1.OwnerDraw = true;
            this.htmlToolTip1.TooltipCssClass = "htmltooltip";
            // 
            // syntaxDocument1
            // 
            this.syntaxDocument1.Lines = new string[] {
        ""};
            this.syntaxDocument1.MaxUndoBufferSize = 1000;
            this.syntaxDocument1.Modified = false;
            this.syntaxDocument1.UndoStep = 0;
            // 
            // uiOpenGlobalIni
            // 
            this.uiOpenGlobalIni.FileName = "Global.ini";
            this.uiOpenGlobalIni.Filter = "Global.ini|Global.ini|All files|*.*";
            this.uiOpenGlobalIni.Title = "Find Global.ini";
            // 
            // MainForm
            // 
            this.AcceptButton = this.uiButtonDoSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 665);
            this.Controls.Add(this.uiTabs);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Verdana", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Runes of Magic Data Base editor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.uiTabs.ResumeLayout(false);
            this.uiTabSettings.ResumeLayout(false);
            this.uiTabSettings.PerformLayout();
            this.uiTabSearch.ResumeLayout(false);
            this.uiTabSearch.PerformLayout();
            this.uiTabAdvancedSearch.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.uiTabEditStrings.ResumeLayout(false);
            this.uiTabEditStrings.PerformLayout();
            this.uiTabEditObject.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel uiStatusLabel;
        private System.Windows.Forms.TabControl uiTabs;
        private System.Windows.Forms.TabPage uiTabSearch;
        private System.Windows.Forms.TabPage uiTabEditStrings;
        private System.Windows.Forms.Button uiButtonDoSearch;
        private System.Windows.Forms.TextBox uiSearchTextBox;
        private System.Windows.Forms.OpenFileDialog uiOpenFDB;
        private System.Windows.Forms.ListView uiSearchResults;
        private System.Windows.Forms.ColumnHeader uiSRViewColumn0;
        private System.Windows.Forms.ImageList uiListIcons;
        private System.Windows.Forms.RichTextBox uiEditStrings_Value;
        private System.Windows.Forms.TextBox uiEditStrings_Language;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox uiEditStrings_Key;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button uiButtonSaveStrings;
        private System.Windows.Forms.TabPage uiTabEditObject;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PropertyGrid uiObjectProps;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog uiSaveDialog;
        private System.Windows.Forms.Button uiEditObject_CopyObject;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newStringToolStripMenuItem;
        private System.Windows.Forms.Button uiEditObject_AddTitleString;
        private System.Windows.Forms.Button uiEditObject_AddShortNote;
        private System.Windows.Forms.CheckBox uiNoStrings;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox uiCurrentLangugae;
        private System.Windows.Forms.TabPage uiTabSettings;
        private System.Windows.Forms.Button uiBrowseDataDb;
        private System.Windows.Forms.TextBox uiCfgDataDb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button uiBrowseDataFdb;
        private System.Windows.Forms.TextBox uiCfgDataFdb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button uiCfgSaveButton;
        private System.Windows.Forms.FolderBrowserDialog uiBrowseFolder;
        private TheArtOfDev.HtmlRenderer.WinForms.HtmlToolTip htmlToolTip1;
        private System.Windows.Forms.TabPage uiTabAdvancedSearch;
        private TheArtOfDev.HtmlRenderer.WinForms.HtmlPanel uiAdvSearchResults;
        private Fireball.Windows.Forms.CodeEditorControl uiScript;
        private Fireball.Syntax.SyntaxDocument syntaxDocument1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button uiBrowseGlobalIni;
        private System.Windows.Forms.TextBox uiCfgPathGlobalIni;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.OpenFileDialog uiOpenGlobalIni;
        private System.Windows.Forms.ToolStripMenuItem utilitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminPanelToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton uiRunButton;
        private System.Windows.Forms.ImageList uiCommonIcons;
    }
}


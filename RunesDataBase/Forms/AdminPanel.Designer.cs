namespace RunesDataBase.Forms
{
    partial class AdminPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminPanel));
            this.uiTabs = new System.Windows.Forms.TabControl();
            this.uiTabAccounts = new System.Windows.Forms.TabPage();
            this.uiAccTable = new System.Windows.Forms.DataGridView();
            this.uiAccTableContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.uiTabMailing = new System.Windows.Forms.TabPage();
            this.uiTabIcons = new System.Windows.Forms.ImageList(this.components);
            this.uiMailProps = new System.Windows.Forms.PropertyGrid();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.uiAccRefreshButton = new System.Windows.Forms.ToolStripButton();
            this.uiAccSubmitButton = new System.Windows.Forms.ToolStripButton();
            this.uiMailSend = new System.Windows.Forms.ToolStripButton();
            this.AccountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uiTabs.SuspendLayout();
            this.uiTabAccounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiAccTable)).BeginInit();
            this.uiAccTableContextMenu.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.uiTabMailing.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AccountBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // uiTabs
            // 
            this.uiTabs.Controls.Add(this.uiTabAccounts);
            this.uiTabs.Controls.Add(this.uiTabMailing);
            this.uiTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTabs.ImageList = this.uiTabIcons;
            this.uiTabs.Location = new System.Drawing.Point(0, 0);
            this.uiTabs.Name = "uiTabs";
            this.uiTabs.SelectedIndex = 0;
            this.uiTabs.Size = new System.Drawing.Size(985, 664);
            this.uiTabs.TabIndex = 0;
            // 
            // uiTabAccounts
            // 
            this.uiTabAccounts.BackColor = System.Drawing.SystemColors.Control;
            this.uiTabAccounts.Controls.Add(this.uiAccTable);
            this.uiTabAccounts.Controls.Add(this.toolStrip1);
            this.uiTabAccounts.ImageKey = "user.png";
            this.uiTabAccounts.Location = new System.Drawing.Point(4, 23);
            this.uiTabAccounts.Name = "uiTabAccounts";
            this.uiTabAccounts.Padding = new System.Windows.Forms.Padding(3);
            this.uiTabAccounts.Size = new System.Drawing.Size(977, 637);
            this.uiTabAccounts.TabIndex = 1;
            this.uiTabAccounts.Text = "Accounts";
            // 
            // uiAccTable
            // 
            this.uiAccTable.AllowUserToAddRows = false;
            this.uiAccTable.AllowUserToOrderColumns = true;
            this.uiAccTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uiAccTable.ContextMenuStrip = this.uiAccTableContextMenu;
            this.uiAccTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiAccTable.Location = new System.Drawing.Point(3, 28);
            this.uiAccTable.Name = "uiAccTable";
            this.uiAccTable.Size = new System.Drawing.Size(971, 606);
            this.uiAccTable.TabIndex = 0;
            // 
            // uiAccTableContextMenu
            // 
            this.uiAccTableContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem});
            this.uiAccTableContextMenu.Name = "uiAccTableContextMenu";
            this.uiAccTableContextMenu.Size = new System.Drawing.Size(111, 26);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.newToolStripMenuItem.Text = "New ...";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uiAccRefreshButton,
            this.uiAccSubmitButton});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(971, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // uiTabMailing
            // 
            this.uiTabMailing.BackColor = System.Drawing.SystemColors.Control;
            this.uiTabMailing.Controls.Add(this.uiMailProps);
            this.uiTabMailing.Controls.Add(this.toolStrip2);
            this.uiTabMailing.ImageKey = "mail_yellow.png";
            this.uiTabMailing.Location = new System.Drawing.Point(4, 23);
            this.uiTabMailing.Name = "uiTabMailing";
            this.uiTabMailing.Padding = new System.Windows.Forms.Padding(3);
            this.uiTabMailing.Size = new System.Drawing.Size(977, 637);
            this.uiTabMailing.TabIndex = 0;
            this.uiTabMailing.Text = "Mailing";
            // 
            // uiTabIcons
            // 
            this.uiTabIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("uiTabIcons.ImageStream")));
            this.uiTabIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.uiTabIcons.Images.SetKeyName(0, "mail_yellow.png");
            this.uiTabIcons.Images.SetKeyName(1, "user.png");
            // 
            // uiMailProps
            // 
            this.uiMailProps.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.uiMailProps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiMailProps.Location = new System.Drawing.Point(3, 28);
            this.uiMailProps.Name = "uiMailProps";
            this.uiMailProps.Size = new System.Drawing.Size(971, 606);
            this.uiMailProps.TabIndex = 0;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uiMailSend});
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(971, 25);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // uiAccRefreshButton
            // 
            this.uiAccRefreshButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.uiAccRefreshButton.Image = global::RunesDataBase.Properties.Resources.update;
            this.uiAccRefreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiAccRefreshButton.Name = "uiAccRefreshButton";
            this.uiAccRefreshButton.Size = new System.Drawing.Size(23, 22);
            this.uiAccRefreshButton.Text = "Refresh";
            this.uiAccRefreshButton.Click += new System.EventHandler(this.uiAccRefreshButton_Click);
            // 
            // uiAccSubmitButton
            // 
            this.uiAccSubmitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.uiAccSubmitButton.Image = global::RunesDataBase.Properties.Resources.accept_button;
            this.uiAccSubmitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiAccSubmitButton.Name = "uiAccSubmitButton";
            this.uiAccSubmitButton.Size = new System.Drawing.Size(23, 22);
            this.uiAccSubmitButton.Text = "Submit changes";
            this.uiAccSubmitButton.Click += new System.EventHandler(this.uiAccSubmitButton_Click);
            // 
            // uiMailSend
            // 
            this.uiMailSend.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.uiMailSend.Image = global::RunesDataBase.Properties.Resources.mailing_list;
            this.uiMailSend.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiMailSend.Name = "uiMailSend";
            this.uiMailSend.Size = new System.Drawing.Size(23, 22);
            this.uiMailSend.Text = "Send mail";
            this.uiMailSend.Click += new System.EventHandler(this.uiMailSend_Click);
            // 
            // AdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 664);
            this.Controls.Add(this.uiTabs);
            this.Font = new System.Drawing.Font("Verdana", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "AdminPanel";
            this.Text = "RoM admin panel";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdminPanel_FormClosed);
            this.Load += new System.EventHandler(this.AdminPanel_Load);
            this.uiTabs.ResumeLayout(false);
            this.uiTabAccounts.ResumeLayout(false);
            this.uiTabAccounts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiAccTable)).EndInit();
            this.uiAccTableContextMenu.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.uiTabMailing.ResumeLayout(false);
            this.uiTabMailing.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AccountBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl uiTabs;
        private System.Windows.Forms.TabPage uiTabAccounts;
        private System.Windows.Forms.TabPage uiTabMailing;
        private System.Windows.Forms.ImageList uiTabIcons;
        private System.Windows.Forms.DataGridView uiAccTable;
        private System.Windows.Forms.ContextMenuStrip uiAccTableContextMenu;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.BindingSource AccountBindingSource;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton uiAccRefreshButton;
        private System.Windows.Forms.ToolStripButton uiAccSubmitButton;
        private System.Windows.Forms.PropertyGrid uiMailProps;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton uiMailSend;
    }
}
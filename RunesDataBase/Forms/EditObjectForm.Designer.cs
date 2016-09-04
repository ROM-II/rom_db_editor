namespace RunesDataBase.Forms
{
    partial class EditObjectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditObjectForm));
            this.uiObjectProps = new System.Windows.Forms.PropertyGrid();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.objectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cloneThisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteThisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stringsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editTitleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editShortNoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTitleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addShortNoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiObjectProps
            // 
            this.uiObjectProps.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.uiObjectProps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiObjectProps.Location = new System.Drawing.Point(0, 24);
            this.uiObjectProps.Name = "uiObjectProps";
            this.uiObjectProps.Size = new System.Drawing.Size(791, 645);
            this.uiObjectProps.TabIndex = 1;
            this.uiObjectProps.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.uiObjectProps_PropertyValueChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.objectToolStripMenuItem,
            this.stringsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(791, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // objectToolStripMenuItem
            // 
            this.objectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cloneThisToolStripMenuItem,
            this.deleteThisToolStripMenuItem});
            this.objectToolStripMenuItem.Name = "objectToolStripMenuItem";
            this.objectToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.objectToolStripMenuItem.Text = "Object";
            // 
            // cloneThisToolStripMenuItem
            // 
            this.cloneThisToolStripMenuItem.Name = "cloneThisToolStripMenuItem";
            this.cloneThisToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cloneThisToolStripMenuItem.Text = "Clone ...";
            this.cloneThisToolStripMenuItem.Click += new System.EventHandler(this.cloneThisToolStripMenuItem_Click);
            // 
            // deleteThisToolStripMenuItem
            // 
            this.deleteThisToolStripMenuItem.Enabled = false;
            this.deleteThisToolStripMenuItem.Name = "deleteThisToolStripMenuItem";
            this.deleteThisToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteThisToolStripMenuItem.Text = "Delete";
            this.deleteThisToolStripMenuItem.ToolTipText = "Not implemented yet";
            // 
            // stringsToolStripMenuItem
            // 
            this.stringsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTitleToolStripMenuItem,
            this.editTitleToolStripMenuItem,
            this.addShortNoteToolStripMenuItem,
            this.editShortNoteToolStripMenuItem});
            this.stringsToolStripMenuItem.Name = "stringsToolStripMenuItem";
            this.stringsToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.stringsToolStripMenuItem.Text = "Strings";
            // 
            // editTitleToolStripMenuItem
            // 
            this.editTitleToolStripMenuItem.Enabled = false;
            this.editTitleToolStripMenuItem.Name = "editTitleToolStripMenuItem";
            this.editTitleToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.editTitleToolStripMenuItem.Text = "Edit title";
            this.editTitleToolStripMenuItem.ToolTipText = "Not implemented yet";
            // 
            // editShortNoteToolStripMenuItem
            // 
            this.editShortNoteToolStripMenuItem.Enabled = false;
            this.editShortNoteToolStripMenuItem.Name = "editShortNoteToolStripMenuItem";
            this.editShortNoteToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.editShortNoteToolStripMenuItem.Text = "Edit short note";
            this.editShortNoteToolStripMenuItem.ToolTipText = "Not implemented yet";
            // 
            // addTitleToolStripMenuItem
            // 
            this.addTitleToolStripMenuItem.Name = "addTitleToolStripMenuItem";
            this.addTitleToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.addTitleToolStripMenuItem.Text = "Add title";
            this.addTitleToolStripMenuItem.Click += new System.EventHandler(this.addTitleToolStripMenuItem_Click);
            // 
            // addShortNoteToolStripMenuItem
            // 
            this.addShortNoteToolStripMenuItem.Name = "addShortNoteToolStripMenuItem";
            this.addShortNoteToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.addShortNoteToolStripMenuItem.Text = "Add short note";
            this.addShortNoteToolStripMenuItem.Click += new System.EventHandler(this.addShortNoteToolStripMenuItem_Click);
            // 
            // EditObjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 669);
            this.Controls.Add(this.uiObjectProps);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Verdana", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "EditObjectForm";
            this.Text = "EditObjectForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditObjectForm_FormClosed);
            this.Load += new System.EventHandler(this.EditObjectForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PropertyGrid uiObjectProps;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem stringsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem objectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cloneThisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteThisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editTitleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editShortNoteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addTitleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addShortNoteToolStripMenuItem;
    }
}
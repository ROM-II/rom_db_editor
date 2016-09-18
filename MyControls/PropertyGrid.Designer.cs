namespace MyControls
{
    partial class PropertyGrid
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.uiContainer = new System.Windows.Forms.Panel();
            this.uiTopToolstrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.uiDefaultButtonCategories = new System.Windows.Forms.ToolStripButton();
            this.uiDefaultButtonSortAlphabetical = new System.Windows.Forms.ToolStripButton();
            this.uiSplitpanel = new System.Windows.Forms.SplitContainer();
            this.uiContainer.SuspendLayout();
            this.uiTopToolstrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiSplitpanel)).BeginInit();
            this.uiSplitpanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiContainer
            // 
            this.uiContainer.Controls.Add(this.uiSplitpanel);
            this.uiContainer.Controls.Add(this.uiTopToolstrip);
            this.uiContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiContainer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.uiContainer.Location = new System.Drawing.Point(0, 0);
            this.uiContainer.Name = "uiContainer";
            this.uiContainer.Size = new System.Drawing.Size(289, 338);
            this.uiContainer.TabIndex = 0;
            // 
            // uiTopToolstrip
            // 
            this.uiTopToolstrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uiDefaultButtonCategories,
            this.uiDefaultButtonSortAlphabetical,
            this.toolStripSeparator1});
            this.uiTopToolstrip.Location = new System.Drawing.Point(0, 0);
            this.uiTopToolstrip.Name = "uiTopToolstrip";
            this.uiTopToolstrip.Size = new System.Drawing.Size(289, 25);
            this.uiTopToolstrip.TabIndex = 0;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // uiDefaultButtonCategories
            // 
            this.uiDefaultButtonCategories.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.uiDefaultButtonCategories.Image = global::MyControls.Properties.Resources.category;
            this.uiDefaultButtonCategories.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiDefaultButtonCategories.Name = "uiDefaultButtonCategories";
            this.uiDefaultButtonCategories.Size = new System.Drawing.Size(23, 22);
            this.uiDefaultButtonCategories.Text = "Group by categories";
            // 
            // uiDefaultButtonSortAlphabetical
            // 
            this.uiDefaultButtonSortAlphabetical.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.uiDefaultButtonSortAlphabetical.Image = global::MyControls.Properties.Resources.sort_alphabel_column;
            this.uiDefaultButtonSortAlphabetical.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiDefaultButtonSortAlphabetical.Name = "uiDefaultButtonSortAlphabetical";
            this.uiDefaultButtonSortAlphabetical.Size = new System.Drawing.Size(23, 22);
            this.uiDefaultButtonSortAlphabetical.Text = "Sort alphabetically";
            // 
            // uiSplitpanel
            // 
            this.uiSplitpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiSplitpanel.Location = new System.Drawing.Point(0, 25);
            this.uiSplitpanel.Name = "uiSplitpanel";
            this.uiSplitpanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.uiSplitpanel.Size = new System.Drawing.Size(289, 313);
            this.uiSplitpanel.SplitterDistance = 248;
            this.uiSplitpanel.TabIndex = 1;
            // 
            // PropertyGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uiContainer);
            this.Name = "PropertyGrid";
            this.Size = new System.Drawing.Size(289, 338);
            this.uiContainer.ResumeLayout(false);
            this.uiContainer.PerformLayout();
            this.uiTopToolstrip.ResumeLayout(false);
            this.uiTopToolstrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiSplitpanel)).EndInit();
            this.uiSplitpanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel uiContainer;
        private System.Windows.Forms.ToolStrip uiTopToolstrip;
        private System.Windows.Forms.ToolStripButton uiDefaultButtonCategories;
        private System.Windows.Forms.ToolStripButton uiDefaultButtonSortAlphabetical;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.SplitContainer uiSplitpanel;
    }
}

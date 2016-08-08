namespace RunesDataBase
{
    partial class SelectLanguagesForm
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
            this.uiLanguages = new System.Windows.Forms.CheckedListBox();
            this.uiOK = new System.Windows.Forms.Button();
            this.uiCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uiLanguages
            // 
            this.uiLanguages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiLanguages.FormattingEnabled = true;
            this.uiLanguages.Location = new System.Drawing.Point(12, 12);
            this.uiLanguages.Name = "uiLanguages";
            this.uiLanguages.Size = new System.Drawing.Size(607, 466);
            this.uiLanguages.TabIndex = 0;
            this.uiLanguages.SelectedValueChanged += new System.EventHandler(this.uiLanguages_SelectedValueChanged);
            // 
            // uiOK
            // 
            this.uiOK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiOK.Location = new System.Drawing.Point(12, 484);
            this.uiOK.Name = "uiOK";
            this.uiOK.Size = new System.Drawing.Size(367, 27);
            this.uiOK.TabIndex = 1;
            this.uiOK.Text = "OK";
            this.uiOK.UseVisualStyleBackColor = true;
            this.uiOK.Click += new System.EventHandler(this.uiOK_Click);
            // 
            // uiCancel
            // 
            this.uiCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uiCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uiCancel.Location = new System.Drawing.Point(385, 484);
            this.uiCancel.Name = "uiCancel";
            this.uiCancel.Size = new System.Drawing.Size(234, 27);
            this.uiCancel.TabIndex = 2;
            this.uiCancel.Text = "Cancel";
            this.uiCancel.UseVisualStyleBackColor = true;
            // 
            // SelectLanguagesForm
            // 
            this.AcceptButton = this.uiOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.uiCancel;
            this.ClientSize = new System.Drawing.Size(631, 523);
            this.Controls.Add(this.uiCancel);
            this.Controls.Add(this.uiOK);
            this.Controls.Add(this.uiLanguages);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectLanguagesForm";
            this.Text = "Select string.db ...";
            this.Load += new System.EventHandler(this.SelectLanguagesForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox uiLanguages;
        private System.Windows.Forms.Button uiOK;
        private System.Windows.Forms.Button uiCancel;
    }
}
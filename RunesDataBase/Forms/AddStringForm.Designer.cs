namespace RunesDataBase.Forms
{
    partial class AddStringForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.uiKey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.uiLanguages = new System.Windows.Forms.CheckedListBox();
            this.uiButtonAccept = new System.Windows.Forms.Button();
            this.uiButtonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Key:";
            // 
            // uiKey
            // 
            this.uiKey.Location = new System.Drawing.Point(60, 12);
            this.uiKey.Name = "uiKey";
            this.uiKey.Size = new System.Drawing.Size(479, 26);
            this.uiKey.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Languages:";
            // 
            // uiLanguages
            // 
            this.uiLanguages.FormattingEnabled = true;
            this.uiLanguages.Location = new System.Drawing.Point(15, 62);
            this.uiLanguages.Name = "uiLanguages";
            this.uiLanguages.Size = new System.Drawing.Size(524, 340);
            this.uiLanguages.TabIndex = 3;
            // 
            // uiButtonAccept
            // 
            this.uiButtonAccept.Location = new System.Drawing.Point(15, 408);
            this.uiButtonAccept.Name = "uiButtonAccept";
            this.uiButtonAccept.Size = new System.Drawing.Size(251, 29);
            this.uiButtonAccept.TabIndex = 4;
            this.uiButtonAccept.Text = "Ok";
            this.uiButtonAccept.UseVisualStyleBackColor = true;
            this.uiButtonAccept.Click += new System.EventHandler(this.uiButtonAccept_Click);
            // 
            // uiButtonCancel
            // 
            this.uiButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uiButtonCancel.Location = new System.Drawing.Point(272, 408);
            this.uiButtonCancel.Name = "uiButtonCancel";
            this.uiButtonCancel.Size = new System.Drawing.Size(267, 29);
            this.uiButtonCancel.TabIndex = 5;
            this.uiButtonCancel.Text = "Cancel";
            this.uiButtonCancel.UseVisualStyleBackColor = true;
            this.uiButtonCancel.Click += new System.EventHandler(this.uiButtonCancel_Click);
            // 
            // AddStringForm
            // 
            this.AcceptButton = this.uiButtonAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.uiButtonCancel;
            this.ClientSize = new System.Drawing.Size(562, 449);
            this.Controls.Add(this.uiButtonCancel);
            this.Controls.Add(this.uiButtonAccept);
            this.Controls.Add(this.uiLanguages);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.uiKey);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddStringForm";
            this.Text = "Add new string";
            this.Load += new System.EventHandler(this.AddStringForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uiKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox uiLanguages;
        private System.Windows.Forms.Button uiButtonAccept;
        private System.Windows.Forms.Button uiButtonCancel;
    }
}
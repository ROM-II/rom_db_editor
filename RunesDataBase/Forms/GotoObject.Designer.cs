namespace RunesDataBase.Forms
{
    partial class GotoObject
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
            this.uiGuid = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.uiDescription = new System.Windows.Forms.TextBox();
            this.uiAcceptButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.uiGuid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Object GUID:";
            // 
            // uiGuid
            // 
            this.uiGuid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiGuid.Location = new System.Drawing.Point(58, 27);
            this.uiGuid.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.uiGuid.Name = "uiGuid";
            this.uiGuid.Size = new System.Drawing.Size(157, 23);
            this.uiGuid.TabIndex = 1;
            this.uiGuid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.uiGuid.ThousandsSeparator = true;
            this.uiGuid.Value = new decimal(new int[] {
            100074,
            0,
            0,
            0});
            this.uiGuid.ValueChanged += new System.EventHandler(this.uiGuid_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Found object:";
            // 
            // uiDescription
            // 
            this.uiDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiDescription.Location = new System.Drawing.Point(12, 71);
            this.uiDescription.Multiline = true;
            this.uiDescription.Name = "uiDescription";
            this.uiDescription.ReadOnly = true;
            this.uiDescription.Size = new System.Drawing.Size(245, 135);
            this.uiDescription.TabIndex = 3;
            this.uiDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // uiAcceptButton
            // 
            this.uiAcceptButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiAcceptButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uiAcceptButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.uiAcceptButton.Location = new System.Drawing.Point(12, 212);
            this.uiAcceptButton.Name = "uiAcceptButton";
            this.uiAcceptButton.Size = new System.Drawing.Size(245, 26);
            this.uiAcceptButton.TabIndex = 4;
            this.uiAcceptButton.Text = "Go!";
            this.uiAcceptButton.UseVisualStyleBackColor = true;
            this.uiAcceptButton.Click += new System.EventHandler(this.uiAcceptButton_Click);
            // 
            // GotoObject
            // 
            this.AcceptButton = this.uiAcceptButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 250);
            this.Controls.Add(this.uiAcceptButton);
            this.Controls.Add(this.uiDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.uiGuid);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GotoObject";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Go to object";
            this.Load += new System.EventHandler(this.GotoObject_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiGuid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown uiGuid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox uiDescription;
        private System.Windows.Forms.Button uiAcceptButton;
    }
}
namespace RunesDataBase.Forms
{
    partial class NewAccount
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
            this.uiLogin = new System.Windows.Forms.TextBox();
            this.uiPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.uiButtonRegister = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login";
            // 
            // uiLogin
            // 
            this.uiLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiLogin.Location = new System.Drawing.Point(12, 26);
            this.uiLogin.Name = "uiLogin";
            this.uiLogin.Size = new System.Drawing.Size(234, 22);
            this.uiLogin.TabIndex = 1;
            this.uiLogin.TextChanged += new System.EventHandler(this.uiLogin_TextChanged);
            // 
            // uiPassword
            // 
            this.uiPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiPassword.Location = new System.Drawing.Point(12, 68);
            this.uiPassword.Name = "uiPassword";
            this.uiPassword.Size = new System.Drawing.Size(234, 22);
            this.uiPassword.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // uiButtonRegister
            // 
            this.uiButtonRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiButtonRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uiButtonRegister.Location = new System.Drawing.Point(116, 96);
            this.uiButtonRegister.Name = "uiButtonRegister";
            this.uiButtonRegister.Size = new System.Drawing.Size(130, 27);
            this.uiButtonRegister.TabIndex = 4;
            this.uiButtonRegister.Text = "Register";
            this.uiButtonRegister.UseVisualStyleBackColor = true;
            this.uiButtonRegister.Click += new System.EventHandler(this.uiButtonRegister_Click);
            // 
            // NewAccount
            // 
            this.AcceptButton = this.uiButtonRegister;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 133);
            this.Controls.Add(this.uiButtonRegister);
            this.Controls.Add(this.uiPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.uiLogin);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewAccount";
            this.Text = "New account";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uiLogin;
        private System.Windows.Forms.TextBox uiPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button uiButtonRegister;
    }
}
namespace Library_WinForm
{
    partial class Login
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
            this.boxID = new System.Windows.Forms.TextBox();
            this.boxPASS = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.labelID = new System.Windows.Forms.Label();
            this.labelPASS = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // boxID
            // 
            this.boxID.Location = new System.Drawing.Point(93, 12);
            this.boxID.Name = "boxID";
            this.boxID.Size = new System.Drawing.Size(100, 21);
            this.boxID.TabIndex = 0;
            // 
            // boxPASS
            // 
            this.boxPASS.Location = new System.Drawing.Point(93, 40);
            this.boxPASS.Name = "boxPASS";
            this.boxPASS.PasswordChar = '●';
            this.boxPASS.Size = new System.Drawing.Size(100, 21);
            this.boxPASS.TabIndex = 1;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(200, 12);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(73, 49);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(15, 15);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(16, 12);
            this.labelID.TabIndex = 3;
            this.labelID.Text = "ID";
            // 
            // labelPASS
            // 
            this.labelPASS.AutoSize = true;
            this.labelPASS.Location = new System.Drawing.Point(15, 43);
            this.labelPASS.Name = "labelPASS";
            this.labelPASS.Size = new System.Drawing.Size(72, 12);
            this.labelPASS.TabIndex = 4;
            this.labelPASS.Text = "PASSWORD";
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(12, 77);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(258, 23);
            this.btnRegister.TabIndex = 5;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(287, 105);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.labelPASS);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.boxPASS);
            this.Controls.Add(this.boxID);
            this.MaximizeBox = false;
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox boxID;
        private System.Windows.Forms.TextBox boxPASS;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Label labelPASS;
        private System.Windows.Forms.Button btnRegister;
    }
}
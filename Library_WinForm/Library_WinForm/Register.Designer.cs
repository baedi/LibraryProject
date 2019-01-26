namespace Library_WinForm
{
    partial class Register
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
            this.labelID = new System.Windows.Forms.Label();
            this.labelPass = new System.Windows.Forms.Label();
            this.rtxtID = new System.Windows.Forms.TextBox();
            this.rtxtPW = new System.Windows.Forms.TextBox();
            this.btnReg = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(12, 20);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(55, 12);
            this.labelID.TabIndex = 0;
            this.labelID.Text = "create ID";
            // 
            // labelPass
            // 
            this.labelPass.AutoSize = true;
            this.labelPass.Location = new System.Drawing.Point(12, 73);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(101, 12);
            this.labelPass.TabIndex = 1;
            this.labelPass.Text = "create Password";
            // 
            // rtxtID
            // 
            this.rtxtID.Location = new System.Drawing.Point(14, 35);
            this.rtxtID.Name = "rtxtID";
            this.rtxtID.Size = new System.Drawing.Size(186, 21);
            this.rtxtID.TabIndex = 2;
            // 
            // rtxtPW
            // 
            this.rtxtPW.Location = new System.Drawing.Point(14, 89);
            this.rtxtPW.Name = "rtxtPW";
            this.rtxtPW.PasswordChar = '●';
            this.rtxtPW.Size = new System.Drawing.Size(186, 21);
            this.rtxtPW.TabIndex = 3;
            // 
            // btnReg
            // 
            this.btnReg.Location = new System.Drawing.Point(14, 128);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(186, 23);
            this.btnReg.TabIndex = 4;
            this.btnReg.Text = "Register Account";
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(212, 163);
            this.Controls.Add(this.btnReg);
            this.Controls.Add(this.rtxtPW);
            this.Controls.Add(this.rtxtID);
            this.Controls.Add(this.labelPass);
            this.Controls.Add(this.labelID);
            this.MaximizeBox = false;
            this.Name = "Register";
            this.Text = "Register";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.TextBox rtxtID;
        private System.Windows.Forms.TextBox rtxtPW;
        private System.Windows.Forms.Button btnReg;
    }
}
namespace Library_WinForm
{
    partial class Blacklist
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
            this.blackview = new System.Windows.Forms.ListView();
            this.bname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.brdate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnbladd = new System.Windows.Forms.Button();
            this.btnbldelete = new System.Windows.Forms.Button();
            this.targetuser = new System.Windows.Forms.TextBox();
            this.tuser = new System.Windows.Forms.Label();
            this.numeric = new System.Windows.Forms.NumericUpDown();
            this.labellimit = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numeric)).BeginInit();
            this.SuspendLayout();
            // 
            // blackview
            // 
            this.blackview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.bname,
            this.brdate});
            this.blackview.Location = new System.Drawing.Point(12, 12);
            this.blackview.Name = "blackview";
            this.blackview.Size = new System.Drawing.Size(180, 238);
            this.blackview.TabIndex = 0;
            this.blackview.UseCompatibleStateImageBehavior = false;
            this.blackview.View = System.Windows.Forms.View.Details;
            this.blackview.Click += new System.EventHandler(this.blackview_Click);
            // 
            // bname
            // 
            this.bname.Text = "계정";
            // 
            // brdate
            // 
            this.brdate.Text = "정지 기간";
            this.brdate.Width = 100;
            // 
            // btnbladd
            // 
            this.btnbladd.Location = new System.Drawing.Point(200, 114);
            this.btnbladd.Name = "btnbladd";
            this.btnbladd.Size = new System.Drawing.Size(106, 30);
            this.btnbladd.TabIndex = 1;
            this.btnbladd.Text = "추가 / 기간변경";
            this.btnbladd.UseVisualStyleBackColor = true;
            this.btnbladd.Click += new System.EventHandler(this.btnbladd_Click);
            // 
            // btnbldelete
            // 
            this.btnbldelete.Location = new System.Drawing.Point(200, 220);
            this.btnbldelete.Name = "btnbldelete";
            this.btnbldelete.Size = new System.Drawing.Size(106, 30);
            this.btnbldelete.TabIndex = 2;
            this.btnbldelete.Text = "리스트 제거";
            this.btnbldelete.UseVisualStyleBackColor = true;
            this.btnbldelete.Click += new System.EventHandler(this.btnbldelete_Click);
            // 
            // targetuser
            // 
            this.targetuser.Location = new System.Drawing.Point(198, 27);
            this.targetuser.Name = "targetuser";
            this.targetuser.Size = new System.Drawing.Size(108, 21);
            this.targetuser.TabIndex = 3;
            // 
            // tuser
            // 
            this.tuser.AutoSize = true;
            this.tuser.Location = new System.Drawing.Point(198, 12);
            this.tuser.Name = "tuser";
            this.tuser.Size = new System.Drawing.Size(41, 12);
            this.tuser.TabIndex = 4;
            this.tuser.Text = "대상자";
            // 
            // numeric
            // 
            this.numeric.Location = new System.Drawing.Point(200, 76);
            this.numeric.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.numeric.Minimum = new decimal(new int[] {
            365,
            0,
            0,
            -2147483648});
            this.numeric.Name = "numeric";
            this.numeric.Size = new System.Drawing.Size(106, 21);
            this.numeric.TabIndex = 6;
            // 
            // labellimit
            // 
            this.labellimit.AutoSize = true;
            this.labellimit.Location = new System.Drawing.Point(200, 61);
            this.labellimit.Name = "labellimit";
            this.labellimit.Size = new System.Drawing.Size(57, 12);
            this.labellimit.TabIndex = 7;
            this.labellimit.Text = "제한 기간";
            // 
            // Blacklist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(318, 262);
            this.Controls.Add(this.labellimit);
            this.Controls.Add(this.numeric);
            this.Controls.Add(this.tuser);
            this.Controls.Add(this.targetuser);
            this.Controls.Add(this.btnbldelete);
            this.Controls.Add(this.btnbladd);
            this.Controls.Add(this.blackview);
            this.MaximizeBox = false;
            this.Name = "Blacklist";
            this.Text = "Blacklist";
            this.Load += new System.EventHandler(this.Blacklist_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView blackview;
        private System.Windows.Forms.ColumnHeader bname;
        private System.Windows.Forms.ColumnHeader brdate;
        private System.Windows.Forms.Button btnbladd;
        private System.Windows.Forms.Button btnbldelete;
        private System.Windows.Forms.TextBox targetuser;
        private System.Windows.Forms.Label tuser;
        private System.Windows.Forms.NumericUpDown numeric;
        private System.Windows.Forms.Label labellimit;
    }
}
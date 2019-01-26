namespace Library_WinForm
{
    partial class Log
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
            this.logView = new System.Windows.Forms.ListView();
            this.date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.logname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.logtext = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // logView
            // 
            this.logView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.date,
            this.logname,
            this.logtext});
            this.logView.Location = new System.Drawing.Point(12, 12);
            this.logView.Name = "logView";
            this.logView.Size = new System.Drawing.Size(642, 365);
            this.logView.TabIndex = 0;
            this.logView.UseCompatibleStateImageBehavior = false;
            this.logView.View = System.Windows.Forms.View.Details;
            // 
            // date
            // 
            this.date.Text = "날짜";
            this.date.Width = 150;
            // 
            // logname
            // 
            this.logname.Text = "계정";
            this.logname.Width = 80;
            // 
            // logtext
            // 
            this.logtext.Text = "내용";
            this.logtext.Width = 400;
            // 
            // Log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(666, 417);
            this.Controls.Add(this.logView);
            this.MaximizeBox = false;
            this.Name = "Log";
            this.Text = "Library Log";
            this.Load += new System.EventHandler(this.Log_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView logView;
        private System.Windows.Forms.ColumnHeader date;
        private System.Windows.Forms.ColumnHeader logname;
        private System.Windows.Forms.ColumnHeader logtext;
    }
}
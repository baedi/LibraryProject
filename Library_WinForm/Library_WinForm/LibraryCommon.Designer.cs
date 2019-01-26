namespace Library_WinForm
{
    partial class LibraryCommon
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
            this.labelUser = new System.Windows.Forms.Label();
            this.boxUser = new System.Windows.Forms.TextBox();
            this.getReturn = new System.Windows.Forms.TextBox();
            this.returnLabel = new System.Windows.Forms.Label();
            this.getToday = new System.Windows.Forms.TextBox();
            this.todayLabel = new System.Windows.Forms.Label();
            this.listBook = new System.Windows.Forms.ListView();
            this.cNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cIsbn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cBookname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cAuthor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cCompany = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cStock = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.userView = new System.Windows.Forms.ListView();
            this.c2number = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c2isbn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c2bookname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c2bdate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c2rdate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c2info = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnBorrow = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.boxSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.labelISBN = new System.Windows.Forms.Label();
            this.boxIsbn1 = new System.Windows.Forms.TextBox();
            this.boxIsbn2 = new System.Windows.Forms.TextBox();
            this.btnlimit = new System.Windows.Forms.Button();
            this.userstate = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(13, 13);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(53, 12);
            this.labelUser.TabIndex = 0;
            this.labelUser.Text = "사용자 : ";
            // 
            // boxUser
            // 
            this.boxUser.Enabled = false;
            this.boxUser.Location = new System.Drawing.Point(72, 10);
            this.boxUser.Name = "boxUser";
            this.boxUser.Size = new System.Drawing.Size(100, 21);
            this.boxUser.TabIndex = 1;
            // 
            // getReturn
            // 
            this.getReturn.Enabled = false;
            this.getReturn.Location = new System.Drawing.Point(479, 10);
            this.getReturn.Name = "getReturn";
            this.getReturn.Size = new System.Drawing.Size(80, 21);
            this.getReturn.TabIndex = 23;
            // 
            // returnLabel
            // 
            this.returnLabel.AutoSize = true;
            this.returnLabel.Location = new System.Drawing.Point(420, 13);
            this.returnLabel.Name = "returnLabel";
            this.returnLabel.Size = new System.Drawing.Size(53, 12);
            this.returnLabel.TabIndex = 22;
            this.returnLabel.Text = "Return : ";
            // 
            // getToday
            // 
            this.getToday.Enabled = false;
            this.getToday.Location = new System.Drawing.Point(318, 10);
            this.getToday.Name = "getToday";
            this.getToday.Size = new System.Drawing.Size(80, 21);
            this.getToday.TabIndex = 21;
            // 
            // todayLabel
            // 
            this.todayLabel.AutoSize = true;
            this.todayLabel.Location = new System.Drawing.Point(259, 13);
            this.todayLabel.Name = "todayLabel";
            this.todayLabel.Size = new System.Drawing.Size(53, 12);
            this.todayLabel.TabIndex = 20;
            this.todayLabel.Text = "Today : ";
            // 
            // listBook
            // 
            this.listBook.BackColor = System.Drawing.SystemColors.Window;
            this.listBook.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cNumber,
            this.cIsbn,
            this.cBookname,
            this.cAuthor,
            this.cCompany,
            this.cStock});
            this.listBook.Location = new System.Drawing.Point(17, 37);
            this.listBook.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBook.MultiSelect = false;
            this.listBook.Name = "listBook";
            this.listBook.Size = new System.Drawing.Size(545, 159);
            this.listBook.TabIndex = 24;
            this.listBook.UseCompatibleStateImageBehavior = false;
            this.listBook.View = System.Windows.Forms.View.Details;
            this.listBook.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listBook_ColumnClick);
            this.listBook.Click += new System.EventHandler(this.listBook_Click);
            // 
            // cNumber
            // 
            this.cNumber.Text = "No";
            this.cNumber.Width = 30;
            // 
            // cIsbn
            // 
            this.cIsbn.Text = "ISBN";
            this.cIsbn.Width = 125;
            // 
            // cBookname
            // 
            this.cBookname.Text = "책 이름";
            this.cBookname.Width = 160;
            // 
            // cAuthor
            // 
            this.cAuthor.Text = "저자";
            this.cAuthor.Width = 80;
            // 
            // cCompany
            // 
            this.cCompany.Text = "출판사";
            this.cCompany.Width = 80;
            // 
            // cStock
            // 
            this.cStock.Text = "재고";
            this.cStock.Width = 50;
            // 
            // userView
            // 
            this.userView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.c2number,
            this.c2isbn,
            this.c2bookname,
            this.c2bdate,
            this.c2rdate,
            this.c2info});
            this.userView.Location = new System.Drawing.Point(17, 231);
            this.userView.MultiSelect = false;
            this.userView.Name = "userView";
            this.userView.Size = new System.Drawing.Size(545, 159);
            this.userView.TabIndex = 25;
            this.userView.UseCompatibleStateImageBehavior = false;
            this.userView.View = System.Windows.Forms.View.Details;
            this.userView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.userView_ColumnClick);
            this.userView.Click += new System.EventHandler(this.userView_Click);
            // 
            // c2number
            // 
            this.c2number.Text = "No";
            this.c2number.Width = 30;
            // 
            // c2isbn
            // 
            this.c2isbn.Text = "ISBN";
            this.c2isbn.Width = 125;
            // 
            // c2bookname
            // 
            this.c2bookname.Text = "책 이름";
            this.c2bookname.Width = 160;
            // 
            // c2bdate
            // 
            this.c2bdate.Text = "대출일자";
            this.c2bdate.Width = 80;
            // 
            // c2rdate
            // 
            this.c2rdate.Text = "반납일자";
            this.c2rdate.Width = 80;
            // 
            // c2info
            // 
            this.c2info.Text = "상태";
            this.c2info.Width = 50;
            // 
            // btnBorrow
            // 
            this.btnBorrow.Location = new System.Drawing.Point(17, 204);
            this.btnBorrow.Name = "btnBorrow";
            this.btnBorrow.Size = new System.Drawing.Size(70, 21);
            this.btnBorrow.TabIndex = 26;
            this.btnBorrow.Text = "▼ 대출";
            this.btnBorrow.UseVisualStyleBackColor = true;
            this.btnBorrow.Click += new System.EventHandler(this.btnBorrow_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(93, 204);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(70, 21);
            this.btnReturn.TabIndex = 27;
            this.btnReturn.Text = "▲ 반납";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // boxSearch
            // 
            this.boxSearch.Location = new System.Drawing.Point(292, 204);
            this.boxSearch.Name = "boxSearch";
            this.boxSearch.Size = new System.Drawing.Size(191, 21);
            this.boxSearch.TabIndex = 28;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(489, 204);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(70, 21);
            this.btnSearch.TabIndex = 29;
            this.btnSearch.Text = "검색";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // labelISBN
            // 
            this.labelISBN.AutoSize = true;
            this.labelISBN.Location = new System.Drawing.Point(17, 404);
            this.labelISBN.Name = "labelISBN";
            this.labelISBN.Size = new System.Drawing.Size(33, 12);
            this.labelISBN.TabIndex = 30;
            this.labelISBN.Text = "ISBN";
            // 
            // boxIsbn1
            // 
            this.boxIsbn1.Enabled = false;
            this.boxIsbn1.Location = new System.Drawing.Point(56, 401);
            this.boxIsbn1.Name = "boxIsbn1";
            this.boxIsbn1.Size = new System.Drawing.Size(143, 21);
            this.boxIsbn1.TabIndex = 31;
            // 
            // boxIsbn2
            // 
            this.boxIsbn2.Enabled = false;
            this.boxIsbn2.Location = new System.Drawing.Point(205, 401);
            this.boxIsbn2.Name = "boxIsbn2";
            this.boxIsbn2.Size = new System.Drawing.Size(143, 21);
            this.boxIsbn2.TabIndex = 32;
            // 
            // btnlimit
            // 
            this.btnlimit.Enabled = false;
            this.btnlimit.Location = new System.Drawing.Point(169, 204);
            this.btnlimit.Name = "btnlimit";
            this.btnlimit.Size = new System.Drawing.Size(70, 20);
            this.btnlimit.TabIndex = 33;
            this.btnlimit.Text = "☆연장";
            this.btnlimit.UseVisualStyleBackColor = true;
            this.btnlimit.Click += new System.EventHandler(this.btnlimit_Click);
            // 
            // userstate
            // 
            this.userstate.Enabled = false;
            this.userstate.Location = new System.Drawing.Point(178, 10);
            this.userstate.Name = "userstate";
            this.userstate.Size = new System.Drawing.Size(70, 21);
            this.userstate.TabIndex = 34;
            // 
            // LibraryCommon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(575, 428);
            this.Controls.Add(this.userstate);
            this.Controls.Add(this.btnlimit);
            this.Controls.Add(this.boxIsbn2);
            this.Controls.Add(this.boxIsbn1);
            this.Controls.Add(this.labelISBN);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.boxSearch);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnBorrow);
            this.Controls.Add(this.userView);
            this.Controls.Add(this.listBook);
            this.Controls.Add(this.getReturn);
            this.Controls.Add(this.returnLabel);
            this.Controls.Add(this.getToday);
            this.Controls.Add(this.todayLabel);
            this.Controls.Add(this.boxUser);
            this.Controls.Add(this.labelUser);
            this.MaximizeBox = false;
            this.Name = "LibraryCommon";
            this.Text = "Library Program";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LibraryCommon_FormClosing);
            this.Load += new System.EventHandler(this.LibraryCommon_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.TextBox boxUser;
        private System.Windows.Forms.TextBox getReturn;
        private System.Windows.Forms.Label returnLabel;
        private System.Windows.Forms.TextBox getToday;
        private System.Windows.Forms.Label todayLabel;
        private System.Windows.Forms.ListView listBook;
        private System.Windows.Forms.ColumnHeader cNumber;
        private System.Windows.Forms.ColumnHeader cIsbn;
        private System.Windows.Forms.ColumnHeader cBookname;
        private System.Windows.Forms.ColumnHeader cAuthor;
        private System.Windows.Forms.ColumnHeader cCompany;
        private System.Windows.Forms.ColumnHeader cStock;
        private System.Windows.Forms.ListView userView;
        private System.Windows.Forms.ColumnHeader c2number;
        private System.Windows.Forms.ColumnHeader c2isbn;
        private System.Windows.Forms.ColumnHeader c2bookname;
        private System.Windows.Forms.ColumnHeader c2bdate;
        private System.Windows.Forms.ColumnHeader c2rdate;
        private System.Windows.Forms.ColumnHeader c2info;
        private System.Windows.Forms.Button btnBorrow;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.TextBox boxSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label labelISBN;
        private System.Windows.Forms.TextBox boxIsbn1;
        private System.Windows.Forms.TextBox boxIsbn2;
        private System.Windows.Forms.Button btnlimit;
        private System.Windows.Forms.TextBox userstate;
    }
}
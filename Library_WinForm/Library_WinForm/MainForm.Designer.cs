namespace Library_WinForm
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.boxIsbn = new System.Windows.Forms.TextBox();
            this.boxName = new System.Windows.Forms.TextBox();
            this.boxAuthor = new System.Windows.Forms.TextBox();
            this.boxCompany = new System.Windows.Forms.TextBox();
            this.boxStock = new System.Windows.Forms.TextBox();
            this.labelIsbn = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.labelCompany = new System.Windows.Forms.Label();
            this.labelStock = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonModify = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.listBook = new System.Windows.Forms.ListView();
            this.cNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cIsbn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cBookname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cAuthor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cCompany = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cStock = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.boxSearch = new System.Windows.Forms.TextBox();
            this.boxNumber = new System.Windows.Forms.TextBox();
            this.number = new System.Windows.Forms.Label();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.userView = new System.Windows.Forms.ListView();
            this.c2borrower = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c2isbn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c2bookname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c2bdate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c2rdate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c2limit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c2info = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.todayLabel = new System.Windows.Forms.Label();
            this.getToday = new System.Windows.Forms.TextBox();
            this.returnLabel = new System.Windows.Forms.Label();
            this.getReturn = new System.Windows.Forms.TextBox();
            this.btnlog = new System.Windows.Forms.Button();
            this.btnblack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // boxIsbn
            // 
            this.boxIsbn.Enabled = false;
            this.boxIsbn.Location = new System.Drawing.Point(66, 30);
            this.boxIsbn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.boxIsbn.Name = "boxIsbn";
            this.boxIsbn.Size = new System.Drawing.Size(491, 21);
            this.boxIsbn.TabIndex = 1;
            // 
            // boxName
            // 
            this.boxName.Enabled = false;
            this.boxName.Location = new System.Drawing.Point(66, 54);
            this.boxName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.boxName.Name = "boxName";
            this.boxName.Size = new System.Drawing.Size(490, 21);
            this.boxName.TabIndex = 2;
            // 
            // boxAuthor
            // 
            this.boxAuthor.Enabled = false;
            this.boxAuthor.Location = new System.Drawing.Point(66, 80);
            this.boxAuthor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.boxAuthor.Name = "boxAuthor";
            this.boxAuthor.Size = new System.Drawing.Size(490, 21);
            this.boxAuthor.TabIndex = 3;
            // 
            // boxCompany
            // 
            this.boxCompany.Enabled = false;
            this.boxCompany.Location = new System.Drawing.Point(66, 105);
            this.boxCompany.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.boxCompany.Name = "boxCompany";
            this.boxCompany.Size = new System.Drawing.Size(490, 21);
            this.boxCompany.TabIndex = 4;
            // 
            // boxStock
            // 
            this.boxStock.Enabled = false;
            this.boxStock.Location = new System.Drawing.Point(66, 130);
            this.boxStock.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.boxStock.Name = "boxStock";
            this.boxStock.Size = new System.Drawing.Size(490, 21);
            this.boxStock.TabIndex = 5;
            // 
            // labelIsbn
            // 
            this.labelIsbn.AutoSize = true;
            this.labelIsbn.Location = new System.Drawing.Point(11, 32);
            this.labelIsbn.Name = "labelIsbn";
            this.labelIsbn.Size = new System.Drawing.Size(33, 12);
            this.labelIsbn.TabIndex = 6;
            this.labelIsbn.Text = "ISBN";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(11, 57);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(45, 12);
            this.labelName.TabIndex = 7;
            this.labelName.Text = "책 이름";
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Location = new System.Drawing.Point(11, 82);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(29, 12);
            this.labelAuthor.TabIndex = 8;
            this.labelAuthor.Text = "저자";
            // 
            // labelCompany
            // 
            this.labelCompany.AutoSize = true;
            this.labelCompany.Location = new System.Drawing.Point(11, 107);
            this.labelCompany.Name = "labelCompany";
            this.labelCompany.Size = new System.Drawing.Size(41, 12);
            this.labelCompany.TabIndex = 9;
            this.labelCompany.Text = "출판사";
            // 
            // labelStock
            // 
            this.labelStock.AutoSize = true;
            this.labelStock.Location = new System.Drawing.Point(11, 132);
            this.labelStock.Name = "labelStock";
            this.labelStock.Size = new System.Drawing.Size(29, 12);
            this.labelStock.TabIndex = 10;
            this.labelStock.Text = "재고";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(14, 165);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(87, 20);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "추가";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(378, 557);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(87, 20);
            this.buttonDelete.TabIndex = 1;
            this.buttonDelete.Text = "삭제";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonModify
            // 
            this.buttonModify.Enabled = false;
            this.buttonModify.Location = new System.Drawing.Point(106, 165);
            this.buttonModify.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonModify.Name = "buttonModify";
            this.buttonModify.Size = new System.Drawing.Size(87, 20);
            this.buttonModify.TabIndex = 2;
            this.buttonModify.Text = "수정";
            this.buttonModify.UseVisualStyleBackColor = true;
            this.buttonModify.Click += new System.EventHandler(this.buttonModify_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(470, 165);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(87, 20);
            this.buttonSearch.TabIndex = 4;
            this.buttonSearch.Text = "검색";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
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
            this.listBook.Location = new System.Drawing.Point(15, 197);
            this.listBook.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBook.MultiSelect = false;
            this.listBook.Name = "listBook";
            this.listBook.Size = new System.Drawing.Size(542, 343);
            this.listBook.TabIndex = 11;
            this.listBook.UseCompatibleStateImageBehavior = false;
            this.listBook.View = System.Windows.Forms.View.Details;
            this.listBook.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listBook_ColumnClick);
            this.listBook.Click += new System.EventHandler(this.listBook_Click);
            // 
            // cNumber
            // 
            this.cNumber.Text = "No";
            this.cNumber.Width = 35;
            // 
            // cIsbn
            // 
            this.cIsbn.Text = "ISBN";
            this.cIsbn.Width = 120;
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
            this.cStock.Width = 40;
            // 
            // boxSearch
            // 
            this.boxSearch.Location = new System.Drawing.Point(237, 165);
            this.boxSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.boxSearch.Name = "boxSearch";
            this.boxSearch.Size = new System.Drawing.Size(228, 21);
            this.boxSearch.TabIndex = 12;
            // 
            // boxNumber
            // 
            this.boxNumber.Enabled = false;
            this.boxNumber.Location = new System.Drawing.Point(57, 557);
            this.boxNumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.boxNumber.Name = "boxNumber";
            this.boxNumber.Size = new System.Drawing.Size(136, 21);
            this.boxNumber.TabIndex = 13;
            // 
            // number
            // 
            this.number.AutoSize = true;
            this.number.Location = new System.Drawing.Point(18, 561);
            this.number.Name = "number";
            this.number.Size = new System.Drawing.Size(33, 12);
            this.number.TabIndex = 14;
            this.number.Text = "ISBN";
            // 
            // buttonCheck
            // 
            this.buttonCheck.Location = new System.Drawing.Point(471, 557);
            this.buttonCheck.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(87, 20);
            this.buttonCheck.TabIndex = 5;
            this.buttonCheck.Text = "조회";
            this.buttonCheck.UseVisualStyleBackColor = true;
            this.buttonCheck.Click += new System.EventHandler(this.buttonCheck_Click);
            // 
            // userView
            // 
            this.userView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.c2borrower,
            this.c2isbn,
            this.c2bookname,
            this.c2bdate,
            this.c2rdate,
            this.c2limit,
            this.c2info});
            this.userView.Location = new System.Drawing.Point(589, 54);
            this.userView.Name = "userView";
            this.userView.Size = new System.Drawing.Size(616, 486);
            this.userView.TabIndex = 15;
            this.userView.UseCompatibleStateImageBehavior = false;
            this.userView.View = System.Windows.Forms.View.Details;
            this.userView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.userView_ColumnClick);
            // 
            // c2borrower
            // 
            this.c2borrower.Text = "대출자";
            // 
            // c2isbn
            // 
            this.c2isbn.Text = "ISBN";
            this.c2isbn.Width = 120;
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
            // c2limit
            // 
            this.c2limit.Text = "연장";
            this.c2limit.Width = 40;
            // 
            // c2info
            // 
            this.c2info.Text = "상태";
            this.c2info.Width = 50;
            // 
            // todayLabel
            // 
            this.todayLabel.AutoSize = true;
            this.todayLabel.Location = new System.Drawing.Point(899, 28);
            this.todayLabel.Name = "todayLabel";
            this.todayLabel.Size = new System.Drawing.Size(53, 12);
            this.todayLabel.TabIndex = 16;
            this.todayLabel.Text = "Today : ";
            // 
            // getToday
            // 
            this.getToday.Enabled = false;
            this.getToday.Location = new System.Drawing.Point(958, 23);
            this.getToday.Name = "getToday";
            this.getToday.Size = new System.Drawing.Size(80, 21);
            this.getToday.TabIndex = 17;
            // 
            // returnLabel
            // 
            this.returnLabel.AutoSize = true;
            this.returnLabel.Location = new System.Drawing.Point(1066, 27);
            this.returnLabel.Name = "returnLabel";
            this.returnLabel.Size = new System.Drawing.Size(53, 12);
            this.returnLabel.TabIndex = 18;
            this.returnLabel.Text = "Return : ";
            // 
            // getReturn
            // 
            this.getReturn.Enabled = false;
            this.getReturn.Location = new System.Drawing.Point(1125, 23);
            this.getReturn.Name = "getReturn";
            this.getReturn.Size = new System.Drawing.Size(80, 21);
            this.getReturn.TabIndex = 19;
            // 
            // btnlog
            // 
            this.btnlog.Location = new System.Drawing.Point(589, 29);
            this.btnlog.Name = "btnlog";
            this.btnlog.Size = new System.Drawing.Size(86, 20);
            this.btnlog.TabIndex = 20;
            this.btnlog.Text = "이용 로그";
            this.btnlog.UseVisualStyleBackColor = true;
            this.btnlog.Click += new System.EventHandler(this.btnlog_Click);
            // 
            // btnblack
            // 
            this.btnblack.Location = new System.Drawing.Point(681, 28);
            this.btnblack.Name = "btnblack";
            this.btnblack.Size = new System.Drawing.Size(86, 20);
            this.btnblack.TabIndex = 21;
            this.btnblack.Text = "블랙리스트";
            this.btnblack.UseVisualStyleBackColor = true;
            this.btnblack.Click += new System.EventHandler(this.btnblack_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1231, 588);
            this.Controls.Add(this.btnblack);
            this.Controls.Add(this.btnlog);
            this.Controls.Add(this.getReturn);
            this.Controls.Add(this.returnLabel);
            this.Controls.Add(this.getToday);
            this.Controls.Add(this.todayLabel);
            this.Controls.Add(this.userView);
            this.Controls.Add(this.number);
            this.Controls.Add(this.boxNumber);
            this.Controls.Add(this.boxSearch);
            this.Controls.Add(this.listBook);
            this.Controls.Add(this.buttonCheck);
            this.Controls.Add(this.labelStock);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.labelCompany);
            this.Controls.Add(this.labelAuthor);
            this.Controls.Add(this.buttonModify);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.labelIsbn);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.boxStock);
            this.Controls.Add(this.boxCompany);
            this.Controls.Add(this.boxAuthor);
            this.Controls.Add(this.boxName);
            this.Controls.Add(this.boxIsbn);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Library Program (manage mode)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox boxIsbn;
        private System.Windows.Forms.TextBox boxName;
        private System.Windows.Forms.TextBox boxAuthor;
        private System.Windows.Forms.TextBox boxCompany;
        private System.Windows.Forms.TextBox boxStock;
        private System.Windows.Forms.Label labelIsbn;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.Label labelCompany;
        private System.Windows.Forms.Label labelStock;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonModify;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.ListView listBook;
        private System.Windows.Forms.TextBox boxSearch;
        private System.Windows.Forms.TextBox boxNumber;
        private System.Windows.Forms.Label number;
        private System.Windows.Forms.Button buttonCheck;
        private System.Windows.Forms.ColumnHeader cNumber;
        private System.Windows.Forms.ColumnHeader cIsbn;
        private System.Windows.Forms.ColumnHeader cBookname;
        private System.Windows.Forms.ColumnHeader cAuthor;
        private System.Windows.Forms.ColumnHeader cCompany;
        private System.Windows.Forms.ColumnHeader cStock;
        private System.Windows.Forms.ListView userView;
        private System.Windows.Forms.ColumnHeader c2borrower;
        private System.Windows.Forms.ColumnHeader c2isbn;
        private System.Windows.Forms.ColumnHeader c2bookname;
        private System.Windows.Forms.ColumnHeader c2bdate;
        private System.Windows.Forms.ColumnHeader c2rdate;
        private System.Windows.Forms.ColumnHeader c2limit;
        private System.Windows.Forms.Label todayLabel;
        private System.Windows.Forms.TextBox getToday;
        private System.Windows.Forms.Label returnLabel;
        private System.Windows.Forms.TextBox getReturn;
        private System.Windows.Forms.ColumnHeader c2info;
        private System.Windows.Forms.Button btnlog;
        private System.Windows.Forms.Button btnblack;
    }
}


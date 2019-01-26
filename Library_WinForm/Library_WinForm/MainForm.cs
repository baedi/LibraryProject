using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections;

namespace Library_WinForm
{
    public partial class MainForm : Form
    {
        private MySqlConnection conn;           // 데이터베이스(DB) 전용 객체
        private MySqlCommand cmd;               // DB 명령어 전용 객체
        private ArrayList tempIsbn;             // DB Primary Key인 ISBN을 받아오기 위한 용도
        private ArrayList tempIsbn2;

        // 상수 관련 멤버변수
        private const string YMD = "yy-MM-dd";  // 날짜 불러오기 용도

        // 생성자
        public MainForm(string[] masteraccount) {

            // DB 연동 명령어 및 가져온 정보 지우기
            conn = new MySqlConnection($"server=localhost;user id={masteraccount[0]}; password={masteraccount[1]}; database=libraryDB;");
            
            InitializeComponent();
        }



        // ### 데이터베이스 연동 메소드 ###
        private void MainForm_Load(object sender, EventArgs e)
        {
            try   { conn.Open(); conn.Close(); }
            catch { MessageBox.Show("MySQL DB 연결 실패"); Application.Exit(); }

            getToday.Text = DateTime.Now.ToString("yyyy-MM-dd");
            getReturn.Text = DateTime.Now.AddDays(7).ToString("yyyy-MM-dd");
            Check();
        }



        // ### 도서 추가 관련 메소드 ###
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // 입력 바 비활성화 상태일 경우
            if (boxIsbn.Enabled == false) TextBoxEnable(true);

            // 입력 바 활성화 상태일 경우
            else 
            {
                // 입력이 안 된 것이 있는 경우 (간이 예외처리)
                if (boxIsbn.Text == "" || boxName.Text == "" || boxAuthor.Text == "" || boxCompany.Text == "" || boxStock.Text == "")
                    MessageBox.Show("입력하지 않은 정보가 있습니다. 정확히 기재해주세요.");

                else if (int.Parse(boxStock.Text) <= 0 || int.Parse(boxStock.Text) > 99)
                    MessageBox.Show("유효한 재고 수를 입력해주세요.");

                // 모든 정보가 입력되었을 경우
                else
                {
                    try
                    {
                        conn.Open();                 // 데이터베이스 연동
                        cmd = new MySqlCommand
                            ($"INSERT INTO booklist VALUES ('{boxIsbn.Text}','{boxName.Text}', '{boxAuthor.Text}', '{boxCompany.Text}', '{boxStock.Text}');", conn);

                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    catch
                    {
                        MessageBox.Show("데이터베이스에 데이터를 다루는 과정에서 문제가 발생하였습니다.\n 프로그램이 강제 종료됩니다.");
                        Application.Exit();
                    }

                    TextBoxEnable(false);       // 텍스트박스 내용물 지우기
                    ControlEnableCheck(true);   // 추가된 이후 나머지 버튼들 활성화시킴
                    Check();
                }

            }
        }



        // ### 도서 제거 관련 메소드 ###
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (boxNumber.Text != "")
            {

                // Yes를 선택할 경우 해당 항목을 삭제함.
                if (MessageBox.Show("정말로 해당 항목을 삭제하시겠습니까?\n대출중인 정보도 함께 제거됩니다.", "MessageBox", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    conn.Open();
                    
                    // 삭제 쿼리
                    cmd = new MySqlCommand($"DELETE FROM booklist where isbn = '{boxNumber.Text}';",conn);       cmd.ExecuteNonQuery();
                    cmd = new MySqlCommand($"DELETE FROM borrowlist where isbn = '{boxNumber.Text}';", conn);    cmd.ExecuteNonQuery();
                        
                    conn.Close();
                }

                boxNumber.Text = "";            // index 입력칸을 비워두어 의도치 않은 메모리 제거 방지
                buttonModify.Enabled = false;
                Check();                        // 출력
            }

            else MessageBox.Show("항목을 선택하지 않으셨습니다.");
        }



        // ### 도서 수정 관련 메소드 ###
        private void buttonModify_Click(object sender, EventArgs e)
        {
            // 수정 처음에 이용할 경우 인덱스 변경 방지를 위해 목록 창 비활성화.
            if (listBook.Enabled == true)
            {
                ControlEnableCheck(false);
                TextBoxEnable(true);

                conn.Open();

                // 모든 데이터 가져오기 위한 쿼리
                cmd = new MySqlCommand($"SELECT * FROM booklist where isbn = '{boxNumber.Text}';", conn);   
                MySqlDataReader rdr = cmd.ExecuteReader();

                rdr.Read();                                     // 데이터 불러오기 위해 호출
                boxIsbn.Text    = rdr["isbn"].ToString();
                boxName.Text    = rdr["name"].ToString();
                boxAuthor.Text  = rdr["author"].ToString();
                boxCompany.Text = rdr["company"].ToString();
                boxStock.Text   = rdr["stock"].ToString();

                rdr.Close();
                conn.Close();
            }


            // 목록 창이 이미 비활성화 되어있는 경우 입력한 데이터를 가지고 수정 절차 진행
            else
            {
                // 입력이 안 된 것이 있는 경우 (간이 예외처리)
                if (boxIsbn.Text == "" || boxName.Text == "" || boxAuthor.Text == "" || boxCompany.Text == "" || boxStock.Text == "")
                    MessageBox.Show("입력하지 않은 정보가 있습니다. 정확히 기재해주세요.");

                else if (int.Parse(boxStock.Text) <= 0 || int.Parse(boxStock.Text) > 99)
                    MessageBox.Show("유효한 재고 수를 입력해주세요.");

                // 모든 정보가 입력되었을 경우
                else
                {
                    bool findsearch = false;

                    conn.Open();                // 데이터베이스 연동
                    cmd = new MySqlCommand      // 도서 수정을 위한 쿼리
                        ($"UPDATE booklist SET isbn='{boxIsbn.Text}', name='{boxName.Text}', author='{boxAuthor.Text}', company='{boxCompany.Text}', stock='{boxStock.Text}' where isbn = '{boxNumber.Text}';",conn);
                    cmd.ExecuteNonQuery();

                    cmd = new MySqlCommand
                        ($"SELECT * FROM borrowlist WHERE isbn = '{boxNumber.Text}';", conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read()) findsearch = true; 
                    rdr.Close();
                    if (findsearch) cmd = new MySqlCommand($"UPDATE borrowlist SET isbn = '{boxIsbn.Text}', name = '{boxName.Text}' where isbn = '{boxNumber.Text}';",conn); cmd.ExecuteNonQuery(); 

                    conn.Close();

                    TextBoxEnable(false);       // 텍스트박스 내용물 지우기
                    ControlEnableCheck(true);   // 변경된 이후 나머지 버튼들 활성화시킴
                    Check();                    // 변경된 데이터 출력

                    MessageBox.Show("수정 완료");
                }
            }
        }



        // ### 도서 정렬 관련 메소드 ###
        private void listBook_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            conn.Open();
            switch (e.Column)                   // 어떤 머리글을 클릭하였는지에 따라 각각 다른 명령어 쿼리
            {
                case 1: cmd = new MySqlCommand("SELECT * FROM booklist ORDER BY isbn;", conn); break;
                case 2: cmd = new MySqlCommand("SELECT * FROM booklist ORDER BY name;", conn); break;
                case 3: cmd = new MySqlCommand("SELECT * FROM booklist ORDER BY author;", conn); break;
                case 4: cmd = new MySqlCommand("SELECT * FROM booklist ORDER BY company;", conn); break;
                case 5: cmd = new MySqlCommand("SELECT * FROM booklist ORDER BY stock;", conn); break;
                default: conn.Close(); return;
            }
            ListPrinter(cmd.ExecuteReader());   // 받아온 쿼리를 수행하여 listBook에 정렬된 데이터 출력함
        }

        private void userView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            conn.Open();
            switch (e.Column)                       // 어떤 머리글을 클릭하였는지에 따라 각각 다른 명령어 쿼리
            {
                case 0: cmd = new MySqlCommand("SELECT * FROM borrowlist ORDER BY borrower;", conn); break;
                case 1: cmd = new MySqlCommand("SELECT * FROM borrowlist ORDER BY isbn;", conn); break;
                case 2: cmd = new MySqlCommand("SELECT * FROM borrowlist ORDER BY name;", conn); break;
                case 3: cmd = new MySqlCommand("SELECT * FROM borrowlist ORDER BY bdate;", conn); break;
                case 4: cmd = new MySqlCommand("SELECT * FROM borrowlist ORDER BY rdate;", conn); break;
                case 5: cmd = new MySqlCommand("SELECT * FROM borrowlist ORDER BY limit_;", conn); break;
                default: conn.Close(); return;
            }
            BorrowListPrinter(cmd.ExecuteReader()); // 받아온 쿼리를 수행하여 listBook에 정렬된 데이터 출력함
        }



        // ### 도서 검색 관련 메소드 ###
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            int count = 1;
            tempIsbn = new ArrayList();

            TextBoxEnable(false);       // 일부 컨트롤 비활성화
            listBook.Items.Clear();     // 목록 비우기

            conn.Open();
            cmd = new MySqlCommand("SELECT * FROM booklist;", conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())          // DB에 존재하는 데이터 수만큼 반복
            {                           // 특정 키워드가 검색되어야만 listBook 창에 해당 데이터를 출력함
                if((rdr["name"].ToString()).Contains(boxSearch.Text) || 
                    (rdr["author"].ToString()).Contains(boxSearch.Text) || 
                    (rdr["company"].ToString()).Contains(boxSearch.Text))
                {
                    listBook.Items.Add(new ListViewItem(new string[]
                    {
                        count.ToString(),
                        rdr["isbn"].ToString(),
                        rdr["name"].ToString(),
                        rdr["author"].ToString(),
                        rdr["company"].ToString(),
                        rdr["stock"].ToString()}
                    ));

                    tempIsbn.Add(rdr["isbn"].ToString());       // 고유 키인 ISBN만 별도의 컬렉션에 추가
                    count++;                                    // No. 카운트 값 증가
                }
            }

            rdr.Close();
            conn.Close();
        }



        // ### 도서 조회 관련 메소드 ###
        private void buttonCheck_Click(object sender, EventArgs e){ Check(); }



        // ### 도서 목록(ListBook) 폼에서 특정 요소를 클릭할 시 발생 ###
        private void listBook_Click(object sender, EventArgs e)
        {
            foreach (int getIndex in listBook.SelectedIndices)      // 누른 항목의 인덱스 가져옴
                boxNumber.Text = tempIsbn[getIndex].ToString();     // boxNumber 텍스트박스에 선택한 인덱스의 ISBN 출력
    
            buttonModify.Enabled = true;                            // 수정 버튼 활성화
        
        }



        // 실질적 조회 메소드
        private void Check()
        {
            // 일부 컨트롤 활성화 변경
            buttonModify.Enabled = false;
            buttonDelete.Enabled = true;
            boxNumber.Text = "";


            cmd = new MySqlCommand("SELECT * FROM booklist;", conn);    // 전체 데이터를 불러오는 쿼리
            conn.Open();
            ListPrinter(cmd.ExecuteReader());                           // 데이터 출력 함수 호출

            cmd = new MySqlCommand($"SELECT * FROM borrowlist;", conn);
            conn.Open();
            BorrowListPrinter(cmd.ExecuteReader());
        }


        // ListView Form에 데이터 출력하기
        private void ListPrinter(MySqlDataReader rdr)
        {
            int count = 1;
            listBook.Items.Clear();         // 기존 조회 정보 초기화
            
            tempIsbn = new ArrayList();     // tempIsbn 객체 생성
            
            while (rdr.Read())              // DB에 저장된 데이터 수만큼 반복문 수행
            {
                listBook.Items.Add(new ListViewItem(new string[] 
                {
                    count.ToString(),           // count    출력
                    rdr["isbn"].ToString(),     // isbn     출력
                    rdr["name"].ToString(),     // name     출력
                    rdr["author"].ToString(),   // author   출력
                    rdr["company"].ToString(),  // company  출력
                    rdr["stock"].ToString() }   // stock    출력
                ));

                tempIsbn.Add(rdr["isbn"].ToString());       // 고유 키인 ISBN만 별도의 컬렉션에 추가
                count++;                                    // No. 카운트 값 증가
            }
            rdr.Close();
            conn.Close();
        }



        // userView Form에 데이터 출력하기
        private void BorrowListPrinter(MySqlDataReader rdr)
        {
            DateTime test1, test2;
            int count = 1;
            userView.Items.Clear();         // 기존 조회 정보 초기화

            tempIsbn2 = new ArrayList();    // tempIsbn 객체 생성

            while (rdr.Read())
            {
                DateTime.TryParse(rdr["bdate"].ToString(), out test1);
                DateTime.TryParse(rdr["rdate"].ToString(), out test2);
                int getDay = DateTime.Now.ToString(YMD).CompareTo(test2.ToString(YMD));

                userView.Items.Add(new ListViewItem(new string[]
                {
                    rdr["borrower"].ToString(), // borrower 출력
                    rdr["isbn"].ToString(),     // isbn     출력
                    rdr["name"].ToString(),     // name     출력
                    test1.ToString(YMD),
                    test2.ToString(YMD),
                    rdr["limit_"].ToString(),   // limit_   출력
                    getDay > 0 ? "연체" : "정상"
                }));

                tempIsbn2.Add(rdr["isbn"].ToString());      // 고유 키인 ISBN만 별도의 컬렉션에 추가
                count++;
            }

            rdr.Close();
            conn.Close();
        }



        // 데이터 텍스트박스 초기화 및 활성화 여부
        private void TextBoxEnable(bool enable)
        {
            boxIsbn.Text = ""; boxName.Text = "";
            boxAuthor.Text = ""; boxCompany.Text = "";
            boxStock.Text = "";

            boxIsbn.Enabled = enable;     boxName.Enabled = enable;
            boxAuthor.Enabled = enable;   boxCompany.Enabled = enable;
            boxStock.Enabled = enable;
        }


        // 부울 값을 가져와서 특정 컨트롤 활성화 여부 결정
        private void ControlEnableCheck(bool enable)
        {
            buttonSearch.Enabled = enable;  buttonDelete.Enabled = enable;
            buttonCheck.Enabled = enable;   listBook.Enabled = enable;
        }


        // 폼 닫을 시 발생되는 이벤트
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("정말 로그아웃하시겠습니까?", "MessageBox", MessageBoxButtons.YesNo) == DialogResult.Yes) { }

            else e.Cancel = true;
        }


        // ### 이용 로그 폼 불러오기 ###
        private void btnlog_Click(object sender, EventArgs e)
        {
            Log log_form = new Log();
            log_form.Show();
        }


        // ### 블랙리스트 폼 불러오기 ###
        private void btnblack_Click(object sender, EventArgs e)
        {
            Blacklist blacklist = new Blacklist();
            blacklist.Show();
        }
    }
}

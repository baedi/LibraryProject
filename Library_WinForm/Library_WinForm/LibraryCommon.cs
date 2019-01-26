using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections;

namespace Library_WinForm
{
    public partial class LibraryCommon : Form
    {
        private MySqlConnection conn;   // 데이터베이스 전용 객체
        private MySqlCommand cmd;       // DB 명령어 전용 객체
        private MySqlDataReader rdr;    // DB 데이터 읽기 용도 객체
        private ArrayList tempIsbn;     // DB Primary Key인 ISBN을 받아오기 위한 용도
        private ArrayList tempIsbn2;
        //private DateTime nowdaySave;         // 오늘 날짜 전용 객체
        private DateTime borrow_day;    // 대출일, 반납일 전용 객체
        private DateTime return_day;
        private string userid;          // 유저 아이디를 저장하기 위한 용도
        private string getBookName;     // 책 이름 가져오는 용도

        // 상수 전용
        private const int MAX = 5;              // 최대 대출 가능 권수
        private const int LIMIT = 7;            // 연장 기간
        private const string YMD = "yy-MM-dd";  // 날짜 불러오기 용도




        // 생성자
        public LibraryCommon(string[] account)
        {
            // DB 연동 명령어 및 가져온 정보 지우기
            conn = new MySqlConnection($"server=localhost;user id={account[0]}; password={account[1]}; database=libraryDB; allow user variables=true;");
            userid = account[0];

            InitializeComponent();
        }



        // ### 블랙리스트 명단 확인 작업 ###
        private void BlacklistCheck()
        {
            // 상태 출력
            conn.Open();
            cmd = new MySqlCommand($"SELECT * FROM `librarydb`.`blacklist` WHERE name='{userid}';", conn);
            rdr = cmd.ExecuteReader();

            // 만약 블랙리스트 명단에 있을 경우 연체 관련 명령 실행
            if (rdr.Read())
            {
                DateTime restoreDate;
                DateTime.TryParse(rdr["date"].ToString(), out restoreDate);
                rdr.Close();
                int dayGap = (restoreDate.Subtract(DateTime.Today).Days);

                if (dayGap > 0) userstate.Text = $"<{dayGap}일 제한>";
                else
                {
                    cmd = new MySqlCommand($"DELETE FROM `librarydb`.`blacklist` WHERE name = '{userid}';", conn);
                    cmd.ExecuteNonQuery();

                    userstate.Text = "<정상>";
                }
            }

            else userstate.Text = "<정상>";
            conn.Close();
        }



        // ### 데이터베이스 연동 및 날짜 불러오는 메소드 + 사용자 정보 불러오기 ###
        private void LibraryCommon_Load(object sender, EventArgs e)
        {
            try { conn.Open(); conn.Close(); }
            catch { MessageBox.Show("데이터베이스 연결 실패"); Application.Exit(); }

            BlacklistCheck();

            conn.Open();
            LogWrite(1);    conn.Close();

            getToday.Text = DateTime.Now.ToString(YMD);
            getReturn.Text = DateTime.Now.AddDays(7).ToString(YMD);
            boxUser.Text = userid;
            Check();
        }



        // ### 도서 대출 메소드 ###
        private void btnBorrow_Click(object sender, EventArgs e)
        {
            if(userstate.Text != "<정상>") { MessageBox.Show("연체자는 대출을 이용하실 수 없습니다."); return; }

            // 지역변수
            int count = 0;
            bool findbook = false;

            // 사용자가 빌린 도서 수를 먼저 확인함.
            cmd = new MySqlCommand($"USE libraryDB; SELECT * FROM borrowlist WHERE borrower = '{userid}';", conn);   conn.Open();
            rdr = cmd.ExecuteReader();
            while (rdr.Read()) { count++;}  rdr.Close();

            // 중복 책 대출을 방지하기 위해 대출 관련 정보를 확인함
            cmd = new MySqlCommand($"SELECT * from borrowlist where borrower = '{userid}' and isbn = '{boxIsbn1.Text}';", conn);
            rdr = cmd.ExecuteReader();
            if (rdr.Read()) findbook = true;
            rdr.Close();    conn.Close();

            // 일정 이상 대출한 상태 혹은 중복 대출했을 경우 대출 불가
            if(count >= MAX) { MessageBox.Show("대출 가능한 한도를 초과하였습니다."); }
            else if (findbook) { MessageBox.Show("이미 대출하신 도서입니다."); }
            else
            {
                if (MessageBox.Show("정말로 해당 도서를 대출하시겠습니까?", "MessageBox", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // 지역변수
                    string stock;
                    int change;

                    // 대출 쿼리
                    cmd = new MySqlCommand($"SELECT * FROM booklist WHERE isbn = '{boxIsbn1.Text}';", conn); conn.Open();
                    rdr = cmd.ExecuteReader();  rdr.Read();
                    getBookName = rdr["name"].ToString();      // 책 목록에서 이름, 재고 정보를 가져옴
                    stock = rdr["stock"].ToString();
                    rdr.Close();

                    // 대여하고자 하는 책이 재고가 있는지 확인
                    if (int.Parse(stock) <= 0) { MessageBox.Show("재고가 없는 도서입니다."); conn.Close(); }
                    else
                    {
                        change = int.Parse(stock) - 1;

                        // 해당 도서의 재고 수를 업데이트, 대여 목록에서 대여 정보 추가
                        cmd = new MySqlCommand
                            ($"UPDATE booklist SET stock='{change.ToString()}' where isbn='{boxIsbn1.Text}';", conn);    cmd.ExecuteNonQuery();

                        cmd = new MySqlCommand
                            ($"INSERT INTO borrowlist VALUES('{boxUser.Text}','{boxIsbn1.Text}','{getBookName}','{DateTime.Now.ToString(YMD)}','{DateTime.Now.AddDays(7).ToString(YMD)}', 'N');", conn);
                        cmd.ExecuteNonQuery();
                        LogWrite(2);
                        conn.Close();

                        // 일부 설정을 변경하고 데이터 조회
                        boxIsbn1.Text = ""; btnBorrow.Enabled = false;  Check();
                        MessageBox.Show($"대출이 완료되었습니다. 반납일은 {DateTime.Now.AddDays(7).ToString(YMD)} 입니다.");
                    }
                }


            }
        }



        // ### 도서 반납 메소드###
        private void btnReturn_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("도서를 반납하시겠습니까?","MessageBox",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // 대여 목록에서 선택한 도서를 제거하고, 해당 도서의 재고를 1 증가시킴
                conn.Open();
                cmd = new MySqlCommand($"SELECT * FROM borrowlist WHERE isbn = '{boxIsbn2.Text}' and borrower = '{userid}';", conn); rdr = cmd.ExecuteReader();
                rdr.Read();

                // 가져온 문자열 날짜 데이터를 DateTime 형식으로 변환
                DateTime.TryParse(rdr["bdate"].ToString(), out borrow_day);
                DateTime.TryParse(rdr["rdate"].ToString(), out return_day);
                rdr.Close();

                // 대출일, 반납일과 비교하여 대입.(추가된 부분)
                //DateTime.TryParse(DateTime.Now.ToString(YMD), out nowdaySave);
                //int dayGap = nowdaySave.Subtract(return_day).Days;
                int dayGap = DateTime.Today.Subtract(return_day).Days;
 
                cmd = new MySqlCommand($"DELETE FROM borrowlist WHERE isbn = '{boxIsbn2.Text}' and borrower = '{userid}';", conn);   cmd.ExecuteNonQuery();
                cmd = new MySqlCommand($"SELECT * FROM booklist WHERE isbn = '{boxIsbn2.Text}';", conn);                             rdr = cmd.ExecuteReader();

                rdr.Read();
                getBookName = rdr["name"].ToString();
                int getEa = int.Parse(rdr["stock"].ToString()) + 1;


                rdr.Close();

                cmd = new MySqlCommand($"UPDATE booklist set stock='{getEa}' where isbn='{boxIsbn2.Text}';", conn);                  cmd.ExecuteNonQuery();
                conn.Close();

                // 일부 설정을 변경하고 데이터 조회
                boxIsbn2.Text = ""; btnReturn.Enabled = false; btnlimit.Enabled = false;  Check();

                
                if (dayGap > 0)
                {
                    cmd = new MySqlCommand($"SELECT * FROM `librarydb`.`blacklist` WHERE name = '{userid}'", conn);
                    conn.Open();    rdr = cmd.ExecuteReader();

                    // 이미 블랙리스트 명단에 있는 경우
                    if (rdr.Read())
                    {
                        MessageBox.Show("1"); /////

                        DateTime restoreDate;
                        DateTime.TryParse(rdr["date"].ToString(), out restoreDate);
                        rdr.Close();
                        //int dayGap2 = restoreDate.Subtract(DateTime.Today).Days;
                        cmd = new MySqlCommand($"UPDATE `librarydb`.`blacklist` SET date='{restoreDate.AddDays(dayGap).ToString(YMD)}' WHERE name = '{userid}'", conn);
                        cmd.ExecuteNonQuery();
                    }

                    else
                    {
                        MessageBox.Show("2"); /////

                        rdr.Close();
                        cmd = new MySqlCommand($"INSERT INTO `librarydb`.`blacklist` VALUES ('{userid}', '{DateTime.Now.AddDays(dayGap).ToString(YMD)}')", conn);
                        cmd.ExecuteNonQuery();

                    }

                    LogWrite(5, dayGap.ToString());
                    MessageBox.Show($"대출 기한을 연체하셨습니다. {dayGap}일동안 대출이 제한됩니다.");

                    conn.Close();

                    BlacklistCheck();
                }
                else { LogWrite(4); MessageBox.Show("도서 반납이 완료되었습니다.");  conn.Close();}
                
            }


        }



        // ### 도서 연장 메소드 ###
        private void btnlimit_Click(object sender, EventArgs e)
        {
            if (userstate.Text != "<정상>") { MessageBox.Show("연체자는 연장을 이용하실 수 없습니다."); return; }

            // 대출기한과 연장유무 정보를 가져오기 위한 코드
            cmd = new MySqlCommand($"SELECT * FROM borrowlist WHERE isbn = '{boxIsbn2.Text}' AND borrower = '{userid}';", conn); conn.Open();
            rdr = cmd.ExecuteReader();
            rdr.Read();
            DateTime.TryParse(rdr["rdate"].ToString(), out return_day);
            char lmCheck = char.Parse(rdr["limit_"].ToString());
            rdr.Close();

            int getDay = DateTime.Now.ToString(YMD).CompareTo(return_day.ToString(YMD));

            // 도서 연체 확인
            if (getDay > 0) { MessageBox.Show("기한을 연체하여 연장이 불가능합니다."); conn.Close(); }
            else if (lmCheck == 'Y') { MessageBox.Show("이미 기한을 연장한 도서입니다."); conn.Close(); }
            else
            {
                if (MessageBox.Show("해당 도서의 대출기한을 연장하시겠습니까?", "MessageBox", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    cmd = new MySqlCommand($"UPDATE borrowlist SET rdate='{return_day.AddDays(LIMIT).ToString(YMD)}', limit_='Y' where isbn='{boxIsbn2.Text}' and borrower = '{userid}';", conn);
                    cmd.ExecuteNonQuery();
                    LogWrite(3);
                    conn.Close();

                    boxIsbn2.Text = ""; btnlimit.Enabled = false; Check();
                    MessageBox.Show("기한 연장 완료 (7일)");
                }
            }
        }



        // ### 도서 검색 메소드 ###
        private void btnSearch_Click(object sender, EventArgs e)
        {
            int count = 1;              // 변수(No)

            tempIsbn = new ArrayList(); // 컬렉션 초기화
            listBook.Items.Clear();     // 목록 비우기

            // 도서 목록 불러옴
            conn.Open();
            cmd = new MySqlCommand("SELECT * FROM booklist;", conn); rdr = cmd.ExecuteReader();

            while (rdr.Read())          // DB에 존재하는 데이터 수만큼 반복
            {                           // 검색한 키워드를 가지고 일치하는 키워드를 찾아냄
                if ((rdr["name"].ToString()).Contains(boxSearch.Text) ||
                    (rdr["author"].ToString()).Contains(boxSearch.Text) ||
                    (rdr["company"].ToString()).Contains(boxSearch.Text))
                {                       // 발견했을 경우 목록에 출력함
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
            rdr.Close();    conn.Close();
        }



        // ## 도서 정렬 관련 메소드 ###
         // --- 1. 도서 목록
        private void listBook_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            conn.Open();
            switch (e.Column)   // 어떤 머리글을 클릭하였는지에 따라 각각 다른 명령어 쿼리
            {
                case 1: cmd = new MySqlCommand("SELECT * FROM booklist ORDER BY isbn;", conn); break;
                case 2: cmd = new MySqlCommand("SELECT * FROM booklist ORDER BY name;", conn); break;
                case 3: cmd = new MySqlCommand("SELECT * FROM booklist ORDER BY author;", conn); break;
                case 4: cmd = new MySqlCommand("SELECT * FROM booklist ORDER BY company;", conn); break;
                case 5: cmd = new MySqlCommand("SELECT * FROM booklist ORDER BY stock;", conn); break;
                default: conn.Close(); return;
            }
            ListPrinter(cmd.ExecuteReader());       // 받아온 쿼리를 수행하여 listBook에 정렬된 데이터 출력함
        }

         // --- 2. 대여 목록
        private void userView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            conn.Open();
            switch (e.Column)   // 어떤 머리글을 클릭하였는지에 따라 각각 다른 명령어 쿼리
            {
                case 1: cmd = new MySqlCommand($"SELECT * FROM borrowlist where borrower = '{userid}' ORDER BY isbn;", conn); break;
                case 2: cmd = new MySqlCommand($"SELECT * FROM borrowlist where borrower = '{userid}' ORDER BY name;", conn); break;
                case 3: cmd = new MySqlCommand($"SELECT * FROM borrowlist where borrower = '{userid}' ORDER BY bdate;", conn); break;
                case 4: cmd = new MySqlCommand($"SELECT * FROM borrowlist where borrower = '{userid}' ORDER BY rdate;", conn); break;
                case 5: cmd = new MySqlCommand($"SELECT * FROM borrowlist where borrower = '{userid}' ORDER BY limit_;", conn); break;
                default: conn.Close(); return;
            }
            BorrowListPrinter(cmd.ExecuteReader()); // 받아온 쿼리를 수행하여 listBook에 정렬된 데이터 출력함
        }



        // ### 뷰 폼에서 특정 요소를 클릭할 시 발생 (도서 및 대출 목록)
        private void listBook_Click(object sender, EventArgs e)
        {
            foreach (int getIndex in listBook.SelectedIndices)      // 누른 항목의 인덱스 가져옴
                boxIsbn1.Text = tempIsbn[getIndex].ToString();      // boxNumber 텍스트박스에 선택한 인덱스의 ISBN 출력

            btnBorrow.Enabled = true;                               // 대출 버튼 활성화
        }

        private void userView_Click(object sender, EventArgs e)
        {
            foreach (int getIndex in userView.SelectedIndices)
                boxIsbn2.Text = tempIsbn2[getIndex].ToString();

            btnReturn.Enabled = true;
            btnlimit.Enabled = true;
        }



        // 실질적 조회 메소드
        private void Check()
        {
            // 일부 컨트롤 활성화 변경
            btnBorrow.Enabled = false;   boxIsbn1.Text = "";
            btnReturn.Enabled = false;   boxIsbn2.Text = "";

            cmd = new MySqlCommand("SELECT * FROM booklist;", conn);    // 전체 데이터를 불러오는 쿼리
            conn.Open();
            ListPrinter(cmd.ExecuteReader());                           // 데이터 출력 함수 호출

            cmd = new MySqlCommand($"SELECT * FROM borrowlist where borrower = '{userid}';", conn);
            conn.Open();
            BorrowListPrinter(cmd.ExecuteReader());
        }



        // ListView Form에 데이터 출력하기
        private void ListPrinter(MySqlDataReader rdr)
        {
            int count = 1;                  // 변수 (No.)

            listBook.Items.Clear();         // 기존 조회 정보 초기화
            tempIsbn = new ArrayList();     // 컬렉션 초기화

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
            rdr.Close();    conn.Close();
        }



        // userView Form에 데이터 출력하기
        private void BorrowListPrinter(MySqlDataReader rdr)
        {
            int count = 1;  // 변수 (No.)

            userView.Items.Clear();                 // 기존 조회 정보 초기화
            tempIsbn2 = new ArrayList();            // 컬렉션 초기화

            while (rdr.Read())
            {
                // 가져온 문자열 날짜 데이터를 DateTime 형식으로 변환
                DateTime.TryParse(rdr["bdate"].ToString(), out borrow_day);
                DateTime.TryParse(rdr["rdate"].ToString(), out return_day);

                // 대출일, 반납일과 비교하여 대입.
                int getDay = DateTime.Now.ToString(YMD).CompareTo(return_day.ToString(YMD));

                userView.Items.Add(new ListViewItem(new string[]
                {
                    count.ToString(),               // 순번(No) 출력
                    rdr["isbn"].ToString(),         // ISBN     출력
                    rdr["name"].ToString(),         // 책 이름  출력
                    borrow_day.ToString(YMD),       // 대출일   출력
                    return_day.ToString(YMD),       // 반납일   출력
                    getDay > 0 ? "연체" : "정상"    // 상태여부 출력
                }));
                if (getDay > 0) userstate.Text = "<연체>";

                tempIsbn2.Add(rdr["isbn"].ToString());      // 고유 키인 ISBN만 별도의 컬렉션에 추가
                count++;                                    // No. 카운트 증가
            }
            rdr.Close();    conn.Close();
        }

        // 폼 닫을 시 발생되는 이벤트
        private void LibraryCommon_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("정말 로그아웃하시겠습니까?", "MessageBox", MessageBoxButtons.YesNo) == DialogResult.Yes)
            { conn.Open(); LogWrite(6); conn.Close(); }

            else e.Cancel = true;
        }


        // 로그 목록
        private void LogWrite(int selectnum, string day = null)
        {
            string logtemp = string.Format("");
            switch (selectnum)
            {
                case 1: logtemp = string.Format($" 로그인 확인됨"); break;                // 로그인 시
                case 2: logtemp = string.Format($" \"{getBookName}\" 대출 완료"); break;  // 도서 대출 성공 시
                case 3: logtemp = string.Format($" \"{getBookName}\" 연장 완료"); break;  // 도서 연장 시
                case 4: logtemp = string.Format($" \"{getBookName}\" 반납 완료"); break;  // 도서 반납 시
                case 5: logtemp = string.Format($" \"{getBookName}\" {day}일 연체"); break;   // 도서 반납 연체 시
                case 6: logtemp = string.Format($" 로그아웃 확인됨"); break;              // 로그아웃 시
            }
            cmd = new MySqlCommand($"INSERT INTO `librarydb`.`loglist` VALUES ('{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', '{userid}', '{logtemp}');", conn);
            cmd.ExecuteNonQuery();
            
        }
    }
}

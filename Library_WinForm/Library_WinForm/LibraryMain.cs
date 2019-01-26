using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Library_WinForm
{
    static class LibraryMain
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string[] info;
            MySqlConnection conn;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
                            
            
            do                                          // 로그인 창을 닫기 전까지 무한반복
            {
                Login log_in = new Login();             // 메소드를 호출하기 위해 객체를 별도로 생성함.
                
                Application.Run(log_in);                // 로그인 폼을 실행함 (로그인 창 나타남)
                info = log_in.getInfo();                // getInfo()를 통해 입력 정보를 가져옴
                log_in.ClearInfo();                     // 보안을 위해 log_in 객체에 저장되어있는 정보까지 지움
                if (log_in.ProgramCheckExit()) break;   // 로그인 창에서 종료(x)를 누른 경우 프로그램 종료
                    
                conn = new MySqlConnection
                    ($"server=localhost;user id='{info[0]}'; password='{info[1]}'; database=libraryDB; allow user variables=true;");
                
                try
                {

                    conn.Open(); conn.Close();

                    // 관리자 전용
                    if (info[0] == "root")  
                    {
                        MainForm master_user = new MainForm(info);  info = null;
                        Application.Run(master_user);
                    }
                    else if (info[0] == "admin") { MessageBox.Show("회원 관리 전용 계정은 접속이 제한됩니다."); }


                    // 일반 이용자
                    else
                    {
                        LibraryCommon common_user = new LibraryCommon(info);    info = null;
                        Application.Run(common_user);
                    }
                }

                catch { MessageBox.Show("로그인 실패");}
            } while (true);
        }
    }
}

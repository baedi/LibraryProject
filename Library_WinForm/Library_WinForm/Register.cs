using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Library_WinForm
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            // 정보 미 기재시
            if (rtxtID.Text == "" || rtxtPW.Text == "") MessageBox.Show("정보를 입력해주세요.");

            // 정보 기재시
            else
            {
                // 어드민(계정관리자) 권한으로 접근
                MySqlConnection conn = new MySqlConnection ("server=localhost;user id=admin; password=master; database=libraryDB; allow user variables=true;");
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("USE mysql;", conn);
                cmd.ExecuteNonQuery();

                // 어드민 권한으로 계정 아이디 존재여부를 확인함.
                cmd = new MySqlCommand($"SELECT USER FROM USER WHERE USER = '{rtxtID.Text}';", conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read()) MessageBox.Show("이미 사용중인 아이디입니다.");
                else
                {
                    rdr.Close();
                    // DB에 계정을 생성함
                    cmd = new MySqlCommand($"USE mysql; create user '{rtxtID.Text}'@localhost identified by '{rtxtPW.Text}';", conn);
                    cmd.ExecuteNonQuery();

                    // 생성한 계정의 권한을 부여해줌
                    cmd = new MySqlCommand($"grant all on libraryDB.* to '{rtxtID.Text}'@localhost;", conn);  cmd.ExecuteNonQuery();
                    //cmd = new MySqlCommand($"grant usage on *.* to {rtxtID.Text}@localhost;", conn);        cmd.ExecuteNonQuery();

                    MessageBox.Show("계정이 생성되었습니다.");
                    Close();
                }

                conn.Close();

            }

        }
    }
}

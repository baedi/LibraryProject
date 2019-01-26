using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Library_WinForm
{
    public partial class Login : Form
    {
        private string[] info;
        private bool exit_ = true;

        public Login()
        {
            InitializeComponent();
        }

        // Connect 버튼 클릭
        private void btnConnect_Click(object sender, EventArgs e)
        {
            // 입력하지 않은 정보기 있을 경우
            if (boxID.Text == "" || boxPASS.Text == "")
            {
                MessageBox.Show("계정 정보를 입력해주세요.");
            }

            // 정보를 모두 입력했을 경우
            else
            {
                info = new string[] { boxID.Text, boxPASS.Text };
                exit_ = false;   // *
                Close();
            }
        }

        // Register 버튼 클릭
        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register reg = new Register();
            reg.Show();
        }


        public string[] getInfo() { return info; }
        public void ClearInfo() { info = null; }
        public bool ProgramCheckExit() { return exit_; }
    }
}

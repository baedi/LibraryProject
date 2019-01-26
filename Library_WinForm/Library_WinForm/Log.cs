using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Library_WinForm
{
    public partial class Log : Form
    {
        public Log()
        {
            InitializeComponent();
        }

        private void Log_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost; user id=admin; password=master; database=libraryDB;");
            try { conn.Open(); conn.Close(); }
            catch { MessageBox.Show("연동 오류가 발생하였습니다."); Close(); }

            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM `librarydb`.`loglist`;", conn);
            conn.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                logView.Items.Add(new ListViewItem(new string[]
                {
                    rdr["ldate"].ToString(),
                    rdr["lname"].ToString(),
                    rdr["message"].ToString()
                }));
            }

            conn.Close();
        }
    }
}

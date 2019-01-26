using System;
using System.Windows.Forms;
using System.Collections;
using MySql.Data.MySqlClient;

namespace Library_WinForm
{
    public partial class Blacklist : Form
    {
        private ArrayList temp;
        private DateTime gdate;
        private MySqlConnection conn;
        private MySqlCommand cmd;
        private MySqlDataReader rdr;

        public Blacklist()
        {
            InitializeComponent();
        }

        private void Blacklist_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection("server=localhost; user id=admin; password=master; database=libraryDB;");
            try { conn.Open(); conn.Close(); }
            catch { MessageBox.Show("연동 오류가 발생하였습니다."); Close(); }

            PrintView();
        }


        // 데이터 전체 출력을 위함 (최신화 용도)
        private void PrintView()
        {
            targetuser.Text = "";
            blackview.Items.Clear();
            temp = new ArrayList();

            cmd = new MySqlCommand($"SELECT * FROM `librarydb`.`blacklist`;", conn);
            conn.Open();    rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                DateTime.TryParse(rdr["date"].ToString(), out gdate);

                blackview.Items.Add(new ListViewItem(new string[]
                {
                    rdr["name"].ToString(),
                    gdate.ToString("yy-MM-dd")
                }));

                temp.Add(rdr["name"].ToString());
            }

            rdr.Close();
            conn.Close();
        }



        // 특정 계정 클릭 시 선택 대상이 되도록 함.
        private void blackview_Click(object sender, EventArgs e)
        {
            foreach (int getIndex in blackview.SelectedIndices)
                targetuser.Text = temp[getIndex].ToString();
        }

        // 블랙리스트 추가
        private void btnbladd_Click(object sender, EventArgs e)
        {
            if (targetuser.Text == "") MessageBox.Show("대상이 비어있습니다.");
            else
            {
                cmd = new MySqlCommand($"SELECT user FROM `mysql`.user WHERE user = '{targetuser.Text}';", conn);
                conn.Open();
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    rdr.Close();    conn.Close();

                    // 블랙리스트에 이미 존재하는 계정인지 확인함.
                    cmd = new MySqlCommand($"SELECT * FROM `librarydb`.`blacklist` WHERE name='{targetuser.Text}';", conn);
                    conn.Open();     rdr = cmd.ExecuteReader();

                    int day = int.Parse(numeric.Value.ToString());

                    // 블랙리스트엔 없는 경우
                    if (rdr.Read())
                    {
                        rdr.Close(); conn.Close();

                        cmd = new MySqlCommand($"SELECT * FROM `librarydb`.`blacklist` WHERE name='{targetuser.Text}';", conn);
                        conn.Open();    rdr = cmd.ExecuteReader();

                        rdr.Read();
                        DateTime.TryParse(rdr["date"].ToString(), out gdate);
                        rdr.Close(); conn.Close();
                        cmd = new MySqlCommand($"UPDATE `librarydb`.`blacklist` SET date='{gdate.AddDays(day).ToString("yy-MM-dd")}' WHERE name='{targetuser.Text}';", conn);
                        conn.Open(); cmd.ExecuteNonQuery();
                        MessageBox.Show("해당 계정에 대한 대출 제한 변경이 완료되었습니다.");
                    }
                    

                    // 블랙리스트엔 있는 경우
                    else
                    {
                        rdr.Close(); conn.Close();
                        cmd = new MySqlCommand($"INSERT INTO `librarydb`.`blacklist` VALUES ('{targetuser.Text}', '{DateTime.Now.AddDays(day).ToString("yy-MM-dd")}');", conn);;
                        conn.Open(); cmd.ExecuteNonQuery();
                        MessageBox.Show("해당 계정에 대한 도서 대출 제한이 완료되었습니다.");
                    }
                    conn.Close();
                    PrintView();
                }

                else { MessageBox.Show("존재하지 않는 계정입니다."); rdr.Close();}
            }
        }

        private void btnbldelete_Click(object sender, EventArgs e)
        {
            if (targetuser.Text == "") { MessageBox.Show("대상이 비어있습니다."); }
            else
            {
                if (MessageBox.Show("정말로 해당 계정의 제한을 해제하시겠습니까?", "MessageBox", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    cmd = new MySqlCommand($"SELECT * FROM `librarydb`.`blacklist` WHERE name='{targetuser.Text}';", conn); conn.Open();
                    rdr = cmd.ExecuteReader();
                    if (!rdr.Read()) { rdr.Close(); conn.Close(); MessageBox.Show("블랙리스트에 존재하지 않는 계정입니다."); return; }
                    conn.Close();

                    cmd = new MySqlCommand($"DELETE FROM `librarydb`.`blacklist` WHERE name='{targetuser.Text}';", conn); conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("삭제 완료");
                    conn.Close();
                    PrintView();
                }
            }
        }



    }
}

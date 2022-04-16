using QuanLyQuanCafe.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class ReloadAccount : Form
    {
        private string s;
        public ReloadAccount()
        {
            InitializeComponent();
        }

        private void btXacnhan_Click(object sender, EventArgs e)
        {
            if (tbEmail.Text == "")
            {
                MessageBox.Show("Vui lòng nhập email");
            }
            else
            {
                if (ReloadAccountDAL.Instance.Reload(tbEmail.Text))
                {
                    tbCode.Visible = true;
                    btOk.Visible = true;
                    btCancel.Visible = true;
                    s = sendcode(tbEmail.Text,0);
                    if (s!=null)
                        lbInfor.Visible = false;
                }
                else
                {
                    lbInfor.Visible = true;
                }
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            if (tbCode.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã CODE !");
            }
            else
            {
                if (tbCode.Text == s)
                {
                    string query = "select UserName , PassWord from NhanVien  where Email = '" + tbEmail.Text + "'";
                    //MessageBox.Show("Lấy mã thành công!");
                    DataTable dt = DataProvider.Instance.GetRecords(query);
                    DataRow dr = dt.Rows[0];
                    string username = dr["UserName"].ToString();
                    string password = dr["password"].ToString();
                    string infor = "Tài khoản của bạn là : \n UserName = " + username + "\nPassWord = " + password;
                    MessageBox.Show(infor);
                }
                else
                {
                    MessageBox.Show("Mã CODE không đúng !");
                }
            }
        }
        public static string sendcode(string gmail,int i)
        {
            string a;
            if (i == 0) a = "Mã Code lấy tài khoản";
            else a = "Mật khẩu của bạn là: ";
            Random generator = new Random();
            string str = generator.Next(0, 100000).ToString("D6");
            if (ReloadAccountDAL.Instance.Send(gmail, a , str))
            {
                MessageBox.Show("Mã Code vừa được gửi đến Mail vừa nhập!");
            }
            else MessageBox.Show("Có lỗi trong quá trình gửi mã CODE !");
            return str;
        }
       
    }
}

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
                    lbInfor.Visible = false;
                    tbNewPass.Visible = true;
                    tbCheckPass.Visible = true;
                    btDoiMatKhau.Visible = true;
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

        private void btDoiMatKhau_Click(object sender, EventArgs e)
        {
            if(tbNewPass.Text == "" && tbCheckPass.Text == "" )
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới");
            }
            else if(tbNewPass.Text != tbCheckPass.Text)
            {
                MessageBox.Show("Các mật khẩu đã nhập không khớp. Vui lòng thử lại!");
            }
            else
            {
                string query = "update TaiKhoan set PassWord = '" + LoginDAL.Instance.EncodePass(tbCheckPass.Text)
                    + "' from TaiKhoan tk inner join NhanVien nv on tk.UserName = nv.UserName where nv.Email = '" + tbEmail.Text + "'";
                if (DataProvider.Instance.executeDB(query))
                {
                    MessageBox.Show("Đổi mật khẩu thành công");
                    this.Close();
                }
                else MessageBox.Show("Error");
            }
        }
    }
}

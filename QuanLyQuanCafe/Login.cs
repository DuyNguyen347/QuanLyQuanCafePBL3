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
    public partial class Login : Form
    {
        public bool CheckPass = true;
        public Login()
        {
            InitializeComponent();
        }

        private void BtLogin_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Họ và tên : " + tbUserName.Text + "\n" + "pass : " + tbPassword.Text);
            Dashboard d = new Dashboard();
            d.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            tbUserName.Text = "";
            tbPassword.Text = "";
        }

        private void BtLogin_Click_1(object sender, EventArgs e)
        {
            if(tbUserName.Text == "" && tbPassword.Text == "")
            {
                MessageBox.Show("Vui lòng nhập UserName và PassWord");
            }

            else
            {
                if(cbbRole.SelectedIndex > -1)
                {
                    if(cbbRole.SelectedItem.ToString() == "Admin")
                    {
                        if(LoginDAL.Instance.Login(tbUserName.Text,tbPassword.Text,1))
                        //if(tbUserName.Text == "Admin" && tbPassword.Text == "12345")
                        {
                            Dashboard ds = new Dashboard();
                            ds.Show();
                            ds.login_show = new Login_show(this.Show);
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("UserName và Password không đúng! ");
                        }
                    }
                    else
                    {
                        if (LoginDAL.Instance.Login(tbUserName.Text,tbPassword.Text,0))
                        {
                            Seller sl = new Seller();
                            sl.Show();
                            sl.login_Show = new Login_show(this.Show);
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("UserName và Password không đúng! ");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn vai trò đăng nhập!");
                }
            } 
              
        }
       private void TB_Enter_Keydown(object o,KeyEventArgs e)
        {
            if(e.KeyValue == 13)
            {
                BtLogin_Click_1(new object(),new EventArgs());
            }
        }

        private void btShowPass_Click(object sender, EventArgs e)
        {
            CheckPass = !CheckPass;
            if(CheckPass)
            {
                tbPassword.PasswordChar = '\0';
            }
            else
            {
                tbPassword.PasswordChar = '*';
            }
        }
    }
}

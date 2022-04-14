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
        string username_admin = "admin";
        string password_admin = "admin";
        public Login()
        {
            InitializeComponent();
        }
        private void BtLogin_Click_1(object sender, EventArgs e)
        {
            //if (tbUserName.Text == "" && tbPassword.Text == "")
            //{
            //    MessageBox.Show("Vui lòng nhập UserName và PassWord");
            //}
            //else if (tbUserName.Text == username_admin && tbPassword.Text == password_admin)
            //{
            //    Dashboard ds = new Dashboard();
            //    ds.Show();
            //    ds.login_show = new Login_show(this.Show);
            //    LB_Clear_Click(new object(),new EventArgs());
            //    this.Hide();
            //}
            //else if (LoginDAL.Instance.Login(tbUserName.Text, tbPassword.Text) == "Admin")
            ////if(tbUserName.Text == "Admin" && tbPassword.Text == "12345")
            //{
            //    Dashboard ds = new Dashboard();
            //    ds.Show();
            //    ds.login_show = new Login_show(this.Show);
            //    LB_Clear_Click(new object(), new EventArgs());
            //    this.Hide();
            //}
            //else if (LoginDAL.Instance.Login(tbUserName.Text, tbPassword.Text) != "Admin")
            //{
            //    Seller sl = new Seller();
            //    sl.Show();
            //    sl.login_Show = new Login_show(this.Show);
            //    LB_Clear_Click(new object(), new EventArgs());
            //    this.Hide();
            //}
            //else
            //{
            //    MessageBox.Show("UserName và Password không đúng! ");
            //    LB_Clear_Click(new object(), new EventArgs());
            //}
            if (tbUserName.Text == "" && tbPassword.Text == "")
            {
                MessageBox.Show("Vui lòng nhập UserName và PassWord");
            }

            else
            {
                if(tbUserName.Text == username_admin && tbPassword.Text == password_admin)
                {
                    Dashboard ds = new Dashboard();
                    ds.Show();
                    ds.login_show = new Quit(this.Show);
                    ds.quit = new Quit(this.Close);
                    this.Hide();
                }
                else if (LoginDAL.Instance.Login(tbUserName.Text, tbPassword.Text,'\0'))
                //if(tbUserName.Text == "Admin" && tbPassword.Text == "12345")
                {
                    Dashboard ds = new Dashboard();
                    ds.Show();
                    ds.login_show = new Quit(this.Show);
                    ds.quit = new Quit(this.Close);
                    this.Hide();
                }
                else if (LoginDAL.Instance.Login(tbUserName.Text, tbPassword.Text,'!'))
                {

                    Seller sl = new Seller();
                    NhanVien nv = DataNhanVienDAL.Instance.getNVbyUserNameAndPassWork(tbUserName.Text,tbPassword.Text);
                    sl.loadInforNV(nv);
                    string s = DataNhanVienDAL.Instance.getNameNV(tbUserName.Text, tbPassword.Text);
                    sl.setNameBtAccount(s);
                    sl.Show();
                    sl.login_Show = new Quit(this.Show);
                    sl.quit = new Quit(this.Close);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("UserName và Password không đúng! ");
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

        private void LB_Clear_Click(object sender, EventArgs e)
        {
            tbUserName.Text = "";
            tbPassword.Text = "";
        }

        private void ReloadAccount_Click(object sender, EventArgs e)
        {
            ReloadAccount rl = new ReloadAccount();
            rl.Show();
        }

        
    }
}

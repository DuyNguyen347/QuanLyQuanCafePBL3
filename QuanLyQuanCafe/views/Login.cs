﻿using QuanLyQuanCafe.DAL;
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
        string s = "";
        public Login()
        {
            InitializeComponent();
        }
        private void BtLogin_Click_1(object sender, EventArgs e)
        {
            if (tbUserName.Text == "" && tbPassword.Text == "")
            {
                MessageBox.Show("Vui lòng nhập UserName và PassWord");
            }

            else
            {
                NhanVien nv = DataNhanVienDAL.Instance.GetNhanVienbyUserName(tbUserName.Text);
                if (tbUserName.Text == username_admin && tbPassword.Text == password_admin)
                {
                    Dashboard ds = new Dashboard();
                    ds.Show();
                    ds.hidebtAccount();
                    ds.login_show = new Quit(this.Show);
                    ds.quit = new Quit(this.Close);
                    this.Hide();
                }
                else if (nv != null)
                {
                    if (nv.ChucVu.TenChucVu == "QUẢN LÝ" && nv.TaiKhoan.PassWord.Trim() == MaHoaMatKhau.Instance.EncodePass(tbPassword.Text))
                    {
                        Dashboard ds = new Dashboard();
                        ds.loadInforNV(nv);
                        ds.setNameBtAccount(nv.Name);
                        ds.Show();
                        ds.login_show = new Quit(this.Show);
                        ds.quit = new Quit(this.Close);
                        this.Hide();
                    }
                    else if (nv.ChucVu.TenChucVu == "BÁN HÀNG" && nv.TaiKhoan.PassWord.Trim() == MaHoaMatKhau.Instance.EncodePass(tbPassword.Text))
                    {
                        Seller sl = new Seller();
                        sl.loadInforNV(nv);
                        sl.setNameBtAccount(nv.Name);
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
            //ReloadAccount rl = new ReloadAccount();
            //rl.Show();
            panelLogin.Visible = false;
            panelChangepass.Visible = true;
            guna2Transition1.ShowSync(panelChangepass);
        }

        private void lbLogin_Click(object sender, EventArgs e)
        {
            panelLogin.Visible = true;
            panelChangepass.Visible = false;
            guna2Transition1.HideSync(panelChangepass);
            setPanelChangePass();
        }

        private void tbGetCode_Click(object sender, EventArgs e)
        {
            if (tbEmail.Text == "" || tbUserNameFP.Text == "")
            {
                MessageBox.Show("Vui lòng nhập email và username");
            }
            else
            {
                if (ReloadAccountDAL.Instance.Reload(tbEmail.Text,tbUserNameFP.Text))
                {
                    tbCode.Visible = true;
                    btXacNhan.Visible = true;
                    s = DataProvider.sendcode(tbEmail.Text, 0);
                }
                else
                {
                    MessageBox.Show("Email hoặc UserName khong đúng");
                }
            }
        }

        private void btXacNhan_Click(object sender, EventArgs e)
        {
            if (tbCode.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã CODE !");
            }
            else
            {
                if (tbCode.Text == s)
                {
                    tbNewPass.Visible = true;
                    tbXacNhanPass.Visible = true;
                    btDoiMatKhau.Visible = true;
                }
                else
                {
                    MessageBox.Show("Mã CODE không đúng !");
                }
            }
        }

        private void btDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (tbNewPass.Text == "" && tbXacNhanPass.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới");
            }
            else if (tbNewPass.Text != tbXacNhanPass.Text)
            {
                MessageBox.Show("Các mật khẩu đã nhập không khớp. Vui lòng thử lại!");
            }
            else
            {
                string query = "update TaiKhoan set PassWord = '" + MaHoaMatKhau.Instance.EncodePass(tbXacNhanPass.Text)
                    + "' from TaiKhoan tk inner join NhanVien nv on tk.UserName = nv.UserName where nv.Email = '" + tbEmail.Text + "' and nv.UserName = N'"
                    + tbUserNameFP.Text + "'";
                if (DataProvider.Instance.executeDB(query))
                {
                    MessageBox.Show("Đổi mật khẩu thành công");
                    lbLogin_Click(new object(), new EventArgs());
                }
                else MessageBox.Show("Error");
            }
        }
        public void setPanelChangePass()
        {
            tbEmail.Text = "";
            tbUserNameFP.Text = "";
            tbCode.Text = "";
            tbNewPass.Text = "";
            tbXacNhanPass.Text = "";
            tbCode.Visible = false;
            tbNewPass.Visible = false;
            tbXacNhanPass.Visible = false;
            btDoiMatKhau.Visible = false;
            btXacNhan.Visible = false;
        }
    }
}

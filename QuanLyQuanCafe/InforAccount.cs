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
    public partial class InforAccount : Form
    {
        NhanVien nv;
        public InforAccount(NhanVien s)
        {
            nv = DataNhanVienDAL.getNVbyID(s.ID);
            InitializeComponent();
            GUI();
        }
        public void GUI()
        {
            tbName.Text = nv.Name;
            tbNgaySinh.Text = nv.NgaySinh;
            tbLuong.Text = nv.Luong.ToString();
            tbChucVu.Text = nv.ChucVu;
            tbEmail.Text = nv.Email;
            tbSDT.Text = nv.SDT;
            tbUserName.Text = nv.Username;
            tbName.Enabled = false;
            tbNgaySinh.Enabled = false;
            tbLuong.Enabled = false ;
            tbChucVu.Enabled = false ;
            tbEmail.Enabled = false ;
            tbSDT.Enabled = false ;
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            string username = tbUserName.Text;
            string oldpass = tbOldPass.Text;
            string newpass = tbNewPass.Text;
            string xacnhanPass = tbXacNhanPass.Text;
            if(newpass != xacnhanPass)
            {
                MessageBox.Show("Vui lòng nhập đúng  mật khẩu mới", "Xác nhận mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (LoginDAL.Instance.EncodePass(oldpass) != DataNhanVienDAL.Instance.getPassNV(nv.ID).Replace(" ", ""))
                {
                    MessageBox.Show("Vui lòng nhập đúng  mật khẩu cũ", "Xác nhận mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (newpass == null || newpass == "")
                {
                    try
                    {
                        string username_ = nv.Username;
                        DataProvider.Instance.setdata("insert into TaiKhoan values('" + tbUserName.Text + "','" + nv.PassWord + "')");
                        string query = "update Nhanvien set UserName = '" + tbUserName.Text + "' where UserName = '" + nv.Username + "'";
                        if (DataProvider.Instance.executeDB(query))
                        {
                            DataProvider.Instance.setdata("delete TaiKhoan where UserName ='" + username_ + "'");
                            MessageBox.Show("Cap nhat thanh cong", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Dispose();
                        }
                        else DataProvider.Instance.setdata("delete TaiKhoan where UserName ='" + tbUserName.Text + "'");
                    }catch(Exception ex) { }
                }
                else
                {
                    //string un = tbUserName.Text;
                    if(tbUserName.Text == nv.Username)
                    {
                        string query = "update TaiKhoan set PassWord = '" + LoginDAL.Instance.EncodePass(newpass) + "' where UserName = '" + nv.Username + "'";
                        if(DataProvider.Instance.executeDB(query))
                        {
                            MessageBox.Show("Cap nhat thanh cong");
                            this.Close();
                        }
                    }   
                    else if(tbUserName.Text != nv.Username)
                    {
                        string query1 = "insert into TaiKhoan values('" + tbUserName.Text + "','" + LoginDAL.Instance.EncodePass(newpass) + "')";
                        DataProvider.Instance.executeDB(query1);
                        string query11 = "update NhanVien set UserName = '" + tbUserName.Text + "' where ID = '" + nv.ID + "'";
                        if(DataProvider.Instance.executeDB(query11))
                        {
                            DataProvider.Instance.executeDB("delete TaiKhoan where UserName = '" + nv.Username + "'");
                            MessageBox.Show("Cap nhat thanh cong!");
                        }
                    }
                    //try
                    //{
                    //    string username_ = nv.Username;
                    //    DataProvider.Instance.executeDB("insert into TaiKhoan values('" + tbUserName.Text + "','" + newpass + "')");
                    //    string query2 = "update NhanVien set UserName = '" + tbUserName.Text + "' where UserName = '" + username_ + "'";
                    //    if (DataProvider.Instance.executeDB(query2))
                    //    {
                    //        DataProvider.Instance.setdata("delete TaiKhoan where UserName ='" + username_ + "'");
                    //        MessageBox.Show("Cap nhat thanh cong", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //        this.Dispose();
                    //    }
                    //    else DataProvider.Instance.setdata("delete TaiKhoan where UserName ='" + tbUserName.Text + "'");
                    //}catch(Exception ex) { }
                }
            }
        }

        private void InforAccount_Load(object sender, EventArgs e)
        {
            nv = DataNhanVienDAL.getNVbyID(nv.ID);
        }
    }
}

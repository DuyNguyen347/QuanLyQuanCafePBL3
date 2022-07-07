using QuanLyQuanCafe.BLL;
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
            nv = NhanVienBLL.Instance.GetNhanVienByID(s.ID);
            InitializeComponent();
            GUI();
        }
        public void GUI()
        {
            tbName.Text = nv.Name;
            tbNgaySinh.Text = nv.NgaySinh;
            tbLuong.Text = nv.ChucVu.Luong.ToString();
            tbChucVu.Text = nv.ChucVu.TenChucVu;
            tbEmail.Text = nv.Email;
            tbSDT.Text = nv.SDT;
            tbUserName.Text = nv.TaiKhoan.UserName;
            tbName.Enabled = false;
            tbNgaySinh.Enabled = false;
            tbLuong.Enabled = false ;
            tbChucVu.Enabled = false ;
            tbEmail.Enabled = false ;
            tbSDT.Enabled = false ;
            pbAnhNV.Image = nv.Anh;
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            string username = tbUserName.Text;
            string oldpass = MaHoaMatKhau.Instance.EncodePass(tbOldPass.Text);
            string newpass = MaHoaMatKhau.Instance.EncodePass(tbNewPass.Text);
            string xacnhanPass = MaHoaMatKhau.Instance.EncodePass(tbXacNhanPass.Text);
            if(newpass != xacnhanPass)
            {
                MessageBox.Show("Vui lòng nhập đúng  mật khẩu mới", "Xác nhận mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (oldpass != NhanVienBLL.Instance.GetNhanVienByID(nv.ID).TaiKhoan.PassWord.Replace(" ", ""))
                {
                    MessageBox.Show("Vui lòng nhập đúng  mật khẩu cũ", "Xác nhận mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (tbNewPass.Text == null || tbNewPass.Text == "")
                {
                    try
                    {
                        string username_ = nv.TaiKhoan.UserName;
                        DataProvider.Instance.SetData("insert into TaiKhoan values('" + tbUserName.Text + "','" + nv.TaiKhoan.PassWord + "')");
                        string query = "update Nhanvien set UserName = '" + tbUserName.Text + "' where UserName = '" + nv.TaiKhoan.UserName + "'";
                        if (DataProvider.Instance.executeDB(query))
                        {
                            DataProvider.Instance.SetData("delete TaiKhoan where UserName ='" + username_ + "'");
                            MessageBox.Show("Cap nhat thanh cong", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Dispose();
                        }
                        else DataProvider.Instance.SetData("delete TaiKhoan where UserName ='" + tbUserName.Text + "'");
                    }catch(Exception ) { }
                }
                else
                {
                    //string un = tbUserName.Text;
                    if(tbUserName.Text == nv.TaiKhoan.UserName)
                    {
                        string query = "update TaiKhoan set PassWord = '" + newpass +"' where UserName = '" + nv.TaiKhoan.UserName + "'";
                        if(DataProvider.Instance.executeDB(query))
                        {
                            MessageBox.Show("Cap nhat thanh cong");
                            this.Close();
                        }
                    }   
                    else if(tbUserName.Text != nv.TaiKhoan.UserName)
                    {
                        string query1 = "insert into TaiKhoan values('" + tbUserName.Text + "','" + newpass + "')";
                        DataProvider.Instance.executeDB(query1);
                        string query11 = "update NhanVien set UserName = '" + tbUserName.Text + "' where ID = '" + nv.ID + "'";
                        if(DataProvider.Instance.executeDB(query11))
                        {
                            DataProvider.Instance.executeDB("delete TaiKhoan where UserName = '" + nv.TaiKhoan.UserName + "'");
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
            nv = NhanVienBLL.Instance.GetNhanVienByID(nv.ID);
        }
    }
}

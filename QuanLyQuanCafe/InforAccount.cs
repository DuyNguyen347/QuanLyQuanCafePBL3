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
            nv = s;
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
                    if(oldpass != DataNhanVienDAL.Instance.getPassNV(nv.ID).Replace(" ",""))
                    { 
                        MessageBox.Show("Vui lòng nhập đúng  mật khẩu cũ","Xác nhận mật khẩu",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    }
                    else if(newpass == null || newpass == "")
                    {
                        string query = "update Nhanvien set UserName = '" + tbUserName.Text + "' where UserName = '" + nv.Username + "'";
                        if (DataProvider.Instance.executeDB(query))
                        {
                            MessageBox.Show("Cap nhat thanh cong", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        string query2 = "update Nhanvien set UserName = '" + tbUserName.Text + "' , PassWord = '" + newpass +  "' where UserName = '" + nv.Username + "'";
                        if (DataProvider.Instance.executeDB(query2))
                        {
                            MessageBox.Show("Cap nhat thanh cong"," ",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        }
                    }
            }
        }
    }
}

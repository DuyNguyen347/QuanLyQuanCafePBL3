using QuanLyQuanCafe.DAL;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public class NhanVien
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string NgaySinh { get; set; }
        public ChucVu ChucVu { get; set; }
        public TaiKhoan TaiKhoan { get; set; }
        public string Email { get; set; }
        public int Luong { get; private set; }
        public string SDT { get; set; }
        public Image Anh { get; set; }
        public NhanVien() {
        }
        public NhanVien(string iD,string name,string ngaysinh, string chucvu,string username,string password,string email,string sdt,Image anh)
        {
            ID = iD;
            Name = name;
            NgaySinh = ngaysinh;
            ChucVu = DataChucVuDAL.Instance.getChucVubyID(chucvu);
            TaiKhoan = new TaiKhoan(username,password);
            Email = email;
            Luong = ChucVu.Luong;
            SDT = sdt;
            Anh = anh;
        }
        public NhanVien(NhanVien nhanVien)
        {
            ID = nhanVien.ID;
            Name = nhanVien.Name;
            NgaySinh = nhanVien.NgaySinh;
            ChucVu = nhanVien.ChucVu;
            TaiKhoan = nhanVien.TaiKhoan;
            Email = nhanVien.Email;
            Luong = nhanVien.Luong;
            SDT = nhanVien.SDT;
            Anh = nhanVien.Anh;
        }
        
        public NhanVien(DataRow row)
        {
            ID = row["ID"].ToString();
            Name = row["Name"].ToString();
            NgaySinh = row["NgaySinh"].ToString().Split(' ').First();
            try
            {
                ChucVu = DataChucVuDAL.Instance.getChucVubyID(row["ChucVu"].ToString());
                Luong = ChucVu.Luong;
            }
            catch (Exception ex)
            {
                ChucVu = new ChucVu("", 0);
                Luong = ChucVu.Luong;
            }
            try
            {
                TaiKhoan = DataTaiKhoanDAL.Instance.getTaiKhoanbyUserName(row["UserName"].ToString());
            }
            catch (Exception ex)
            {
                TaiKhoan = new TaiKhoan("", "");
            }
            Email = row["Email"].ToString();
            SDT = row["Phone"].ToString();
            try
            {
                byte[] b = (byte[])row["Anh"]; ;
                Anh = DataNhanVienDAL.Instance.ByteArrayToImage(b);
            }
            catch(Exception ex)
            {
                Anh = null;
            }
            
        }
    }
}

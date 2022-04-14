using QuanLyQuanCafe.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
        public string ChucVu { get; set; }
        public string Username { get; set; }
        public string PassWord { get; set; }
        public double Luong { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public NhanVien() {
        }
        public NhanVien(string iD,string name,string ngaysinh, string chucvu,string username,string password,string luong,string email,string sdt)
        {
            ID = iD;
            Name = name;
            NgaySinh = ngaysinh;
            ChucVu = chucvu;
            Username = username;
            PassWord = password;
            if(luong == "")
            {
                Luong = 0;
            }
            else
            {
                Luong = Convert.ToDouble(luong);
            }
            Email = email;
            SDT = sdt;
        }
        public NhanVien(NhanVien nhanVien)
        {
            Luong = nhanVien.Luong;
            ID = nhanVien.ID;
            Name = nhanVien.Name;
            NgaySinh = nhanVien.NgaySinh;
            ChucVu = nhanVien.ChucVu;
            Username = nhanVien.Username;
            PassWord = nhanVien.PassWord;
            Email = nhanVien.Email;
            SDT = nhanVien.SDT;
        }
        
        public NhanVien(DataRow row)
        {
            ID = row[0].ToString();
            Name = row[1].ToString();
            NgaySinh = row[2].ToString().Split(' ').First();
            ChucVu = row[3].ToString();
            Username = row[4].ToString();
            Email = row[5].ToString();
            Luong = Convert.ToDouble(row[6].ToString());
            SDT = row[7].ToString();
        }
    }
}

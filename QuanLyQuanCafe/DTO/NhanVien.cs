using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public NhanVien() { }
        public NhanVien(string iD,string name,string ngaysinh, string chucvu,string username,string password,string luong)
        {
            ID = iD;
            Name = name;
            NgaySinh = ngaysinh;
            ChucVu = chucvu;
            Username = username;
            PassWord = password;
            Luong = Luong;
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
        }
    }
}

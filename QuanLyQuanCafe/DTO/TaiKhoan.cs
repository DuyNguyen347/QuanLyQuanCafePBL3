using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class TaiKhoan
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public TaiKhoan(string username,string password)
        {
            UserName = username;
            PassWord = password;
        }
        public TaiKhoan(DataRow row)
        {
            UserName = row["UserName"].ToString();
            PassWord = row["PassWord"].ToString();
        }
        public override string ToString()
        {
            return UserName.ToString();
        }
    }
}

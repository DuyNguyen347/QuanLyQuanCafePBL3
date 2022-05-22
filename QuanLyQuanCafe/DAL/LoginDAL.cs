using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAL
{
    public  class LoginDAL
    {

        private static LoginDAL instance;

        public static LoginDAL Instance {
            get
            {
                if(instance == null)
                {
                    instance = new LoginDAL();
                }
                return instance;
            }
            private set => instance = value; 
        }
        public LoginDAL() { }
        public bool Login(string username, string password,char c)
        {
            string s = "select * from View_Login where UserName = N'" + username + "' and PassWord = '" + password + "' and ChucVu " + c + "= N'Quản Lý'";
            DataTable d =  DataProvider.Instance.GetRecords(s);
            return d.Rows.Count > 0 ;
        }
        public string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public string MD5Hash(string input)
        {

            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));
            // x2 là định dạng hệ thập lục phân
            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();

            ////Tạo MD5 
            //MD5 mh = MD5.Create();
            ////Chuyển kiểu chuổi thành kiểu byte
            //byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes("Chuỗi cần mã hóa");
            ////mã hóa chuỗi đã chuyển
            //byte[] hash = mh.ComputeHash(inputBytes);
            ////tạo đối tượng StringBuilder (làm việc với kiểu dữ liệu lớn)
            //StringBuilder sb = new StringBuilder();

            //for (int i = 0; i < hash.Length; i++)
            //{
            //    sb.Append(hash[i].ToString("X2"));
            //}
            //return sb.ToString();
            //nếu bạn muốn các chữ cái in thường thay vì in hoa thì bạn thay chữ "X" in hoa 
            //trong "X2" thành "x"
        }
        public string EncodePass(string pass)
        {
            return MD5Hash(Base64Encode(pass));
        }
    }
}

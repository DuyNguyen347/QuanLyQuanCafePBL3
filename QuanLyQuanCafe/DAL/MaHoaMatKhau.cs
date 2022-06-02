using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAL
{
    public class MaHoaMatKhau
    {
        private static MaHoaMatKhau _Instance;

        public static MaHoaMatKhau Instance {
            get
            {
                if(_Instance == null)
                {
                    _Instance = new MaHoaMatKhau();
                }
                return _Instance;
            }
            private set { }
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

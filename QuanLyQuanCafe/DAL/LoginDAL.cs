using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
        public string Login(string username, string password)
        {
            string s = "select ChucVu from NhanVien where UserName = '"+username +"' and PassWord = '"+password+"'";
            DataTable  d =  DataProvider.Instance.GetRecords(s);
            return d.Rows[0][0].ToString();
        }
    }
}

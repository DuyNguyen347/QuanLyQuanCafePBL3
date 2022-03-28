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
        public bool Login(string username, string password,char c)
        {
            string s = "select * from dbo.NhanVien where UserName = N'" + username + "' and PassWord = '" + password + "' and ChucVu " + c + "= N'Quản Lý'";
            DataTable d =  DataProvider.Instance.GetRecords(s);
            return d.Rows.Count > 0 ;
        }
    }
}

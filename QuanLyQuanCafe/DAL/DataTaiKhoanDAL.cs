using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe.DAL
{
    internal class DataTaiKhoanDAL
    {
        private static DataTaiKhoanDAL instance;
        public static DataTaiKhoanDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new DataTaiKhoanDAL();
                return instance;
            }
            private set { }
        }
        public DataTable data()
        {
            DataTable data;
            string query = "select *  from dbo.TaiKhoan";
            data = DataProvider.Instance.GetRecords(query);
            return data;
        }
        public List<TaiKhoan> locdulieu(string username,string password)
        {
            List<TaiKhoan> taikhoans = new List<TaiKhoan>();
            foreach (DataRow i in data().Rows)
                if (i["UserName"].ToString().ToUpper().Equals(username.Trim().ToUpper())&& 
                    i["PassWord"].ToString().ToUpper().Equals(password.Trim().ToUpper()))
                    taikhoans.Add(new TaiKhoan(i));
            return taikhoans;
        }
        public TaiKhoan getTaiKhoanbyUserName(string username)
        {
            List<TaiKhoan> taikhoans = new List<TaiKhoan>();
            foreach (DataRow i in data().Rows)
                if (i["UserName"].ToString().ToUpper().Equals(username.Trim().ToUpper())) {
                    taikhoans.Add(new TaiKhoan(i));
            }
            return taikhoans[0];
        }
        public void addTaiKhoan(TaiKhoan taikhoan)
        {
            DataProvider.Instance.setdata("insert into TaiKhoan values('" + taikhoan.UserName + "','" + DataProvider.Instance.EncodePass(taikhoan.PassWord) + "')");
        }
        public void deleteTaiKhoan(String username)
        {
            DataProvider.Instance.setdata("update NhanVien set UserName = null where UserName = '" + username + "'");
            DataProvider.Instance.setdata("delete from TaiKhoan where UserName = N'" + username + "'");
        }
        public void updateTaiKhoan(TaiKhoan taikhoan)
        {
            DataProvider.Instance.setdata("update TaiKhoan set PassWord = '" + DataProvider.Instance.EncodePass(taikhoan.PassWord) + "' where UserName = '" + taikhoan.UserName + "'");
        }
    }
}

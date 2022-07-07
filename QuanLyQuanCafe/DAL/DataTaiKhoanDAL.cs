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
        public DataTable Data()
        {
            DataTable data;
            string query = "select *  from dbo.TaiKhoan";
            data = DataProvider.Instance.GetRecords(query);
            return data;
        }
        public List<TaiKhoan> LocDuLieu(string username,string password)
        {
            List<TaiKhoan> taikhoans = new List<TaiKhoan>();
            foreach (DataRow i in Data().Rows)
                if (i["UserName"].ToString().ToUpper().Equals(username.Trim().ToUpper())&& 
                    i["PassWord"].ToString().ToUpper().Equals(password.Trim().ToUpper()))
                    taikhoans.Add(new TaiKhoan(i));
            return taikhoans;
        }
        public TaiKhoan GetTaiKhoanbyUserName(string username)
        {
            List<TaiKhoan> taikhoans = new List<TaiKhoan>();
            foreach (DataRow i in Data().Rows)
                if (i["UserName"].ToString().ToUpper().Equals(username.Trim().ToUpper())) {
                    taikhoans.Add(new TaiKhoan(i));
            }
            return taikhoans[0];
        }
        public void AddTaiKhoan(TaiKhoan taikhoan)
        {
            DataProvider.Instance.SetData("insert into TaiKhoan values('" + taikhoan.UserName + "','" + MaHoaMatKhau.Instance.EncodePass(taikhoan.PassWord) + "')");
        }
        public void AddTaiKhoan(string username,string email)
        {
            try
            {
                DataProvider.Instance.SetData("insert into TaiKhoan values('" + username + "','" + "24062002" + "')");
                string passWord = DataProvider.sendcode(email, 1);
                UpdateTaiKhoan(new TaiKhoan(username, passWord));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteTaiKhoan(string username)
        {
            DataProvider.Instance.SetData("update NhanVien set UserName = null where UserName = '" + username + "'");
            DataProvider.Instance.SetData("delete from TaiKhoan where UserName = N'" + username + "'");
        }
        public void UpdateTaiKhoan(TaiKhoan taikhoan)
        {
            DataProvider.Instance.SetData("update TaiKhoan set PassWord = '" + MaHoaMatKhau.Instance.EncodePass(taikhoan.PassWord) + "' where UserName = '" + taikhoan.UserName + "'");
        }
    }
}

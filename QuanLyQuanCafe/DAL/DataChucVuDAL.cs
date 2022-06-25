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
    class DataChucVuDAL
    {
        private static DataChucVuDAL instance;
        public static DataChucVuDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new DataChucVuDAL();
                return instance;
            }
            private set { }
        }
        public DataTable Data()
        {
            DataTable data;
            string query = "select *  from dbo.ChucVu";
            data = DataProvider.Instance.GetRecords(query);
            return data;
        }
        public List<ChucVu> LocDuLieu(string chucvu)
        {
            List<ChucVu> chucVus = new List<ChucVu>();
            foreach (DataRow i in Data().Rows)
                if (i[0].ToString().ToUpper().Contains(chucvu.Trim().ToUpper()))
                    chucVus.Add(new ChucVu(i));
            return chucVus;
        }
        public ChucVu GetChucVuByID(string chucvu)
        {
            List<ChucVu> chucVus = new List<ChucVu>();
            foreach (DataRow i in Data().Rows)
                if (i[0].ToString().ToUpper().Equals(chucvu.Trim().ToUpper()))
                    chucVus.Add(new ChucVu(i));
            return chucVus[0];
        }
        public void AddChucvu(ChucVu chucVu)
        {
            DataProvider.Instance.SetData("insert into ChucVu values(N'" + chucVu.TenChucVu + "'," + chucVu.Luong + ")");
        }
        public void DeleteChucvu(String tenchucvu)
        {
            DataProvider.Instance.SetData("update NhanVien set ChucVu = null where ChucVu = N'" + tenchucvu + "'");
            DataProvider.Instance.SetData("delete from ChucVu where ChucVu.ChucVu = N'" + tenchucvu + "'");
        }
        public void UpdateChucvu(ChucVu chucVu)
        {
            DataProvider.Instance.SetData("update ChucVu set Luong = " + chucVu.Luong + " where ChucVu.ChucVu = N'" + chucVu.TenChucVu + "' ");
        }
    }
}

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
        public static DataTable data()
        {
            DataTable data;
            string query = "select *  from dbo.ChucVu";
            data = DataProvider.Instance.GetRecords(query);
            return data;
        }
        public static List<ChucVu> locdulieu(string chucvu)
        {
            List<ChucVu> chucVus = new List<ChucVu>();
            foreach (DataRow i in data().Rows)
                if (i[0].ToString().ToUpper().Contains(chucvu.Trim().ToUpper()))
                    chucVus.Add(new ChucVu(i));
            return chucVus;
        }
        public static DataTable capnhatChucvu(ChucVu chucVu, int i)
        {
            string query = "";
            switch (i)
            {
                case 1:
                    int dem = 0;
                    foreach (DataRow row in DataChucVuDAL.data().Rows)
                        if (row[0].ToString() == chucVu.TenChucVu)
                            dem++;
                    if (dem == 0)
                        try
                        {
                            DataProvider.Instance.setdata("insert into ChucVu values(N'" + chucVu.TenChucVu + "'," + chucVu.Luong + ")");
                        }catch(Exception ex) { MessageBox.Show(ex.Message); }
                    break;
                case 2:
                    try
                    {
                        DataProvider.Instance.setdata("update NhanVien set ChucVu = null where ChucVu = N'" + chucVu.TenChucVu + "'");
                        DataProvider.Instance.setdata("delete from ChucVu where ChucVu.ChucVu = N'" + chucVu.TenChucVu + "'");
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                    break;
                case 3:
                    try
                    {
                        DataProvider.Instance.setdata("update ChucVu set Luong = " + chucVu.Luong + " where ChucVu.ChucVu = N'" + chucVu.TenChucVu + "' ");
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                    break;
                default:
                    break;
            }
            return null;
        }
    }
}

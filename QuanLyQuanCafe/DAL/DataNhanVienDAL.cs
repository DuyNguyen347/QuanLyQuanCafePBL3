using QuanLyQuanCafe.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace QuanLyQuanCafe.DAL
{
    internal class DataNhanVienDAL
    {

        
        public static DataTable data()
        {
            DataTable data;
            string query = "select *  from NhanVien";
            data = DataProvider.Instance.GetRecords(query);
            return data;
        }
    }
}

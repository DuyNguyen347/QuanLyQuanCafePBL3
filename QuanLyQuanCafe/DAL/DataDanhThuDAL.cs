using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace QuanLyQuanCafe.DAL
{
    internal class DataDanhThuDAL
    {
        public static DataTable data(DateTime datebegin, DateTime dateend)
        {
            DataTable data;
            string query = "select DanhThu1.TimeCheckout,SoDon,TongTien from DanhThu1 inner join DanhThu2 on DanhThu1.TimeCheckout = DanhThu2.TimeCheckout where DanhThu1.TimeCheckout >= '"+datebegin+"' and DanhThu1.TimeCheckout <= '"+dateend+"'";
            data = DataProvider.Instance.GetRecords(query);
            return data;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace QuanLyQuanCafe.DAL
{
    internal class DataBillDAL
    {
        public static DataTable data(DateTime datebegin,DateTime dateend)
        {
            DataTable data;
            string query = " select HoaDon.ID_Hoa,TimeCheckin,TimeCheckout,ID_table,TongTien from HoaDon inner join HoaDon2 on HoaDon.ID_Hoa = HoaDon2.ID_Hoa where TimeCheckout >= '" + datebegin+"' and TimeCheckout <= '"+dateend+"'   ";
            data = DataProvider.Instance.GetRecords(query);
            return data;
        }
        

    }
}

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
            string query = "select DanhThu1.TimeCheckout,SoDon,TongTien from DanhThu1 inner join DanhThu2 on DanhThu1.TimeCheckout = DanhThu2.TimeCheckout where DanhThu1.TimeCheckout >= '"+DataBillDAL.FormatDatetimeShort(datebegin)+"' and DanhThu1.TimeCheckout <= '"+DataBillDAL.FormatDatetimeShort(dateend)+"'";
            data = DataProvider.Instance.GetRecords(query);
            return data;
        }
        public static void XoaThongTinHoaDonTuMon(string ID)
        {
            string query = "delete from ThongTinHoaDon where ID_Mon = '" + ID + "'";
            DataProvider.Instance.setdata(query);
        }
        public static void XoaThongTinHoaDonTuHoaDon(string ID)
        {
            string query = "delete from ThongTinHoaDon where ID_HoaDon = '" + ID + "'";
            DataProvider.Instance.setdata(query);
        }
        public static void XoaHoaDonTuBan(string ID)
        {
            string query = "delete from HoaDon where ID_table = '" + ID + "'";
            foreach (DataRow id in DataProvider.Instance.GetRecords("select * from HoaDon where ID_table = '" + ID + "'").Rows)
                XoaThongTinHoaDonTuHoaDon(id[0].ToString());
            DataProvider.Instance.setdata(query);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuanLyQuanCafe.DTO;
using System.Windows.Forms;

namespace QuanLyQuanCafe.DAL
{
    internal class DataBillDAL
    {
        public static DataTable locdata(DateTime datebegin,DateTime dateend)
        {
            DataTable data;
            string query = " select HoaDon.ID_Hoa,TimeCheckin,TimeCheckout,ID_table,TongTien from HoaDon inner join HoaDon2 on HoaDon.ID_Hoa = HoaDon2.ID_Hoa where TimeCheckout >= '" + datebegin+"' and TimeCheckout <= '"+dateend+"'   ";
            data = DataProvider.Instance.GetRecords(query);
            return data;
        }
        public static DataTable data()
        {
            DataTable data;
            string query = " select * from HoaDon ";
            data = DataProvider.Instance.GetRecords(query);
            return data;
        }
        public static List<HoaDon> locdulieu(string id = "",string id_table = "")
        {
            List<HoaDon> hoaDons = new List<HoaDon>();
            foreach (DataRow i in data().Rows)
                if (i[0].ToString().Contains(id.ToUpper().Trim()) && i[3].ToString().Contains(id_table.ToUpper().Trim()))
                    hoaDons.Add(new HoaDon(i));
            return hoaDons;
        }
        public static DataTable capnhatHoaDon(HoaDon hoadon,int i)
        {
            string query = "";
            switch (i)
            {
                case 1:
                    int dem = 0;
                    foreach (DataRow row in DataBillDAL.data().Rows)
                        if (row[0].ToString() == hoadon.ID)
                            dem++;
                    if (dem == 0)
                        query = "insert into HoaDon values('"+hoadon.ID+"',"+FormatDatetimetoSQL(hoadon.TimeCheckin)+ ","+FormatDatetimetoSQL(hoadon.TimeCheckout)+",'" + hoadon.ID_ban+"')";
                    break;
                case 2:
                    query = "delete from HoaDon where ID_Hoa = '" + hoadon.ID + "'";
                    DataDanhThuDAL.XoaThongTinHoaDonTuHoaDon(hoadon.ID);
                    break;
                case 3:
                    query = "update HoaDon set TimeCheckout = " + FormatDatetimetoSQL(hoadon.TimeCheckout) + " and ID_table"+ hoadon.ID_ban +"where ID_Hoa= '" + hoadon.ID + "' ";
                    break;
                default:
                    break;
            }
            DataTable data;
            data = DataProvider.Instance.setdata(query);
            return data;
        }
        public static string FormatDatetimetoSQL(DateTime dateTime)
        {
            string s = "";
            s += dateTime.Day.ToString() + "-" + dateTime.Month.ToString() + "-" + (dateTime.Year % 100).ToString() + " " +
               dateTime.Hour.ToString() + ":" + dateTime.Minute.ToString() + ":" + dateTime.Second.ToString();
            return "convert(datetime, '"+ s +"', 5)";
        }
    }
}

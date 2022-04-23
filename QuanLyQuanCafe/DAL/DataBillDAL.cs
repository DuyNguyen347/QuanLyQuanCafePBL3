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
            string query = " select HoaDon.ID_Hoa,TimeCheckin,TimeCheckout,ID_table,TongTien from HoaDon inner join HoaDon2 on HoaDon.ID_Hoa = HoaDon2.ID_Hoa " +
                           "where TimeCheckout >= '" +FormatDatetimeShort(datebegin)+ "' and TimeCheckout <= '"+ FormatDatetimeShort(dateend) +"' order by TimeCheckout asc";
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
        public static List<HoaDon> locdulieu(string id = "", string id_table = "", string checkout = "1/1/2001 12:00:00 AM")
        {
            List<HoaDon> hoaDons = new List<HoaDon>();
            foreach (DataRow i in data().Rows)
                if (i[0].ToString().Contains(id.ToUpper().Trim()) && i[3].ToString().Contains(id_table.ToUpper().Trim()) && i[2].ToString() == checkout)
                {
                    hoaDons.Add(new HoaDon(i));
                }
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
                    query = "update HoaDon set TimeCheckout = " + FormatDatetimetoSQL(hoadon.TimeCheckout) + ", ID_table = '"+ hoadon.ID_ban +"' where ID_Hoa= '" + hoadon.ID + "' ";
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
        public static string FormatDatetimeShort(DateTime dateTime)
        {
            string s = "";
            s = dateTime.Year + "/" + dateTime.Month + "/" + dateTime.Day;
            return s;
        }
        public static string CapIdHoaDon()
        {
            string id = "";
            int n = GetCountNumOfOrderInDate();
            string m = "";
            if (DateTime.Now.Month < 10)
            {
                m = "0" + DateTime.Now.Month.ToString();
            }
            else m = DateTime.Now.Month.ToString();
            if (n < 10)
            {
                id = "HD00" + (n + 1).ToString() + DateTime.Now.Day.ToString() + m + DateTime.Now.Year.ToString().Remove(0, 2);
            }
            else if (n >=10 && n < 100)
            {
                id = "HD0" + (n + 1).ToString() + DateTime.Now.Day.ToString() + m + DateTime.Now.Year.ToString().Remove(0, 2);
            }
            else
            {
                id = "HD" + (n + 1).ToString() + DateTime.Now.Day.ToString() + m + DateTime.Now.Year.ToString().Remove(0, 2);
            }
            return id;
        }
        public static int GetCountNumOfOrderInDate()
        {
            string sql = "select * from HoaDon where convert(nvarchar(10),TimeCheckIn,103) = convert(nvarchar(10),getdate(),103)";
            DataTable dt = DataProvider.Instance.GetRecords(sql);
            return dt.Rows.Count;
        }
    }
}

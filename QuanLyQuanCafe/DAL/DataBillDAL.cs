﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuanLyQuanCafe.DTO;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyQuanCafe.DAL
{
    internal class DataBillDAL
    {
        public static DataTable locdata(DateTime datebegin,DateTime dateend)
        {
            DataTable data;
            string query = " select * from HoaDon where LEN(ID_HoaDon) <12 and TimeCheckout between '" + FormatDatetimeShort(datebegin) + "' and '"+ FormatDatetimeShort(dateend) + "'";
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
        public static List<HoaDon> locdulieu(string id = "", string id_table = "", DateTime s = default)
        {
            s = new DateTime(2001, 01, 01);
            DataTable data;
            string query = " select * from View_LichSu where TimeCheckout = " + FormatDatetimetoSQL(s);
            data = DataProvider.Instance.GetRecords(query);
            List<HoaDon> hoaDons = new List<HoaDon>();
            if (id == "")
                foreach (DataRow i in data.Rows)
                {
                    //MessageBox.Show(i[3].ToString().Trim() + "|" + id_table.ToUpper().Trim());
                    if (i[3].ToString().Trim() == id_table.ToUpper().Trim() && i[2].ToString() == s.ToString())
                        hoaDons.Add(new HoaDon(i));
                }
            else if (id_table == "")
                foreach (DataRow i in data.Rows)
                {
                    if (i[0].ToString().Substring(0, 11) == id.ToUpper().Substring(0, 11) && i[2].ToString() == s.ToString())
                        hoaDons.Add(new HoaDon(i));
                }
            return hoaDons;
        }
        public static List<HoaDon> locdulieu_(string id)
        {
            DataTable data;
            string query = " select * from HoaDon where ID_HoaDon = '" + id + "'";
            data = DataProvider.Instance.GetRecords(query);
            List<HoaDon> hoaDons = new List<HoaDon>();
            foreach (DataRow i in data.Rows)
            {
                hoaDons.Add(new HoaDon(i));
            }
            return hoaDons;
        }
        public static DataTable capnhatHoaDon(HoaDon hoadon, int i, String id_hd = "")
        {
            string query = "";
            switch (i)
            {
                case 1:
                    try
                    {
                        DataProvider.Instance.setdata("insert into HoaDon values('" + hoadon.ID + "'," + FormatDatetimetoSQL(hoadon.TimeCheckin) + "," + FormatDatetimetoSQL(hoadon.TimeCheckout) + ","
                                                                                    + hoadon.Tongtinh + "," + hoadon.Dathu + ",'" + hoadon.ID_NhanVien + "')");
                    }
                    catch (Exception e) { MessageBox.Show("Không thực hiện được!\n" + e.Message); }
                    break;
                case 2:
                    try
                    {
                        DataProvider.Instance.setdata("delete ThongTinHoaDon where ID_HoaDon = '" + hoadon.ID + "'");
                        DataProvider.Instance.setdata("delete HoaDon where ID_HoaDon = '" + hoadon.ID + "'");
                    }
                    catch (Exception e) { MessageBox.Show("Không thực hiện được!\n" + e.Message); }
                    break;
                case 3:
                    try
                    {
                        DataProvider.Instance.setdata("update HoaDon set TimeCheckout = " + FormatDatetimetoSQL(hoadon.TimeCheckout) + ",TongTinh = " + hoadon.Tongtinh +
                                                    ",DaThu =" + hoadon.Dathu + " where ID_HoaDon like '" + hoadon.ID + "%' ");
                    }
                    catch (Exception e) { MessageBox.Show("Không thực hiện được!\n" + e.Message); }
                    break;
                case 4:
                    try
                    {
                        DataProvider.Instance.setdata("update HoaDon set TimeCheckout = " + FormatDatetimetoSQL(hoadon.TimeCheckout) + " where ID_HoaDon like '" + hoadon.ID + "%' ");
                    }
                    catch (Exception e) { MessageBox.Show("Không thực hiện được!\n" + e.Message);
                    }
                    break;
                default:
                    break;
            }
            return null;
        }
        public static void capnhatHoaDon_(HoaDon hoadon, int i)
        {
            DataProvider.Instance.setdata("insert into HoaDon values('" + hoadon.ID + "'," + FormatDatetimetoSQL(hoadon.TimeCheckin) + "," + FormatDatetimetoSQL(hoadon.TimeCheckout) + ","
                                                                        + hoadon.Tongtinh + "," + hoadon.Dathu + ",'" + hoadon.ID_NhanVien + "')");
        }
        public static List<string> dataHoaDon_Ban(string id_hoadon)
        {
            List<string> bans = new List<string>();
            DataTable data;
            string query = " select * from HoaDon_Ban where ID_HoaDon = '" + id_hoadon + "'";
            data = DataProvider.Instance.GetRecords(query);
            foreach (DataRow i in data.Rows)
                bans.Add(i["ID_table"].ToString());
            return bans;
        }
        public static void capnhatHoaDon_Ban(string id_hoadon,string id_ban,int option)
        {
            switch(option)
            {
                case 1://///chèn thêm bàn
                    DataProvider.Instance.setdata("insert into HoaDon_Ban values ('"+id_hoadon+"','"+id_ban+"')");
                    break;
                case 2:////////// xóa bàn tại id_ban và id_hoadon
                    DataProvider.Instance.setdata("delete HoaDon_Ban where ID_HoaDon ='" + id_hoadon + "' and ID_table ='" + id_ban + "'");
                    break;
                case 3:////////// xóa bàn tại id_hoadon và ID_table khác id_ban
                    foreach (HoaDon i in locdulieu(id_hoadon))
                        if(i.ID_ban.Trim().ToUpper() != id_ban.Trim().ToUpper())
                            DataTableDAL.capnhatBan(new Table(i.ID_ban, true), 3);
                    DataProvider.Instance.setdata("delete HoaDon_Ban where ID_HoaDon ='" + id_hoadon + "' and ID_table !='" + id_ban + "'");
                    break;
                case 4:///// cập nhật lại mã hóa đơn cho những bàn đã chọn
                    string hoadon_truoc = locdulieu("", id_ban)[0].ID;
                    DataProvider.Instance.setdata("update HoaDon_Ban set ID_HoaDon = '" + id_hoadon + "' where ID_HoaDon = '"+hoadon_truoc+"'");
                    break;
                default:
                    break;
            }    
        }
        public static void capnhatHoaDon_Ban_(string id_hoadontruoc, string id_hoadonsau, string id_ban)
        {
            DataProvider.Instance.setdata("update HoaDon_Ban set ID_HoaDon = '" + id_hoadonsau + "' where ID_HoaDon = '" + id_hoadontruoc + "' and ID_table = '" + id_ban + "'");
        }
        public static void Doi_IDBan_ChoNhau(String id_bantruoc, String id_bansau,int option)
        {
            switch (option)
            {  
                case 1: //////Bàn sau trống, đổi id_ban trước thành id bàn sau trong bảng 
                    DataProvider.Instance.setdata("update HoaDon_Ban set ID_table = '" + id_bansau + "' where ID_HoaDon = '" +
                                                        locdulieu("", id_bantruoc)[0].ID + "' and ID_table = '" + id_bantruoc + "'");
                    break;
                case 2://////Bàn bỏ id bàn sau vào hóa đơn bàn trước, sau đó bỏ hóa đơn bàn trước vào bàn sau
                    string id_hoadonsau = locdulieu("", id_bansau)[0].ID;
                    string id_hoadontruoc = locdulieu("", id_bantruoc)[0].ID;
                    if (id_hoadontruoc.Substring(0, 11) != id_hoadonsau.Substring(0, 11))
                    {
                        DataProvider.Instance.setdata("update HoaDon_Ban set ID_table = '" + id_bansau + "' where ID_HoaDon = '" +
                                                            id_hoadontruoc + "' and ID_table = '" + id_bantruoc + "'");
                        DataProvider.Instance.setdata("update HoaDon_Ban set ID_table = '" + id_bantruoc + "' where ID_HoaDon = '" +
                                                            id_hoadonsau + "' and ID_table = '" + id_bansau + "'");
                    }
                    else
                    {
                        DataBillDAL.capnhatHoaDon_(new HoaDon("NQTdacomat",default,default,default,default,default), 1);
                        DataProvider.Instance.setdata("update ThongTinHoaDon set ID_HoaDon = '" + "NQTdacomat" + "' where ID_HoaDon = '" + id_hoadontruoc+ "'");
                        DataProvider.Instance.setdata("update ThongTinHoaDon set ID_HoaDon = '" + id_hoadontruoc + "' where ID_HoaDon = '" + id_hoadonsau + "'");
                        DataProvider.Instance.setdata("update ThongTinHoaDon set ID_HoaDon = '" + id_hoadonsau + "' where ID_HoaDon = '" + "NQTdacomat" + "'");
                        DataBillDAL.capnhatHoaDon(new HoaDon("NQTdacomat", default, default, default, default,default), 2);
                    }
                    break;
                default:
                    break;
            }        
        }
        public static void CapNhatIDHoadon_ForBan(string id_ban)
        {
            DataTable data;
            string query = " select * from View_HienTai where ID_table = '" + id_ban + "'";
            data = DataProvider.Instance.GetRecords(query);
            string id_hoadon = data.Rows[0]["ID_HoaDon"].ToString();
            if ( id_hoadon.Length> 11)
            {
                if (id_hoadon.Substring(11, 1) != id_ban)
                {
                    DateTime timecheckin = Convert.ToDateTime(data.Rows[0]["TimeCheckin"].ToString());
                    int tongtinh = Convert.ToInt32(data.Rows[0]["TongTinh"].ToString());
                    int dathu = Convert.ToInt32(data.Rows[0]["DaThu"].ToString());
                    string id_nhanvien = data.Rows[0]["ID_NhanVien"].ToString();
                    DataBillDAL.capnhatHoaDon_(new HoaDon(id_hoadon.Substring(0, 11) + id_ban, timecheckin, id_ban, tongtinh, dathu,id_nhanvien), 1);
                    DataProvider.Instance.setdata("update HoaDon_Ban set ID_HoaDon = '" + id_hoadon.Substring(0, 11) + id_ban + "' " +
                                                    "where ID_HoaDon = '"+id_hoadon+"'");
                    DataProvider.Instance.setdata("update ThongTinHoaDon set ID_HoaDon = '" + id_hoadon.Substring(0, 11) + id_ban + "' " +
                                                    "where ID_HoaDon = '" + id_hoadon + "'");
                    DataProvider.Instance.setdata("delete HoaDon where ID_HoaDon = '" + id_hoadon + "'");
                }
            }
        }
        public static DataTable Doi_IDBan_theoHoaDon(String id_ban, String id_hd)
        {
            String query = "";
            query = "update HoaDon set ID_table = '" + id_ban + "' where ID_Hoa= '" + id_hd + "' ";
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
            string d = "";
            if (DateTime.Now.Month < 10)
            {
                m = "0" + DateTime.Now.Month.ToString();
            }
            else m = DateTime.Now.Month.ToString();
            if (DateTime.Now.Day < 10)
            {
                d = "0" + DateTime.Now.Day.ToString();
            }
            else d = DateTime.Now.Day.ToString();
            if (n < 9)
            {
                id = "HD" + DateTime.Now.Year.ToString().Remove(0, 2)+m + d +  "00" + (n + 1).ToString();
            }
            else if (n >=9 && n < 99)
            {
                id = "HD" + DateTime.Now.Year.ToString().Remove(0, 2) + m + d + "0" + (n + 1).ToString();
            }
            else
            {
                id = "HD" + DateTime.Now.Year.ToString().Remove(0, 2) + m + d + (n + 1).ToString();
            }
            return id;
        }
        public static int GetCountNumOfOrderInDate()
        {
            string sql = "select top 1 * from HoaDon  where convert(nvarchar(10),TimeCheckIn,103) = convert(nvarchar(10),getdate(),103) order by ID_HoaDon desc";
            DataTable dt = DataProvider.Instance.GetRecords(sql);
            if(dt.Rows.Count == 0)
            {
                return 0;
            }
            else
            {
                string temp = dt.Rows[0]["ID_HoaDon"].ToString();
                return Convert.ToInt32(temp.Substring(8, 3).ToString());
            }          
        }
        
    }
}

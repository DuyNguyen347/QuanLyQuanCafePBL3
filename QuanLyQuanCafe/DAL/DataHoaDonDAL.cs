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
    internal class DataHoaDonDAL
    {
        private static DataHoaDonDAL instance;
        public static DataHoaDonDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new DataHoaDonDAL();
                return instance;
            }
            private set { }
        }
        public DataTable locdata(DateTime datebegin, DateTime dateend)
        {
            DataTable data;
            //string query = " select * from HoaDon where LEN(ID_HoaDon) <12 and TimeCheckout between '" + DataProvider.FormatDatetimeShort(datebegin) + "' and '" + DataProvider.FormatDatetimeShort(dateend) + "'";
            string query = $" select * from HoaDon where LEN(ID_HoaDon) <12 and TimeCheckout between '{datebegin}' and '{dateend}'";
            data = DataProvider.Instance.GetRecords(query);
            return data;
        }
        public DataTable data()
        {
            DataTable data;
            string query = " select * from HoaDon ";
            data = DataProvider.Instance.GetRecords(query);
            return data;
        }
        public HoaDon getHoaDonbyID(string ID)
        {
            foreach (DataRow row in data().Rows)
            {
                if (row["ID_HoaDon"].ToString() == ID)
                    return new HoaDon(row);
            }
            return null;
        }
        public HoaDon getHoaDonHienTaibyID(string ID)
        {
            DataTable data;
            data = DataProvider.Instance.GetRecords("select * from View_HienTai");
            foreach (DataRow row in data.Rows)
            {
                if (row["ID_HoaDon"].ToString() == ID)
                    return getHoaDonbyID(ID);
            }
            return null;
        }
        public HoaDon getHoaDonHienTaibyTable(string ID_table)
        {
            DataTable data;
            data = DataProvider.Instance.GetRecords("select * from View_HienTai where ID_table ='"+ID_table+"'");
            foreach (DataRow row in data.Rows)
            {
                if (row["ID_table"].ToString() == ID_table)
                    return getHoaDonbyID(row["ID_HoaDon"].ToString());
            }
            return null;
        }
        public void addHoaDon(HoaDon hoadon)
        {
            DataProvider.Instance.SetData("insert into HoaDon values('" + hoadon.ID_HoaDon + "'," + DataProvider.FormatDatetimetoSQL(hoadon.TimeCheckin) + "," +
                DataProvider.FormatDatetimetoSQL(hoadon.TimeCheckout) + "," + hoadon.Tongtinh + "," + hoadon.Dathu + ",'" + hoadon.NhanVien.ID + "')");
        }
        public void deleteHoaDon(string ID_HoaDon)
        {
            DataProvider.Instance.SetData("delete HoaDon_Ban where ID_HoaDon like '" + ID_HoaDon + "%'");
            DataProvider.Instance.SetData("delete ThongTinHoaDon where ID_HoaDon like '" + ID_HoaDon + "%'");
            DataProvider.Instance.SetData("delete HoaDon where ID_HoaDon like '" + ID_HoaDon + "%'");
        }
        public void updateHoaDon(HoaDon hoadon)
        {
            DataProvider.Instance.SetData("update HoaDon set TongTinh = " + hoadon.Tongtinh + ",DaThu =" + hoadon.Dathu + " where ID_HoaDon like '" + hoadon.ID_HoaDon + "%' ");
        }
        public void checkoutHoaDon(String idhoadon)
        {
            DataProvider.Instance.SetData("update HoaDon set TimeCheckout = " + DataProvider.FormatDatetimetoSQL(DateTime.Now) + " where ID_HoaDon like '" + idhoadon + "%' ");
        }
        public void Doi_IDBan_ChoNhau(String id_bantruoc, String id_bansau, int option)
        {
            switch (option)
            {
                case 1: //////Bàn sau trống, đổi id_ban trước thành id bàn sau trong bảng 
                    DataProvider.Instance.SetData("update HoaDon_Ban set ID_table = '" + id_bansau + "' where ID_HoaDon = '" +
                        DataHoaDonDAL.Instance.getHoaDonHienTaibyTable(id_bantruoc).ID_HoaDon + "' and ID_table = '" + id_bantruoc + "'");
                    break;
                case 2://////Bàn bỏ id bàn sau vào hóa đơn bàn trước, sau đó bỏ hóa đơn bàn trước vào bàn sau
                    string id_hoadonsau = DataHoaDonDAL.Instance.getHoaDonHienTaibyTable(id_bansau).ID_HoaDon;
                    string id_hoadontruoc = DataHoaDonDAL.Instance.getHoaDonHienTaibyTable(id_bantruoc).ID_HoaDon;
                    if (id_hoadontruoc.Substring(0, 11) != id_hoadonsau.Substring(0, 11))
                    {
                        DataProvider.Instance.SetData("update HoaDon_Ban set ID_table = '" + id_bansau + "' where ID_HoaDon = '" +
                                                            id_hoadontruoc + "' and ID_table = '" + id_bantruoc + "'");
                        DataProvider.Instance.SetData("update HoaDon_Ban set ID_table = '" + id_bantruoc + "' where ID_HoaDon = '" +
                                                            id_hoadonsau + "' and ID_table = '" + id_bansau + "'");
                    }
                    else
                    {
                        DataHoaDonDAL.Instance.addHoaDon(new HoaDon("NQTdacomat", default, default, default, default, default));
                        DataProvider.Instance.SetData("update ThongTinHoaDon set ID_HoaDon = '" + "NQTdacomat" + "' where ID_HoaDon = '" + id_hoadontruoc + "'");
                        DataProvider.Instance.SetData("update ThongTinHoaDon set ID_HoaDon = '" + id_hoadontruoc + "' where ID_HoaDon = '" + id_hoadonsau + "'");
                        DataProvider.Instance.SetData("update ThongTinHoaDon set ID_HoaDon = '" + id_hoadonsau + "' where ID_HoaDon = '" + "NQTdacomat" + "'");
                        DataHoaDonDAL.Instance.deleteHoaDon("NQTdacomat");
                    }
                    break;
                default:
                    break;
            }
        }
        public void CapNhatIDHoadon_ForBan(string id_ban)
        {
            DataTable data;
            string query = " select * from View_HienTai where ID_table = '" + id_ban + "'";
            data = DataProvider.Instance.GetRecords(query);
            string id_hoadon = data.Rows[0]["ID_HoaDon"].ToString();
            if (id_hoadon.Length > 11)
            {
                if (id_hoadon.Substring(11, 1) != id_ban)
                {
                    DateTime timecheckin = Convert.ToDateTime(data.Rows[0]["TimeCheckin"].ToString());
                    int tongtinh = Convert.ToInt32(data.Rows[0]["TongTinh"].ToString());
                    int dathu = Convert.ToInt32(data.Rows[0]["DaThu"].ToString());
                    string id_nhanvien = data.Rows[0]["ID_NhanVien"].ToString();
                    DataHoaDonDAL.Instance.addHoaDon(new HoaDon(id_hoadon.Substring(0, 11) + id_ban, timecheckin, tongtinh, dathu, id_nhanvien));
                    DataProvider.Instance.SetData("update HoaDon_Ban set ID_HoaDon = '" + id_hoadon.Substring(0, 11) + id_ban + "' " +
                                                    "where ID_HoaDon = '" + id_hoadon + "'");
                    DataProvider.Instance.SetData("update ThongTinHoaDon set ID_HoaDon = '" + id_hoadon.Substring(0, 11) + id_ban + "' " +
                                                    "where ID_HoaDon = '" + id_hoadon + "'");
                    DataProvider.Instance.SetData("delete HoaDon where ID_HoaDon = '" + id_hoadon + "'");
                }
            }
        }
        public void Doi_IDBan_theoHoaDon(String id_ban, String id_hd)
        {
            DataProvider.Instance.SetData("update HoaDon set ID_table = '" + id_ban + "' where ID_Hoa= '" + id_hd + "' ");
        }
        public DataTable LoadMonDaChon(string idbill)
        {
            DataTable dt = new DataTable();

            string query = "select * from View_InforBill where ID_HoaDon ='" + idbill + "'";
            dt = DataProvider.Instance.GetRecords(query);
            dt.Columns[0].ColumnName = "Mã món";
            dt.Columns[1].ColumnName = "Tên món";
            dt.Columns[2].ColumnName = "Danh mục";
            dt.Columns[3].ColumnName = "Giá";
            dt.Columns[4].ColumnName = "Số lượng";
            dt.Columns.RemoveAt(5);
            return dt;
        }
    }
}

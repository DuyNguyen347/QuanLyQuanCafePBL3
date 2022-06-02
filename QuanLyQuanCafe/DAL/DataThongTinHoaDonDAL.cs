using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAL
{
    internal class DataThongTinHoaDonDAL
    {
        private static DataThongTinHoaDonDAL instance;
        public static DataThongTinHoaDonDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new DataThongTinHoaDonDAL();
                return instance;
            }
            private set
            {

            }
        }
        public DataTable data(string idbill = "")
        {
            DataTable data;
            string query = " select * from ThongTinHoaDon where ID_HoaDon ='" + idbill + "'";
            data = DataProvider.Instance.GetRecords(query);
            return data;
        }
        public DataTable LoadMonDaChon(string idbill)
        {
            DataTable dt = new DataTable();

            string query = "select * from View_InforBill where ID_HoaDon ='" + idbill + "'";
            dt = DataProvider.Instance.GetRecords(query);
            dt.Columns["ID_Mon"].ColumnName = "Mã món";
            dt.Columns["TenMon"].ColumnName = "Tên món";
            dt.Columns["Ten_Category"].ColumnName = "Danh mục";
            dt.Columns["Gia"].ColumnName = "Giá";
            dt.Columns["SoLuong"].ColumnName = "Số lượng";
            dt.Columns.RemoveAt(5);
            return dt;
        }
        public List<ThongTinHoaDon> locdulieu(string idbill = "")
        {

            List<ThongTinHoaDon> list = new List<ThongTinHoaDon>();
            foreach (DataRow i in data(idbill).Rows)
                list.Add(new ThongTinHoaDon(i));
            return list;
        }
        public void addThongTinHoaDon(ThongTinHoaDon thongtinhoadon)
        {
            DataProvider.Instance.setdata("insert into ThongTinHoaDon values('" + thongtinhoadon.ID_HoaDon + "','" + thongtinhoadon.ID_Mon + "'," + thongtinhoadon.Soluong + ")");
        }
        public void deleteThongTinHoaDonbyIDHoaDon(string id_hoadon)
        {
            DataProvider.Instance.setdata("delete from ThongTinHoaDon where ID_HoaDon = '" + id_hoadon + "'");
        }
        public void deleteThongTinHoaDonbyIDMon(string id_mon)
        {
            DataProvider.Instance.setdata("delete from ThongTinHoaDon where ID_Mon = '" + id_mon + "'");
        }
        public void updateThongTinHoaDon(ThongTinHoaDon thongtinhoadon)
        {
            int count = 0;
            foreach (ThongTinHoaDon i in locdulieu(thongtinhoadon.ID_HoaDon))
                if (i.ID_Mon.Trim() == thongtinhoadon.ID_Mon.Trim())
                {
                    count++;
                    if (i.Soluong <=
                        thongtinhoadon.Soluong)
                        DataProvider.Instance.setdata("update ThongTinHoaDon set Soluong = " + thongtinhoadon.Soluong + "where ID_Mon= '" + thongtinhoadon.ID_Mon + "' ");
                }
            if (count == 0)
                DataProvider.Instance.setdata("insert into ThongTinHoaDon values('" + thongtinhoadon.ID_HoaDon + "','" + thongtinhoadon.ID_Mon + "'," + thongtinhoadon.Soluong + ")");
        }
        public void gophoadon(string id_truoc, string id_sau)
        {
            foreach (ThongTinHoaDon i in locdulieu(id_truoc))
                try
                {
                    DataProvider.Instance.GetRecords("select Soluong from ThongTinHoaDon where ID_HoaDon ='" + id_sau + "' and ID_Mon = '" + i.ID_Mon + "'").Rows[0].ToString();
                    DataProvider.Instance.setdata("update ThongTinHoaDon set  Soluong = " +
                        "(select Soluong from ThongTinHoaDon where ID_HoaDon ='" + id_sau + "' and ID_Mon = '" + i.ID_Mon + "')+" + i.Soluong +
                        "where ID_HoaDon ='" + id_sau + "' and ID_Mon = '" + i.ID_Mon + "'");
                    DataProvider.Instance.setdata("delete ThongTinHoaDon where ID_HoaDon = '" + id_truoc + "' and ID_Mon = '" + i.ID_Mon + "'");
                }
                catch (Exception e)
                {
                    DataProvider.Instance.setdata("update ThongTinHoaDon set ID_HoaDon ='" + id_sau + "' where ID_HoaDon = '" + id_truoc + "'and ID_Mon = '" + i.ID_Mon + "'");
                }
            DataProvider.Instance.setdata("update HoaDon set TongTinh = TongTinh + (select TongTinh from HoaDon where ID_HoaDon = '" + id_truoc + "')," +
                                                            "DaThu = DaThu + (select DaThu from HoaDon where ID_HoaDon = '" + id_truoc + "')" +
                                            "where ID_HoaDon = '" + id_sau + "'");
        }
        public void dongbohoadonchinh(string id_hoadonchinh)
        {
            //int tongtinh = 0, dathu = 0;
            //deleteThongTinHoaDonbyIDHoaDon(id_hoadonchinh);
            //HoaDon hoadon = DataHoaDonDAL.Instance.getHoaDonbyID(id_hoadonchinh);
            //{
            //    foreach (ThongTinHoaDon i in locdulieu(j.ID))
            //        try
            //        {
            //            DataProvider.Instance.GetRecords("select Soluong from ThongTinHoaDon where ID_HoaDon ='" + id_hoadonchinh + "' and ID_Mon = '" + i.ID_Mon + "'").Rows[0].ToString();
            //            DataProvider.Instance.setdata("update ThongTinHoaDon set  Soluong = " +
            //                "(select Soluong from ThongTinHoaDon where ID_HoaDon ='" + id_hoadonchinh + "' and ID_Mon = '" + i.ID_Mon + "')+" + i.Soluong +
            //                "where ID_HoaDon ='" + id_hoadonchinh + "' and ID_Mon = '" + i.ID_Mon + "'");
            //        }
            //        catch (Exception e)
            //        {
            //            DataProvider.Instance.setdata("insert into ThongTinHoaDon values('" + id_hoadonchinh + "','" + i.ID_Mon + "'," + i.Soluong + ")");
            //        }
            //    tongtinh += j.Tongtinh;
            //    dathu += j.Dathu;
            //}
            ////MessageBox.Show("update HoaDon set TongTinh =" + tongtinh + " ,DaThu =" + dathu + " where ID_HoaDon = '" + id_hoadonchinh + "'");
            //DataProvider.Instance.setdata("update HoaDon set TongTinh =" + tongtinh + " ,DaThu =" + dathu + " where ID_HoaDon = '" + id_hoadonchinh + "'");
        }
        public void doiidhoadon(string id_truoc, string id_sau)
        {
            DataProvider.Instance.setdata("update ThongTinHoaDon set ID_HoaDon = '" + id_sau + "' where ID_HoaDon = '" + id_truoc + "'");
            //MessageBox.Show("update ThongTinHoaDon set ID_HoaDon = '" + id_sau + "' where ID_HoaDon = '" + id_truoc + "'");
        }
    }
}

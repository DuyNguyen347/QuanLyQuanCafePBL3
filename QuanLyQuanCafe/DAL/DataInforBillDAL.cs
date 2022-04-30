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
    internal class DataInforBillDAL
    {


        public static DataTable data(string idbill = "")
        {
            DataTable data;
            string query = " select * from ThongTinHoaDon where ID_HoaDon ='" + idbill + "'";
            data = DataProvider.Instance.GetRecords(query);
            return data;
        }
        public static DataTable LoadMonDaChon(string idbill)
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
        public static List<InforBill> locdulieu(string idbill = "")
        {

            List<InforBill> list = new List<InforBill>();
            foreach (DataRow i in DataInforBillDAL.data(idbill).Rows)
                list.Add(new InforBill(i));
            return list;

        }
        public static DataTable capnhatInforHoaDon(InforBill inforBill, int i)
        {
            string query = "";
            switch (i)
            {
                case 1:
                    try
                    {
                        DataProvider.Instance.setdata("insert into ThongTinHoaDon values('" + inforBill.ID_Bill + "','" + inforBill.ID_Mon + "'," + inforBill.Soluong + ")");
                    }
                    catch (Exception e) { MessageBox.Show(e.Message); }
                    break;
                case 2:
                    try
                    {
                        DataProvider.Instance.setdata("delete from ThongTinHoaDon where ID_HoaDon = '" + inforBill.ID_Bill + "'");
                    }
                    catch (Exception e) { MessageBox.Show(e.Message); }
                    break;
                case 3:
                    int count = 0;
                    foreach (InforBill infor in locdulieu(inforBill.ID_Bill))
                        if (infor.ID_Mon.Trim() == inforBill.ID_Mon.Trim())
                        {
                            count++;
                            if (infor.Soluong <=
                                inforBill.Soluong)
                                DataProvider.Instance.setdata("update ThongTinHoaDon set Soluong = " + inforBill.Soluong + "where ID_Mon= '" + inforBill.ID_Mon + "' ");
                        }
                    if (count == 0)
                        DataProvider.Instance.setdata("insert into ThongTinHoaDon values('" + inforBill.ID_Bill + "','" + inforBill.ID_Mon + "'," + inforBill.Soluong + ")");
                    break;
                default:
                    break;
            }
            return null;
        }
        public static void gophoadon(string id_truoc, string id_sau)
        {
            foreach (InforBill i in locdulieu(id_truoc))
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

        }
    }
}

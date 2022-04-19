using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAL
{
    internal class DataInforBillDAL
    {


        public static DataTable data(string idbill = "")
        {
            DataTable data;
            string query = " select * from ThongTinHoaDon where ID_HoaDon like'%"+idbill+"%'";
            data = DataProvider.Instance.GetRecords(query);
            return data;
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
                    int dem = 0;
                    foreach (DataRow row in DataBillDAL.data().Rows)
                        if (row[0].ToString() == inforBill.ID)
                            dem++;
                    if (dem == 0)
                        query = "insert into ThongTinHoaDon values('" + inforBill.ID + "','" + inforBill.ID_Bill + "','" + inforBill.ID_Mon + "'," + inforBill.Soluong + ")";
                    break;
                case 2:
                    query = "delete from ThongTinHoaDon where ID = '" + inforBill.ID + "'";
                    break;
                case 3:
                    query = "update ThongTinHoaDon set Soluong = " + inforBill.Soluong + "where ID= '" + inforBill.ID + "' ";
                    break;
                default:
                    break;
            }
            DataTable data;
            data = DataProvider.Instance.setdata(query);
            return data;
        }
    }
}

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
            string query = " select * from ThongTinHoaDon where ID_HoaDon ='"+idbill+"'";
            data = DataProvider.Instance.GetRecords(query);
            return data;
        }
        public static DataTable LoadMonDaChon(string idbill)
        {
            DataTable dt = new DataTable();
            
            string query = "select ID_Mon,TenMon,Ten_Category,Gia,Soluong from ThongTinHoaDon inner join Mon on ID_Mon = Mon.ID inner join DanhMuc on ID_category = DanhMuc.ID where ThongTinHoaDon.ID_HoaDon ='"+idbill+"'";
            dt = DataProvider.Instance.GetRecords(query);
            dt.Columns[0].ColumnName = "Mã món";
            dt.Columns[1].ColumnName = "Tên món";
            dt.Columns[2].ColumnName = "Danh mục";
            dt.Columns[3].ColumnName = "Giá";
            dt.Columns[4].ColumnName = "Số lượng";
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
                    int count = 0;
                    foreach (InforBill infor in locdulieu(inforBill.ID_Bill))
                        if (infor.ID_Mon.Trim() == inforBill.ID_Mon.Trim())
                        {
                            count++;
                            if (infor.Soluong <=
                                inforBill.Soluong)
                                query = "update ThongTinHoaDon set Soluong = " + inforBill.Soluong + "where ID_Mon= '" + inforBill.ID_Mon + "' ";
                            else query = "";
                        }
                    if(count == 0)
                        query = "insert into ThongTinHoaDon values('" + inforBill.ID + "','" + inforBill.ID_Bill + "','" + inforBill.ID_Mon + "'," + inforBill.Soluong + ")";
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

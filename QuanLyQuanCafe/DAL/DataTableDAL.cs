using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
namespace QuanLyQuanCafe.DAL
{ 
    internal class DataTableDAL
    {
        public static DataTable data()
        {
            DataTable data;
            string query = "select * from BanAn";
            data = DataProvider.Instance.GetRecords(query);
            return data;
        }
        public static DataTable data_status()
        {
            DataTable data;
            string query = "select Status from BanAn Group by Status";
            data = DataProvider.Instance.GetRecords(query);
            return data;
        }
        public static DataTable capnhatBan(Table table , int i)
        {
            string query = "";
            switch (i)
            {
                case 1:
                    int dem = 0;
                    foreach (DataRow row in DataTableDAL.data().Rows)
                        if (row[0].ToString() == table.Id)
                            dem++;
                    if (dem == 0)
                        query = "insert into BanAn values('" + table.Id +"',N'"+table.Status.ToString()+"')";
                    break;
                case 2:
                    query = "delete from BanAn where ID = '" +table.Id + "'";
                    DataDanhThuDAL.XoaHoaDonTuBan(table.Id);
                    break;
                case 3:
                    query = "update BanAn set Status = '"+table.Status.ToString()+"'  where ID = '" + table.Id + "'";
                    break;
                default:
                    break;
            }
            DataTable data;
            data = DataProvider.Instance.setdata(query);
            return data;
        }
        public static List<Table> locdulieu(string id = "",string trangthai = "")
        {
            List<Table> tables = new List<Table>();
            foreach (DataRow row in data().Rows)
                if (row[0].ToString().ToUpper().Contains(id.ToUpper()) && row[1].ToString().ToUpper().Contains(trangthai.ToUpper()))
                    tables.Add(new Table(row));
            return tables;
        }
    }
}

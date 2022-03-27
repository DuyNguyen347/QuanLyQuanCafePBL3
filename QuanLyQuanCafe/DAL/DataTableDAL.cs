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
                    query = "insert into BanAn values('" + table.Id +"',N'"+table.Status.ToString()+"')";
                    break;
                case 2:
                    query = "delete from BanAn where ID = '" +table.Id + "'";
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

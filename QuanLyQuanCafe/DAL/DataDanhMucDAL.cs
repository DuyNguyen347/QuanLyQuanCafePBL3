using System.Data;
using System.Windows.Forms;
namespace QuanLyQuanCafe.DAL
{
    internal class DataDanhMucDAL
    {
        public static DataTable data()
        {
            DataTable data;
            string query = "select *  from DanhMuc";
            data = DataProvider.Instance.GetRecords(query);
            return data;
        }
        public static DataTable capnhatDM(DanhMuc danhMuc, int i)
        {
            string query = "";
            switch (i)
            {
                case 1:
                    query = "insert into DanhMuc values('" + danhMuc.ID + "',N'" + danhMuc.Name + "')";
                    break;
                case 2:
                    query = "delete from DanhMuc where ID = '" + danhMuc.ID + "'";
                    break;
                case 3:
                    query = "update DanhMuc set Ten_Category = N'" + danhMuc.Name + "'where ID= '" + danhMuc.ID + "' ";
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

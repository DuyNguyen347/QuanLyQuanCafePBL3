using System.Data;
namespace QuanLyQuanCafe.DAL
{
    internal class DataNhanVienDAL
    {

        
        public static DataTable data()
        {
            DataTable data;
            string query = "select *  from NhanVien";
            data = DataProvider.Instance.GetRecords(query);
            return data;
        }
        public static DataTable data_Chucvu()
        {
            DataTable data;
            string query = "select ChucVu  from NhanVien Group by ChucVu";
            data = DataProvider.Instance.GetRecords(query);
            return data;
        }
        public static DataTable capnhatNV(NhanVien nhanVien,int i)
        {
            string query = "";
            switch (i)
            {
                case 1:
                    query = "insert into NhanVien values('" + nhanVien.ID + "',N'" + nhanVien.Name + "','" + nhanVien.NgaySinh + "',N'" + nhanVien.ChucVu + "','" + nhanVien.Username + "','" + nhanVien.PassWord + "','" + nhanVien.Email + "'," + nhanVien.Luong + ",'" + nhanVien.SDT + "' )";
                    break;
                case 2:
                    query = "delete from NhanVien where ID = '" + nhanVien.ID + "'";
                    break;
                case 3:
                    query = "update NhanVien set Name = N'" + nhanVien.Name + "',NgaySinh = '" + nhanVien.NgaySinh + "',ChucVu = N'" + nhanVien.ChucVu + "',UserName='" + nhanVien.Username + "',PassWord='" + nhanVien.PassWord + "',Email='" + nhanVien.Email + "',Luong='" + nhanVien.Luong + "', SĐT = '" + nhanVien.SDT + "' where ID= '" + nhanVien.ID + "' ";
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

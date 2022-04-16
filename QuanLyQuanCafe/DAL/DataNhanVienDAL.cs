using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace QuanLyQuanCafe.DAL
{
    public class DataNhanVienDAL
    {

        private static DataNhanVienDAL _Instance;

        public static DataNhanVienDAL Instance {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DataNhanVienDAL();
                }    
                return _Instance;
            }
            set => _Instance = value; }

        public static DataTable data()
        {
            DataTable data;
            string query = "select *  from NhanVien";
            data = DataProvider.Instance.GetRecords(query);
            data.Columns.RemoveAt(5);
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
                    int dem = 0;
                    foreach (DataRow row in DataNhanVienDAL.data().Rows)
                        if (row[0].ToString() == nhanVien.ID)
                            dem++;
                    if (dem == 0)
                        query = "insert into NhanVien values('" + nhanVien.ID + "',N'" + nhanVien.Name + "','" + nhanVien.NgaySinh + "',N'" + nhanVien.ChucVu + "','" + nhanVien.Username + "','" + nhanVien.PassWord + "','" + nhanVien.Email + "'," + nhanVien.Luong + ",'" + nhanVien.SDT + "' )";
                    break;
                case 2:
                    query = "delete from NhanVien where ID = '" + nhanVien.ID + "'";
                    break;
                case 3:
                            query = "update NhanVien set Name = N'" + nhanVien.Name + "',NgaySinh = '" + nhanVien.NgaySinh + "',ChucVu = N'" + nhanVien.ChucVu + "',UserName='" + nhanVien.Username + "',Email='" + nhanVien.Email + "',Luong='" + nhanVien.Luong + "', SĐT = '" + nhanVien.SDT + "' where ID= '" + nhanVien.ID + "' ";
                    break;
                default:
                    break;

            }
            DataTable data;
            data = DataProvider.Instance.setdata(query);
            return data;
        }
        public static List<NhanVien> locdulieu(string ten = "", string chucvu = "")
        {
            List<NhanVien> nhanViens = new List<NhanVien>();
            foreach (DataRow i in data().Rows)
                if ((i[1].ToString().ToUpper()).Contains(ten.ToUpper()) && (i[3].ToString().ToUpper()).Contains(chucvu.ToUpper()))
                    nhanViens.Add(new NhanVien(i));
            return nhanViens;
        }    
        public NhanVien getNVbyUserNameAndPassWork(string username,string pass)
        {
            NhanVien nhanVien = new NhanVien();
            string query = "select * from Nhanvien where UserName = '" + username + "' and PassWord = '" + pass + "'";
            DataTable data = DataProvider.Instance.GetRecords(query);
            nhanVien.ID = data.Rows[0]["ID"].ToString();
            nhanVien.Name = data.Rows[0]["Name"].ToString();
            nhanVien.NgaySinh = data.Rows[0]["NgaySinh"].ToString();
            nhanVien.ChucVu = data.Rows[0]["ChucVu"].ToString();
            nhanVien.Username = data.Rows[0]["UserName"].ToString();
            nhanVien.PassWord = data.Rows[0]["PassWord"].ToString().Replace(" ","");
            nhanVien.Email = data.Rows[0]["Email"].ToString();
            nhanVien.Luong = Convert.ToDouble(data.Rows[0]["Luong"].ToString());
            nhanVien.SDT = data.Rows[0]["SĐT"].ToString();
            return nhanVien;
        }
        public string getNameNV(string username,string pass)
        {
            string name;
            string query = "select * from Nhanvien where UserName = '" + username + "' and PassWord = '" + pass + "'";
            DataTable data = DataProvider.Instance.GetRecords(query);
            name = data.Rows[0]["Name"].ToString();
            return name;
        }
        public string getPassNV(string id)
        {
            string pass;
            string query = "select * from Nhanvien where ID = '" + id +  "'";
            DataTable data = DataProvider.Instance.GetRecords(query);
            pass = data.Rows[0]["PassWord"].ToString();
            return pass;
        }
    }
}

using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

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
        #region NQT update 30/4
        public static DataTable data()
        {
            DataTable data;
            string query = "select *  from View_NhanVien";
            data = DataProvider.Instance.GetRecords(query);
            return data;
        }
        
        #endregion
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
                    {
                        try
                        {
                            DataProvider.Instance.setdata("insert into TaiKhoan values(N'" + nhanVien.Username + "','" + nhanVien.PassWord + "')");
                            DataProvider.Instance.setdata("insert into NhanVien values('" + nhanVien.ID + "',N'" + nhanVien.Name + "','" + DataBillDAL.FormatDatetimeShort(Convert.ToDateTime(nhanVien.NgaySinh)) + "','" + nhanVien.Email + "','" + nhanVien.SDT + "' ,N'" + nhanVien.ChucVu + "','" + nhanVien.Username + "')");
                        }catch (Exception ex) { MessageBox.Show("Không thể thực hiện thao tác này"); }
                    }
                    break;
                case 2:
                    try
                    {
                        string username = getusernamebyid(nhanVien.ID);
                        DataProvider.Instance.setdata("delete from NhanVien where ID = '" + nhanVien.ID + "'");
                        DataProvider.Instance.setdata("delete TaiKhoan where Username = '" + username + "'");
                    }catch(Exception ex) { MessageBox.Show("Không thể thực hiện thao tác này"); }
                    break;
                case 3:
                    try
                    {
                        DataProvider.Instance.setdata("update NhanVien set Name = N'" + nhanVien.Name + "',NgaySinh = '" + DataBillDAL.FormatDatetimeShort(Convert.ToDateTime(nhanVien.NgaySinh)) + "',ChucVu = N'" + nhanVien.ChucVu + "',Email='" + nhanVien.Email + "', Phone = '" + nhanVien.SDT + "' where ID= '" + nhanVien.ID + "'");
                    }catch(Exception ex) { MessageBox.Show("Không thể thực hiện thao tác này\n"+ex.Message);}
                        break;
                default:
                    break;

            }
            return null;
        }
        public static string getusernamebyid(string id)
        {
            string username = "";
            foreach (DataRow i in data().Rows)
                if (i[0].ToString().ToUpper().Trim() == id.ToUpper().Trim())
                    username = i[4].ToString();
            return username;
        }
        public static List<NhanVien> locdulieu(string ten = "", string chucvu = "")
        {
            List<NhanVien> nhanViens = new List<NhanVien>();
            foreach (DataRow i in data().Rows)
                if ((i[1].ToString().ToUpper()).Contains(ten.ToUpper()) && (i[3].ToString().ToUpper()).Contains(chucvu.ToUpper()))
                    nhanViens.Add(new NhanVien(i));
            return nhanViens;
        }
        
        public NhanVien getNVbyUserNameAndPassWork(string username,string password)
        {
            NhanVien nhanVien = new NhanVien();
            string query = "select * from View_Nhanvien inner join TaiKhoan on View_NhanVien.UserName =TaiKhoan.UserName where TaiKhoan.UserName = '" + username + "' and PassWord = '" + LoginDAL.Instance.EncodePass(password) + "'";
            DataTable data = DataProvider.Instance.GetRecords(query);
            nhanVien.ID = data.Rows[0]["ID"].ToString();
            nhanVien.Name = data.Rows[0]["Name"].ToString();
            nhanVien.NgaySinh = data.Rows[0]["NgaySinh"].ToString();
            nhanVien.ChucVu = data.Rows[0]["ChucVu"].ToString();
            nhanVien.Username = data.Rows[0]["UserName"].ToString();
            nhanVien.PassWord = data.Rows[0]["PassWord"].ToString().Replace(" ","");
            nhanVien.Email = data.Rows[0]["Email"].ToString();
            nhanVien.Luong = Convert.ToDouble(data.Rows[0]["Luong"].ToString());
            nhanVien.SDT = data.Rows[0]["Phone"].ToString();
            return nhanVien;
        }
        public static NhanVien getNVbyID(string id)
        {
            NhanVien nhanVien = new NhanVien();
            string query = "select * from View_Nhanvien inner join TaiKhoan on View_NhanVien.UserName =TaiKhoan.UserName where ID = '" + id+"'";
            DataTable data = DataProvider.Instance.GetRecords(query);
            nhanVien.ID = data.Rows[0]["ID"].ToString();
            nhanVien.Name = data.Rows[0]["Name"].ToString();
            nhanVien.NgaySinh = data.Rows[0]["NgaySinh"].ToString();
            nhanVien.ChucVu = data.Rows[0]["ChucVu"].ToString();
            nhanVien.Username = data.Rows[0]["UserName"].ToString();
            nhanVien.PassWord = data.Rows[0]["PassWord"].ToString().Replace(" ", "");
            nhanVien.Email = data.Rows[0]["Email"].ToString();
            nhanVien.Luong = Convert.ToDouble(data.Rows[0]["Luong"].ToString());
            nhanVien.SDT = data.Rows[0]["Phone"].ToString();
            return nhanVien;
        }
        public string getNameNV(string username,string pass)
        {
            string name;
            string query = "select * from View_Nhanvien inner join TaiKhoan on View_NhanVien.UserName =TaiKhoan.UserName where TaiKhoan.UserName = '" + username + "' and PassWord = '" + LoginDAL.Instance.EncodePass(pass) + "'";
            DataTable data = DataProvider.Instance.GetRecords(query);
            name = data.Rows[0]["Name"].ToString();
            return name;
        }
        public string getPassNV(string id)
        {
            string pass;
            string query = "select * from Nhanvien inner join TaiKhoan on NhanVien.UserName =TaiKhoan.UserName where ID = '" + id +  "'";
            DataTable data = DataProvider.Instance.GetRecords(query);
            pass = data.Rows[0]["PassWord"].ToString();
            return pass;
        }
    }
}

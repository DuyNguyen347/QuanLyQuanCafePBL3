using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
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
        public DataTable Data()
        {
            DataTable data;
            string query = "select * from View_NhanVien";
            data = DataProvider.Instance.GetRecords(query);
            return data;
        }
        public NhanVien GetNhanVienbyID(string ID)
        {
            foreach (DataRow row in Data().Rows)
            {
                NhanVien nhanvien = new NhanVien(row);
                if (nhanvien.ID == ID)
                    return nhanvien;
            }
            return null;
        }
        public void AddNhanVien(NhanVien nhanvien)
        {
            if (nhanvien.Anh == null)
            {
            if (nhanvien.Email.Trim() == "" || nhanvien.TaiKhoan.UserName.Trim()=="")
                DataProvider.Instance.SetData("insert into NhanVien values('" + nhanvien.ID + "',N'" + nhanvien.Name + "','" + DataProvider.FormatDatetimeShort(Convert.ToDateTime(nhanvien.NgaySinh)) + "'," + "null" + ",'" + nhanvien.SDT + "' ,N'" + nhanvien.ChucVu.TenChucVu + "'," + "null" + ",null)");
            else
            {
                nhanvien.TaiKhoan.PassWord = DataProvider.sendcode(nhanvien.Email, 1);
                DataTaiKhoanDAL.Instance.AddTaiKhoan(nhanvien.TaiKhoan);
                DataProvider.Instance.SetData("insert into NhanVien values('" + nhanvien.ID + "',N'" + nhanvien.Name + "','" + DataProvider.FormatDatetimeShort(Convert.ToDateTime(nhanvien.NgaySinh)) + "','" + nhanvien.Email + "','" + nhanvien.SDT + "' ,N'" + nhanvien.ChucVu.TenChucVu + "','" + nhanvien.TaiKhoan.UserName + "',null)");
            }
            }
            else
            {
                String query2 = "";
                if (nhanvien.Email.Trim() == "" || nhanvien.TaiKhoan.UserName.Trim() == "")
                {
                    query2 = "insert into NhanVien values('" + nhanvien.ID + "',N'" + nhanvien.Name + "','" + DataProvider.FormatDatetimeShort(Convert.ToDateTime(nhanvien.NgaySinh)) + "'," + "null" + ",'" + nhanvien.SDT + "' ,N'" + nhanvien.ChucVu.TenChucVu + "'," + "null" + ", @data)";
                    DataProvider.Instance.Execute(query2, ImageToByteArray(nhanvien.Anh));
                }
                else
                {
                    nhanvien.TaiKhoan.PassWord = DataProvider.sendcode(nhanvien.Email, 1);
                    DataTaiKhoanDAL.Instance.AddTaiKhoan(nhanvien.TaiKhoan);
                    query2 = "insert into NhanVien values('" + nhanvien.ID + "',N'" + nhanvien.Name + "','" + DataProvider.FormatDatetimeShort(Convert.ToDateTime(nhanvien.NgaySinh)) + "','" + nhanvien.Email + "','" + nhanvien.SDT + "' ,N'" + nhanvien.ChucVu.TenChucVu + "','" + nhanvien.TaiKhoan.UserName + "',@data)";
                    DataProvider.Instance.Execute(query2, ImageToByteArray(nhanvien.Anh));
                }
            }

        }
        public void DeleteNhanVien(string ID)
        {
            NhanVien nhanvien = GetNhanVienbyID(ID);
            DataProvider.Instance.SetData("update HoaDon set ID_NhanVien = null where ID_NhanVien = '" + ID + "'");
            DataProvider.Instance.SetData("delete from NhanVien where ID = '" + ID + "'");
            DataProvider.Instance.SetData("delete TaiKhoan where Username = '" + nhanvien.TaiKhoan.UserName + "'");
        }
        public void UpdateNhanVien(NhanVien nhanvien)
        {
            NhanVien a = GetNhanVienbyID(nhanvien.ID);
            if (nhanvien.Anh == null)
            {
                if (nhanvien.Email.Trim() == "" || nhanvien.TaiKhoan.UserName.Trim() == "" || a.Email.Trim() != "")
                    DataProvider.Instance.SetData("update NhanVien set Name = N'" + nhanvien.Name + "',NgaySinh = '" +
                    DataProvider.FormatDatetimeShort(Convert.ToDateTime(nhanvien.NgaySinh)) + "',ChucVu = N'" + nhanvien.ChucVu.TenChucVu +
                    "',Phone = '" + nhanvien.SDT + "' where ID= '" + nhanvien.ID + "'");
                else
                {
                    try
                    {
                        DataTaiKhoanDAL.Instance.AddTaiKhoan(nhanvien.TaiKhoan);
                        nhanvien.TaiKhoan.PassWord = DataProvider.sendcode(nhanvien.Email, 1);
                        DataTaiKhoanDAL.Instance.UpdateTaiKhoan(nhanvien.TaiKhoan);
                    }
                    catch (Exception ) { }
                    DataProvider.Instance.SetData("update NhanVien set Name = N'" + nhanvien.Name + "',NgaySinh = '" +
                    DataProvider.FormatDatetimeShort(Convert.ToDateTime(nhanvien.NgaySinh)) + "',ChucVu = N'" + nhanvien.ChucVu.TenChucVu +
                    "',Email='" + nhanvien.Email + "',UserName='" + nhanvien.TaiKhoan.UserName + "', Phone = '" + nhanvien.SDT + "' where ID= '" + nhanvien.ID + "'");
                }
            }
            else
            {
                String query3 = "";
                if (nhanvien.Email.Trim() == "" || nhanvien.TaiKhoan.UserName.Trim() == "" || a.Email.Trim() != "")
                {
                    query3 = "update NhanVien set Name = N'" + nhanvien.Name + "',NgaySinh = '" +
                    DataProvider.FormatDatetimeShort(Convert.ToDateTime(nhanvien.NgaySinh)) + "',ChucVu = N'" + nhanvien.ChucVu.TenChucVu +
                    "',Phone = '" + nhanvien.SDT + "',Anh = @data where ID= '" + nhanvien.ID + "'";
                    DataProvider.Instance.Execute(query3, ImageToByteArray(nhanvien.Anh));
                }
                else
                {
                    try
                    {
                        DataTaiKhoanDAL.Instance.AddTaiKhoan(nhanvien.TaiKhoan);
                        nhanvien.TaiKhoan.PassWord = DataProvider.sendcode(nhanvien.Email, 1);
                        DataTaiKhoanDAL.Instance.UpdateTaiKhoan(nhanvien.TaiKhoan);
                    }
                    catch (Exception ) { }
                    query3 = "update NhanVien set Name = N'" + nhanvien.Name + "',NgaySinh = '" +DataProvider.FormatDatetimeShort(Convert.ToDateTime(nhanvien.NgaySinh)) +
                        "',ChucVu = N'" +nhanvien.ChucVu.TenChucVu +"',Email='" + nhanvien.Email + "',UserName='" + nhanvien.TaiKhoan.UserName + 
                        "', Phone = '" + nhanvien.SDT + "',Anh = @data where ID= '" + nhanvien.ID + "'";
                    DataProvider.Instance.Execute(query3, ImageToByteArray(nhanvien.Anh));
                }
            }

        }

        public List<NhanVien> LocDuLieu(string ten = "", string chucvu = "")
        {
            List<NhanVien> nhanViens = new List<NhanVien>();
            foreach (DataRow i in Data().Rows)
                if ((i["Name"].ToString().ToUpper()).Contains(ten.ToUpper()) && (i["ChucVu"].ToString().ToUpper()).Contains(chucvu.ToUpper()))
                    nhanViens.Add(new NhanVien(i));
            return nhanViens;
        }
        
        public NhanVien GetNhanVienbyUserName(string username)
        {
            foreach (DataRow row in Data().Rows)
            {
                NhanVien nhanvien = new NhanVien(row);
                if (nhanvien.TaiKhoan.UserName == username)
                    return nhanvien;
            }
            return null;
        }
        public NhanVien GetNhanVienbyEmail(string email)
        {
            foreach (DataRow row in Data().Rows)
            {
                NhanVien nhanvien = new NhanVien(row);
                if (nhanvien.Email == email)
                    return nhanvien;
            }
            return null;
        }
        public byte[] ImageToByteArray(Image img)
        {
            if (img == null) return null;
            MemoryStream m = new MemoryStream();
            img.Save(m, System.Drawing.Imaging.ImageFormat.Png);
            return m.ToArray();
        }
        // chuyển từ Byte sang Image
        public Image ByteArrayToImage(byte[] b)
        {
            MemoryStream ms = new MemoryStream(b);
            return Image.FromStream(ms);
        }
        public string GetLastNV()
        {
            string query = "select top 1 * from NhanVien order by ID desc";
            DataTable dt = DataProvider.Instance.GetRecords(query);
            if (dt.Rows.Count == 0)
            {
                return "";
            }
            else
            {
                return dt.Rows[0]["ID"].ToString().Substring(2,3);
            }
        }
        public string SetIdNV()
        {
            string kq = "";
            int s = 0;
            if (GetLastNV() == "") s = 1;
            else s = Convert.ToInt32(GetLastNV()) + 1;
            if (s< 10) kq = "NV00" + s.ToString();
            else if (s< 99) kq = "NV0" + s.ToString();
            else kq = "NV" + s.ToString();
            return kq;
        }
    }
}

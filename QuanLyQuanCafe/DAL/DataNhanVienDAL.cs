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
        public DataTable data()
        {
            DataTable data;
            string query = "select * from View_NhanVien";
            data = DataProvider.Instance.GetRecords(query);
            return data;
        }
        public NhanVien getNhanVienbyID(string ID)
        {
            foreach (DataRow row in data().Rows)
            {
                NhanVien nhanvien = new NhanVien(row);
                if (nhanvien.ID == ID)
                    return nhanvien;
            }
            return null;
        }
        public void addNhanVien(NhanVien nhanvien)
        {
            if (nhanvien.Anh == null)
            {
            if (nhanvien.Email.Trim() == "" || nhanvien.TaiKhoan.UserName.Trim()=="")
                DataProvider.Instance.setdata("insert into NhanVien values('" + nhanvien.ID + "',N'" + nhanvien.Name + "','" + DataProvider.FormatDatetimeShort(Convert.ToDateTime(nhanvien.NgaySinh)) + "'," + "null" + ",'" + nhanvien.SDT + "' ,N'" + nhanvien.ChucVu.TenChucVu + "'," + "null" + ",null)");
            else
            {
                nhanvien.TaiKhoan.PassWord = DataProvider.sendcode(nhanvien.Email, 1);
                DataTaiKhoanDAL.Instance.addTaiKhoan(nhanvien.TaiKhoan);
                DataProvider.Instance.setdata("insert into NhanVien values('" + nhanvien.ID + "',N'" + nhanvien.Name + "','" + DataProvider.FormatDatetimeShort(Convert.ToDateTime(nhanvien.NgaySinh)) + "','" + nhanvien.Email + "','" + nhanvien.SDT + "' ,N'" + nhanvien.ChucVu.TenChucVu + "','" + nhanvien.TaiKhoan.UserName + "',null)");
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
                    DataTaiKhoanDAL.Instance.addTaiKhoan(nhanvien.TaiKhoan);
                    query2 = "insert into NhanVien values('" + nhanvien.ID + "',N'" + nhanvien.Name + "','" + DataProvider.FormatDatetimeShort(Convert.ToDateTime(nhanvien.NgaySinh)) + "','" + nhanvien.Email + "','" + nhanvien.SDT + "' ,N'" + nhanvien.ChucVu.TenChucVu + "','" + nhanvien.TaiKhoan.UserName + "',@data)";
                    DataProvider.Instance.Execute(query2, ImageToByteArray(nhanvien.Anh));
                }
            }

        }
        public void deleteNhanVien(string ID)
        {
            NhanVien nhanvien = getNhanVienbyID(ID);
            DataProvider.Instance.setdata("update HoaDon set ID_NhanVien = null where ID_NhanVien = '" + ID + "'");
            DataProvider.Instance.setdata("delete from NhanVien where ID = '" + ID + "'");
            DataProvider.Instance.setdata("delete TaiKhoan where Username = '" + nhanvien.TaiKhoan.UserName + "'");
        }
        public void updateNhanVien(NhanVien nhanvien)
        {
            NhanVien a = getNhanVienbyID(nhanvien.ID);
            if (nhanvien.Anh == null)
            {
                if (nhanvien.Email.Trim() == "" || nhanvien.TaiKhoan.UserName.Trim() == "" || a.Email.Trim() != "")
                    DataProvider.Instance.setdata("update NhanVien set Name = N'" + nhanvien.Name + "',NgaySinh = '" +
                    DataProvider.FormatDatetimeShort(Convert.ToDateTime(nhanvien.NgaySinh)) + "',ChucVu = N'" + nhanvien.ChucVu.TenChucVu +
                    "',Phone = '" + nhanvien.SDT + "' where ID= '" + nhanvien.ID + "'");
                else
                {
                    try
                    {
                        DataTaiKhoanDAL.Instance.addTaiKhoan(nhanvien.TaiKhoan);
                        nhanvien.TaiKhoan.PassWord = DataProvider.sendcode(nhanvien.Email, 1);
                        DataTaiKhoanDAL.Instance.updateTaiKhoan(nhanvien.TaiKhoan);
                    }
                    catch (Exception e) { }
                    DataProvider.Instance.setdata("update NhanVien set Name = N'" + nhanvien.Name + "',NgaySinh = '" +
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
                        DataTaiKhoanDAL.Instance.addTaiKhoan(nhanvien.TaiKhoan);
                        nhanvien.TaiKhoan.PassWord = DataProvider.sendcode(nhanvien.Email, 1);
                        DataTaiKhoanDAL.Instance.updateTaiKhoan(nhanvien.TaiKhoan);
                    }
                    catch (Exception e) { }
                    query3 = "update NhanVien set Name = N'" + nhanvien.Name + "',NgaySinh = '" +DataProvider.FormatDatetimeShort(Convert.ToDateTime(nhanvien.NgaySinh)) +
                        "',ChucVu = N'" +nhanvien.ChucVu.TenChucVu +"',Email='" + nhanvien.Email + "',UserName='" + nhanvien.TaiKhoan.UserName + 
                        "', Phone = '" + nhanvien.SDT + "',Anh = @data where ID= '" + nhanvien.ID + "'";
                    DataProvider.Instance.Execute(query3, ImageToByteArray(nhanvien.Anh));
                }
            }

        }

        public List<NhanVien> locdulieu(string ten = "", string chucvu = "")
        {
            List<NhanVien> nhanViens = new List<NhanVien>();
            foreach (DataRow i in data().Rows)
                if ((i["Name"].ToString().ToUpper()).Contains(ten.ToUpper()) && (i["ChucVu"].ToString().ToUpper()).Contains(chucvu.ToUpper()))
                    nhanViens.Add(new NhanVien(i));
            return nhanViens;
        }
        
        public NhanVien getNhanVienbyUserName(string username)
        {
            foreach (DataRow row in data().Rows)
            {
                NhanVien nhanvien = new NhanVien(row);
                if (nhanvien.TaiKhoan.UserName == username)
                    return nhanvien;
            }
            return null;
        }
        public NhanVien getNhanVienbyEmail(string email)
        {
            foreach (DataRow row in data().Rows)
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
    }
}

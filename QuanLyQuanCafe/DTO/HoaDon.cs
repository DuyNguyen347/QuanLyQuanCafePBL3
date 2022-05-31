using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using QuanLyQuanCafe.DAL;

namespace QuanLyQuanCafe.DTO
{
    public class HoaDon
    {
        public string ID_HoaDon { get; set; }
        public DateTime TimeCheckin { get; set; }
        public DateTime TimeCheckout { get; set; }
        public int Tongtinh { get; set; }
        public int Dathu { get; set; }
        public NhanVien NhanVien { get; set; }
        public HoaDon(string id, DateTime timecheckin, int tongtinh, int dathu,string id_nhanvien)
        {
            ID_HoaDon = id;
            TimeCheckin = timecheckin;
            TimeCheckout = new DateTime();
            Tongtinh = tongtinh;
            Dathu = dathu;
            NhanVien = DataNhanVienDAL.Instance.getNhanVienbyID(id_nhanvien);
        }
        public HoaDon(string id, DateTime timecheckin,DateTime timecheckout,int tongtinh,int dathu,string id_nhanvien)
        {
            ID_HoaDon = id;
            TimeCheckin = timecheckin;
            TimeCheckout = timecheckout;
            Tongtinh = tongtinh;
            Dathu = dathu;
            NhanVien = DataNhanVienDAL.Instance.getNhanVienbyID(id_nhanvien);
        }
        public HoaDon(DataRow row)
        {
            ID_HoaDon = row["ID_HoaDon"].ToString().Trim();
            TimeCheckin = Convert.ToDateTime(row["TimeCheckin"].ToString());
            TimeCheckout =Convert.ToDateTime(row["TimeCheckout"].ToString().Trim());
            Tongtinh = Convert.ToInt32(row["TongTinh"].ToString());
            Dathu = Convert.ToInt32(row["DaThu"].ToString());
            NhanVien = DataNhanVienDAL.Instance.getNhanVienbyID(row["ID_NhanVien"].ToString());
        }
    }
}

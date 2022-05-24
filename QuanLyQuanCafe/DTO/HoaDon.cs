using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace QuanLyQuanCafe.DTO
{
    public class HoaDon
    {
        public string ID { get; set; }
        public DateTime TimeCheckin { get; set; }
        public DateTime TimeCheckout { get; set; }
        public string ID_ban { get; set; }
        public int Tongtinh { get; set; }
        public int Dathu { get; set; }
        public string ID_NhanVien { get; set; }
        public HoaDon(string id, DateTime timecheckin, string idban, int tongtinh, int dathu,string id_nhanvien)
        {
            ID = id;
            TimeCheckin = timecheckin;
            ID_ban = idban;
            TimeCheckout = new DateTime();
            Tongtinh = tongtinh;
            Dathu = dathu;
            ID_NhanVien = id_nhanvien;
        }
        public HoaDon(string id, DateTime timecheckin, string idban,DateTime timecheckout,int tongtinh,int dathu,string id_nhanvien)
        {
            ID = id;
            TimeCheckin = timecheckin;
            ID_ban = idban;
            TimeCheckout = timecheckout;
            Tongtinh = tongtinh;
            Dathu = dathu;
            ID_NhanVien = id_nhanvien;
        }
        public HoaDon(DataRow row)
        {
            ID = row[0].ToString().Trim();
            TimeCheckin = Convert.ToDateTime(row[1].ToString());
            TimeCheckout =Convert.ToDateTime(row[2].ToString().Trim());
            ID_ban = row[3].ToString().Trim();
            Tongtinh = Convert.ToInt32(row["TongTinh"].ToString());
            Dathu = Convert.ToInt32(row["DaThu"].ToString());
        }
    }
}

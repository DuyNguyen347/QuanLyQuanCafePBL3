using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    internal class ThongTinHoaDon
    {
        public string ID_HoaDon { get; set; }
        public string ID_Mon { get; set; }
        public int Soluong { get; set; }

        public ThongTinHoaDon(string id_hoadon,string id_mon,int soluong)
        {
            ID_HoaDon = id_hoadon;
            ID_Mon = id_mon;
            Soluong = soluong;
        }
        public ThongTinHoaDon(DataRow row)
        {
            ID_HoaDon = row["ID_HoaDon"].ToString().Trim();
            ID_Mon = row["ID_Mon"].ToString().Trim();
            Soluong = Convert.ToInt32(row["Soluong"].ToString());
        }
    }
}

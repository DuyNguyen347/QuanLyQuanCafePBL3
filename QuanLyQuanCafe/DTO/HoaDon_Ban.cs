using QuanLyQuanCafe.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    internal class HoaDon_Ban
    {
        public HoaDon HoaDon { get; set; }
        public BanAn BanAn { get; set; }

        public HoaDon_Ban(string id_hoadon,string idban)
        {
            HoaDon = DataHoaDonDAL.Instance.getHoaDonbyID(id_hoadon);
            BanAn = DataBanAnDAL.Instance.GetTableByID(idban);
        }
        public HoaDon_Ban(DataRow row)
        {
            HoaDon = DataHoaDonDAL.Instance.getHoaDonbyID(row["ID_HoaDon"].ToString());
            BanAn = DataBanAnDAL.Instance.GetTableByID(row["ID_table"].ToString());
        }
    }
}

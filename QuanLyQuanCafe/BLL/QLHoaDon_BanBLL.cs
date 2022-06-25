using QuanLyQuanCafe.DAL;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.BLL
{
    class QLHoaDon_BanBLL
    {
        private static QLHoaDon_BanBLL instance;
        public static QLHoaDon_BanBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new QLHoaDon_BanBLL();
                return instance;
            }
            private set
            {
            }
        }
        public void ThemBanVoiHoaDon(HoaDon_Ban hoadon_ban, BanAn banan)
        {
            DataHoaDon_BanDAL.Instance.addHoaDon_Ban(hoadon_ban);
            DataBanAnDAL.Instance.UpdateTable(banan);
        }
        public List<string> getListBanbyHoaDon(String ID_HoaDon)
        {
            return DataHoaDon_BanDAL.Instance.data(ID_HoaDon);
        }
        public void XoaMotBanKhoiHoaDon(HoaDon_Ban hoadon_ban)
        {
            DataHoaDon_BanDAL.Instance.deleteHoaDon_Ban_(hoadon_ban);
        }
        public void gopBan(HoaDon_Ban hoadon_ban)
        {
            string hoadon_truoc = QLHoaDonBLL.Instance.getHoaDonHienTaibyTable(hoadon_ban.BanAn.ID).ID_HoaDon.Trim();
            DataHoaDon_BanDAL.Instance.updateHoaDon_Ban(hoadon_ban);
            DataThongTinHoaDonDAL.Instance.gophoadon(hoadon_truoc, hoadon_ban.HoaDon.ID_HoaDon);                ////Gộp 2 hóa đơn lại
            DataHoaDonDAL.Instance.deleteHoaDon(hoadon_truoc);///// cập nhật lại hóa đơn cho mấy bàn đã gộp
        }
        public void addHoaDon_Ban(HoaDon_Ban hoadon_ban)
        {
            DataHoaDon_BanDAL.Instance.addHoaDon_Ban(hoadon_ban);
        }
        public void gopBanTrong(HoaDon_Ban hoadon_ban)
        {
            DataHoaDon_BanDAL.Instance.addHoaDon_Ban(hoadon_ban);         //////////// thêm bàn vào hóa đơn
            QLBanAnBLL.Instance.setBanCoNguoi(hoadon_ban.BanAn.ID); /////////// chỉnh lại trạng thái bàn
        }
    }
        
}

using QuanLyQuanCafe.DAL;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.BLL
{
    class QLHoaDonBLL
    {
        private static QLHoaDonBLL instance;
        public static QLHoaDonBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new QLHoaDonBLL();
                return instance;
            }
            private set
            {

            }
        }
        public HoaDon getHoaDonHienTaibyTable(string idtable)
        {
            return DataHoaDonDAL.Instance.getHoaDonHienTaibyTable(idtable);
        }
        public void addHoaDon(HoaDon hoadon)
        {
            DataHoaDonDAL.Instance.addHoaDon(hoadon);
        }
        public void addThongTinHoaDon(ThongTinHoaDon thongtinhoadon)
        {
            DataThongTinHoaDonDAL.Instance.addThongTinHoaDon(thongtinhoadon);
        }
        public DataTable LoadMonByHoaDon(string ID_HoaDon)
        {
            return DataThongTinHoaDonDAL.Instance.LoadMonDaChon(ID_HoaDon);
        }
        public void checkoutHoaDon(string idHoaDon)
        {
            DataHoaDonDAL.Instance.checkoutHoaDon(idHoaDon);
        }
        public void Doi_IDBan_ChoNhau(string tab,string tab1,int option)
        {
            DataHoaDonDAL.Instance.Doi_IDBan_ChoNhau(tab, tab1, option);
        }
        public HoaDon getHoaDonHienTaibyID(String ID_HoaDon)
        {
            return DataHoaDonDAL.Instance.getHoaDonHienTaibyID(ID_HoaDon);
        }
        public void updateMonforHoaDon(ThongTinHoaDon thongtinhoadon)
        {
            DataThongTinHoaDonDAL.Instance.updateThongTinHoaDon(thongtinhoadon);
        }

        public void updateHoaDon(HoaDon hoadon)
        {
            DataHoaDonDAL.Instance.updateHoaDon(hoadon);
        }
        public DataTable GetListBill(DateTime dateBegin,DateTime dateEnd)
        {
            return DataHoaDonDAL.Instance.locdata(dateBegin, dateEnd);
        }
    }
}

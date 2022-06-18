using QuanLyQuanCafe.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.BLL
{
    class QLThongTinHoaDonBLL
    {
        private static QLThongTinHoaDonBLL instance;
        public static QLThongTinHoaDonBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new QLThongTinHoaDonBLL();
                return instance;
            }
            private set
            {

            }
        }
        public void dongbohoadonchinh(String ID_HoaDon)
        {
            DataThongTinHoaDonDAL.Instance.dongbohoadonchinh(ID_HoaDon);
        }

    }
}

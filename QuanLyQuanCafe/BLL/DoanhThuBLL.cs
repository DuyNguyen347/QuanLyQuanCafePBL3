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
    public class DoanhThuBLL
    {
        private static DoanhThuBLL _Instance;

        public static DoanhThuBLL Instance {
            get
            {
                if(_Instance == null)
                {
                    _Instance = new DoanhThuBLL();
                }
                return _Instance;
            }
            private set => _Instance = value;
        }
        public List<RevenueByDate> GetListDoanhThu()
        {
            return ThongKeDAL.Instance.GrossRevenueList;
        }
        public List<KeyValuePair<string, int>> GetListTopSeller()
        {
            return ThongKeDAL.Instance.TopProductsList;
        }
        public string GetNumberOrder()
        {
            return ThongKeDAL.Instance.NumOrders.ToString();
        }
        public int GetTotalDoanhThu()
        {
            return ThongKeDAL.Instance.TotalRevenue;
        }
        public bool LoadData(DateTime dateBegin,DateTime dateEnd)
        {
            return ThongKeDAL.Instance.LoadData(dateBegin,dateEnd);
        }
        public DataTable GetListDoanhThuTheoNgay(DateTime dateBegin,DateTime dateEnd)
        {
            return DataDanhThuDAL.Instance.Data(dateBegin,dateEnd);
        }
    }
}

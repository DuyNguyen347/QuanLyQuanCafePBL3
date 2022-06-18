using QuanLyQuanCafe.DAL;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.BLL
{
    class QLBanAnBLL
    {
        static private QLBanAnBLL instance;
        public static QLBanAnBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new QLBanAnBLL();
                return instance;
            }
            private set
            {
            }
        }
        public List<BanAn> getBanAnbyStatus(string trangthai)
        {
            return DataBanAnDAL.Instance.getBanAnbyStatus(trangthai);
        }
        public BanAn getBanAnbyID(string id)
        {
            return DataBanAnDAL.Instance.getBanAnbyID(id);
        }
        public void setBanTrong(string idban)
        {
            DataBanAnDAL.Instance.updateBanAn(new BanAn(idban.Trim().ToUpper(), true));
        }
        public void setBanCoNguoi(string idban)
        {
            DataBanAnDAL.Instance.updateBanAn(new BanAn(idban.Trim().ToUpper(), false));
        }
        public List<BanAn> getListBanAnbyID(string id)
        {
            return DataBanAnDAL.Instance.locBanAnbyID(id);
        }
        public List<string> getListStatus()
        {
            return DataBanAnDAL.Instance.statuses();
        }
            
    }
}

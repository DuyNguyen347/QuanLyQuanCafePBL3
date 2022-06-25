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
        public List<BanAn> GetBanAnbyStatus(string trangthai)
        {
            return DataBanAnDAL.Instance.GetTableByStatus(trangthai);
        }
        public BanAn getBanAnbyID(string id)
        {
            return DataBanAnDAL.Instance.GetTableByID(id);
        }
        public void setBanTrong(string idban)
        {
            DataBanAnDAL.Instance.UpdateTable(new BanAn(idban.Trim().ToUpper(), true));
        }
        public void setBanCoNguoi(string idban)
        {
            DataBanAnDAL.Instance.UpdateTable(new BanAn(idban.Trim().ToUpper(), false));
        }
        public List<BanAn> GetListBanAnbyID(string id)
        {
            return DataBanAnDAL.Instance.FilterTableByID(id);
        }
        public List<string> getListStatus()
        {
            List<string> list = new List<string>();
            list.Add("Tất cả");
            foreach (string i in DataBanAnDAL.Instance.GetStatuses())
            {
                if (i.ToUpper().Trim().Equals("TRUE"))
                {
                    list.Add("Trống");
                }
                else if (i.ToUpper().Trim().Equals("FALSE"))
                    list.Add("Có người");
            }
            return list;
        }
        public void AddTable(BanAn table)
        {
            DataBanAnDAL.Instance.AddTable(table);
        }
        public void UpdateTable(BanAn table)
        {
            DataBanAnDAL.Instance.UpdateTable(table);
        }
        public void DeleteTable(string idTable)
        {
            DataBanAnDAL.Instance.DeleteTable(idTable);
        }
        public List<BanAn> GetListTable()
        {
            return DataBanAnDAL.Instance.ListTable();
        }
    }
}

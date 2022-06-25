using QuanLyQuanCafe.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.BLL
{
    class QLMonBLL
    {
        private static QLMonBLL instance;
        public static QLMonBLL Instance
        {
            get
            {
                if(instance == null)
                    instance = new QLMonBLL();
                return instance;
            }
            private set { }
        }
        public List<Mon> GetListMonbyName(string tenmon)
        {
            return DataMonDAL.Instance.LocDuLieu(tenmon);
        }
        public List<Mon> GetListMonbyDanhMuc(string danhmuc)
        {
            return DataMonDAL.Instance.LocDuLieu("", danhmuc);
        }
        public List<Mon> GetAllListMon()
        {
            return DataMonDAL.Instance.LocDuLieu();
        }
        public Mon GetMonbyID(string ID)
        {
            return DataMonDAL.Instance.GetMonByID(ID);
        }
        public void AddMon(Mon mon)
        {
            DataMonDAL.Instance.AddMon(mon);
        }
        public void UpdateMon(Mon mon)
        {
            DataMonDAL.Instance.UpdateMon(mon);
        }
        public void DeleteMon(string idMon)
        {
            DataMonDAL.Instance.DeleteMon(idMon);
        }
    }
}

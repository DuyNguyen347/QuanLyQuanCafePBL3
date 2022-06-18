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
        public List<Mon> getListMonbyName(string tenmon)
        {
            return DataMonDAL.Instance.locdulieu(tenmon);
        }
        public List<Mon> getListMonbyDanhMuc(string danhmuc)
        {
            return DataMonDAL.Instance.locdulieu("", danhmuc);
        }
        public Mon getMonbyID(string ID)
        {
            return DataMonDAL.Instance.getMonbyID(ID);
        }
    }
}

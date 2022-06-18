using QuanLyQuanCafe.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.BLL
{
    class QLDanhMucBLL
    {
        private static QLDanhMucBLL instance;
        public static QLDanhMucBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new QLDanhMucBLL();
                return instance;
            }
            private set
            {

            }
        }
        public DataTable getAllDanhMuc()
        {
            return DataDanhMucDAL.Instance.data();
        }
    }
}

using QuanLyQuanCafe.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.BLL
{
    public class DanhMucBLL
    {
        private static DanhMucBLL _Instance;

        public static DanhMucBLL Instance {
            get
            {
                if(_Instance == null)
                {
                    _Instance = new DanhMucBLL();
                }
                return _Instance;
            }
            private set => _Instance = value;
        }
        public DataTable GetAllDanhMuc()
        {
            return DataDanhMucDAL.Instance.Data();
        }
        public List<DanhMuc> LocDuLieu(string name)
        {
            return DataDanhMucDAL.Instance.LocDuLieu(name);
        }
        public void AddDanhMuc(DanhMuc danhmuc)
        {
            DataDanhMucDAL.Instance.AddDanhMuc(danhmuc);
        }
        public void DeleteDanhMuc(string idDM)
        {
            DataDanhMucDAL.Instance.DeleteDanhMuc(idDM);
        }
        public void UpdateDanhMuc(DanhMuc danhmuc)
        {
            DataDanhMucDAL.Instance.UpdateDanhMuc(danhmuc);
        }
        public DanhMuc GetDanhMucByName(string name)
        {
            return DataDanhMucDAL.Instance.GetDanhMucByTen(name);
        }
    }
}

using QuanLyQuanCafe.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.BLL
{
    public class NhanVienBLL
    {
        private static NhanVienBLL _Instance;

        public static NhanVienBLL Instance {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new NhanVienBLL();
                }
                return _Instance;
            }
            private set => _Instance = value; }

        public List<NhanVien> GetNhanVien(string nameNV = "", string chucVu = "")
        {
            return DataNhanVienDAL.Instance.LocDuLieu(nameNV, chucVu);
        }
        public DataTable GetAllNhanVien()
        {
            return DataNhanVienDAL.Instance.Data();
        }
        public  NhanVien GetNhanVienByID(string id)
        {
            return DataNhanVienDAL.Instance.GetNhanVienbyID(id);
        }
        public void AddNhanVien(NhanVien nv)
        {
            DataNhanVienDAL.Instance.AddNhanVien(nv);
        }
        public void DeleteNhanVien(string idNV)
        {
            DataNhanVienDAL.Instance.DeleteNhanVien(idNV);
        }
        public void UpdateNhanVien(NhanVien nv)
        {
            DataNhanVienDAL.Instance.UpdateNhanVien(nv);
        }
    }
}

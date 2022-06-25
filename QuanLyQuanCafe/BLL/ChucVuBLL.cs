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
    public class ChucVuBLL
    {
        private static ChucVuBLL _Instance;

        public static ChucVuBLL Instance {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ChucVuBLL();
                }
                return _Instance;
            }
            private set => _Instance = value; }

        public DataTable GetChucVu()
        {
            return DataChucVuDAL.Instance.Data();
        }
        public ChucVu GetChucVuByID(string id)
        {
            return DataChucVuDAL.Instance.GetChucVuByID(id);
        }
        public List<ChucVu> GetChucVuByName(string name)
        {
            return DataChucVuDAL.Instance.LocDuLieu(name);
        }
        public void AddChucVu(ChucVu chucvu)
        {
            DataChucVuDAL.Instance.AddChucvu(chucvu);
        }
        public void UpdateChucVu(ChucVu chucvu)
        {
            DataChucVuDAL.Instance.UpdateChucvu(chucvu);
        }
        public void DeleteChucVu(string idChucVu)
        {
            DataChucVuDAL.Instance.DeleteChucvu(idChucVu);
        }
    }
}

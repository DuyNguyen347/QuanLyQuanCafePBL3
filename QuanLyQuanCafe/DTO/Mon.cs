using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QuanLyQuanCafe.DAL;

namespace QuanLyQuanCafe
{
    public class Mon
    {
        public string ID { get; set; }
        public string TenMon { get; set; }
        public DanhMuc DanhMuc { get; set; }
        public int Gia { get; set; }
        public Mon()
        {
        }
        public Mon(string id, string tenmon,string ID_category,int gia)
        {
            ID = id;
            TenMon = tenmon;
            DanhMuc = DataDanhMucDAL.Instance.getDanhMucbyID(ID_category);
            Gia = gia;
        }
        public Mon(DataRow dataRow)
        {
            ID = dataRow["ID"].ToString();
            TenMon = dataRow["TenMon"].ToString();
            try
            {
                DanhMuc = DataDanhMucDAL.Instance.getDanhMucbyID(dataRow["ID_category"].ToString());
            }
            catch(Exception ex)
            {
                DanhMuc = new DanhMuc("","");
            }
            Gia = Convert.ToInt32(dataRow["Gia"].ToString());
        }
    }
}

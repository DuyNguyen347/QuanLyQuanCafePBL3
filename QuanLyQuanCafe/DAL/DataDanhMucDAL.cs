using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
namespace QuanLyQuanCafe.DAL
{
    internal class DataDanhMucDAL
    {
        private static DataDanhMucDAL instance;
        public static DataDanhMucDAL Instance
        {
            get
            {
                if(instance == null)
                    instance = new DataDanhMucDAL();
                return instance;
            }
            private set
            {

            }
        }
        public DataTable Data()
        {
            DataTable data;
            string query = "select *  from DanhMuc";
            data = DataProvider.Instance.GetRecords(query);
            return data;
        }
        public List<DanhMuc> LocDuLieu(string ten="")
        {
            List<DanhMuc> danhMucs = new List<DanhMuc>();
            foreach (DataRow i in Data().Rows)
                if ((i["Ten_Category"].ToString().ToUpper()).Contains(ten.ToUpper()))
                    danhMucs.Add(new DanhMuc(i));
            return danhMucs;
        }
        public DanhMuc GetDanhMucByID(string ID)
        {
            List<DanhMuc> danhMucs = new List<DanhMuc>();
            foreach (DataRow i in Data().Rows)
                if (i["ID"].ToString().ToUpper().Trim().Equals(ID.ToUpper().Trim()))
                    danhMucs.Add(new DanhMuc(i));
            return danhMucs[0];
        }
        public DanhMuc GetDanhMucByTen(string Ten)
        {
            List<DanhMuc> danhMucs = new List<DanhMuc>();
            foreach (DataRow i in Data().Rows)
                if (i["Ten_Category"].ToString().ToUpper().Trim().Equals(Ten.ToUpper().Trim()))
                    danhMucs.Add(new DanhMuc(i));
            return danhMucs[0];
        }
        public void AddDanhMuc(DanhMuc danhmuc)
        {
            DataProvider.Instance.SetData("insert into DanhMuc values('" + danhmuc.ID + "',N'" + danhmuc.Ten_Category + "')");
        }
        public void DeleteDanhMuc(String ID)
        {
            DataProvider.Instance.SetData("update Mon set ID_category = null where ID_category = '" + ID + "'");
            DataProvider.Instance.SetData("delete from DanhMuc where ID = '" + ID + "'");
        }
        public void UpdateDanhMuc(DanhMuc danhmuc)
        {
            DataProvider.Instance.SetData("update DanhMuc set Ten_Category = N'" + danhmuc.Ten_Category + "'where ID= '" + danhmuc.ID + "' ");
        }

    }
}

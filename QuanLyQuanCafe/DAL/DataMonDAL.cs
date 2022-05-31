using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace QuanLyQuanCafe.DAL
{
    internal class DataMonDAL
    {
        private static DataMonDAL instance;
        public static DataMonDAL Instance
        {
            get
            {
                if(instance == null)
                    instance = new DataMonDAL();
                return instance;
            }
            private set
            {

            }
        }
        public DataTable data()
        {
            DataTable data;
            string query = "select * from Mon";
            data = DataProvider.Instance.GetRecords(query);
            return data;
        }
        public Mon getMonbyID(string ID)
        {
            foreach (DataRow i in data().Rows)
            {
                Mon mon = new Mon(i);
                if (mon.ID.ToUpper().Trim().Equals(ID.ToUpper().Trim()))
                    return mon;
            }
            return null;
        }
        public List<Mon> locdulieu(string ten = "", string danhmuc = "")
        {
            List<Mon> mons = new List<Mon>();
            foreach (DataRow i in data().Rows)
            {
                Mon mon = new Mon(i);
                if (mon.TenMon.ToUpper().Contains(ten) && mon.DanhMuc.Ten_Category.ToUpper().Trim().Contains(danhmuc))
                    mons.Add(mon);
            }
            return mons;
        }
        public void addMon(Mon mon)
        {
            DataProvider.Instance.setdata("insert into Mon values('" + mon.ID + "',N'" + mon.TenMon + "','" + mon.DanhMuc.ID + "'," + mon.Gia + ")");
        }
        public void deleteMon(String ID)
        {
            DataThongTinHoaDonDAL.Instance.deleteThongTinHoaDonbyIDMon(ID);
            DataProvider.Instance.setdata("delete from Mon where ID = '" + ID + "'");
        }
        public void updateMon(Mon mon)
        {
            DataProvider.Instance.setdata("update Mon set TenMon = N'" + mon.TenMon + "', ID_category = '" + mon.DanhMuc.ID + "',Gia =" + mon.Gia + "where ID= '" + mon.ID + "' ");
        }
    }
}
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
        public DataTable Data()
        {
            DataTable data;
            string query = "select * from Mon";
            data = DataProvider.Instance.GetRecords(query);
            return data;
        }
        public Mon GetMonByID(string ID)
        {
            foreach (DataRow i in Data().Rows)
            {
                Mon mon = new Mon(i);
                if (mon.ID.ToUpper().Trim().Equals(ID.ToUpper().Trim()))
                    return mon;
            }
            return null;
        }
        public List<Mon> LocDuLieu(string ten = "", string danhmuc = "")
        {
            List<Mon> mons = new List<Mon>();
            foreach (DataRow i in Data().Rows)
            {
                Mon mon = new Mon(i);
                if (mon.TenMon.ToUpper().Contains(ten) && mon.DanhMuc.Ten_Category.ToUpper().Trim().Contains(danhmuc) && mon.DaXoa==false)
                    mons.Add(mon);
            }
            return mons;
        }
        public List<Mon> LocAllDuLieu()
        {
            List<Mon> mons = new List<Mon>();
            foreach (DataRow i in Data().Rows)
            {
                mons.Add(new Mon(i));
            }
            return mons;
        }
        public void AddMon(Mon mon)
        {
            try
            {
                DataProvider.Instance.SetData("insert into Mon values('" + mon.ID + "',N'" + mon.TenMon + "','" + mon.DanhMuc.ID + "'," + mon.Gia + ",0)");
            }
            catch (Exception ex)
            {
                DataProvider.Instance.SetData("update Mon set DaXoa = 0 where ID = '" + mon.ID + "'");
            }
        }
        public void DeleteMon(String ID)
        {
            try
            {
                DataProvider.Instance.SetData("delete from Mon where ID = '" + ID + "'");
            }catch(Exception ex)
            {
                DataProvider.Instance.SetData("update Mon set DaXoa = 1 where ID = '" + ID + "'");
            }
        }
        public void UpdateMon(Mon mon)
        {
            DataProvider.Instance.SetData("update Mon set TenMon = N'" + mon.TenMon + "', ID_category = '" + mon.DanhMuc.ID + "',Gia =" + mon.Gia + "where ID= '" + mon.ID + "' ");
        }
        public string GetLastIdMon()
        {
            string query = "select top 1 * from Mon order by ID desc";
            DataTable dt = DataProvider.Instance.GetRecords(query);
            if (dt.Rows.Count == 0)
            {
                return "";
            }
            else
            {
                return dt.Rows[0]["ID"].ToString().Substring(1);
            }
        }
        public string CapIDmon()
        {
            string kq = "";
            int s = 0;
            if (GetLastIdMon() == "") s = 1;
            else s = Convert.ToInt32(GetLastIdMon()) + 1;
            if (s < 10) kq = "00" + s.ToString();
            else if (s < 99) kq = "0" + s.ToString();
            else kq = s.ToString();
            return kq;
        }
    }
}
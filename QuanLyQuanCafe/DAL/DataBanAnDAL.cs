using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAL
{
    internal class DataBanAnDAL
    {
        private static DataBanAnDAL instance;
        public static DataBanAnDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new DataBanAnDAL();
                return instance;
            }
            private set
            {

            }
        }
        public DataTable data()
        {
            DataTable data;
            string query = "select * from BanAn";
            data = DataProvider.Instance.GetRecords(query);
            return data;
        }
        public List<BanAn> listban()
        {
            List<BanAn> tables = new List<BanAn>();
            foreach (DataRow i in DataBanAnDAL.Instance.data().Rows)
                tables.Add(new BanAn(i));
            return tables;
        }
        public List<String> statuses()
        {
            DataTable data;
            string query = "select Status from BanAn Group by Status";
            data = DataProvider.Instance.GetRecords(query);
            List<String> list = new List<String>();
            foreach(DataRow row in data.Rows)
            {
                list.Add(row["Status"].ToString());
            }
            return list;
        }
        public BanAn getBanAnbyID(string id)
        {
            DataTable data;
            string query = "select * from BanAn where ID = '"+id+"'";
            data = DataProvider.Instance.GetRecords(query);
            return new BanAn(data.Rows[0]);
        }
        public List<BanAn> locBanAnbyID(string id)
        {
            DataTable data;
            string query = "select * from BanAn where ID like '%" + id + "%'";
            data = DataProvider.Instance.GetRecords(query);
            List<BanAn> banans = new List<BanAn>();
            foreach (DataRow row in data.Rows)
                banans.Add(new BanAn(row));
            return banans;
        }
        public List<BanAn> getBanAnbyStatus(string trangthai)
        {
            DataTable data;
            List<BanAn> banans = new List<BanAn>();
            string query = "select * from BanAn where Status = '"+trangthai+"'";
            data = DataProvider.Instance.GetRecords(query);
            foreach (DataRow row in data.Rows)
                banans.Add(new BanAn(row));
            return banans;
        }
        public void addBanAn(BanAn banan)
        {
            DataProvider.Instance.setdata("insert into BanAn values('" + banan.ID +"', N'"+banan.Status.ToString()+"')");
        }
        public void deleteBanAn(string ID)
        {
            DataHoaDon_BanDAL.Instance.deleteHoaDon_BanbyBan(ID);
            DataProvider.Instance.setdata("delete from BanAn where ID = '" + ID + "'");
        }
        public void updateBanAn(BanAn banan)
        {
            DataProvider.Instance.setdata("update BanAn set Status = '" + banan.Status.ToString() + "'  where ID = '" + banan.ID + "'");
        }
    }
}

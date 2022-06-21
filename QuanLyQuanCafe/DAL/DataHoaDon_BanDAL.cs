using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe.DAL
{
    internal class DataHoaDon_BanDAL
    {
        private static DataHoaDon_BanDAL instance;
        public static DataHoaDon_BanDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new DataHoaDon_BanDAL();
                return instance;
            }
            private set
            {

            }
        }
        public List<string> data(string id_hoadon)
        {
            List<string> bans = new List<string>();
            DataTable data;
            string query = " select * from HoaDon_Ban where ID_HoaDon like '" + id_hoadon + "%'";
            data = DataProvider.Instance.GetRecords(query);
            foreach (DataRow i in data.Rows)
                bans.Add(i["ID_table"].ToString());
            return bans;
        }
        public void addHoaDon_Ban(HoaDon_Ban hoadon_ban)
        {
            DataProvider.Instance.setdata("insert into HoaDon_Ban values ('" + hoadon_ban.HoaDon.ID_HoaDon + "','" + hoadon_ban.BanAn.ID + "')");
        }
        public void deleteHoaDon_Ban(HoaDon_Ban hoadon_ban)
        {
            DataProvider.Instance.setdata("delete HoaDon_Ban where ID_HoaDon ='" + hoadon_ban.HoaDon.ID_HoaDon + "' and ID_table ='" + hoadon_ban.BanAn.ID + "'");
        }
        public void deleteHoaDon_BanbyBan(string id_ban)
        {
            DataProvider.Instance.setdata("delete HoaDon_Ban where ID_table ='" + id_ban + "'");
        }
        public void deleteHoaDon_Ban_(HoaDon_Ban hoadon_ban)
        {
            foreach (string i in data(hoadon_ban.HoaDon.ID_HoaDon))
            {
                if (i.Trim().ToUpper() != hoadon_ban.BanAn.ID.Trim().ToUpper())
                    DataBanAnDAL.Instance.updateBanAn(new BanAn(i, true));
            }
            DataProvider.Instance.setdata("delete HoaDon_Ban where ID_HoaDon ='" + hoadon_ban.HoaDon.ID_HoaDon + "' and ID_table !='" + hoadon_ban.BanAn.ID + "'");
        }
        public void updateHoaDon_Ban(HoaDon_Ban hoadon_ban)
        {
            HoaDon hoadon = DataHoaDonDAL.Instance.getHoaDonHienTaibyTable(hoadon_ban.BanAn.ID);
            DataProvider.Instance.setdata("update HoaDon_Ban set ID_HoaDon = '" + hoadon_ban.HoaDon.ID_HoaDon + "' where ID_HoaDon = '" + hoadon.ID_HoaDon + "'");
        }
        public void updateHoaDon_Ban(string id_hoadontruoc, string id_hoadonsau, string id_ban)
        {
            DataProvider.Instance.setdata("update HoaDon_Ban set ID_HoaDon = '" + id_hoadonsau + "' where ID_HoaDon = '" + id_hoadontruoc + "' and ID_table = '" + id_ban + "'");
        }    }
}

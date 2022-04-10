using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace QuanLyQuanCafe.DAL
{
    internal class DataMonDAL
    {
       public static DataTable data()
        {
            DataTable data;
            string query = "select mon.ID,TenMon,Ten_Category,Gia  from Mon inner join DanhMuc on Mon.ID_category = DanhMuc.ID  ";
            data = DataProvider.Instance.GetRecords(query);
            return data;
        }
        public static DataTable capnhatMon(Mon mon, int i)
        {
            string ID_category = "";
            foreach (DataRow row in DataDanhMucDAL.data().Rows)
                if(row[1].ToString().Trim() == mon.DanhMuc.ToString())
                    ID_category = row[0].ToString();
            string query = "";
            switch (i)
            {   
                case 1:
                    int dem = 0;
                    foreach (DataRow row in DataMonDAL.data().Rows)
                        if (row[0].ToString() == mon.ID)
                            dem++;
                    if (dem == 0)
                        query = "insert into Mon values('" + mon.ID + "',N'" + mon.Name + "','"+ID_category+"',"+mon.Gia+")";
                    break;
                case 2:
                    query = "delete from Mon where ID = '" + mon.ID + "'";
                    DataDanhThuDAL.XoaThongTinHoaDonTuMon(mon.ID);
                    break;
                case 3:
                    query = "update Mon set TenMon = N'" + mon.Name + "', ID_category = '"+ID_category+"',Gia ="+mon.Gia+"where ID= '" + mon.ID + "' ";
                    break;
                default:
                    break;
            }
            DataTable data;
            data = DataProvider.Instance.setdata(query);
            return data;
        }
        public static void XoaTuDanhMuc(string ID)
        {
            string query = "delete from Mon where ID_category = '" + ID + "'";
            foreach(DataRow id in DataProvider.Instance.GetRecords("select * from Mon where ID_category = '"+ID+"'").Rows)
                DataDanhThuDAL.XoaThongTinHoaDonTuMon(id[0].ToString());
            DataProvider.Instance.setdata(query);
        }
        public static List<Mon> locdulieu(string ten = "",string danhmuc = "")
        {
            List<Mon> mons = new List<Mon>();
            foreach (DataRow i in data().Rows)
                if ((i[1].ToString().ToUpper()).Contains(ten) && i[2].ToString().ToUpper().Trim().Contains(danhmuc))
                    mons.Add(new Mon(i));
            return mons;
        }
    }
}
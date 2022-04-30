using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace QuanLyQuanCafe.DAL
{
    internal class DataMonDAL
    {
        #region NQT_Update 30/4
        public static DataTable data()
        {
            DataTable data;
            string query = "select *  from View_Mon  ";
            data = DataProvider.Instance.GetRecords(query);
            return data;
        }
        #endregion
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
                        try
                        {
                            DataProvider.Instance.setdata("insert into Mon values('" + mon.ID + "',N'" + mon.Name + "','" + ID_category + "'," + mon.Gia + ")");
                        }catch(Exception ex) { MessageBox.Show("Không thể thực hiện thao tác này"); }
                    break;
                case 2:
                    try
                    {
                        DataProvider.Instance.setdata("delete ThongTinHoaDon where ID_Mon = '" + mon.ID + "'");
                        DataProvider.Instance.setdata("delete from Mon where ID = '" + mon.ID + "'");
                    }catch(Exception ex) { MessageBox.Show("Không thể thực hiện thao tác này"); }
                    break;
                case 3:
                    try
                    {
                        DataProvider.Instance.setdata("update Mon set TenMon = N'" + mon.Name + "', ID_category = '" + ID_category + "',Gia =" + mon.Gia + "where ID= '" + mon.ID + "' ");
                    }catch(Exception ex) { MessageBox.Show("Không thể thực hiện thao tác này"); }
                        break;
                default:
                    break;
            }
            return null;
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
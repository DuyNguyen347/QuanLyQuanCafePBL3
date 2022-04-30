using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
namespace QuanLyQuanCafe.DAL
{
    internal class DataDanhMucDAL
    {
        public static DataTable data()
        {
            DataTable data;
            string query = "select *  from DanhMuc";
            data = DataProvider.Instance.GetRecords(query);
            return data;
        }
        public static DataTable capnhatDM(DanhMuc danhMuc, int i)
        {
            string query = "";
            switch (i)
            {
                case 1:
                    int dem = 0;
                    foreach (DataRow row in DataDanhMucDAL.data().Rows)
                        if (row[0].ToString() == danhMuc.ID)
                            dem++;
                    if (dem == 0)
                        try
                        {
                            DataProvider.Instance.setdata("insert into DanhMuc values('" + danhMuc.ID + "',N'" + danhMuc.Name + "')");
                        }
                        catch (Exception ex) { MessageBox.Show("Không thể thực hiện thao tác này"); }
                    break;
                case 2:
                    try
                    {
                        DataProvider.Instance.setdata("update Mon set ID_category = null where ID_category = '" + danhMuc.ID + "'");
                        DataProvider.Instance.setdata("delete from DanhMuc where ID = '" + danhMuc.ID + "'");
                    }
                    catch (Exception ex) { MessageBox.Show("Không thể thực hiện thao tác này"); }
                    break;
                case 3:
                    DataProvider.Instance.setdata("update DanhMuc set Ten_Category = N'" + danhMuc.Name + "'where ID= '" + danhMuc.ID + "' ");
                    break;
                default:
                    break;
            }
            return null;
        }
        public static List<DanhMuc> locdulieu(string ten="")
        {
            List<DanhMuc> danhMucs = new List<DanhMuc>();
            foreach (DataRow i in data().Rows)
                if ((i[1].ToString().ToUpper()).Contains(ten.ToUpper()))
                    danhMucs.Add(new DanhMuc(i));
            return danhMucs;
        }
    }
}

using Microsoft.Reporting.WinForms;
using QuanLyQuanCafe.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe.Report
{
    public partial class PrintInvoice : Form
    {
        string MS = "";
        string tenNV = "";
        string Ban = "";
        string Giamgia = "";
        public PrintInvoice(string MaHD,string NV,string table,string discount)
        {
            InitializeComponent();
            MS = MaHD;
            tenNV = NV;
            Ban = table;
            Giamgia = discount;
            //this.reportViewer1.RefreshReport();

        }

        private void PrintInvoice_Load(object sender, EventArgs e)
        {
            string s = DataProvider.Instance.GetConnectionString();
            SqlConnection con = new SqlConnection(s);
            string query = "select * from View_All_Bill4 where ID_HoaDon = '" + MS + "'";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataSet1 ds = new DataSet1();
            da.Fill(ds, "DataTable1");
            ReportDataSource datasource = new ReportDataSource("DataSet_Report", ds.Tables[0]);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(datasource);
            ReportParameter[] para = new ReportParameter[]
            {
                new ReportParameter("TenNV",tenNV),
                new ReportParameter("Ban", Ban),
                new ReportParameter("GiamGia", Giamgia)
        };
            this.reportViewer1.LocalReport.SetParameters(para);
            this.reportViewer1.RefreshReport();
        }
    }
}

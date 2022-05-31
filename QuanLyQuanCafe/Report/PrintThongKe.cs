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
    public partial class PrintThongKe : Form
    {
        DateTime start, end;
        string soHD, tong;
        public PrintThongKe(string sohoadon,string tongtien,DateTime daybegin,DateTime dayend)
        {
            InitializeComponent();
            start = daybegin;
            end = dayend;
            soHD = sohoadon;
            tong = tongtien;
        }

        private void PrintThongKe_Load(object sender, EventArgs e)
        {
            string s = DataProvider.Instance.getConnectionString();
            SqlConnection con = new SqlConnection(s);
            string query = "select convert(nvarchar(10),TimeCheckout,103) as TimeCheckout,Total,TongTinh,DaThu from View_DanhThuNgay where TimeCheckout between '" + DataProvider.FormatDatetimeShort(start) + "' and '" + DataProvider.FormatDatetimeShort(end) + "'";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataSetThongKe ds = new DataSetThongKe();
            da.Fill(ds, "DataTableThongKe");
            ReportDataSource datasource = new ReportDataSource("DataSetDoanhThu", ds.Tables[0]);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(datasource);
            // this.reportViewer1.LocalReport.SetParameters(para);
            ReportParameter[] para = new ReportParameter[]
            {
                new ReportParameter("TimeBegin",start.ToString()),
                new ReportParameter("TimeEnd", end.ToString()),
                new ReportParameter("SoHoaDon", soHD),
                new ReportParameter("TongTien", tong),
        };
            this.reportViewer1.LocalReport.SetParameters(para);
            this.reportViewer1.RefreshReport();
        }
    }
}

using QuanLyQuanCafe.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe.views
{
    public partial class Detail : Form
    {
        public string maHD;
        public string tenNV;
        public string ban;
        public int tongTinh;
        public int thanhTien ;
        public DateTime gioVao ;
        public DateTime gioRa ;
        public Detail()
        {
            InitializeComponent();
            
        }

        private void Detail_Load(object sender, EventArgs e)
        {
            MaHD.Text = maHD;
            lbTenNV.Text = tenNV;
            Table_Id.Text = ban;
            CheckIn.Text = gioVao.ToString();
            CheckOut.Text = gioRa.ToString();
            CultureInfo culture = new CultureInfo("vi-VN");
            Tong.Text = tongTinh.ToString("c", culture);
            ThanhTien.Text = thanhTien.ToString("c", culture);
            DGV_ListMon.DataSource = DataHoaDonDAL.Instance.LoadMonDaChon(maHD);
        }
    }
}

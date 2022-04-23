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

namespace QuanLyQuanCafe
{
    public delegate void Quit();
    public partial class Dashboard : Form
    {
        public Quit login_show;
        public Quit quit;
       
        public Dashboard()
        {
            InitializeComponent();
            BT_Refresh_Click_NhanVien(new object(),new EventArgs());
            BT_refresh_DanhMuc_Click(new object(),new EventArgs());
            BT_Refresh2_Click(new object(),new EventArgs());
            BT_Refresh_Ban_Click(new object(), new EventArgs());
            updatedate();
            BT_List_Bill_Click(new object(), new EventArgs());
            BT_List_Danhthu_Click(new object(), new EventArgs());
        }

        /// <summary>
        /// Nhân viên
        /// </summary>
        void load_cbb_chucvu()
        {
            cbB_ChucVuNV.Items.Clear();
            cbB_ChucVu.Items.Clear();
            cbB_ChucVuNV.Items.Add("Tất cả");
            foreach (DataRow i in DataNhanVienDAL.data_Chucvu().Rows)
            {
                cbB_ChucVu.Items.Add(i[0].ToString());
                cbB_ChucVuNV.Items.Add(i[0].ToString());
            }
        }    
        public void btLogOut_Click(object sender, EventArgs e)
        {
            login_show();
            this.Close();
        }
        private void TB_TimNhanVien_TextChanged(object sender, EventArgs e)
        {
            DGV_NhanVien.DataSource = DataNhanVienDAL.locdulieu(TB_TimNhanVien.Text.Trim());
            DGV_NhanVien.Columns.RemoveAt(5);
        }
        private void cbB_ChucVuNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbB_ChucVuNV.Text.ToString().Trim() == "Tất cả")
                DGV_NhanVien.DataSource = DataNhanVienDAL.data();
            else
            {
                DGV_NhanVien.DataSource = DataNhanVienDAL.locdulieu("",cbB_ChucVuNV.Text.Trim());
                DGV_NhanVien.Columns.RemoveAt(5);
            }
        }
        private void BT_Refresh_Click_NhanVien(object sender, EventArgs e)
        {
            DGV_NhanVien.DataSource = DataNhanVienDAL.data();
            DGV_NhanVien.Columns[0].HeaderText = "Mã NV";
            DGV_NhanVien.Columns[1].HeaderText = "Họ và tên";
            DGV_NhanVien.Columns[2].HeaderText = "Ngày sinh";
            DGV_NhanVien.Columns[3].HeaderText = "Chức vụ";
            DGV_NhanVien.Columns[4].HeaderText = "Tài khoản";
            DGV_NhanVien.Columns[5].HeaderText = "Email";
            DGV_NhanVien.Columns[6].HeaderText = "Lương";
            load_cbb_chucvu();
            TB_TimNhanVien.Text = "";
            TB_TenNV.Text = "";
            TB_IDNV.Text = "";
            TB_emailNV.Text = "";
            TB_ChucVu.Text = "";
            TB_UserName.Text = "";
            TB_LuongNV.Text = "";
            TB_SDT.Text = "";
        }
        private void DGV_NhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TB_IDNV.Text = DGV_NhanVien.CurrentRow.Cells[0].Value.ToString().Trim();
            TB_TenNV.Text = DGV_NhanVien.CurrentRow.Cells[1].Value.ToString().Trim();
            DT_NSNV.Text = DGV_NhanVien.CurrentRow.Cells[2].Value.ToString().Trim();
            TB_ChucVu.Text = DGV_NhanVien.CurrentRow.Cells[3].Value.ToString().Trim();
            TB_UserName.Text = DGV_NhanVien.CurrentRow.Cells[4].Value.ToString().Trim();
            TB_emailNV.Text = DGV_NhanVien.CurrentRow.Cells[5].Value.ToString().Trim();
            TB_LuongNV.Text = DGV_NhanVien.CurrentRow.Cells[6].Value.ToString().Trim(); 
            TB_SDT.Text = DGV_NhanVien.CurrentRow.Cells[7].Value.ToString().Trim();
            
        }
        private void BT_Them1_Click(object sender, EventArgs e)
        {
            if(TB_emailNV.Text == "")
            {
                DataNhanVienDAL.capnhatNV(new NhanVien(TB_IDNV.Text.ToString().ToUpper(), TB_TenNV.Text, DT_NSNV.Text,
                                                   TB_ChucVu.Text,"", "", TB_LuongNV.Text, TB_emailNV.Text, TB_SDT.Text), 1);
                BT_Refresh_Click_NhanVien(new object(), new EventArgs());
            }
            else
            {
                if (CheckEmail.Instance.Check(TB_emailNV.Text))
                {
                    string password = ReloadAccount.sendcode(TB_emailNV.Text, 1);
                    DataNhanVienDAL.capnhatNV(new NhanVien(TB_IDNV.Text.ToString().ToUpper(), TB_TenNV.Text, DT_NSNV.Text,
                                                           TB_ChucVu.Text, TB_UserName.Text, password, TB_LuongNV.Text, TB_emailNV.Text, TB_SDT.Text), 1);
                    BT_Refresh_Click_NhanVien(new object(), new EventArgs());
                }
                else MessageBox.Show("Có lỗi trong quá trình kiểm tra email. Vui lòng thực hiện lại!!");
            }
        }
        private void BT_Xoa1_Click(object sender, EventArgs e)
        {
            DataNhanVienDAL.capnhatNV(new NhanVien(TB_IDNV.Text.ToString().ToUpper(),"","","","","","","",""), 2) ;
            BT_Refresh_Click_NhanVien(new object(), new EventArgs());
        }
        private void BT_Sua1_Click(object sender, EventArgs e)
        {
            DataNhanVienDAL.capnhatNV(new NhanVien(TB_IDNV.Text.ToString().ToUpper(), TB_TenNV.Text, DT_NSNV.Text,
                                                   TB_ChucVu.Text, TB_UserName.Text,"",TB_LuongNV.Text, TB_emailNV.Text,TB_SDT.Text),3);
            BT_Refresh_Click_NhanVien(new object(), new EventArgs());
        }
        private void cbB_ChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            TB_ChucVu.Text = cbB_ChucVu.Text.Trim();
        }


        ///
        //// DanhMuc
        ///
        void load_cbb_danhmuc()
        {
            CBB_DanhMuc.Items.Clear();
            CBB_ChonDanhMuc.Items.Clear();
            foreach(DataRow i in DataDanhMucDAL.data().Rows)
            {
                CBB_ChonDanhMuc.Items.Add(i[1].ToString().Trim());
                CBB_DanhMuc.Items.Add(i[1].ToString().Trim());
            }    
        }
        private void TB_TimDM_TextChanged(object sender, EventArgs e)
        {
            DGV_DanhMuc.DataSource = DataDanhMucDAL.locdulieu(TB_TimDM.Text.Trim());
            DGV_DanhMuc.Columns[0].HeaderText = "Mã DM";
            DGV_DanhMuc.Columns[1].HeaderText = "Tên danh mục";
        }
        private void BT_refresh_DanhMuc_Click(object sender, EventArgs e)
        {
            DGV_DanhMuc.DataSource = DataDanhMucDAL.data();
            DGV_DanhMuc.Columns[0].HeaderText = "Mã DM";
            DGV_DanhMuc.Columns[1].HeaderText = "Tên danh mục";
            load_cbb_danhmuc();
            TB_TimDM.Text = "";
            TB_ID_DM.Text = "";
            TB_NhapDanhMuc.Text = "";
        }
        private void DGV_DanhMuc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TB_ID_DM.Text = DGV_DanhMuc.CurrentRow.Cells[0].Value.ToString().Trim();
            TB_NhapDanhMuc.Text = DGV_DanhMuc.CurrentRow.Cells[1].Value.ToString().Trim();
        }
        private void BT_Them3_Click(object sender, EventArgs e)
        {
            DataDanhMucDAL.capnhatDM(new DanhMuc(TB_ID_DM.Text.ToString().ToUpper().Trim(), TB_NhapDanhMuc.Text.ToString().Trim()),1);
            BT_refresh_DanhMuc_Click(new object(), new EventArgs());
        }
        private void BT_Xoa3_Click(object sender, EventArgs e)
        {
            DataDanhMucDAL.capnhatDM(new DanhMuc(TB_ID_DM.Text.ToString().ToUpper().Trim(),""), 2);
            BT_refresh_DanhMuc_Click(new object(), new EventArgs());
        }
        private void BT_Sua3_Click(object sender, EventArgs e)
        {
            DataDanhMucDAL.capnhatDM(new DanhMuc(TB_ID_DM.Text.ToString().ToUpper().Trim(), TB_NhapDanhMuc.Text.ToString().Trim()), 3);
            BT_refresh_DanhMuc_Click(new object(), new EventArgs());
        }


        //
        /// ///Mon
        /// 
        private void TB_TimMon_TextChanged(object sender, EventArgs e)
        {
            DGV_Mon.DataSource = DataMonDAL.locdulieu(TB_TimMon.Text.ToUpper());
            DGV_Mon.Columns[0].HeaderText = "Mã món";
            DGV_Mon.Columns[1].HeaderText = "Tên món";
            DGV_Mon.Columns[2].HeaderText = "Danh mục";
            DGV_Mon.Columns[3].HeaderText = "Giá";
        }
        private void CBB_DanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            DGV_Mon.DataSource = DataMonDAL.locdulieu("",CBB_DanhMuc.Text.ToUpper().Trim());
            DGV_Mon.Columns[0].HeaderText = "Mã món";
            DGV_Mon.Columns[1].HeaderText = "Tên món";
            DGV_Mon.Columns[2].HeaderText = "Danh mục";
            DGV_Mon.Columns[3].HeaderText = "Giá";
        }
        private void BT_Refresh2_Click(object sender, EventArgs e)
        {
            DGV_Mon.DataSource = DataMonDAL.data();
            DGV_Mon.Columns[0].HeaderText = "Mã món";
            DGV_Mon.Columns[1].HeaderText = "Tên món";
            DGV_Mon.Columns[2].HeaderText = "Danh mục";
            DGV_Mon.Columns[3].HeaderText = "Giá";
            TB_TimMon.Text = "";
            TB_IDmon.Text = "";
            TB_TenM0n.Text = "";
            TB_DanhMuc.Text = "";
            TB_Gia.Text = "";
            load_cbb_danhmuc();
        }
        private void DGV_Mon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TB_IDmon.Text = DGV_Mon.CurrentRow.Cells[0].Value.ToString().Trim();
            TB_TenM0n.Text = DGV_Mon.CurrentRow.Cells[1].Value.ToString().Trim(); ;
            TB_DanhMuc.Text = DGV_Mon.CurrentRow.Cells[2].Value.ToString().Trim();
            TB_Gia.Text = DGV_Mon.CurrentRow.Cells[3].Value.ToString().Trim();
        }
        private void BT_Them2_Click(object sender, EventArgs e)
        {
            DataMonDAL.capnhatMon(new Mon(TB_IDmon.Text.ToString().ToUpper().Trim(), TB_TenM0n.Text.ToString().Trim(),TB_DanhMuc.Text.ToString().Trim(),Convert.ToInt32(TB_Gia.Text)), 1);
            BT_Refresh2_Click(new object(), new EventArgs());
        }
        private void BT_Sua2_Click(object sender, EventArgs e)
        {
            DataMonDAL.capnhatMon(new Mon(TB_IDmon.Text.ToString().ToUpper().Trim(), TB_TenM0n.Text.ToString().Trim(), TB_DanhMuc.Text.ToString().Trim(), Convert.ToInt32(TB_Gia.Text)), 3);
            BT_Refresh2_Click(new object(), new EventArgs());
        }
        private void BT_Xoa2_Click(object sender, EventArgs e)
        {
            DataMonDAL.capnhatMon(new Mon(TB_IDmon.Text.ToString().ToUpper().Trim(),"","",0), 2);
            BT_Refresh2_Click(new object(), new EventArgs());
        }
        private void CBB_ChonDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            TB_DanhMuc.Text = CBB_ChonDanhMuc.Text.Trim();
        }

        //
        /// ////Bàn
        /// 
        void load_cbb_status()
        {
            cbB_TrangThai.Items.Clear();
            foreach (DataRow i in DataTableDAL.data_status().Rows)
            {
                if (Convert.ToBoolean(i[0].ToString()))
                    cbB_TrangThai.Items.Add("Trống");
                else 
                    cbB_TrangThai.Items.Add("Có người");
            }
        }
        private void TB_TimBan_TextChanged(object sender, EventArgs e)
        {
            load_FLP_Table(DataTableDAL.locdulieu(TB_TimBan.Text.Trim()));
        }
        private void cbB_TrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = "";
            if (cbB_TrangThai.Text.Trim() == "Trống")
                str = "True";
            else if (cbB_TrangThai.Text.Trim() == "Có người")
                str = "False";
            load_FLP_Table(DataTableDAL.locdulieu("",str));
        }
        private void BT_Refresh_Ban_Click(object sender, EventArgs e)
        {
            List<Table> tables = new List<Table> ();
            foreach (DataRow i in DataTableDAL.data().Rows)
                tables.Add(new Table(i));
            load_FLP_Table(tables);
            load_cbb_status();
            TB_TimBan.Text = "";
            TB_IDban.Text = "";
            TB_BanStatus.Text = "";
        }
        private void BT_Them4_Click(object sender, EventArgs e)
        {
            DataTableDAL.capnhatBan(new Table(TB_IDban.Text.ToString().ToUpper().Trim(),Convert.ToBoolean("True")), 1);
            BT_Refresh_Ban_Click(new object(), new EventArgs());
        }
        private void BT_Xoa4_Click(object sender, EventArgs e)
        {
            if (TB_BanStatus.Text == "Có người")
                MessageBox.Show("Lỗi!");
            else
            {
                DataTableDAL.capnhatBan(new Table(TB_IDban.Text.Trim().ToUpper(),true), 2);
                BT_Refresh_Ban_Click(new object(), new EventArgs());
            }
        }
        public void load_FLP_Table(List<Table> tables)
        {
            FLP_Ban.Controls.Clear();
            foreach (Table i in tables)
            {
                Button button = new Button();
                button.Text = i.Id + "\n" + (i.Status ? "Trống" : "Có người");
                button.BackColor = System.Drawing.Color.SpringGreen;
                button.Cursor = System.Windows.Forms.Cursors.Hand;
                button.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                button.Margin = new System.Windows.Forms.Padding(0);
                button.Name = i.Id;
                button.Size = new System.Drawing.Size(75, 50);
                button.Click += new System.EventHandler(this.BT_Click);
                if (!i.Status)
                {
                    button.BackColor = System.Drawing.Color.HotPink;
                }
                FLP_Ban.Controls.Add(button);
            }

        }
        
        
        //
        /// ///Khác
        ///
        private void BT_Click(object sender, EventArgs e)
        {
            TB_IDban.Text = ((Button)sender).Text.ToString().Split('\n')[0];
            TB_BanStatus.Text = ((Button)sender).Text.ToString().Split('\n')[1];
        }
        private void BT_List_Danhthu_Click(object sender, EventArgs e)
        {
            DGV_DoanhThu.DataSource = DataDanhThuDAL.data(DT_Danhthu_Begin.Value, DT_Danhthu_End.Value);
            DGV_DoanhThu.Columns[0].HeaderText = "Ngày";
            DGV_DoanhThu.Columns[1].HeaderText = "Số đơn";
            DGV_DoanhThu.Columns[2].HeaderText = "Tổng danh thu";
            
        }
        private void BT_List_Bill_Click(object sender, EventArgs e)
        {
            DGV_Bill.DataSource = DataBillDAL.locdata(DT_Bill_Begin.Value, DT_Bill_End.Value);
            DGV_Bill.Columns[0].HeaderText = "Mã hóa đơn";
            DGV_Bill.Columns[1].HeaderText = "Thời gian vào";
            DGV_Bill.Columns[2].HeaderText = "Thời gian ra";
            DGV_Bill.Columns[3].HeaderText = "Bàn";
            DGV_Bill.Columns[4].HeaderText = "Thanh toán";
        }
        void updatedate()
        {
            DateTime d = DateTime.Now;
            TimeSpan aInterval = new System.TimeSpan(1, 0, 0, 0);
            DT_Bill_Begin.Value = d.Subtract(aInterval);
            DT_Bill_End.Value = d.Add(aInterval);
            DT_Danhthu_Begin.Value = d.Subtract(aInterval);
            DT_Danhthu_End.Value = d.Add(aInterval);
            DT_NSNV.Value = d;
            
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            quit();
        }

    }
}

using QuanLyQuanCafe.DAL;
using QuanLyQuanCafe.DTO;
using QuanLyQuanCafe.Report;
using QuanLyQuanCafe.views;
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
        NhanVien nv = new NhanVien();
        public Dashboard()
        {
            InitializeComponent();
            BT_Refresh_Click_NhanVien(new object(), new EventArgs());
            BT_refresh_DanhMuc_Click(new object(), new EventArgs());
            BT_Refresh2_Click(new object(), new EventArgs());
            BT_Refresh_Ban_Click(new object(), new EventArgs());
            BT_ResetChucVu_Click(new object(), new EventArgs());
            updatedate();
            BT_List_Bill_Click(new object(), new EventArgs());
            BT_List_Danhthu_Click(new object(), new EventArgs());

        }

        /// <summary>
        /// Nhân viên
        /// </summary>
        #region NhanVien
        void load_cbb_chucvu()
        {
            cbB_ChucVuNV.Items.Clear();
            cbB_ChucVu.Items.Clear();
            cbB_ChucVuNV.Items.Add("Tất cả");
            foreach (DataRow i in DataChucVuDAL.Instance.data().Rows)
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
            DGV_NhanVien.DataSource = DataNhanVienDAL.Instance.locdulieu(TB_TimNhanVien.Text.Trim());
            if (DGV_NhanVien.Columns.Contains("Anh"))
                DGV_NhanVien.Columns.Remove("Anh");
        }
        private void cbB_ChucVuNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbB_ChucVuNV.Text.ToString().Trim() == "Tất cả")
            {
                DGV_NhanVien.DataSource = DataNhanVienDAL.Instance.data();
                DGV_NhanVien.Columns.Remove("Anh");
            }
            else
            {
                DGV_NhanVien.DataSource = DataNhanVienDAL.Instance.locdulieu("", cbB_ChucVuNV.Text.Trim());
                if (DGV_NhanVien.Columns.Contains("Anh"))
                    DGV_NhanVien.Columns.Remove("Anh");
            }
        }
        private void DGV_NhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TB_IDNV.Text = DGV_NhanVien.CurrentRow.Cells[0].Value.ToString().Trim();
            NhanVien nv = DataNhanVienDAL.Instance.getNhanVienbyID(TB_IDNV.Text);
            TB_TenNV.Text = nv.Name.Trim();
            DT_NSNV.Text = nv.NgaySinh.ToString().Trim();
            cbB_ChucVu.Text = nv.ChucVu.TenChucVu.Trim();
            TB_UserName.Text = nv.TaiKhoan.UserName.Trim();
            TB_emailNV.Text = nv.Email.Trim();
            TB_LuongNV.Text = nv.ChucVu.Luong.ToString().Trim();
            TB_SDT.Text = nv.SDT.Trim();
            if (nv.Anh == null) 
                pbAnhNV.Image = null;
            else
            pbAnhNV.Image = nv.Anh;//DataNhanVienDAL.Instance.ByteArrayToImage(b);
        }
        private void BT_Them1_Click(object sender, EventArgs e)
        {
            try
            {
                if (TB_emailNV.Text == "")
                {
                    DataNhanVienDAL.Instance.addNhanVien(new NhanVien(TB_IDNV.Text.ToString().ToUpper(), TB_TenNV.Text, DT_NSNV.Text,
                                                       cbB_ChucVu.Text, "", "", TB_emailNV.Text, TB_SDT.Text, pbAnhNV.Image));
                    BT_Refresh_Click_NhanVien(new object(), new EventArgs());
                }
                else
                {
                    //if (CheckEmail.Instance.Check(TB_emailNV.Text))
                    //{
                    DataNhanVienDAL.Instance.addNhanVien(new NhanVien(TB_IDNV.Text.ToString().ToUpper(), TB_TenNV.Text, DT_NSNV.Text,
                                                           cbB_ChucVu.Text, TB_UserName.Text, "", TB_emailNV.Text, TB_SDT.Text, pbAnhNV.Image));
                    BT_Refresh_Click_NhanVien(new object(), new EventArgs());
                    //}
                    //else MessageBox.Show("Có lỗi trong quá trình kiểm tra email. Vui lòng thực hiện lại!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message);
            }
        }
        private void BT_Xoa1_Click(object sender, EventArgs e)
        {
            DataNhanVienDAL.Instance.deleteNhanVien(TB_IDNV.Text.ToString().ToUpper());
            BT_Refresh_Click_NhanVien(new object(), new EventArgs());
        }
        private void BT_Sua1_Click(object sender, EventArgs e)
        {
            DataNhanVienDAL.Instance.updateNhanVien(new NhanVien(TB_IDNV.Text.ToString().ToUpper(), TB_TenNV.Text, DT_NSNV.Text,
                                                   cbB_ChucVu.Text, TB_UserName.Text, "", TB_emailNV.Text, TB_SDT.Text, pbAnhNV.Image));
            BT_Refresh_Click_NhanVien(new object(), new EventArgs());
        }
        private void cbB_ChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            TB_LuongNV.Text = DataChucVuDAL.Instance.getChucVubyID(cbB_ChucVu.Text.Trim()).Luong.ToString();
        }
        #endregion

        ///
        //// DanhMuc
        ///
        #region DanhMuc
        void load_cbb_danhmuc()
        {
            CBB_DanhMuc.Items.Clear();
            CBB_ChonDanhMuc.Items.Clear();
            foreach (DataRow i in DataDanhMucDAL.Instance.data().Rows)
            {
                CBB_ChonDanhMuc.Items.Add(i[1].ToString().Trim());
                CBB_DanhMuc.Items.Add(i[1].ToString().Trim());
            }
        }
        private void TB_TimDM_TextChanged(object sender, EventArgs e)
        {
            DGV_DanhMuc.DataSource = DataDanhMucDAL.Instance.locdulieu(TB_TimDM.Text.Trim());
            DGV_DanhMuc.Columns[0].HeaderText = "Mã DM";
            DGV_DanhMuc.Columns[1].HeaderText = "Tên danh mục";
        }
        private void BT_Refresh_Click_NhanVien(object sender, EventArgs e)
        {
            DataTable data = DataNhanVienDAL.Instance.data();
            data.Columns.Remove("Anh");
            DGV_NhanVien.DataSource = data;
            DGV_NhanVien.Columns[0].HeaderText = "Mã NV";
            DGV_NhanVien.Columns[1].HeaderText = "Họ và tên";
            DGV_NhanVien.Columns[2].HeaderText = "Ngày sinh";
            DGV_NhanVien.Columns[3].HeaderText = "Chức vụ";
            DGV_NhanVien.Columns[4].HeaderText = "Tài khoản";
            DGV_NhanVien.Columns[5].HeaderText = "Email";
            DGV_NhanVien.Columns[6].HeaderText = "Lương";
            DGV_NhanVien.Columns[7].HeaderText = "SĐT";
            load_cbb_chucvu();
            TB_TimNhanVien.Text = "";
            TB_TenNV.Text = "";
            TB_IDNV.Text = "";
            TB_emailNV.Text = "";
            cbB_ChucVu.Text = "";
            TB_UserName.Text = "";
            TB_LuongNV.Text = "";
            TB_SDT.Text = "";
            pbAnhNV.Image = null;
        }


        private void BT_refresh_DanhMuc_Click(object sender, EventArgs e)
        {
            DGV_DanhMuc.DataSource = DataDanhMucDAL.Instance.data();
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
            try
            {
                DataDanhMucDAL.Instance.addDanhMuc(new DanhMuc(TB_ID_DM.Text.ToString().ToUpper().Trim(), TB_NhapDanhMuc.Text.ToString().Trim()));
                BT_refresh_DanhMuc_Click(new object(), new EventArgs());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message);
            }
            
        }
        private void BT_Xoa3_Click(object sender, EventArgs e)
        {
            DataDanhMucDAL.Instance.deleteDanhMuc(TB_ID_DM.Text.ToString().ToUpper().Trim());
            BT_refresh_DanhMuc_Click(new object(), new EventArgs());
        }
        private void BT_Sua3_Click(object sender, EventArgs e)
        {
            DataDanhMucDAL.Instance.updateDanhMuc(new DanhMuc(TB_ID_DM.Text.ToString().ToUpper().Trim(), TB_NhapDanhMuc.Text.ToString().Trim()));
            BT_refresh_DanhMuc_Click(new object(), new EventArgs());
        }

        #endregion
        //
        /// ///Mon
        /// 
        #region Mon
        private void TB_TimMon_TextChanged(object sender, EventArgs e)
        {
            DGV_Mon.DataSource = DataMonDAL.Instance.locdulieu(TB_TimMon.Text.ToUpper());
            DGV_Mon.Columns[0].HeaderText = "Mã món";
            DGV_Mon.Columns[1].HeaderText = "Tên món";
            DGV_Mon.Columns[2].HeaderText = "Danh mục";
            DGV_Mon.Columns[3].HeaderText = "Giá";
        }
        private void CBB_DanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            DGV_Mon.DataSource = DataMonDAL.Instance.locdulieu("", CBB_DanhMuc.Text.ToUpper().Trim());
            DGV_Mon.Columns[0].HeaderText = "Mã món";
            DGV_Mon.Columns[1].HeaderText = "Tên món";
            DGV_Mon.Columns[2].HeaderText = "Danh mục";
            DGV_Mon.Columns[3].HeaderText = "Giá";
            DGV_Mon.Columns.Remove("DaXoa");
        }
        private void BT_Refresh2_Click(object sender, EventArgs e)
        {
            DGV_Mon.DataSource = DataMonDAL.Instance.loctatcadulieu();
            DGV_Mon.Columns[0].HeaderText = "Mã món";
            DGV_Mon.Columns[1].HeaderText = "Tên món";
            DGV_Mon.Columns[2].HeaderText = "Danh mục";
            DGV_Mon.Columns[3].HeaderText = "Giá";
            DGV_Mon.Columns["DaXoa"].HeaderText = "Đã xóa"; ;
            TB_TimMon.Text = "";
            TB_IDmon.Text = "";
            TB_TenM0n.Text = "";
            CBB_ChonDanhMuc.Text = "";
            TB_Gia.Text = "";
            load_cbb_danhmuc();
        }
        private void DGV_Mon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TB_IDmon.Text = DGV_Mon.CurrentRow.Cells[0].Value.ToString().Trim();
            TB_TenM0n.Text = DGV_Mon.CurrentRow.Cells[1].Value.ToString().Trim(); ;
            CBB_ChonDanhMuc.Text = DGV_Mon.CurrentRow.Cells[2].Value.ToString().Trim();
            TB_Gia.Text = DGV_Mon.CurrentRow.Cells[3].Value.ToString().Trim();
        }
        private void BT_Them2_Click(object sender, EventArgs e)
        {
            try
            {
                DataMonDAL.Instance.addMon(new Mon(DataMonDAL.Instance.CapIDmon(), TB_TenM0n.Text.ToString().Trim(),
                    DataDanhMucDAL.Instance.getDanhMucbyTen(CBB_ChonDanhMuc.Text.ToString().Trim()).ID, Convert.ToInt32(TB_Gia.Text)));
                BT_Refresh2_Click(new object(), new EventArgs());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message);
            }
        }
        private void BT_Sua2_Click(object sender, EventArgs e)
        {
            DataMonDAL.Instance.updateMon(new Mon(TB_IDmon.Text.ToString().ToUpper().Trim(), TB_TenM0n.Text.ToString().Trim(),
                DataDanhMucDAL.Instance.getDanhMucbyTen(CBB_ChonDanhMuc.Text.ToString().Trim()).ID, Convert.ToInt32(TB_Gia.Text)));
            BT_Refresh2_Click(new object(), new EventArgs());
        }
        private void BT_Xoa2_Click(object sender, EventArgs e)
        {
            DataMonDAL.Instance.deleteMon(TB_IDmon.Text.ToString().ToUpper().Trim());
            BT_Refresh2_Click(new object(), new EventArgs());
        }
        #endregion
        //
        /// ////Bàn
        /// 
        #region Ban
        void load_cbb_status()
        {
            cbB_TrangThai.Items.Clear();
            foreach (string i in DataBanAnDAL.Instance.statuses())
            {
                if (Convert.ToBoolean(i.ToString()))
                    cbB_TrangThai.Items.Add("Trống");
                else
                    cbB_TrangThai.Items.Add("Có người");
            }
        }
        private void TB_TimBan_TextChanged(object sender, EventArgs e)
        {
            load_FLP_Table(DataBanAnDAL.Instance.locBanAnbyID(TB_TimBan.Text.Trim()));
        }
        private void cbB_TrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = "";
            if (cbB_TrangThai.Text.Trim() == "Trống")
                str = "True";
            else if (cbB_TrangThai.Text.Trim() == "Có người")
                str = "False";
            load_FLP_Table(DataBanAnDAL.Instance.getBanAnbyStatus(str));
        }
        private void BT_Refresh_Ban_Click(object sender, EventArgs e)
        {
            load_FLP_Table(DataBanAnDAL.Instance.listban());
            load_cbb_status();
            TB_TimBan.Text = "";
            TB_IDban.Text = "";
            TB_BanStatus.Text = "";
        }
        private void BT_Them4_Click(object sender, EventArgs e)
        {
            try
            {
                DataBanAnDAL.Instance.addBanAn(new BanAn(TB_IDban.Text.ToString().ToUpper().Trim(), Convert.ToBoolean("True")));
                BT_Refresh_Ban_Click(new object(), new EventArgs());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message);
            }
        }
        private void BT_Xoa4_Click(object sender, EventArgs e)
        {
            if (TB_BanStatus.Text == "Có người")
                MessageBox.Show("Lỗi!");
            else
            {
                DataBanAnDAL.Instance.deleteBanAn(TB_IDban.Text.Trim().ToUpper());
                BT_Refresh_Ban_Click(new object(), new EventArgs());
            }
        }
        public void load_FLP_Table(List<BanAn> tables)
        {
            FLP_Ban.Controls.Clear();
            foreach (BanAn i in tables)
            {
                Button button = new Button();
                button.Text = i.ID + "\n" + (i.Status ? "Trống" : "Có người");
                button.BackColor = System.Drawing.Color.SpringGreen;
                button.Cursor = System.Windows.Forms.Cursors.Hand;
                button.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                button.Margin = new System.Windows.Forms.Padding(0);
                button.Name = i.ID;
                button.Size = new System.Drawing.Size(75, 50);
                button.Click += new System.EventHandler(this.BT_Click);
                if (!i.Status)
                {
                    button.BackColor = System.Drawing.Color.HotPink;
                }
                FLP_Ban.Controls.Add(button);
            }

        }
        #endregion

        //
        /// ///Khác
        ///
        #region Khác
        private void BT_Click(object sender, EventArgs e)
        {
            TB_IDban.Text = ((Button)sender).Text.ToString().Split('\n')[0];
            TB_BanStatus.Text = ((Button)sender).Text.ToString().Split('\n')[1];
        }
        private void BT_List_Danhthu_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void BT_List_Bill_Click(object sender, EventArgs e)
        {
            DGV_Bill.DataSource = DataHoaDonDAL.Instance.locdata(DT_Bill_Begin.Value, DT_Bill_End.Value);
            DGV_Bill.Columns[0].HeaderText = "Mã hóa đơn";
            DGV_Bill.Columns[1].HeaderText = "Thời gian vào";
            DGV_Bill.Columns[2].HeaderText = "Thời gian ra";
            DGV_Bill.Columns[3].HeaderText = "Tổng tính";
            DGV_Bill.Columns[4].HeaderText = "Đã thu";
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
        #endregion
        /// <summary>
        /// Chức vụ
        /// </summary>
        /// <param name="Chức vụ"></param>
        /// <param name="e"></param>
        #region Chức vụ
        private void TB_TimChucVu_TextChanged(object sender, EventArgs e)
        {
            DGV_ChucVu.DataSource = DataChucVuDAL.Instance.locdulieu(TB_TimChucVu.Text.Trim());
            DGV_ChucVu.Columns[0].HeaderText = "Tên chức vụ";
            DGV_ChucVu.Columns[1].HeaderText = "Lương";
        }

        private void BT_ResetChucVu_Click(object sender, EventArgs e)
        {
            DGV_ChucVu.DataSource = DataChucVuDAL.Instance.data();
            DGV_ChucVu.Columns[0].HeaderText = "Tên chức vụ";
            DGV_ChucVu.Columns[1].HeaderText = "Lương";
            load_cbb_chucvu();
            TB_TimChucVu.Text = "";
            TB_Chucvuv.Clear();
            TB_Luong.Text = "";
        }

        private void BT_themChucVu_Click(object sender, EventArgs e)
        {
            try
            {
                DataChucVuDAL.Instance.addChucvu(new ChucVu(TB_Chucvuv.Text.ToString().ToUpper().Trim(), Convert.ToInt32(TB_Luong.Text.ToString().Trim())));
                BT_ResetChucVu_Click(new object(), new EventArgs());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message);
            }
        }

        private void BT_suaChucVu_Click(object sender, EventArgs e)
        {
            DataChucVuDAL.Instance.updateChucvu(new ChucVu(TB_Chucvuv.Text.ToString().ToUpper().Trim(), Convert.ToInt32(TB_Luong.Text.ToString().Trim())));
            BT_ResetChucVu_Click(new object(), new EventArgs());
        }

        private void BT_Xoachucvu_Click(object sender, EventArgs e)
        {
            DataChucVuDAL.Instance.deleteChucvu(TB_Chucvuv.Text.ToString().ToUpper().Trim());
            BT_ResetChucVu_Click(new object(), new EventArgs());
        }
        #endregion

        private void DGV_ChucVu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TB_Chucvuv.Text = DGV_ChucVu.CurrentRow.Cells[0].Value.ToString().Trim();
            TB_Luong.Text = DGV_ChucVu.CurrentRow.Cells[1].Value.ToString().Trim();
        }

        private void btCustom_Click(object sender, EventArgs e)
        {
            DT_Danhthu_Begin.Enabled = true;
            DT_Danhthu_End.Enabled = true;
            BT_List_Danhthu.Visible = true;
        }

        private void Day_Click(object sender, EventArgs e)
        {
            DT_Danhthu_Begin.Value = DateTime.Today.AddDays(-7);
            DT_Danhthu_End.Value = DateTime.Now;
            LoadData();
            DisableCustomDates();
        }

        private void OneMonth_Click(object sender, EventArgs e)
        {
            DT_Danhthu_Begin.Value = DateTime.Today.AddDays(-30);
            DT_Danhthu_End.Value = DateTime.Now;
            LoadData();
            DisableCustomDates();
        }
        private void LoadData()
        {
            bool refreshData = ThongKeDAL.Instance.LoadData(DT_Danhthu_Begin.Value, DT_Danhthu_End.Value);
            if (refreshData == true)
            {
                chart1.DataSource = ThongKeDAL.Instance.GrossRevenueList;
                chart1.Series[0].XValueMember = "Date";
                chart1.Series[0].YValueMembers = "TotalAmount";
                chart1.DataBind();
                chartTopProducts.DataSource = ThongKeDAL.Instance.TopProductsList;
                chartTopProducts.Series[0].XValueMember = "Key";
                chartTopProducts.Series[0].YValueMembers = "Value";
                chartTopProducts.DataBind();
                lbSoHD.Text = ThongKeDAL.Instance.NumOrders.ToString();
                lbTongThu.Text = ThongKeDAL.Instance.TotalRevenue.ToString() + "đ";
                DGV_DoanhThu.DataSource = DataDanhThuDAL.data(DT_Danhthu_Begin.Value, DT_Danhthu_End.Value);
                DGV_DoanhThu.Columns[0].HeaderText = "Ngày";
                DGV_DoanhThu.Columns[1].HeaderText = "Số đơn";
                DGV_DoanhThu.Columns[2].HeaderText = "Đã tính";
                DGV_DoanhThu.Columns[3].HeaderText = "Tổng danh thu";
                Console.WriteLine("Loaded view :)");
            }
            else Console.WriteLine("View not loaded, same query");
        }
        private void DisableCustomDates()
        {
            DT_Danhthu_Begin.Enabled = false;
            DT_Danhthu_End.Enabled = false;
            BT_List_Danhthu.Visible = false;
        }

        private void ThisMonth_Click(object sender, EventArgs e)
        {
            DT_Danhthu_Begin.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DT_Danhthu_End.Value = DateTime.Now;
            LoadData();
            DisableCustomDates();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            DT_Danhthu_Begin.Value = DateTime.Today.AddDays(-7);
            DT_Danhthu_End.Value = DateTime.Now;
            Day.Select();
            DisableCustomDates();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            chart1.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            chart1.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart1.Series["Series1"]["DrawingStyle"] = "Cylinder";
        }

        private void btInThongKe_Click(object sender, EventArgs e)
        {
            PrintThongKe tk = new PrintThongKe(lbSoHD.Text,lbTongThu.Text, DT_Danhthu_Begin.Value, DT_Danhthu_End.Value);
            tk.Show();
        }
        private void btUploadImage_Click(object sender, EventArgs e)
        {
            try
            {
                openFileAnh.ShowDialog();
                string nameFile = openFileAnh.FileName;
                if (string.IsNullOrEmpty(nameFile)) return;
                Image image = Image.FromFile(nameFile);
                pbAnhNV.Image = image;
            }
            catch (Exception)
            {
            }
        }
        private void btAccount_Click(object sender, EventArgs e)
        {
            InforAccount i = new InforAccount(nv);
            i.Show();
        }
        public void loadInforNV(NhanVien s)
        {
            nv = s;
        }
        public void setNameBtAccount(string s)
        {
            btAccount.Text = s;
        }
        public void hidebtAccount()
        {
            btAccount.Visible = false;
        }

        private void BT_XemChiTiet_Click(object sender, EventArgs e)
        {
            Detail detail = new Detail();
            detail.MaHD.Text = DGV_Bill.CurrentRow.Cells[0].Value.ToString();
            detail.CheckIn.Text = DGV_Bill.CurrentRow.Cells[1].Value.ToString();
            detail.CheckOut.Text = DGV_Bill.CurrentRow.Cells[2].Value.ToString();
            detail.Table_Id.Text = "";
            foreach (String i in DataHoaDon_BanDAL.Instance.data(detail.MaHD.Text))
                detail.Table_Id.Text += i + "  ";
            detail.Tong.Text = DGV_Bill.CurrentRow.Cells[3].Value.ToString();
            detail.ThanhTien.Text = DGV_Bill.CurrentRow.Cells[4].Value.ToString();
            detail.DGV_ListMon.DataSource = DataHoaDonDAL.Instance.LoadMonDaChon(detail.MaHD.Text);
            detail.lbTenNV.Text = DataNhanVienDAL.Instance.getNhanVienbyID(DGV_Bill.CurrentRow.Cells[5].Value.ToString()).Name.ToString();
            detail.ShowDialog();
        }
    }
}

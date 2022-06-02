using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyQuanCafe.DAL;
using QuanLyQuanCafe.DTO;
using QuanLyQuanCafe.Report;

namespace QuanLyQuanCafe
{
    public partial class Seller : Form
    {
        public Quit login_Show;
        public Quit quit;
        DataTable dt;
        NhanVien nv = new NhanVien();
        public Seller()
        {
            InitializeComponent();
            dt = new DataTable();
            Add_Column();
            TB_IDban.Enabled = false;
            TB_IDhoadon.Enabled = false;
            TB_Checkin.Enabled = false;
            TB_nhanvien.Enabled = false;
            Add_CbbChonBan();
        }

        private void Seller_Load(object sender, EventArgs e)
        {
            refresh(false, true, false, true, true, true);
            TB_nhanvien.Text = nv.ID.Trim() + " ( " + nv.Name.Trim() + " )";
        }
        #region Tĩnh bàn
        string current_cbb = "Tất cả";
        private void cbB_ChonBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbB_ChonBan.SelectedItem.ToString() == "Tất cả")
            {
                if (current_cbb == "Tất cả")
                    refresh(true, false, false, true, false, false);
                else
                {
                    current_cbb = cbB_ChonBan.Text.Trim();
                    refresh(true, false, false, true, true, false);
                    currenttable = "";
                }
            }
            else if (cbB_ChonBan.SelectedItem.ToString() == "Trống")
                Load_FLP_Table(DataBanAnDAL.Instance.getBanAnbyStatus("True"));
            else if (cbB_ChonBan.SelectedItem.ToString() == "Có người")
                Load_FLP_Table(DataBanAnDAL.Instance.getBanAnbyStatus("False"));
            current_cbb = cbB_ChonBan.Text.Trim();
        }
        public void Load_FLP_Table(List<BanAn> banans)
        {
            FLP_table.Controls.Clear();
            foreach (BanAn i in banans)
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
                FLP_table.Controls.Add(button);
            }
        }
        

        string currenttable = "", suppercurrenttble = "";
        private void BT_Click(object sender, EventArgs e)
        {
            if (LB_Gopban.Visible)
            {
                string str = ((Button)sender).Text.ToString().Split('\n')[0].Trim();
                if (str != "" && !TB_IDban.Text.Contains(str))
                {
                    if (TB_IDban.Text.Trim() == "")
                        TB_IDban.Text += str;
                    else if (TB_IDban.Text.Trim().EndsWith(","))
                        TB_IDban.Text += str;
                    else
                        TB_IDban.Text += "," + str;
                }
                else if (TB_IDban.Text.Contains(str))
                {
                    string idban = "";
                    try { idban = TB_IDban.Text.Remove(TB_IDban.Text.IndexOf(str), str.Length + 1); }
                    catch (Exception ex)
                    {
                        try { idban = TB_IDban.Text.Remove(TB_IDban.Text.IndexOf(str) - 1, str.Length + 1); }
                        catch (Exception ex1) { idban = TB_IDban.Text.Remove(TB_IDban.Text.IndexOf(str), str.Length); }
                    }
                    TB_IDban.Text = idban;
                }
            }
            else
            {
                refresh(true, false, false, false, false, false);
                string str = ((Button)sender).Text.ToString().Split('\n')[0];
                BanAn banan = DataBanAnDAL.Instance.getBanAnbyID(str);
                if (banan.Status)
                {
                    TB_IDban.Text = banan.ID.Trim();
                    if (currenttable.Trim() == "" || TB_IDban.Text == currenttable) ;
                    else
                    {
                        refresh(true, false, true, false, false, false);
                        TB_IDban.Text = banan.ID.Trim();
                    }
                    Panel_DoiBan.Visible = false;
                }
                else
                {
                    HoaDon hoaDon = DataHoaDonDAL.Instance.getHoaDonHienTaibyTable(banan.ID);
                    foreach (String j in DataHoaDon_BanDAL.Instance.data(hoaDon.ID_HoaDon.Substring(0,11)))
                    {
                        if (TB_IDban.Text.Trim() == "")
                            TB_IDban.Text += j.Trim();
                        else if (TB_IDban.Text.Trim().EndsWith(","))
                            TB_IDban.Text += j.Trim();
                        else
                            TB_IDban.Text += "," + j.Trim();
                    }
                    TB_IDhoadon.Text = hoaDon.ID_HoaDon;
                    TB_Checkin.Text = hoaDon.TimeCheckin.ToString();
                    dt.Clear();
                    dt = DataThongTinHoaDonDAL.Instance.LoadMonDaChon(hoaDon.ID_HoaDon);
                    DGV_DaChon.DataSource = dt;
                    try
                    {
                        loadnumric(DGV_DaChon.SelectedRows[0].Cells["Mã món"].Value.ToString());
                    }
                    catch (Exception ex) { }
                    Panel_DoiBan.Visible = true;
                }


                currenttable = TB_IDban.Text;
                try
                {
                    HoaDon hoa_don = DataHoaDonDAL.Instance.getHoaDonHienTaibyID(TB_IDhoadon.Text.Substring(0, 11));
                    if (hoa_don != null)
                    {
                        TB_Tongtien.Text = hoa_don.Tongtinh.ToString();
                        TB_thanhtien.Text = hoa_don.Dathu.ToString();
                        NumericGiamGia.Value = hoa_don.Tongtinh - hoa_don.Dathu;
                    }
                }
                catch (Exception ex)
                {
                    Tinh_tong_tien();
                }
            }
            suppercurrenttble = ((Button)sender).Text.ToString().Split('\n')[0].Trim();
        }

        #endregion

        #region Long tạp nham

        private void Add_Column()
        {
            dt.Columns.AddRange(new DataColumn[]
                {
                new DataColumn {ColumnName = "Mã món", DataType = typeof(string)},
                new DataColumn {ColumnName = "Tên món", DataType = typeof(string)},
                new DataColumn {ColumnName = "Danh mục", DataType = typeof(string )},
                new DataColumn {ColumnName = "Giá", DataType = typeof(string) },
                new DataColumn {ColumnName = "Số lượng", DataType = typeof(int)},
                });
            DataGridViewButtonColumn bt = new DataGridViewButtonColumn();
            bt.HeaderText = "Xoá";
            bt.Name = "btXoa";
            bt.Text = "X";
            bt.UseColumnTextForButtonValue = true;
            DGV_DaChon.DataSource = dt;
            DGV_DaChon.Columns.Add(bt);
            DGV_DaChon.Columns[0].Width = 35;
            DGV_DaChon.Columns[1].Width = 40;
            DGV_DaChon.Columns[2].Width = 40;
            DGV_DaChon.Columns[3].Width = 30;
            DGV_DaChon.Columns[4].Width = 25;
            DGV_DaChon.Columns[5].Width = 35;
            DGV_DaChon.ColumnHeadersHeight = 60;
        }

        private void Change_HeaderText()
        {
            DGV_Mon.Columns[0].HeaderText = "Mã món";
            DGV_Mon.Columns[1].HeaderText = "Tên món";
            DGV_Mon.Columns[2].HeaderText = "Danh mục";
            DGV_Mon.Columns[3].HeaderText = "Giá";
        }
        private void Tinh_tong_tien()
        {
            int total_money = 0;
            foreach (DataGridViewRow dr in DGV_DaChon.Rows)
                total_money += Convert.ToInt32(dr.Cells["GIá"].Value.ToString()) * Convert.ToInt32(dr.Cells["Số lượng"].Value.ToString());
            TB_Tongtien.Text = total_money.ToString();
        }

        #endregion

        #region Tĩnh Món
        private void TB_TimMon_TextChanged(object sender, EventArgs e)
        {
            DGV_Mon.DataSource = DataMonDAL.Instance.locdulieu(TB_TimMon.Text.ToUpper().Trim());
            Change_HeaderText();
        }
        private void Cbb_Danhmuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            DGV_Mon.DataSource = DataMonDAL.Instance.locdulieu("", Cbb_Danhmuc.Text.ToUpper().Trim());
            Change_HeaderText();
        }

        private void BT_refreshMon_Click(object sender, EventArgs e)
        {
            refresh(false, true, false, false, false, true);
            DGV_Mon.DataSource = DataMonDAL.Instance.locdulieu();
            Change_HeaderText();
        }

        #endregion


        #region Long CellContentClick
        private void DGV_Mon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Mon mon = DataMonDAL.Instance.getMonbyID(DGV_Mon.CurrentRow.Cells["ID"].FormattedValue.ToString());
            int dem = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString() == mon.ID)
                {
                    dem++;
                    dt.Rows[i][4] = Convert.ToInt32(dt.Rows[i][4].ToString()) + 1;
                    break;
                }
            }
            if (dem == 0) dt.Rows.Add(mon.ID, mon.TenMon, mon.DanhMuc.Ten_Category, mon.Gia, 1);
            DGV_DaChon.DataSource = dt;

            for (int i = 0; i < DGV_DaChon.Rows.Count; i++)
            {
                if (DGV_DaChon.Rows[i].Cells["Mã món"].Value.ToString().Trim() == DGV_Mon.CurrentRow.Cells[0].Value.ToString().Trim())
                    DGV_DaChon.Rows[i].Selected = true;
                else
                    DGV_DaChon.Rows[i].Selected = false;
            }
            loadnumric(DGV_DaChon.SelectedRows[0].Cells["Mã món"].Value.ToString());
            Tinh_tong_tien();
        }
        private void DGV_DaChon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV_DaChon.Columns[e.ColumnIndex].Name == "btXoa")
            {
                dt.Rows.RemoveAt(e.RowIndex);
                dt.AcceptChanges();
                Tinh_tong_tien();
            }
            else loadnumric(DGV_DaChon.SelectedRows[0].Cells["Mã món"].Value.ToString());
        }
        #endregion

        #region Tĩnh numric
        void loadnumric(string id)
        {
            Numric_Soluong.Value = Convert.ToInt32(DGV_DaChon.SelectedRows[0].Cells["Số lượng"].Value.ToString()); ;
        }

        private void Numric_Soluong_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (Numric_Soluong.Value == 0)
                {
                    DGV_DaChon.Rows.Remove(DGV_DaChon.SelectedRows[0]);
                }
                else
                    DGV_DaChon.SelectedRows[0].Cells["Số lượng"].Value = Numric_Soluong.Value;
                Tinh_tong_tien();
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region Duy Account
        private void btAccount_Click(object sender, EventArgs e)
        {
            InforAccount i = new InforAccount(nv);
            i.Show();
        }
        public void loadInforNV(NhanVien s)
        {
            nv.ID = s.ID;
            nv.Name = s.Name;
            nv.NgaySinh = s.NgaySinh;
            nv.ChucVu = s.ChucVu;
            nv.SDT = s.SDT;
            nv.Email = s.Email;
            nv.TaiKhoan = s.TaiKhoan;
        }
        public void setNameBtAccount(string s)
        {
            btAccount.Text = s;
        }
        #endregion

        #region Tĩnh control
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            login_Show();
            this.Close();
        }


        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            quit();
        }


        #endregion

        #region Tĩnh thanh toán, checkout 
        private void BT_ThanhToan_Click(object sender, EventArgs e)
        {
            ///// Thêm bàn mới
            if (LB_Gopban.Visible) btGopban_Click(new object(), new EventArgs());
            if (DataBanAnDAL.Instance.getBanAnbyID(TB_IDban.Text.Split(',')[0].ToUpper()).Status)
            {
                if (TB_IDban.Text.Trim() != "")
                {
                    //try
                    //{
                    TB_Checkin.Text = DateTime.Now.ToString();
                    TB_IDhoadon.Text = DataProvider.CapIdHoaDon();
                    try
                    {
                        HoaDon hoadon = new HoaDon(TB_IDhoadon.Text.Trim().ToUpper(), Convert.ToDateTime(TB_Checkin.Text),
                                       Convert.ToInt32(TB_Tongtien.Text), Convert.ToInt32(TB_thanhtien.Text), nv.ID);
                        DataHoaDonDAL.Instance.addHoaDon(hoadon);
                        foreach (string i in TB_IDban.Text.Split(','))
                        {
                            DataHoaDon_BanDAL.Instance.addHoaDon_Ban(new HoaDon_Ban(hoadon.ID_HoaDon, i));
                            DataBanAnDAL.Instance.updateBanAn(new BanAn(i.Trim().ToUpper(), false));
                        }
                    }
                    catch (Exception ex) { MessageBox.Show("Thanh toán không thành công!\n" + ex.Message); }
                    try
                    {
                        foreach (DataGridViewRow i in DGV_DaChon.Rows)
                            DataThongTinHoaDonDAL.Instance.addThongTinHoaDon(new ThongTinHoaDon(TB_IDhoadon.Text.Trim().ToUpper(),
                                i.Cells[1].Value.ToString().Trim(), Convert.ToInt32(i.Cells[5].Value.ToString())));
                        MessageBox.Show("Thanh toán thành công!");
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                    refresh(false, false, false, false, true, false);

                    ///// Đơn tại quán
                    HoaDon hoaDon = DataHoaDonDAL.Instance.getHoaDonHienTaibyTable(currenttable.Split(',')[0]);
                    foreach (string j in DataHoaDon_BanDAL.Instance.data(hoaDon.ID_HoaDon))
                    {
                        if (TB_IDban.Text.Trim() == "")
                            TB_IDban.Text += j.Trim();
                        else if (TB_IDban.Text.Trim().EndsWith(","))
                            TB_IDban.Text += j.Trim();
                        else
                            TB_IDban.Text += "," + j.Trim();
                    }
                    TB_IDhoadon.Text = hoaDon.ID_HoaDon;
                    TB_Checkin.Text = hoaDon.TimeCheckin.ToString();
                    dt.Clear();
                    dt = DataThongTinHoaDonDAL.Instance.LoadMonDaChon(hoaDon.ID_HoaDon);
                    DGV_DaChon.DataSource = dt;
                    try
                    {
                        loadnumric(DGV_DaChon.SelectedRows[0].Cells["Mã món"].Value.ToString());
                    }
                    catch (Exception ex) { }
                    Panel_DoiBan.Visible = true;

                    //}
                    //catch (Exception ex) { TB_Checkin.Clear(); MessageBox.Show("ID hóa đơn đã tồn tại " + ex.Message); }
                }
                ///// Đơn mang đi
                else
                {
                    try
                    {
                        TB_Checkin.Text = DateTime.Now.ToString();
                        TB_IDhoadon.Text = DataProvider.CapIdHoaDon();
                        DataHoaDonDAL.Instance.addHoaDon(
                            new HoaDon(TB_IDhoadon.Text.Substring(0, 11).ToUpper(),Convert.ToDateTime(TB_Checkin.Text),
                            Convert.ToDateTime(TB_Checkin.Text), Convert.ToInt32(TB_Tongtien.Text),Convert.ToInt32(TB_thanhtien.Text), nv.ID));
                        foreach (DataGridViewRow i in DGV_DaChon.Rows)
                            DataThongTinHoaDonDAL.Instance.addThongTinHoaDon(new ThongTinHoaDon(TB_IDhoadon.Text.Trim().ToUpper(), 
                                i.Cells[1].Value.ToString().Trim(), Convert.ToInt32(i.Cells[5].Value.ToString())));
                        MessageBox.Show("Đã thanh toán!");
                        refresh(true, true, true, false, false, true);
                    }
                    catch (Exception ex) { MessageBox.Show("ID hóa đơn đã tồn tại"); }
                }
            }
            ////// GỌi món cho bàn cũ
            else
            {
                foreach (DataGridViewRow i in DGV_DaChon.Rows)
                    try
                    {
                        DataThongTinHoaDonDAL.Instance.updateThongTinHoaDon(
                            new ThongTinHoaDon(TB_IDhoadon.Text.Trim().ToUpper(), i.Cells[1].Value.ToString().Trim(),
                                                                                Convert.ToInt32(i.Cells[5].Value.ToString())));
                    }
                    catch (Exception ex) { MessageBox.Show("Ở " + i.Cells["Mã món"].Value.ToString().Trim() + " chưa được cập nhật!\n" + ex.Message); }

                Tinh_tong_tien();
                DataHoaDonDAL.Instance.updateHoaDon(new HoaDon(TB_IDhoadon.Text.Trim().ToUpper(), Convert.ToDateTime(TB_Checkin.Text),
                                                       Convert.ToInt32(TB_Tongtien.Text), Convert.ToInt32(TB_thanhtien.Text),nv.ID));
                MessageBox.Show("Thanh toán thành công!");
                if (TB_IDhoadon.Text.Trim().Length > 11)
                    DataThongTinHoaDonDAL.Instance.dongbohoadonchinh(TB_IDhoadon.Text.Substring(0, 11));
                {
                    HoaDon hoaDon = DataHoaDonDAL.Instance.getHoaDonHienTaibyTable(TB_IDban.Text.Split(',')[0]);
                    dt.Clear();
                    dt = DataThongTinHoaDonDAL.Instance.LoadMonDaChon(hoaDon.ID_HoaDon);
                    DGV_DaChon.DataSource = dt;
                    try
                    {
                        loadnumric(DGV_DaChon.SelectedRows[0].Cells["Mã món"].Value.ToString());
                    }
                    catch (Exception ex) { }
                    Panel_DoiBan.Visible = true;
                }
            }
        }

        private void BT_Checkout_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (string i in DataHoaDon_BanDAL.Instance.data(TB_IDhoadon.Text.Substring(0, 11)))
                    DataBanAnDAL.Instance.updateBanAn(new BanAn(i.Trim().ToUpper(), true));
                DataHoaDonDAL.Instance.checkoutHoaDon(TB_IDhoadon.Text.Substring(0, 11).ToUpper());
                DialogResult d = MessageBox.Show("Checkout thành công!.Bạn có muốn in hoá đơn không ?", "In hoá đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    string giamgia = NumericGiamGia.Value.ToString() + "%";
                    PrintInvoice p = new PrintInvoice(TB_IDhoadon.Text.Substring(0, 11), TB_nhanvien.Text, TB_IDban.Text, giamgia);
                    p.Show();
                }
                refresh(true, false, true, false, true, false);
                NumericGiamGia.Value = 0;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        public void refresh(bool textbox = true, bool dgv_mon = true, bool dgv_dachon = true, bool flp = true, bool cbb_ban = true, bool cbb_danhmuc = true)
        {
            if (textbox)
            {
                TB_IDban.Text = "";
                TB_IDhoadon.Text = "";
                TB_Checkin.Text = "";
            }
            if (dgv_mon)
            {
                DGV_Mon.DataSource = DataMonDAL.Instance.locdulieu();
                Change_HeaderText();

            }
            if (dgv_dachon)
            {
                dt.Clear();
                DGV_DaChon.DataSource = dt;
                Numric_Soluong.Value = 0;
            }
            if (flp)
            {
                //MessageBox.Show("1");
                Load_FLP_Table(DataBanAnDAL.Instance.locBanAnbyID(""));
            }
            if (cbb_ban)
            {
                cbB_ChonBan.Items.Clear();
                cbB_ChonBan.Items.Add("Tất cả");
                foreach (String i in DataBanAnDAL.Instance.statuses())
                {
                    if (i.ToUpper().Trim().Equals("True"))
                    {
                        cbB_ChonBan.Items.Add("Trống");
                    }
                    else if (i.ToUpper().Trim().Equals("FALSE"))
                        cbB_ChonBan.Items.Add("Có người");
                }
                cbB_ChonBan.Text = cbB_ChonBan.Items[0].ToString();
            }
            if (cbb_danhmuc)
            {
                TB_TimMon.Clear();
                Cbb_Danhmuc.Items.Clear();
                foreach (DataRow i in DataDanhMucDAL.Instance.data().Rows)
                {
                    Cbb_Danhmuc.Items.Add(i[1].ToString().Trim());
                }
            }
        }
        #endregion

        #region Tĩnh gộp bàn 23/4

        private void btGopban_Click(object sender, EventArgs e)
        {
            HoaDon hoaDon;
            LB_Gopban.Visible = !LB_Gopban.Visible;
            if (!LB_Gopban.Visible)
            {
                foreach (string i in TB_IDban.Text.ToString().Split(','))
                {
                    hoaDon = DataHoaDonDAL.Instance.getHoaDonHienTaibyTable(i);////// i dịch lên 1 nếu i đang trống
                    if (hoaDon != null)
                    {
                        DataHoaDon_BanDAL.Instance.deleteHoaDon_Ban_(new HoaDon_Ban(hoaDon.ID_HoaDon, i));
                        foreach (string j in TB_IDban.Text.ToString().Split(','))
                        {
                            if (j.Trim() != "" && j != i) ////// Nếu là bàn "" hoặc trùng i thì j dịch lên 1
                            {
                                if (!DataBanAnDAL.Instance.getBanAnbyID(j.Trim()).Status) /////Kiểm tra bàn j đang trống hay không
                                {
                                    if (DataHoaDonDAL.Instance.getHoaDonHienTaibyTable(j) != null)
                                    {
                                        String hoadon_truoc = DataHoaDonDAL.Instance.getHoaDonHienTaibyTable(j).ID_HoaDon.Trim();
                                        DataHoaDon_BanDAL.Instance.updateHoaDon_Ban(new HoaDon_Ban(hoaDon.ID_HoaDon, j));
                                        DataThongTinHoaDonDAL.Instance.gophoadon(hoadon_truoc, hoaDon.ID_HoaDon);                ////Gộp 2 hóa đơn lại
                                        DataHoaDonDAL.Instance.deleteHoaDon(hoadon_truoc);///// cập nhật lại hóa đơn cho mấy bàn đã gộp
                                    }
                                    else
                                    {
                                        DataHoaDon_BanDAL.Instance.addHoaDon_Ban(new HoaDon_Ban(hoaDon.ID_HoaDon, j));
                                    }
                                }
                                else
                                    try
                                    {
                                        DataHoaDon_BanDAL.Instance.addHoaDon_Ban(new HoaDon_Ban(hoaDon.ID_HoaDon, j));         //////////// thêm bàn vào hóa đơn
                                        DataBanAnDAL.Instance.updateBanAn(new BanAn(j.Trim().ToUpper(), false)); /////////// chỉnh lại trạng thái bàn
                                    }
                                    catch (Exception ex) { }
                            }
                        }
                        ///
                        ///Hiển thị lại dữ liệu thôi
                        ///
                        TB_IDban.Clear();
                        foreach (String j in DataHoaDon_BanDAL.Instance.data(hoaDon.ID_HoaDon))
                        {
                            if (TB_IDban.Text.Trim() == "")
                                TB_IDban.Text += j.Trim();
                            else if (TB_IDban.Text.Trim().EndsWith(","))
                                TB_IDban.Text += j.Trim();
                            else
                                TB_IDban.Text += "," + j.Trim();
                        }
                        dt.Clear();
                        currenttable = TB_IDban.Text;
                        dt = DataThongTinHoaDonDAL.Instance.LoadMonDaChon(hoaDon.ID_HoaDon);
                        DGV_DaChon.DataSource = dt;
                        try
                        {
                            loadnumric(DGV_DaChon.SelectedRows[0].Cells["Mã món"].Value.ToString());
                        }
                        catch (Exception ex) { }
                        Panel_DoiBan.Visible = true;
                        refresh(false, false, false, true, true, false);
                        TB_IDban.Text = currenttable;
                        TB_IDhoadon.Text = hoaDon.ID_HoaDon;
                        TB_Checkin.Text = hoaDon.TimeCheckin.ToString();
                        Tinh_tong_tien();
                        return;
                    }
                    else
                    {
                        currenttable = TB_IDban.Text;
                    }
                }
            }
        }
        #endregion

        #region Long Chuyển bàn & Show Combobox chọn bàn 25/4
        private void Add_CbbChonBan()      //Add Bàn vào Combobox CBB_Ban
        {
            foreach (DataRow i in DataBanAnDAL.Instance.data().Rows)
            {
                cbbChonBan.Items.Add(i[0].ToString().Trim());
            }
        }

        private void btChuyenBan_Click(object sender, EventArgs e)
        {
            String tab = suppercurrenttble;
            String tab1 = cbbChonBan.Text; //.SelectedItem.ToString();
            if (tab == "" || tab1 == "")
            {
                MessageBox.Show("Bạn cần chọn bàn !!!");
                LB_BanCanChuyen.Visible = true;
                LB_BanChuyenDen.Visible = true;
                LB_banNow.Visible = true;
            }
            else
            {
                if (DataBanAnDAL.Instance.locBanAnbyID(tab)[0].Status && DataBanAnDAL.Instance.locBanAnbyID(tab1)[0].Status) { }
                else
                {
                    if (DataBanAnDAL.Instance.locBanAnbyID(tab)[0].Status)///// tab1 có người, tab trống
                    {
                        DataHoaDonDAL.Instance.Doi_IDBan_ChoNhau(tab1, tab, 1);
                        ///// tab có người, tab1 trống
                        DataBanAnDAL.Instance.updateBanAn(new BanAn(tab, false));
                        DataBanAnDAL.Instance.updateBanAn(new BanAn(tab1, true));
                    }
                    else if (DataBanAnDAL.Instance.locBanAnbyID(tab1)[0].Status) ///// tab có người, tab1 trống
                    {
                        DataHoaDonDAL.Instance.Doi_IDBan_ChoNhau(tab, tab1, 1);
                        ///// tab1 có người, tab trống
                        DataBanAnDAL.Instance.updateBanAn(new BanAn(tab1, false));
                        DataBanAnDAL.Instance.updateBanAn(new BanAn(tab, true));
                    }
                    else if (!DataBanAnDAL.Instance.locBanAnbyID(tab)[0].Status && !DataBanAnDAL.Instance.locBanAnbyID(tab1)[0].Status)
                    {
                        DataHoaDonDAL.Instance.Doi_IDBan_ChoNhau(tab, tab1, 2);
                    }
                    dt.Clear();
                    refresh(true, false, false, false, true, false);
                }

            }
            LB_BanCanChuyen.Visible = false;
            LB_BanChuyenDen.Visible = false;
            LB_banNow.Visible = false;
            suppercurrenttble = "";
        }

        #endregion
        #region giảm giá
        private void TB_Tongtien_TextChanged(object sender, EventArgs e)
        {
            if (TB_Tongtien.Text == "")
            {
                TB_Tongtien.Text = "0";
                NumericGiamGia.Value = 0;
                TB_thanhtien.Text = "0";
            }
            try
            {
                int a = Convert.ToInt32(TB_Tongtien.Text);
                TB_Tongtien.Text = a.ToString();
                int b = Convert.ToInt32(NumericGiamGia.Value);
                TB_thanhtien.Text = (Convert.ToInt32(TB_Tongtien.Text) - (Convert.ToInt32(TB_Tongtien.Text) * b / 100)).ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void NumericGiamGia_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                int a = Convert.ToInt32(NumericGiamGia.Value);
                //NumericGiamGia.Value = a;
                TB_thanhtien.Text = (Convert.ToInt32(TB_Tongtien.Text) - (Convert.ToInt32(TB_Tongtien.Text) * a / 100)).ToString();
            }
            catch (Exception ex)
            {
            }
        }


        #endregion
    }
}

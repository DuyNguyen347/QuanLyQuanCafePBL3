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
        }

        private void Seller_Load(object sender, EventArgs e)
        {
            refresh(false, true, false, true, true, true);
            TB_nhanvien.Text = nv?.ID?.Trim() + " ( " + nv?.Name?.Trim() + " )";
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
                load_FLP_Table(DataTableDAL.locdulieu("", "True"));
            else if (cbB_ChonBan.SelectedItem.ToString() == "Có người")
                load_FLP_Table(DataTableDAL.locdulieu("", "False"));
            current_cbb = cbB_ChonBan.Text.Trim();
        }
        public void load_FLP_Table(List<Table> tables)
        {
            FLP_table.Controls.Clear();
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
                FLP_table.Controls.Add(button);
            }
        }


        string currenttable = "";
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
                foreach (Table i in DataTableDAL.locdulieu())
                    if (i.Id.Trim() == str.Trim())
                    {
                        if (i.Status)
                        {
                            TB_IDban.Text = i.Id.Trim();
                            if (currenttable.Trim() == "" || TB_IDban.Text == currenttable) ;
                            else
                            {
                                refresh(true, false, true, false, false, false);
                                TB_IDban.Text = i.Id.Trim();
                            }
                            Panel_DoiBan.Visible = false;
                        }
                        else
                        {
                            HoaDon hoaDon = DataBillDAL.locdulieu("", i.Id)[0];
                            foreach (HoaDon j in DataBillDAL.locdulieu(hoaDon.ID))
                            {
                                if (TB_IDban.Text.Trim() == "")
                                    TB_IDban.Text += j.ID_ban.Trim();
                                else if (TB_IDban.Text.Trim().EndsWith(","))
                                    TB_IDban.Text += j.ID_ban.Trim();
                                else
                                    TB_IDban.Text += "," + j.ID_ban.Trim();
                            }
                            TB_IDhoadon.Text = hoaDon.ID;
                            TB_Checkin.Text = hoaDon.TimeCheckin.ToString();
                            dt.Clear();
                            dt = DataInforBillDAL.LoadMonDaChon(hoaDon.ID);
                            DGV_DaChon.DataSource = dt;
                            try
                            {
                                loadnumric(DGV_DaChon.SelectedRows[0].Cells["Mã món"].Value.ToString());
                            }
                            catch (Exception ex) { }
                            Panel_DoiBan.Visible = true;
                        }
                    }

                currenttable = TB_IDban.Text;
                Tinh_tong_tien();
            }
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

            //tbGiamGia.Text = "10%";
        }

        private void Change_HeaderText()
        {
            DGV_Mon.Columns[0].HeaderText = "Mã món";
            DGV_Mon.Columns[1].HeaderText = "Tên món";
            DGV_Mon.Columns[2].HeaderText = "Danh mục";
            DGV_Mon.Columns[3].HeaderText = "Giá";
        }
        private void Tinh_tong_tien(string valueGiamGia = null)
        {
            int total_money = 0;
            foreach (DataGridViewRow dr in DGV_DaChon.Rows)
                total_money += Convert.ToInt32(dr.Cells["GIá"].Value.ToString()) * Convert.ToInt32(dr.Cells["Số lượng"].Value.ToString());

            TB_Tongtien.Text = total_money.ToString();
            if (total_money == 0)
            {
                tbThanhTien.Text = "0";
            }
            Tinh_thanh_tien(valueGiamGia);
        }

        private void Tinh_thanh_tien(string valueGiamGia = null)
        {
            if (!string.IsNullOrWhiteSpace(TB_Tongtien.Text))
            {
                double giamGia = 0;
                double tongTien = 0;
                double.TryParse(TB_Tongtien.Text, out tongTien);
                if (valueGiamGia != null)
                {
                    double.TryParse(valueGiamGia, out giamGia);
                }
                else
                {
                    double.TryParse(tbGiamGia.Text, out giamGia);
                }
                if (tongTien > 0)
                {
                    var total = giamGia == 0 ? tongTien : (tongTien - tongTien * giamGia / 100);

                    tbThanhTien.Text = total.ToString();
                }

            }

        }
        #endregion

        #region Tĩnh Món
        private void TB_TimMon_TextChanged(object sender, EventArgs e)
        {
            DGV_Mon.DataSource = DataMonDAL.locdulieu(TB_TimMon.Text.ToUpper().Trim());
            Change_HeaderText();
        }
        private void Cbb_Danhmuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            DGV_Mon.DataSource = DataMonDAL.locdulieu("", Cbb_Danhmuc.Text.ToUpper().Trim());
            Change_HeaderText();
        }

        private void BT_refreshMon_Click(object sender, EventArgs e)
        {
            refresh(false, true, false, false, false, true);
            DGV_Mon.DataSource = DataMonDAL.locdulieu();
            Change_HeaderText();
        }

        #endregion


        #region Long CellContentClick
        private void DGV_Mon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ID = DGV_Mon.CurrentRow.Cells["ID"].FormattedValue.ToString();
            string name = DGV_Mon.CurrentRow.Cells["Name"].FormattedValue.ToString();
            string DM = DGV_Mon.CurrentRow.Cells["DanhMuc"].FormattedValue.ToString();
            string gia = DGV_Mon.CurrentRow.Cells["Gia"].FormattedValue.ToString();
            int dem = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString() == ID)
                {
                    dem++;
                    dt.Rows[i][4] = Convert.ToInt32(dt.Rows[i][4].ToString()) + 1;
                    break;
                }
            }
            if (dem == 0) dt.Rows.Add(ID, name, DM, gia, 1);
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
            nv.Luong = s.Luong;
            nv.Username = s.Username;
            nv.PassWord = s.PassWord;
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
            if (DataTableDAL.locdulieu(TB_IDban.Text.Split(',')[0].ToUpper())[0].Status)
            {
                if (TB_IDban.Text.Trim() != "")
                {
                    try
                    {
                        TB_Checkin.Text = DateTime.Now.ToString();
                        TB_IDhoadon.Text = DataBillDAL.CapIdHoaDon();
                        foreach (string i in TB_IDban.Text.Split(','))
                            try
                            {
                                DataBillDAL.capnhatHoaDon(new HoaDon(TB_IDhoadon.Text.Trim().ToUpper(), Convert.ToDateTime(TB_Checkin.Text), i.Trim()), 1);
                                DataTableDAL.capnhatBan(new Table(i.Trim().ToUpper(), false), 3);
                            }
                            catch (Exception ex) { }
                        foreach (DataGridViewRow i in DGV_DaChon.Rows)
                            DataInforBillDAL.capnhatInforHoaDon(new InforBill(TB_IDhoadon.Text.Trim().ToUpper(), i.Cells[1].Value.ToString().Trim(), Convert.ToInt32(i.Cells[5].Value.ToString())), 1);
                        MessageBox.Show("Thanh toán thành công!");
                        refresh(false, false, false, false, true, false);
                        {
                            ///// Đơn tại quán
                            HoaDon hoaDon = DataBillDAL.locdulieu("", currenttable.Split(',')[0])[0];
                            foreach (HoaDon j in DataBillDAL.locdulieu(hoaDon.ID))
                            {
                                if (TB_IDban.Text.Trim() == "")
                                    TB_IDban.Text += j.ID_ban.Trim();
                                else if (TB_IDban.Text.Trim().EndsWith(","))
                                    TB_IDban.Text += j.ID_ban.Trim();
                                else
                                    TB_IDban.Text += "," + j.ID_ban.Trim();
                            }
                            TB_IDhoadon.Text = hoaDon.ID;
                            TB_Checkin.Text = hoaDon.TimeCheckin.ToString();
                            dt.Clear();
                            dt = DataInforBillDAL.LoadMonDaChon(hoaDon.ID);
                            DGV_DaChon.DataSource = dt;
                            try
                            {
                                loadnumric(DGV_DaChon.SelectedRows[0].Cells["Mã món"].Value.ToString());
                            }
                            catch (Exception ex) { }
                            Panel_DoiBan.Visible = true;
                        }
                    }
                    catch (Exception ex) { TB_Checkin.Clear(); MessageBox.Show("ID hóa đơn đã tồn tại " + ex.Message); }
                }
                ///// Đơn mang đi
                else
                {
                    try
                    {
                        TB_Checkin.Text = DateTime.Now.ToString();
                        TB_IDhoadon.Text = DataBillDAL.CapIdHoaDon();
                        DataBillDAL.capnhatHoaDon(new HoaDon(TB_IDhoadon.Text.Trim().ToUpper(), Convert.ToDateTime(TB_Checkin.Text), TB_IDban.Text.Trim(), Convert.ToDateTime(TB_Checkin.Text)), 1);
                        foreach (DataGridViewRow i in DGV_DaChon.Rows)
                            DataInforBillDAL.capnhatInforHoaDon(new InforBill(TB_IDhoadon.Text.Trim().ToUpper(), i.Cells[1].Value.ToString().Trim(), Convert.ToInt32(i.Cells[5].Value.ToString())), 1);
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
                        DataInforBillDAL.capnhatInforHoaDon(new InforBill(TB_IDhoadon.Text.Trim().ToUpper(), i.Cells[1].Value.ToString().Trim(), Convert.ToInt32(i.Cells[5].Value.ToString())), 3);
                    }
                    catch (Exception ex) { MessageBox.Show("Ở " + i.Cells["Mã món"].Value.ToString().Trim() + " chưa được cập nhật!"); }
                MessageBox.Show("Thanh toán thành công!");
                {
                    HoaDon hoaDon = DataBillDAL.locdulieu("", TB_IDban.Text.Split(',')[0])[0];
                    dt.Clear();
                    dt = DataInforBillDAL.LoadMonDaChon(hoaDon.ID);
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
                foreach (HoaDon i in DataBillDAL.locdulieu(TB_IDhoadon.Text.Trim(), ""))
                    DataTableDAL.capnhatBan(new Table(i.ID_ban.Trim().ToUpper(), true), 3);
                DataBillDAL.capnhatHoaDon(new HoaDon(TB_IDhoadon.Text.Trim().ToUpper(), Convert.ToDateTime(TB_Checkin.Text), TB_IDban.Text.Trim(), DateTime.Now), 3);
                MessageBox.Show("Checkout thành công!");
                refresh(true, false, true, false, true, false);
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
                DGV_Mon.DataSource = DataMonDAL.locdulieu();
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
                load_FLP_Table(DataTableDAL.locdulieu());
            }
            if (cbb_ban)
            {
                cbB_ChonBan.Items.Clear();
                cbB_ChonBan.Items.Add("Tất cả");
                foreach (Table i in DataTableDAL.locdulieu())
                {
                    if (i.Status)
                    {
                        if (!cbB_ChonBan.Items.Contains("Trống"))
                            cbB_ChonBan.Items.Add("Trống");
                    }
                    else
                        if (!cbB_ChonBan.Items.Contains("Có người"))
                        cbB_ChonBan.Items.Add("Có người");
                }
                cbB_ChonBan.Text = cbB_ChonBan.Items[0].ToString();
            }
            if (cbb_danhmuc)
            {
                TB_TimMon.Clear();
                Cbb_Danhmuc.Items.Clear();
                foreach (DataRow i in DataDanhMucDAL.data().Rows)
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
                    try
                    {
                        hoaDon = DataBillDAL.locdulieu("", i)[0];
                        foreach (string j in TB_IDban.Text.ToString().Split(','))
                            if (j.Trim() != "" && j != i)
                            {
                                if (!DataTableDAL.locdulieu(j.Trim())[0].Status)
                                {
                                    DataBillDAL.capnhatHoaDon(new HoaDon(DataBillDAL.locdulieu("", j)[0].ID.Trim().ToUpper(), DataBillDAL.locdulieu("", j)[0].TimeCheckin, j.Trim().ToUpper(), DateTime.Now), 3);
                                }
                                try
                                {
                                    DataBillDAL.capnhatHoaDon(new HoaDon(hoaDon.ID.Trim().ToUpper(), hoaDon.TimeCheckin, j.Trim()), 1);
                                    DataTableDAL.capnhatBan(new Table(j.Trim().ToUpper(), false), 3);
                                }
                                catch (Exception ex) { }
                            }
                        TB_IDban.Clear();
                        foreach (HoaDon j in DataBillDAL.locdulieu(hoaDon.ID))
                        {
                            if (TB_IDban.Text.Trim() == "")
                                TB_IDban.Text += j.ID_ban.Trim();
                            else if (TB_IDban.Text.Trim().EndsWith(","))
                                TB_IDban.Text += j.ID_ban.Trim();
                            else
                                TB_IDban.Text += "," + j.ID_ban.Trim();
                        }
                        dt.Clear();
                        currenttable = TB_IDban.Text;
                        dt = DataInforBillDAL.LoadMonDaChon(hoaDon.ID);
                        DGV_DaChon.DataSource = dt;
                        try
                        {
                            loadnumric(DGV_DaChon.SelectedRows[0].Cells["Mã món"].Value.ToString());
                        }
                        catch (Exception ex) { }
                        Panel_DoiBan.Visible = true;
                        refresh(false, false, false, true, true, false);
                        TB_IDban.Text = currenttable;
                        TB_IDhoadon.Text = hoaDon.ID;
                        TB_Checkin.Text = hoaDon.TimeCheckin.ToString();
                        Tinh_tong_tien();
                        return;
                    }
                    catch (Exception exx) { currenttable = TB_IDban.Text; }
            }
        }
        #endregion

        #region Long Chuyển bàn & Show Combobox chọn bàn 25/4
        private void Add_CbbChonBan()      //Add Bàn vào Combobox CBB_Ban
        {
            foreach (DataRow i in DataTableDAL.data().Rows)
            {
                cbbChonBan.Items.Add(i[0].ToString().Trim());
            }
        }

        HoaDon hd, hd1;
        bool stat;
        String id_ban;

        private void tbGiamGia_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tbGiamGia_ValueChanged_1(object sender, EventArgs e)
        {
            Tinh_tong_tien(tbGiamGia.Value.ToString());
        }

        private void btChuyenBan_Click(object sender, EventArgs e)
        {
            String tab = TB_IDban.Text;
            String tab1 = cbbChonBan.SelectedItem.ToString();
            foreach (Table i in DataTableDAL.locdulieu())
            {
                if (i.Id.Trim() == tab)
                {
                    hd = DataBillDAL.locdulieu("", i.Id)[0];
                    tab = hd.ID;
                }
                if (i.Id.Trim() == tab1)
                {
                    if (i.Status)
                    {
                        stat = true;
                        id_ban = i.Id;
                    }
                    else
                    {
                        stat = false;
                        hd1 = DataBillDAL.locdulieu("", i.Id)[0];
                        tab1 = hd1.ID;
                    }
                }
            }

            if (stat == false)
            {
                DataBillDAL.capnhatHoaDon(hd, 4, tab1);
                DataBillDAL.capnhatHoaDon(hd1, 4, tab);
                dt = DataInforBillDAL.LoadMonDaChon(hd1.ID);
                DGV_DaChon.DataSource = dt;
                TB_IDban.Text = hd.ID_ban;
                TB_IDhoadon.Text = hd1.ID;
                TB_Checkin.Text = hd1.TimeCheckin.ToString();
                MessageBox.Show("Đã chuyển thành công giữa bàn " + hd.ID_ban + " và " + hd1.ID_ban);
            }
            else
            {
                String id_bancu = hd.ID_ban;
                DataTableDAL.capnhatBan(new Table(id_ban.Trim().ToUpper(), false), 3);
                DataBillDAL.Doi_IDBan_theoHoaDon(id_ban, hd.ID);
                DataTableDAL.capnhatBan(new Table(id_bancu.Trim().ToUpper(), true), 3);
                dt = DataInforBillDAL.LoadMonDaChon(hd.ID);
                refresh(false, false, false, false, true, false);
                TB_IDban.Text = id_ban;
                TB_IDhoadon.Text = hd.ID;
                TB_Checkin.Text = hd.TimeCheckin.ToString();
                MessageBox.Show("Đã chuyển thành công từ bàn " + id_bancu + " sang bàn " + id_ban);
            }

        }

        #endregion     

    }
}

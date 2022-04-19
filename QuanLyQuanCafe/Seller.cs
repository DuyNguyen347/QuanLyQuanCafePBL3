﻿using System.Data.SqlClient;
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
          
        }

        private void Seller_Load(object sender, EventArgs e)
        {
            DGV_Mon_Load();
            load_cbBchonBan();
            CB_Timdanhmuc_Load();
            load_FLP_Table(DataTableDAL.locdulieu());
            TB_nhanvien.Text = nv.ID + " ( " + nv.Name + " )";
        }
        #region Tĩnh bàn
        private void cbB_ChonBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbB_ChonBan.SelectedItem.ToString() == "Tất cả")
            {
                load_FLP_Table(DataTableDAL.locdulieu());
                TB_IDban.Clear();
                TB_Checkin.Clear();
                TB_IDhoadon.Clear();
                TB_nhanvien.Clear();
                currenttable = "";
            }
            else if(cbB_ChonBan.SelectedItem.ToString() == "Trống")
                load_FLP_Table(DataTableDAL.locdulieu("","True"));
            else if (cbB_ChonBan.SelectedItem.ToString() == "Có người")
                load_FLP_Table(DataTableDAL.locdulieu("", "False"));
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
            string str = ((Button)sender).Text.ToString().Split('\n')[0];
            foreach (Table i in DataTableDAL.locdulieu())
                if (i.Id == str)
                {
                    if (i.Status)
                    {
                        TB_IDban.Text = i.Id;
                        if (currenttable.Trim() =="" || TB_IDban.Text == currenttable) ;
                        else
                        {
                            dt.Clear();
                            DGV_DaChon.DataSource = dt;
                        }
                    }
                    else
                    {
                        DataBillDAL.locdulieu("", i.Id);
                    }    
                }
            
            currenttable = TB_IDban.Text;
            Tinh_tong_tien();
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
            foreach (DataRow dr in dt.Rows)
                total_money += Convert.ToInt32(dr["GIá"].ToString()) * Convert.ToInt32(dr["Số lượng"].ToString());
            TB_Tongtien.Text = total_money.ToString();
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
            DGV_Mon.DataSource = DataMonDAL.locdulieu();
            Change_HeaderText();
            load_cbBchonBan();
            TB_TimMon.Text = "";
        }
        
        private void DGV_Mon_Load()
        {
            List<Mon> mon_an = new List<Mon>();
            foreach (DataRow d in DataMonDAL.data().Rows)
            {
                mon_an.Add(new Mon(d));
            }
            DGV_Mon.DataSource=mon_an;
        }
        #endregion

        #region Tĩnh Load Combobox
        private void CB_Timdanhmuc_Load()
        {
            foreach (DataRow i in DataDanhMucDAL.data().Rows)
            {
                Cbb_Danhmuc.Items.Add(i[1].ToString().Trim());                
            }
        }
        void load_cbBchonBan()
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

        #endregion
        
        #region Long CellContentClick
        private void DGV_Mon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {            
            string ID = DGV_Mon.Rows[e.RowIndex].Cells["ID"].FormattedValue.ToString();
            string name = DGV_Mon.Rows[e.RowIndex].Cells["Name"].FormattedValue.ToString();
            string DM = DGV_Mon.Rows[e.RowIndex].Cells["DanhMuc"].FormattedValue.ToString();
            string gia = DGV_Mon.Rows[e.RowIndex].Cells["Gia"].FormattedValue.ToString();
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
                if (DGV_DaChon.Rows[i].Cells[1].Value == DGV_Mon.CurrentRow.Cells[0].Value)
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
            //quit();
        }


        #endregion

        private void BT_ThanhToan_Click(object sender, EventArgs e)
        {
            TB_Checkin.Text = DateTime.Now.ToString();
            DataBillDAL.capnhatHoaDon(new HoaDon(TB_IDhoadon.Text.Trim().ToUpper(), Convert.ToDateTime(TB_Checkin.Text), TB_IDban.Text.Trim()), 1);
            foreach (DataGridViewRow i in DGV_DaChon.Rows)
                DataInforBillDAL.capnhatInforHoaDon(new InforBill(TB_IDhoadon.Text.Trim().ToUpper(), i.Cells[1].Value.ToString().Trim(),Convert.ToInt32(i.Cells[5].Value.ToString())),1);
            MessageBox.Show("Checkin thành công!");
            if (TB_IDban.Text.Trim() != "")
                DataTableDAL.capnhatBan(new Table(TB_IDban.Text.Trim().ToUpper(), false),3);
            load_FLP_Table(DataTableDAL.locdulieu());

        }
    }
}

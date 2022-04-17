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

namespace QuanLyQuanCafe
{
    public partial class Seller : Form
    {
        public Quit login_Show;
        public Quit quit;
        DataTable dt;        
        int n = 0;
        NhanVien nv = new NhanVien();

        int sl_Table = 0;
        String[] ID_tab;
        DataTable[] d_tab;
        int vt_tab = 0;

        public Seller()
        {
            InitializeComponent();

            dt = new DataTable();
            Add_Column();
            
            btAccount.Text = nv.Name;
            Find_SL_Tables(DataTableDAL.locdulieu());
            ID_tab = new String[sl_Table];
            d_tab = new DataTable[sl_Table];
            Add_DataTable_Tables();
            Add_Id_Tables(DataTableDAL.locdulieu());
        }

        private void Add_DataTable_Tables()
        {            
            for (int i = 0; i < sl_Table; i++)
            {
                d_tab[i] = new DataTable();
                d_tab[i].Columns.AddRange(new DataColumn[]
                {
                new DataColumn {ColumnName = "Mã món", DataType = typeof(string)},
                new DataColumn {ColumnName = "Tên món", DataType = typeof(string)},
                new DataColumn {ColumnName = "Danh mục", DataType = typeof(string )},
                new DataColumn {ColumnName = "Giá", DataType = typeof(string) },
                new DataColumn {ColumnName = "Số lượng", DataType = typeof(int)},
                });
            }            
        }
        private void Find_SL_Tables(List <Table> tables)
        {
            foreach (Table i in tables)
            {
                sl_Table++;               
            }                        
        }

        private void Add_Id_Tables(List <Table> tables) 
        {
            int n = 0;
            foreach (Table i in tables)
            {
                ID_tab[n] = i.Id;
                n++;
            }
        }
        
        private void Seller_Load(object sender, EventArgs e)
        {
            DGV_Mon_Load();
            load_cbBchonBan();
            CB_Timdanhmuc_Load();
            load_FLP_Table(DataTableDAL.locdulieu());
        }
        #region Tĩnh bàn
        private void cbB_ChonBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbB_ChonBan.SelectedItem.ToString() == "Tất cả")
            {
                load_FLP_Table(DataTableDAL.locdulieu());
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
                        TB_Checkin.Text = DateTime.Now.ToString();
                        TB_nhanvien.Text = nv.ID;
                    }
                    else
                    {
                        //// LoadDatabill chưa làm
                    }    
                }
            /*if (currenttable != "" && currenttable != TB_IDban.Text)
            {
                dt.Clear();
                DGV_DaChon.DataSource = dt;
            }*/
            currenttable = TB_IDban.Text;

            Search_vt_table(TB_IDban.Text);            
            DGV_DaChon.DataSource = d_tab[vt_tab];
            Tinh_tong_tien();
        }

        private void Search_vt_table(String ID)
        {
            for (int i=0; i<sl_Table; i++)            
                if (ID_tab[i] == ID)
                    vt_tab = i;               
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
            DGV_DaChon.DataSource = dt;
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
            dt = d_tab[vt_tab];
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
            dt = d_tab[vt_tab];            
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
            d_tab[vt_tab] = dt;

            for (int i = 0; i < DGV_DaChon.Rows.Count; i++)
            {
                if (DGV_DaChon.Rows[i].Cells[0].Value == DGV_Mon.CurrentRow.Cells[0].Value)
                    DGV_DaChon.Rows[i].Selected = true;
                else
                    DGV_DaChon.Rows[i].Selected = false;
            }
            loadnumric(DGV_DaChon.SelectedRows[0].Cells[0].Value.ToString());
            Tinh_tong_tien();                        
        }
        private void DGV_DaChon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            loadnumric(DGV_DaChon.SelectedRows[0].Cells[0].Value.ToString());
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
                    DGV_DaChon.SelectedRows[0].Cells[4].Value = Numric_Soluong.Value;
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

        private void FLP_table_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

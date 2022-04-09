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
        public Login_show login_Show;
        List<Table> tables = new List<Table>();
        DataTable dt;
        int n = 0;
        int[] count;
        string[] food;

        public Seller()
        {
            InitializeComponent();

            dt = new DataTable();
            Add_Column();

            count = new int[100];
            food = new string[100];
            Set_Count();
        }
        
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

        private void Set_Count()
        {
            foreach (DataRow d in DataMonDAL.data().Rows)
            {
                ++n;
                food[n] = d[1].ToString();
                count[n] = 0;
            }
        }

        private void Seller_Load(object sender, EventArgs e)
        {
            tables.Add(new Table("1", true));
            tables.Add(new Table("2", true));
            tables.Add(new Table("3", true));
            tables.Add(new Table("4", true));
            load_cbBchonBan();
            CB_Timdanhmuc_Load();
        }

        private void cbB_ChonBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbB_ChonBan.SelectedItem.ToString()== "Tất cả")
            {
                
                ChonBanForm chonBanForm = new ChonBanForm();
                chonBanForm.add_table(tables);
                chonBanForm.chonban = new Chonban(select_tables);
                chonBanForm.ShowDialog();
            }    

        }

        private void BT_Huy_Click(object sender, EventArgs e)
        {

        }

        private void BT_Ok_Click(object sender, EventArgs e)
        {

        }

        private void BT_Sửa_Click(object sender, EventArgs e)
        {

        }

        private void BT_refreshMon_Click(object sender, EventArgs e)
        {

        }

        private void Change_HeaderText()
        {
            DGV_Mon.Columns[0].HeaderText = "Mã món";
            DGV_Mon.Columns[1].HeaderText = "Tên món";
            DGV_Mon.Columns[2].HeaderText = "Danh mục";
            DGV_Mon.Columns[3].HeaderText = "Giá";
        }

        private void TB_TimMon_TextChanged(object sender, EventArgs e)
        {
            List<Mon> mon_an = new List<Mon>();
            
            foreach (DataRow d in DataMonDAL.data().Rows)
                if (d[1].ToString().ToUpper().Contains(TB_TimMon.Text.ToUpper()))
                {
                    mon_an.Add(new Mon(d));
                }

            DGV_Mon.DataSource = mon_an;
            Change_HeaderText();
        }

        private void CB_Timdanhmuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Mon> mon_an = new List<Mon>();
            foreach (DataRow i in DataMonDAL.data().Rows)
                if ((i[2].ToString().ToUpper().Trim() == CB_Timdanhmuc.Text.ToUpper()))
                    mon_an.Add(new Mon(i));

            DGV_Mon.DataSource = mon_an;
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

        private void CB_Timdanhmuc_Load()
        {
            foreach (DataRow i in DataDanhMucDAL.data().Rows)
            {
                CB_Timdanhmuc.Items.Add(i[1].ToString().Trim());                
            }
        }              

        private void DGV_Mon_CellClick(object sender, DataGridViewCellEventArgs e)
        {            
        }
        
        private void Tinh_tong_tien()
        {
            int total_money = 0;
            foreach (DataRow dr in dt.Rows)
                total_money += Convert.ToInt32(dr["GIá"].ToString())* Convert.ToInt32(dr["Số lượng"].ToString());
            TB_Tongtien.Text = total_money.ToString();
        }
        private void DGV_Mon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {           
            if (DGV_Mon.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)                
            {
                DGV_Mon.CurrentRow.Selected = true;
                string ID = DGV_Mon.Rows[e.RowIndex].Cells["ID"].FormattedValue.ToString();
                string name = DGV_Mon.Rows[e.RowIndex].Cells["Name"].FormattedValue.ToString();
                string DM = DGV_Mon.Rows[e.RowIndex].Cells["DanhMuc"].FormattedValue.ToString();
                string gia = DGV_Mon.Rows[e.RowIndex].Cells["Gia"].FormattedValue.ToString();
                
                for (int i=0; i<=n; i++)
                {
                    if (name == food[i])
                    {
                        ++count[i];
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (dr["Tên món"] == name)
                            {
                                dt.Rows.Remove(dr);
                                break;                                
                            }
                        }
                        dt.Rows.Add(ID, name, DM, gia, count[i]);                        
                        break;
                    }
                }
                    
                    

                //dt.Rows.Add(ID, name, DM, gia, count[n]);                
            }
            DGV_DaChon.DataSource = dt;
            Tinh_tong_tien();
        }
        void load_cbBchonBan()
        {
            cbB_ChonBan.Items.Clear();
            cbB_ChonBan.Items.Add("Tất cả");
            foreach (Table i in tables)
                if(i.Status)
                    cbB_ChonBan.Items.Add(i.Id);
        }
        void select_tables(string str)
        {
            cbB_ChonBan.Text = str;
            load_cbBchonBan();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            login_Show();
            this.Close();
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {
            DGV_Mon_Load();
            /*DGV_Mon.Columns[0].HeaderText = "Mã món";
            DGV_Mon.Columns[1].HeaderText = "Tên món";
            DGV_Mon.Columns[2].HeaderText = "Danh mục";
            DGV_Mon.Columns[3].HeaderText = "Giá";*/
        }

        private void cbB_ChonBan_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void DGV_DaChon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV_DaChon.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                DGV_DaChon.CurrentRow.Selected = true;
                int so_luong = Convert.ToInt32(DGV_DaChon.Rows[e.RowIndex].Cells["Số lượng"].FormattedValue.ToString());
                guna2NumericUpDown1.Value = so_luong;                                                        
            }
        }       
    }
}

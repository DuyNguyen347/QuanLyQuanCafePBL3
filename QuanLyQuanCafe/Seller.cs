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
        public Seller()
        {
            InitializeComponent();
            
        }

        private void Seller_Load(object sender, EventArgs e)
        {
            tables.Add(new Table("1", true));
            tables.Add(new Table("2", true));
            tables.Add(new Table("3", true));
            tables.Add(new Table("4", true));
            load_cbBchonBan();
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



        private void TB_TimMon_TextChanged(object sender, EventArgs e)
        {
            List<Mon> mon_an = new List<Mon>();
            
            foreach (DataRow d in DataMonDAL.data().Rows)
                if (d[1].ToString().ToUpper().Contains(TB_TimMon.Text.ToUpper()))
                {
                    mon_an.Add(new Mon(d));
                }
            DGV_Mon.DataSource = mon_an;

            DGV_Mon.Columns[0].HeaderText = "Mã món";
            DGV_Mon.Columns[1].HeaderText = "Tên món";
            DGV_Mon.Columns[2].HeaderText = "Danh mục";
            DGV_Mon.Columns[3].HeaderText = "Giá";



        }
        private void TB_TimDanhMuc_TextChanged(object sender, EventArgs e)
        {
            List<DanhMuc>danh_muc = new List<DanhMuc>();

            foreach (DataRow d in DataDanhMucDAL.data().Rows)
                if (d[1].ToString().ToUpper().Contains(TB_TimDanhMuc.Text.ToUpper()))
                {
                    danh_muc.Add(new DanhMuc(d));
                }
            DGV_Mon.DataSource = danh_muc;

            DGV_Mon.Columns[0].HeaderText = "Mã món";            
            DGV_Mon.Columns[1].HeaderText = "Danh mục";            
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

        private void Set_Count()
        {
            int[] count;
            /*foreach (DataRow d in DGV_Mon.Rows)
                count[i] = */
        }

        private void DGV_Mon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            List<Mon> mon_an = new List<Mon>();
            foreach (DataRow d in DataMonDAL.data().Rows)
            {
                if (d[1].ToString() == DGV_Mon.CurrentRow.Cells[1].Value.ToString())
                {
                    foreach (DataRow i in DGV_DaChon.Rows)

                }
                    mon_an.Add(new Mon(d));
                DGV_DaChon.DataSource = mon_an;
            }               
            
            // Add so luong ...
        }
        
        private void DGV_Mon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            List<Mon> mon_an = new List<Mon>();
            foreach (DataRow d in DataMonDAL.data().Rows)
            {
                mon_an.Add(new Mon(d));
            }
            DGV_Mon.DataSource = mon_an;
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
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            tables.Add(new Table("2", false));
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

        }

        private void TB_TimDanhMuc_TextChanged(object sender, EventArgs e)
        {

        }

        private void DGV_Mon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
    }
}

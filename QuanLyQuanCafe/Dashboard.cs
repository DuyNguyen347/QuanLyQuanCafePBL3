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
    public delegate void Login_show();
    public partial class Dashboard : Form
    {
        public Login_show login_show;
       
        public Dashboard()
        {
            InitializeComponent();
            DGV_NhanVien.DataSource = DataNhanVienDAL.data();
        }

        
        

        public void btLogOut_Click(object sender, EventArgs e)
        {
            login_show();
            this.Close();
        }

        private void TB_TimNhanVien_TextChanged(object sender, EventArgs e)
        {
            List<NhanVien> nhanViens = new List<NhanVien>();
            foreach (DataRow i in DataNhanVienDAL.data().Rows)
                if ((i[1].ToString().ToUpper()).Contains(TB_TimNhanVien.Text.ToUpper()))
                    nhanViens.Add(new NhanVien(i));
            DGV_NhanVien.DataSource = nhanViens;                    
        }
    }
}

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
            LoadDatabase();
        }

        
        public void LoadDatabase()
        {
            //string s = @"Data Source=DESKTOP-KMNS09Q\SQLEXPRESS;Initial Catalog=QuanLiQuanCafe;Integrated Security=True";
            //SqlConnection cnn = new SqlConnection(s);
            string query = "select *  from dbo.Account";
            //cnn.Open();
            //SqlCommand cmd = new SqlCommand(query, cnn);
            ////cmd.ExecuteScalar();
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            ////DataSet ds = new DataSet();
            //da.Fill(dt);
            ////DGV_NhanVien.DataSource = dt;
            //cnn.Close();
            //DGV_NhanVien.DataSource = dt;
            DGV_NhanVien.DataSource = DataProvider.Instance.GetRecords(query);
        }

        public void btLogOut_Click(object sender, EventArgs e)
        {
            login_show();
            this.Close();
        }
    }
}

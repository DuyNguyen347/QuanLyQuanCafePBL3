using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyQuanCafe
{
    public class ChucNang
    {
        static SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-G3DN301\SQLEXPRESS;Initial Catalog=QL_cafe2;Integrated Security=True");
        static SqlCommand command;
        static SqlDataAdapter adapter = new SqlDataAdapter();
        static DataTable datatable;
        
        public static bool checkdata(string username, string password, string chucvu)
        {
            bool check = false;
            try
            {
                string query;
                if (chucvu == "Admin")
                    query = "select * from NhanVien where UserName = '" + username + "' and PassWord = '" + password + "' and ChucVu = N'Quản lí'";//
                else
                    query = "select * from NhanVien where UserName = '" + username + "' and PassWord = '" + password + "'";
                connect.Open();
                SqlCommand command = new SqlCommand(query, connect);
                SqlDataReader data = command.ExecuteReader();
                if (data.Read() == true)
                    check = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối!");
            }
            connect.Close();

            return check;
        }       

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Security.Cryptography;

namespace QuanLyQuanCafe.DAL
{
    public class DataProvider
    {
        private static DataProvider _Instance;
        private string s;

        public static DataProvider Instance {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DataProvider();
                }
                return _Instance;
            }
            private set => _Instance = value;
        }
        public DataProvider()
        {
            // ConnectionString of Tinh 
            //s = @"Data Source = 192.168.1.100,1433; Initial Catalog = QL_cafe; User ID = NQT; Password = 68709502";
            // ConnectionString of Duy
            //s = ConfigurationManager.ConnectionStrings["QuanLyQuanCafeConnectionString"].ConnectionString;
            //s = @"Data Source=DESKTOP-KMNS09Q\SQLEXPRESS;Initial Catalog=QL_cafe;Integrated Security=True";
            //connect to tĩnh network
            // Đà Nẵng
            //s = @"Data Source = 116.105.164.50,1433; Initial Catalog = QL_cafe; User ID = NQT; Password = 68709502";
            //s = @"Data Source = 14.165.149.140,1433; Initial Catalog = QL_cafe; User ID = NQT; Password = 68709502";
            s = @"Data Source=DESKTOP-KMNS09Q\SQLEXPRESS;Initial Catalog=QL_cafe;Integrated Security=True";
        }
        public bool executeDB(string query, object[] parameter = null)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(s))
                {
                    SqlCommand cmd = new SqlCommand(query, cnn);
                    cnn.Open();
                    if (parameter != null)
                    {
                        string[] list = query.Split(' ');
                        int i = 0;
                        foreach (string item in list)
                        {
                            if (item.Contains('@'))
                            {
                                cmd.Parameters.AddWithValue(item, parameter[i]);
                                i++;
                            }
                        }
                    }
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                    return true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi!");
                return false;
            }
        }
        public bool Execute(string query, byte[] byteData = null)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(s))
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand(query, cnn);
                    if (byteData != null) cmd.Parameters.Add("@data", SqlDbType.VarBinary, byteData.Length).Value = byteData;
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public DataTable GetRecords(string query, object[] parameter = null)
        {
            //try
            //{
            DataTable dt = new DataTable();
            using (SqlConnection cnn = new SqlConnection(s))
            {
                SqlCommand cmd = new SqlCommand(query, cnn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cnn.Open();
                if (parameter != null)
                {
                    string[] list = query.Split(' ');
                    int i = 0;
                    foreach (string item in list)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                da.Fill(dt);
                cnn.Close();
                return dt;
            }
        }
        //catch (Exception e)
        //{
        //    MessageBox.Show("Lỗi");
        //    return null;
        //}
 
        public void setdata(string query, object[] parameter = null)
        {
            //try
            //{
                using (SqlConnection cnn = new SqlConnection(s))
                {
                    SqlCommand cmd = new SqlCommand(query, cnn);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Lỗi!");
            //    return null;
            //}
        }
        public string getConnectionString()
        {
            return s;
        }
        public SqlConnection GetConnection()
        {
            return new SqlConnection(s);
        }
        public static string FormatDatetimetoSQL(DateTime dateTime)
        {
            string s = "";
            s += dateTime.Day.ToString() + "-" + dateTime.Month.ToString() + "-" + (dateTime.Year % 100).ToString() + " " +
               dateTime.Hour.ToString() + ":" + dateTime.Minute.ToString() + ":" + dateTime.Second.ToString();
            return "convert(datetime, '" + s + "', 5)";
        }
        public static string FormatDatetimeShort(DateTime dateTime)
        {
            string s = "";
            s = dateTime.Year + "/" + dateTime.Month + "/" + dateTime.Day;
            return s;
        }
        public static string CapIdHoaDon()
        {
            string id = "";
            int n = GetCountNumOfOrderInDate();
            string m = "";
            string d = "";
            if (DateTime.Now.Month < 10)
            {
                m = "0" + DateTime.Now.Month.ToString();
            }
            else m = DateTime.Now.Month.ToString();
            if (DateTime.Now.Day < 10)
            {
                d = "0" + DateTime.Now.Day.ToString();
            }
            else d = DateTime.Now.Day.ToString();
            if (n < 9)
            {
                id = "HD" + DateTime.Now.Year.ToString().Remove(0, 2) + m + d + "00" + (n + 1).ToString();
            }
            else if (n >= 9 && n < 99)
            {
                id = "HD" + DateTime.Now.Year.ToString().Remove(0, 2) + m + d + "0" + (n + 1).ToString();
            }
            else
            {
                id = "HD" + DateTime.Now.Year.ToString().Remove(0, 2) + m + d + (n + 1).ToString();
            }
            return id;
        }
        public static int GetCountNumOfOrderInDate()
        {
            string sql = "select top 1 * from HoaDon  where convert(nvarchar(10),TimeCheckIn,103) = convert(nvarchar(10),getdate(),103) order by ID_HoaDon desc";
            DataTable dt = DataProvider.Instance.GetRecords(sql);
            if (dt.Rows.Count == 0)
            {
                return 0;
            }
            else
            {
                string temp = dt.Rows[0]["ID_HoaDon"].ToString();
                return Convert.ToInt32(temp.Substring(8, 3).ToString());
            }
        }
        public static string sendcode(string gmail, int i)
        {
            string a;
            if (i == 0) a = "Mã Code lấy tài khoản";
            else a = "Mật khẩu của bạn là: ";
            Random generator = new Random();
            string str = generator.Next(0, 100000).ToString("D6");
            if (ReloadAccountDAL.Instance.Send(gmail, a, str))
            {
                MessageBox.Show("Mã Code vừa được gửi đến Mail vừa nhập!");
            }
            else MessageBox.Show("Có lỗi trong quá trình gửi mã CODE !");
            return str;
        }
    }
}

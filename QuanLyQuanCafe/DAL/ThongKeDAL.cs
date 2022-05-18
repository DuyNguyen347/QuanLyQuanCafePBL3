using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAL
{
    public class ThongKeDAL
    {
        private static ThongKeDAL _Instance;
        private DateTime startDate;
        private DateTime endDate;
        private int numberDays;
        public List<KeyValuePair<string, int>> TopProductsList { get; private set; }
        public List<KeyValuePair<string, int>> UnderstockList { get; private set; }
        public List<RevenueByDate> GrossRevenueList { get; private set; }
        public int NumOrders { get; set; }
        public int TotalRevenue { get; set; }

        public static ThongKeDAL Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new ThongKeDAL();
                return _Instance;
            }
            private set => _Instance = value;
        }
        public void SoDon()
        {
            string query = " select count (*) as Tong from HoaDon" +
                           " where LEN(ID_HoaDon) < 12 and TimeCheckout between '" + startDate + "' and '" + endDate + "'";
            NumOrders = Convert.ToInt32(DataProvider.Instance.GetRecords(query).Rows[0]["Tong"].ToString());
        }
        private void GetOrderAnalisys()
        {
            GrossRevenueList = new List<RevenueByDate>();
            TotalRevenue = 0;
            using (var connection = DataProvider.Instance.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"select TimeCheckout, sum(DaThu)
                                            from HoaDon
                                            where LEN(ID_HoaDon) <12 and TimeCheckout between @fromDate and @toDate
                                            group by TimeCheckout";
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = endDate;
                    var reader = command.ExecuteReader();
                    var resultTable = new List<KeyValuePair<DateTime, int>>();
                    while (reader.Read())
                    {
                        resultTable.Add(
                            new KeyValuePair<DateTime, int>((DateTime)reader[0], (int)reader[1])
                            );
                        TotalRevenue += (int)reader[1];
                    }
                    reader.Close();

                    //Group by Hours
                    if (numberDays <= 1)
                    {
                        GrossRevenueList = (from DanhsachOrder in resultTable
                                            group DanhsachOrder by DanhsachOrder.Key.ToString("hh tt")
                                           into order
                                            select new RevenueByDate
                                            {
                                                Date = order.Key,
                                                TotalAmount = order.Sum(amount => amount.Value)
                                            }).ToList();
                    }
                    //Group by Days
                    else if (numberDays <= 30)
                    {
                        GrossRevenueList = (from orderList in resultTable
                                            group orderList by orderList.Key.ToString("dd MMM")
                                           into order
                                            select new RevenueByDate
                                            {
                                                Date = order.Key,
                                                TotalAmount = order.Sum(amount => amount.Value)
                                            }).ToList();
                    }

                    //Group by Weeks
                    else if (numberDays <= 92)
                    {
                        GrossRevenueList = (from orderList in resultTable
                                            group orderList by CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                                                orderList.Key, CalendarWeekRule.FirstDay, DayOfWeek.Monday)
                                           into order
                                            select new RevenueByDate
                                            {
                                                Date = "Week " + order.Key.ToString(),
                                                TotalAmount = order.Sum(amount => amount.Value)
                                            }).ToList();
                    }

                    //Group by Months
                    else if (numberDays <= (365 * 2))
                    {
                        bool isYear = numberDays <= 365 ? true : false;
                        GrossRevenueList = (from orderList in resultTable
                                            group orderList by orderList.Key.ToString("MMM yyyy")
                                           into order
                                            select new RevenueByDate
                                            {
                                                Date = isYear ? order.Key.Substring(0, order.Key.IndexOf(" ")) : order.Key,
                                                TotalAmount = order.Sum(amount => amount.Value)
                                            }).ToList();
                    }

                    //Group by Years
                    else
                    {
                        GrossRevenueList = (from DanhsachOrder in resultTable
                                            group DanhsachOrder by DanhsachOrder.Key.ToString("yyyy")
                                           into orderList
                                            select new RevenueByDate
                                            {
                                                Date = orderList.Key,
                                                TotalAmount = orderList.Sum(amount => amount.Value)
                                            }).ToList();
                    }
                }
            }
        }
        private void GetProductAnalisys()
        {
            TopProductsList = new List<KeyValuePair<string, int>>();
            UnderstockList = new List<KeyValuePair<string, int>>();
            using (var connection = DataProvider.Instance.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlDataReader reader;
                    command.Connection = connection;
                    //Get Top 5 products
                    command.CommandText = @"select top 5 P.TenMon, sum(ThongTinHoaDon.SoLuong) as Q
                                            from ThongTinHoaDon
                                            inner join Mon P on P.ID = ThongTinHoaDon.ID_Mon
                                            inner join HoaDon O on O.ID_HoaDon = ThongTinHoaDon.ID_HoaDon
                                            where TimeCheckout between @fromDate and @toDate
                                            group by P.TenMon
                                            order by Q desc ";
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = endDate;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        TopProductsList.Add(
                            new KeyValuePair<string, int>(reader[0].ToString(), (int)reader[1]));
                    }
                    reader.Close();
                }
            }
        }
        public bool LoadData(DateTime startDate, DateTime endDate)
        {
            endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day,
                endDate.Hour, endDate.Minute, 59);
            if (startDate != this.startDate || endDate != this.endDate)
            {
                this.startDate = startDate;
                this.endDate = endDate;
                this.numberDays = (endDate - startDate).Days;
                //MessageBox.Show(this.numberDays.ToString());
                //GetNumberItems();
                SoDon();
                GetProductAnalisys();
                GetOrderAnalisys();
                Console.WriteLine("Refreshed data: {0} - {1}", startDate.ToString(), endDate.ToString());
                return true;
            }
            else
            {
                Console.WriteLine("Data not refreshed, same query: {0} - {1}", startDate.ToString(), endDate.ToString());
                return false;
            }
        }

    }
}

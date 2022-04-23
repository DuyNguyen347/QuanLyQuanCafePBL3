using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace QuanLyQuanCafe.DTO
{
    public class HoaDon
    {
        public string ID { get; set; }
        public DateTime TimeCheckin { get; set; }
        public DateTime TimeCheckout { get; set; }
        public string ID_ban { get; set; }

        public HoaDon(string id, DateTime timecheckin, string idban)
        {
            ID = id;
            TimeCheckin = timecheckin;
            ID_ban = idban;
            TimeCheckout = new DateTime();
        }
        public HoaDon(string id, DateTime timecheckin, string idban,DateTime timecheckout)
        {
            ID = id;
            TimeCheckin = timecheckin;
            ID_ban = idban;
            TimeCheckout = timecheckout;
        }
        public HoaDon(DataRow row)
        {
            ID = row[0].ToString().Trim();
            TimeCheckin = Convert.ToDateTime(row[1].ToString());
            ID_ban = row[3].ToString().Trim();
            TimeCheckout =Convert.ToDateTime(row[2].ToString().Trim());
        }
    }
}

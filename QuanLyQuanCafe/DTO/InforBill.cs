using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace QuanLyQuanCafe.DTO
{
    public class InforBill
    {
        public string ID { get; set; }
        public string ID_Bill { get; set; }
        public string ID_Mon { get; set; }
        public int Soluong { get; set; }
        public InforBill(string idbill,string idmon,int soluong)
        {
            ID_Bill = idbill;
            ID_Mon = idmon;
            Soluong = soluong;
        }
        public InforBill(DataRow dataRow)
        {
            ID = dataRow[0].ToString().Trim();
            ID_Bill = dataRow[1].ToString().Trim();
            ID_Mon = dataRow[2].ToString().Trim();
            Soluong =Convert.ToInt32(dataRow[3].ToString());
        }
        
    }
}

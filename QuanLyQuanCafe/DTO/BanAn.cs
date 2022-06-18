using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class BanAn
    {
        public string ID { get; set; }
        public bool Status { get; set; }
        public BanAn()
        {
            Status = true;
        }
        public BanAn(string id, bool status)
        {
            ID = id;
            Status = status;
        }
        public BanAn(DataRow dataRow)
        {
            ID = dataRow["ID"].ToString();
            Status = Convert.ToBoolean(dataRow["Status"].ToString());
        }
        public override string ToString()
        {
            return ID.ToString();
        }
    }
}

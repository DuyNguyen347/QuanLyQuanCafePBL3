using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLyQuanCafe
{
    public class Table
    {
        public string Id { get; set; }
        public bool Status { get; set; }
        public Table()
        {
            Status = true;
        }
        public Table(string id,bool status)
        {
            Id = id;
            Status = status;
        }
        public Table(DataRow dataRow)
        {
            Id = dataRow[0].ToString();
            Status = Convert.ToBoolean(dataRow[1].ToString());
        }
    }
}

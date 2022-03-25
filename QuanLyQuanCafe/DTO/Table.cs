using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Table(Table table)
        {
            Id=table.Id;
            Status = table.Status;
        }
    }
}

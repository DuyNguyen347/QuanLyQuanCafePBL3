using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QuanLyQuanCafe
{
    public class DanhMuc
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public DanhMuc()
        {
        }
        public DanhMuc(string id,string name)
        {
            ID = id;
            Name = name;
        }
        public DanhMuc(DataRow dataRow)
        {
            ID=dataRow[0].ToString();
            Name = dataRow[1].ToString();
        }
    }
}

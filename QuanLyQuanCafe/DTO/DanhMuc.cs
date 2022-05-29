using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QuanLyQuanCafe
{
    public class DanhMuc : Object
    {
        public string ID { get; set; }
        public string Ten_Category { get; set; }
        public DanhMuc()
        {
        }
        public DanhMuc(string id,string ten_category)
        {
            ID = id;
            Ten_Category = ten_category;
        }
        public DanhMuc(DataRow dataRow)
        {
            ID=dataRow["ID"].ToString();
            Ten_Category = dataRow["Ten_Category"].ToString();
        }
        public override string ToString()
        {
            return Ten_Category;
        }
    }
}

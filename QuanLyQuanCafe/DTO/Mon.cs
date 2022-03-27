using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QuanLyQuanCafe
{
    public class Mon
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string DanhMuc { get; set; }
        public int Gia { get; set; }
        public Mon()
        {
        }
        public Mon(string id, string name,string danhmuc,int gia)
        {
            ID = id;
            Name = name;
            DanhMuc = danhmuc;
            Gia = gia;
        }
        public Mon(DataRow dataRow)
        {
            ID = dataRow[0].ToString();
            Name = dataRow[1].ToString();
            DanhMuc = dataRow[2].ToString();
            Gia = Convert.ToInt32(dataRow[3].ToString());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class ChucVu
    {
        public string TenChucVu { get; set; }
        public int Luong { get; set; }

        public ChucVu(string tenchucvu,int luong)
        {
            TenChucVu = tenchucvu;
            Luong = luong;
        }
        public ChucVu(DataRow row)
        {
            TenChucVu = row[0].ToString();
            Luong = Convert.ToInt32(row[1].ToString());
        }
    }
}

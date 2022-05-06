using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class Detail_Bill : UserControl
    {
        public Detail_Bill()
        {
            InitializeComponent();
        }
        public void settext(string s)
        {
            guna2TextBox1.Text = s;
        }
    }
}

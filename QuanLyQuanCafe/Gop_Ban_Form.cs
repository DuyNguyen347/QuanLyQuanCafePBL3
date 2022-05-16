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
    public partial class Gop_Ban_Form : Form
    {
        public int i;
        public Gop_Ban_Form()
        {
            InitializeComponent();
            i = -1;
        }

        private void BT_Gop1_Click(object sender, EventArgs e)
        {
            i = 0;
            Close();
        }

        private void BT_Gop2_Click(object sender, EventArgs e)
        {
            i = 1;
            Close();
        }
    }
}

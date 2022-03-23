﻿using System;
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
    public partial class ChonBanForm : Form
    {
        List<Table> tables = new List<Table>();
        public ChonBanForm()
        {
            InitializeComponent();
            
            tables.Add(new Table("1", true));
            tables.Add(new Table("2", false));
            tables.Add(new Table("1", true));
            tables.Add(new Table("2", false));
            tables.Add(new Table("1", true));
            tables.Add(new Table("2", false));
            tables.Add(new Table("1", true));
            tables.Add(new Table("2", false));
            tables.Add(new Table("1", true));
            tables.Add(new Table("2", false));
            tables.Add(new Table("1", true));
            tables.Add(new Table("2", false));
            tables.Add(new Table("1", true));
            tables.Add(new Table("2", false));
            tables.Add(new Table("1", true));
            tables.Add(new Table("2", false));
            tables.Add(new Table("1", true));
            tables.Add(new Table("2", false));
            tables.Add(new Table("1", true));
            tables.Add(new Table("2", false));
            tables.Add(new Table("1", true));
            tables.Add(new Table("2", false));
            tables.Add(new Table("1", true));
            tables.Add(new Table("2", false));
            tables.Add(new Table("1", true));
            tables.Add(new Table("2", false));
            tables.Add(new Table("1", true));
            tables.Add(new Table("2", false));
            tables.Add(new Table("1", true));
            tables.Add(new Table("2", false));
            tables.Add(new Table("1", true));
            tables.Add(new Table("2", false));
            tables.Add(new Table("1", true));
            tables.Add(new Table("2", false));
            tables.Add(new Table("1", true));
            tables.Add(new Table("2", false));

        }

        private void ChonBanForm_Load(object sender, EventArgs e)
        {
            load_FLP_Table(tables);
        }

        private void BT_OK_Click(object sender, EventArgs e)
        {

        }

        private void BT_Cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public void load_FLP_Table(List<Table> tables)
        {
            foreach (Table i in tables)
            {
                Button button = new Button();
                button.Text = i.Id + "\n" + (i.Status ? "Trống" : "Có người");
                button.BackColor = System.Drawing.Color.SpringGreen;
                button.Cursor = System.Windows.Forms.Cursors.Hand;
                button.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                button.Margin = new System.Windows.Forms.Padding(0);
                button.Name = i.Id;
                button.Size = new System.Drawing.Size(75, 50);
                button.Click += new System.EventHandler(this.BT_Click);
                if (!i.Status)
                {
                    button.BackColor= System.Drawing.Color.HotPink;
                }
                FLP_Ban.Controls.Add(button);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void BT_Click(object sender, EventArgs e)
        {

        }
    }
}

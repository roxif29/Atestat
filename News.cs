﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace Atestat
{
    public partial class News : Form
    {
        private int id;
        OleDbConnection con = new OleDbConnection();
        public News(int id)
        {
            InitializeComponent();
            this.id = id;
            con.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; 
            Data Source = " + Environment.CurrentDirectory + @"\Atestat.accdb";
            this.id = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Profil f = new Profil(id);
            f.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Lista_jocuri f = new Lista_jocuri(id);
            f.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Info f = new Info(id);
            f.Show();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Meniu f = new Meniu(id);
            f.Show();
            Hide();
        }
    }
}

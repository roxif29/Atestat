using System;
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
    public partial class Meniu : Form
    {
        int idutilizator;
        private int id;
        public static int idcom;
        OleDbConnection con = new OleDbConnection();
        public Meniu(int id)
        {
            InitializeComponent();
            this.id = id;
            con.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; 
            Data Source = " + Environment.CurrentDirectory + @"\Atestat.accdb";
            this.id = id;
            





            /*
            int ct = 0;
            con.Open();
            OleDbCommand com = new OleDbCommand("select * from Comenzi where id_comanda=" + idcom + "", con);
            OleDbDataReader r = com.ExecuteReader();
            while (r.Read())
            {
                ct++;
            }
            con.Close();

            //daca nu există comanda, este creată una nouă 
            if (ct == 0)
            {

                con.Open();
                string sql = "insert into Comenzi(id_utilizator) values (" + idcom + ")";
                string sql1 = "select @@Identity";
                OleDbCommand cmd = new OleDbCommand(sql, con);
                cmd.ExecuteNonQuery();


                OleDbCommand cmd2 = new OleDbCommand(sql1, con);
                idcom = (int)cmd2.ExecuteScalar();
                con.Close();
            }*/
        }

        private void Meniu_Load(object sender, EventArgs e)
        {
            pictureBox5.Visible = false;
            pictureBox4.Visible = false;
            pictureBox3.Visible = false;
            pictureBox2.Visible = false;
            timer1.Start();
        }
        //Slideshow
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox1.Visible == true)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = true;
            }

            else if (pictureBox2.Visible == true)
            {
                pictureBox2.Visible = false;
                pictureBox3.Visible = true;
            }

            else if (pictureBox3.Visible == true)
            {
                pictureBox3.Visible = false;
                pictureBox4.Visible = true;
            }

            else if (pictureBox4.Visible == true)
            {
                pictureBox4.Visible = false;
                pictureBox5.Visible = true;
            }

            else if (pictureBox5.Visible == true)
            {
                pictureBox5.Visible = false;
                pictureBox1.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Lista_jocuri f = new Lista_jocuri(id);
            f.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Profil f = new Profil(id); f.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Info f = new Info(id); f.Show();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            News f = new News(id); f.Show();
            Hide();
        }

        
    }
}

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
    public partial class Descriere : Form
    {
         public int id;
        OleDbConnection con = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; 
Data Source = " + Environment.CurrentDirectory + @"\Atestat.accdb");
        string numefis = "", calefis = "";

        

        public Descriere(int idj)
        {
            id = idj;
            //label5.Text = "dwoiahd";
            InitializeComponent();
            con.Open();
           // string sql = "select denumire_joc from Jocuri where id_joc=id";
            string sql = "select * from Jocuri where id_joc="+id;
            OleDbCommand cmd = new OleDbCommand(sql, con);
            OleDbDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                joctextBox.Text = rdr[1].ToString();
                datatextBox.Text = rdr[5].ToString();
                dezvoltattextBox.Text = rdr[2].ToString();
                publicattextBox.Text = rdr[3].ToString();
                descrieretextBox.Text = rdr[4].ToString();
                

            }
            if(id==1)
            {
                pictureBox2.Image = Atestat.Properties.Resources._1;

            }
            if (id == 2)
            {
                pictureBox2.Image = Atestat.Properties.Resources._2;

            }
            if (id == 3)
            {
                pictureBox2.Image = Atestat.Properties.Resources._3;

            }
            if (id == 4)
            {
                pictureBox2.Image = Atestat.Properties.Resources._4;

            }
            if (id == 5)
            {
                pictureBox2.Image = Atestat.Properties.Resources._5;

            }
            if (id == 6)
            {
                pictureBox2.Image = Atestat.Properties.Resources._6;

            }
            if (id == 7)
            {
                pictureBox2.Image = Atestat.Properties.Resources._7;

            }
            if (id == 8)
            {
                pictureBox2.Image = Atestat.Properties.Resources._8;

            }
            if (id == 9)
            {
                pictureBox2.Image = Atestat.Properties.Resources._9;

            }
            if (id == 10)
            {
                pictureBox2.Image = Atestat.Properties.Resources._10;

            }
            if (id == 11)
            {
                pictureBox2.Image = Atestat.Properties.Resources._11;

            }
            if (id == 12)
            {
                pictureBox2.Image = Atestat.Properties.Resources._12;

            }
            if (id == 13)
            {
                pictureBox2.Image = Atestat.Properties.Resources._13;

            }
            if (id == 14)
            {
                pictureBox2.Image = Atestat.Properties.Resources._14;

            }
            if (id == 15)
            {
                pictureBox2.Image = Atestat.Properties.Resources._15;

            }
            if (id == 16)
            {
                pictureBox2.Image = Atestat.Properties.Resources._16;

            }
            if (id == 17)
            {
                pictureBox2.Image = Atestat.Properties.Resources._17;

            }
            if (id == 18)
            {
                pictureBox2.Image = Atestat.Properties.Resources._18;

            }
            if (id == 19)
            {
                pictureBox2.Image = Atestat.Properties.Resources._19;

            }
            if (id == 20)
            {
                pictureBox2.Image = Atestat.Properties.Resources._20;

            }
            if (id == 21)
            {
                pictureBox2.Image = Atestat.Properties.Resources._21;

            }
            if (id == 22)
            {
                pictureBox2.Image = Atestat.Properties.Resources._22;

            }
            if (id == 23)
            {
                pictureBox2.Image = Atestat.Properties.Resources._23;

            }
            if (id == 24)
            {
                pictureBox2.Image = Atestat.Properties.Resources._24;

            }
            if (id == 25)
            {
                pictureBox2.Image = Atestat.Properties.Resources._25;

            }
            if (id == 26)
            {
                pictureBox2.Image = Atestat.Properties.Resources._26;

            }
            if (id == 27)
            {
                pictureBox2.Image = Atestat.Properties.Resources._27;

            }
            if (id == 28)
            {
                pictureBox2.Image = Atestat.Properties.Resources._28;

            }
            /*  else
                  if(id==2)
                      {
                  Image img = Image.FromFile("");
                  pictureBox2.Image = img;
              }
              else
                 if(id==3)
              {
                  Image img = Image.FromFile("");
                  pictureBox2.Image = img;
              }
              else
                  if(id==4)
              {
                  Image img = Image.FromFile("");
                  pictureBox2.Image = img;
              }
              else
                  if(id==5)
              {
                  Image img = Image.FromFile("");
                  pictureBox2.Image = img;
              }
              else
                  if(id==6)
              {
                  Image img = Image.FromFile("");
                  pictureBox2.Image = img;
              }*/



            con.Close(); rdr.Close();


          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Lista_jocuri f = new Lista_jocuri(id);
            f.Show();
            Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Descriere_Load(object sender, EventArgs e)
        {
            


        }
    }
}

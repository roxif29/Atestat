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
    public partial class Profil : Form
    {
        private int id;
        string idutilizator;
        OleDbConnection con = new OleDbConnection();
        public Profil(int id)
        {
            InitializeComponent();
            this.id = id;
            con.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; 
            Data Source = " + Environment.CurrentDirectory + @"\Atestat.accdb";
            this.id = id;
            con.Open();
            string sql = "select * from Utilizatori where ID_utilizator=" + id + "";
            OleDbCommand cmd = new OleDbCommand(sql, con);
            OleDbDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {

                numelabel.Text = rdr["nume"].ToString();
                prenumelabel.Text = rdr["prenume"].ToString();
                emaillabel.Text = rdr["email"].ToString();
                userlabel.Text = rdr["username"].ToString();
                idutilizator = rdr[0].ToString();


            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Parolanoua f = new Parolanoua(id);
            f.Show();
            Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Emailnou f = new Emailnou(id);
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
            News f = new News(id);
            f.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Meniu f = new Meniu(id);
            f.Show();
            Hide();
        }

        private void Profil_Load(object sender, EventArgs e)
        {
           
        }
    }
}

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
    public partial class Parolanoua : Form
    {
        private int id;
        string parola;

        OleDbConnection con = new OleDbConnection();

        public Parolanoua(int id)
        {

            InitializeComponent();
            this.id = id;
            con.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; 
            Data Source = " + Environment.CurrentDirectory + @"\Atestat.accdb";
            this.id = id;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();

            string sql2 = "select id_utilizator, parola from Utilizatori where id_utilizator=" + id + "";
            OleDbCommand cmd2 = new OleDbCommand(sql2, con);
            OleDbDataReader rdr = cmd2.ExecuteReader();
            while (rdr.Read())
                parola = rdr["parola"].ToString();
            if (textBox1.Text != parola)
                MessageBox.Show("Parolă incorectă!");
            else
                if (textBox2.Text != textBox3.Text)
            {
                    MessageBox.Show("Parolele nu coincid!");
                textBox1.Text = textBox2.Text = textBox3.Text = "";
            }
                
            else
            {

                string s = "update Utilizatori set parola='" + textBox2.Text + "' where id_utilizator=" + id + "";
                OleDbCommand cmd = new OleDbCommand(s, con);
                cmd.ExecuteNonQuery();
               Hide();

            }
            Profil f = new Profil(id);
            f.Show();
            this.Hide();
        }
    }
}

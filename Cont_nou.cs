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

    public partial class Cont_nou : Form
    {
        OleDbConnection con = new OleDbConnection();
        public Cont_nou()
        { InitializeComponent();
            con.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; 
Data Source = " + Environment.CurrentDirectory + @"\Atestat.accdb";
           
        }

        private void creeazacontbutton_Click(object sender, EventArgs e)
        {
            if (parola1textBox.Text != parola2textBox.Text)
            {
                MessageBox.Show("Parolele nu sunt identice. Reintroduceti parola!");
                parola1textBox.Text = parola2textBox.Text = "";
            }
            else
            {
                con.Open();
               OleDbCommand cmd=new OleDbCommand( "insert into Utilizatori(nume,prenume,email,username,parola)" +
                    " values('" + numetextBox.Text + "','" + prenumetextBox.Text + "','" + emailtextBox.Text + "','" + usernametextBox.Text + "','" + parola1textBox.Text + "')",con);
               /// OleDbCommand cmd = new OleDbCommand(sql, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Multumim pentru inregistrare!");
                con.Close();
               
               
                Pagina_Start f = new Pagina_Start();
                f.Show();
              
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pagina_Start f = new Pagina_Start();
            f.Show();
            Hide();
        }
    }
}

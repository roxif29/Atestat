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
    
    public partial class Pagina_Start : Form

    {
        public static int id;
        OleDbConnection con = new OleDbConnection();
        public Pagina_Start()
        {
            con.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; 
Data Source = " + Environment.CurrentDirectory + @"\Atestat.accdb";
            InitializeComponent();
           
        }

        private void loginbutton_Click(object sender, EventArgs e)
        {
            int ct = 0;
            con.Open();
            string sql = "select ID_utilizator from Utilizatori " +
                "where username='" + usertextBox.Text + "'" +
                " and parola='" + passtextBox.Text + "'";
            OleDbCommand cmd = new OleDbCommand(sql, con);
            OleDbDataReader rdr = cmd.ExecuteReader();
            
            while (rdr.Read())
            {
                ct++;
                id = int.Parse(rdr[0].ToString());
            }
            if (ct > 0)
            {
                con.Close();
                Meniu f = new Meniu(id);
                f.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Email sau parola gresite! Reincearca!", "Eroare", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                usertextBox.Text = passtextBox.Text = "";
            }
           // con.Close();
        }

        private void creare_cont_noubutton_Click(object sender, EventArgs e)
        {
            Cont_nou f = new Cont_nou();
                f.Show();
            Hide();
           
        }
    }
}

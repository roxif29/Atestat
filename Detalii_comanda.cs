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
    public partial class Detalii_comanda : Form
    {   private int id, idsub; OleDbConnection con = new OleDbConnection();
        public Detalii_comanda(int idutilizator, int idcom)
        { 
        InitializeComponent();
            this.id = id;
            con.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; 
            Data Source = " + Environment.CurrentDirectory + @"\Atestat.accdb";
            /*this.id = id;
            this.idcom = idcom;*/

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            Meniu f = new Meniu(id);
            f.Show();
            this.Hide();
            
        
        }

        private void Detalii_comanda_Load(object sender, EventArgs e)
        {
            con.Open();
            string sql= @"select a.id_joc,b.denumire_joc,b.pret " +
                "from Subcomenzi a inner join Jocuri b " +
                "on a.id_joc=b.id_joc " +
                "where a.id_comanda=" + Lista_jocuri.idcom + "";
            OleDbCommand cmd = new OleDbCommand(sql, con);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            textBox2.Text = Lista_jocuri.prettotal.ToString();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vă mulțumim pentru comanda efectuată! Vă veți întoarce la meniul principal!");
            Meniu f = new Meniu(id);
            f.Show();
            Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["elimina"].Index)
            {
                float p = 0;//pentru preluare pret,cantit,kcal eliminate din comanda
                DataGridViewRow r = dataGridView1.CurrentCell.OwningRow;
                p = float.Parse(r.Cells["pret"].Value.ToString());
            
                con.Open();
                string sql = "select id_subcomanda " +
                    "from Subcomenzi " +
                    "where id_comanda=" + Lista_jocuri.idcom + " and " +
                    "id_joc=" + r.Cells["id_joc"].Value + "";
                OleDbCommand cmd = new OleDbCommand(sql, con);
                OleDbDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    idsub = int.Parse(rdr["id_subcomanda"].ToString());

                }
                string sql2 = "delete from Subcomenzi where id_subcomanda=" + idsub + "";
                cmd = new OleDbCommand(sql2, con);
                cmd.ExecuteNonQuery();

                //actualizare grid
                con.Close();
                con.Open();
                string sql3 = @"select a.id_joc,b.denumire_joc,b.pret " +
                "from Subcomenzi a inner join Jocuri b " +
                "on a.id_joc=b.id_joc " +
                "where a.id_comanda=" + Lista_jocuri.idcom + "";
                OleDbCommand cmd2 = new OleDbCommand(sql3, con);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd2);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                textBox2.Text = (float.Parse(textBox2.Text) - p).ToString();
                
                con.Close();
               
                
            }
        }
    }
}

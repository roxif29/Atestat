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
    public partial class Lista_jocuri : Form
    {
        int ct=0;
        public static double prettotal;
        public static int idcom;
        int id;
        
        OleDbConnection con = new OleDbConnection();
        public Lista_jocuri(int id)
        {
            InitializeComponent();
            this.id = id;
            con.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; 
            Data Source = " + Environment.CurrentDirectory + @"\Atestat.accdb";
            this.id = id;
           // idutilizator = id;
            string sql1 = "insert into Comenzi(ID_utilizator) " +
                "values(" + Pagina_Start.id + ")";
            string sql2 = "select @@Identity";
            OleDbCommand cmd1 = new OleDbCommand(sql1, con);
            OleDbCommand cmd2 = new OleDbCommand(sql2, con);
            con.Open();
            cmd1.ExecuteNonQuery();
            idcom = (int)cmd2.ExecuteScalar();//returneaza id-ul comenzii

            con.Close();



        }

        private void Lista_jocuri_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'atestatDataSet.Jocuri' table. You can move, or remove it, as needed.
             this.jocuriTableAdapter.Fill(this.atestatDataSet.Jocuri);
            /*con.Close();
            con.Open();
            string sql = "select ID_joc, denumire_joc, dezvoltat_de, publicat_de,pret from Jocuri";
            OleDbCommand cmd = new OleDbCommand(sql, con);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            con.Open();*/
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Profil f = new Profil(id);
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
        // det comanda
        private void button5_Click(object sender, EventArgs e)
        {
            Detalii_comanda f = new Detalii_comanda(Pagina_Start.id, idcom);
            f.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Meniu f = new Meniu(id);
            f.Show();
            Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*if (e.ColumnIndex == dataGridView1.Columns["adauga_cos"].Index)
            {
                DataGridViewRow r = dataGridView1.CurrentCell.OwningRow;

                string p = r.Cells["pret"].Value.ToString();

                prettotal += Convert.ToDouble(p);
                //label1.Text = prettotal.ToString();


                con.Open();
                string sql = "insert into Subcomenzi(id_comanda,id_joc) values(" + idcom  + "," + r.Cells["id_joc"].Value + ")";
                OleDbCommand cmd = new OleDbCommand(sql, con);
                cmd.ExecuteNonQuery();

                con.Close();



            }*/
            if (e.ColumnIndex == dataGridView1.Columns["detalii"].Index)
            {
                DataGridViewRow r = dataGridView1.CurrentCell.OwningRow;
                int idj = int.Parse(r.Cells["id_joc"].Value.ToString());
                
                Form f = new Descriere(idj);
                f.ShowDialog();
                             
            }
            else 

            if (e.ColumnIndex == dataGridView1.Columns["adauga"].Index)
            {
                DataGridViewRow r1 = dataGridView1.CurrentCell.OwningRow;
               /// JCFFEFFE
               double p= double.Parse(r1.Cells["pret"].Value.ToString());
                prettotal = prettotal + p;
                label1.Text = prettotal.ToString();
                

                //inserez aceasta subcomanda
                con.Open();
                int idj = int.Parse(r1.Cells["id_joc"].Value.ToString());
                string sql = "insert into Subcomenzi (id_comanda,id_joc) values (" + idcom + "," + idj + ")";
                OleDbCommand cmd = new OleDbCommand(sql, con);
                cmd.ExecuteNonQuery();
                ct++;
                con.Close();
            }
        }
    }
}

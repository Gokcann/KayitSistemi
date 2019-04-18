using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJE
{
    public partial class SQL : Form
    {
        public SQL()
        {
            InitializeComponent();
        }
        public OleDbDataAdapter da;
        public OleDbCommand cmd;
        public DataSet ds;
        public OleDbConnection con;

        public void kapat()
        {
            con.Close();
        }


        public void baglan()
        {
            try
            {
                con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=kutuphane.accdb");


                con.Open();



            }
            catch { con.Close(); MessageBox.Show("veritabanı bağlantı hatası"); }
        }

        private void SQL_Load(object sender, EventArgs e)
        {
            
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu="";
            sorgu = textBox1.Text;
            try
            {
                ds = new DataSet();
                baglan();
                da = new OleDbDataAdapter(sorgu, con);
                da.Fill(ds, sorgu);
                dataGridView1.DataSource = ds.Tables[sorgu];
                kapat();
            }
            catch { MessageBox.Show("Yanlış yazdınız lütfen daha dikkatli olunuz :("); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

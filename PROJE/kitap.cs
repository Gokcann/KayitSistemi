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
    public partial class kitap : Form
    {
        public kitap()
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

        private void kitap_Load(object sender, EventArgs e)
        {
            try
            {
                ds = new DataSet();
                baglan();
                da = new OleDbDataAdapter("Select * from kitap", con);
                da.Fill(ds, "kitap");
                dataGridView1.DataSource = ds.Tables["kitap"];
                kapat();
            }
            catch { MessageBox.Show("Gösteremedi"); }
        
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "insert into kitap (kitapno,isbnno,kitapadi,yazarno,turno,sayfasayisi) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')";
                cmd.ExecuteNonQuery();
                con.Close();

                kitap_Load(sender, e);
            }
            catch { MessageBox.Show("Eklenemedi"); }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "delete from kitap where kitapno=" + textBox7.Text + "";
                cmd.ExecuteNonQuery();
                con.Close();

                kitap_Load(sender, e);
            }
            catch { MessageBox.Show("silinemedi"); }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "update kitap set isbnno='" + textBox9.Text + "',kitapadi='" + textBox10.Text + "',yazarno='" + textBox11.Text + "',turno='" + textBox12.Text + "',sayfasayisi='" + textBox13.Text + "' where kitapno=" + textBox8.Text + "";
                cmd.ExecuteNonQuery();
                con.Close();

                kitap_Load(sender, e);
            }
            catch { MessageBox.Show("Güncelleyemedi"); }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

            try
            {
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "update kitap set isbnno='" + textBox9.Text + "' where kitapno=" + textBox8.Text + "";
                cmd.ExecuteNonQuery();
                con.Close();

                kitap_Load(sender, e);
            }
            catch { MessageBox.Show("isbbno Güncellenemedi"); }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            try
            {
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "update kitap set kitapadi='" + textBox10.Text + "' where kitapno=" + textBox8.Text + "";
                cmd.ExecuteNonQuery();
                con.Close();

                kitap_Load(sender, e);
            }
            catch { MessageBox.Show("kitapadi Güncellenemedi"); }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            try
            {
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "update kitap set yazarno='" + textBox11.Text + "' where kitapno=" + textBox8.Text + "";
                cmd.ExecuteNonQuery();
                con.Close();

                kitap_Load(sender, e);
            }
            catch { MessageBox.Show("yazarno Güncellenemedi"); }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            try
            {
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "update kitap set turno='" + textBox12.Text + "' where kitapno=" + textBox8.Text + "";
                cmd.ExecuteNonQuery();
                con.Close();

                kitap_Load(sender, e);
            }
            catch { MessageBox.Show("turno Güncellenemedi"); }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            try
            {
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "update kitap set sayfasayisi='" + textBox13.Text + "' where kitapno=" + textBox8.Text + "";
                con.Close();

                kitap_Load(sender, e);
            }
            catch { MessageBox.Show("sayfasayisi Güncellenemedi"); }
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

            string a = "kitapadi";
          (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("{0} LIKE '{1}%'", a, textBox14.Text);

        }

        private void comboBox1_SelectedValueChanged_1(object sender, EventArgs e)
        {
            string a = "", b = "", c = "";

            if (comboBox1.SelectedIndex == 0)
            {
                c = "ogrno";
                a = "ogrenci";
                b = "islem";
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                c = "kitapno";
                a = "islem";
                b = "kitap";
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                c = "yazarno";
                a = "kitap";
                b = "yazar";
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                c = "turno";
                a = "kitap";
                b = "tur";
            }
            if (comboBox1.SelectedIndex != 4)
            {


                cmd = new OleDbCommand();
                string sorgu = "select * from " + a + " o inner join " + b + " i on o." + c + "=" + "i." + c + "";
                ds = new DataSet();
                baglan();
                da = new OleDbDataAdapter(sorgu, con);
                da.Fill(ds, sorgu);
                dataGridView1.DataSource = ds.Tables[sorgu];
                kapat();
            }
            if (comboBox1.SelectedIndex == 4)
                kitap_Load(sender, e);
            ///    cmd.Connection = con;
            //  cmd.CommandText = "select * from " + a + " o inner join " + b + " i on o." + c + "=" + "i." + c + "";
            //   cmd.ExecuteNonQuery();
            //     con.Close();


        }

       
    }
}

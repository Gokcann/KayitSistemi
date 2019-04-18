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
    public partial class yazar : Form
    {
        public yazar()
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

        private void yazar_Load(object sender, EventArgs e)
        {
            try
            {
                ds = new DataSet();
                baglan();
                da = new OleDbDataAdapter("Select * from yazar", con);
                da.Fill(ds, "yazar");
                dataGridView1.DataSource = ds.Tables["yazar"];
                kapat();
            }
            catch { MessageBox.Show("Gösteremedi"); }
            radioButton1.Checked = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "insert into yazar (yazarno,yazarad,yazarsoyad) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
                cmd.ExecuteNonQuery();
                con.Close();

                yazar_Load(sender, e);
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
                cmd.CommandText = "delete from yazar where yazarno=" + textBox7.Text + "";
                cmd.ExecuteNonQuery();
                con.Close();

                yazar_Load(sender, e);
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
                cmd.CommandText = "update yazar set yazarad='" + textBox9.Text + "',yazarsoyad='" + textBox10.Text + "' where yazarno=" + textBox8.Text + "";
                cmd.ExecuteNonQuery();
                con.Close();

                yazar_Load(sender, e);
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
                cmd.CommandText = "update yazar set yazarad='" + textBox9.Text + "' where yazarno=" + textBox8.Text + "";
                cmd.ExecuteNonQuery();
                con.Close();

                yazar_Load(sender, e);
            }
            catch { MessageBox.Show("yazar ad Güncellenemedi"); }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            try
            {
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "update yazar set yazarsoyad='" + textBox10.Text + "' where yazarno=" + textBox8.Text + "";
                cmd.ExecuteNonQuery();
                con.Close();

                yazar_Load(sender, e);
            }
            catch { MessageBox.Show("yazar soyad Güncellenemedi"); }
        }



        private void textBox14_TextChanged_1(object sender, EventArgs e)
        {

            string a = "";
            if (radioButton1.Checked == true)
                a = "yazarad";
            else if (radioButton2.Checked == true)
                a = "yazarsoyad";





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
                yazar_Load(sender, e);
            ///    cmd.Connection = con;
            //  cmd.CommandText = "select * from " + a + " o inner join " + b + " i on o." + c + "=" + "i." + c + "";
            //   cmd.ExecuteNonQuery();
            //     con.Close();



        }

    }
    }

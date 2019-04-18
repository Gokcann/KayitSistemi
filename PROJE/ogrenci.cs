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
    public partial class ogrenci : Form
    {
        public ogrenci()
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

        private void ogrenci_Load(object sender, EventArgs e)
        {
            try
            {
                ds = new DataSet();
                baglan();
                da = new OleDbDataAdapter("Select * from ogrenci", con);
                da.Fill(ds, "ogrenci");
                dataGridView1.DataSource = ds.Tables["ogrenci"];
                kapat();
            }
            catch { MessageBox.Show("Gösteremedi"); }
            radioButton1.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "insert into ogrenci (ogrno,ograd,ogrsoyad,cinsiyet,dtarih,sinif) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')";
                cmd.ExecuteNonQuery();
                con.Close();

                ogrenci_Load(sender, e);
            }
            catch { MessageBox.Show("Eklenemedi"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "delete from ogrenci where ogrno=" + textBox7.Text + "";
                cmd.ExecuteNonQuery();
                con.Close();

                ogrenci_Load(sender, e);
            }
            catch { MessageBox.Show("silinemedi"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "update ogrenci set ograd='" + textBox9.Text + "',ogrsoyad='" + textBox10.Text + "',cinsiyet='" + textBox11.Text + "',dtarih='" + textBox12.Text + "',sinif='" + textBox13.Text + "' where ogrno=" + textBox8.Text + "";
                cmd.ExecuteNonQuery();
                con.Close();

                ogrenci_Load(sender, e);
            }
            catch { MessageBox.Show("Güncelleyemedi"); }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            try
            {
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "update ogrenci set ograd='" + textBox9.Text + "' where ogrno=" + textBox8.Text + "";
                cmd.ExecuteNonQuery();
                con.Close();

                ogrenci_Load(sender, e);
            }
            catch { MessageBox.Show("ad Güncellenemedi"); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "update ogrenci set ogrsoyad='" + textBox10.Text + "' where ogrno=" + textBox8.Text + "";
                cmd.ExecuteNonQuery();
                con.Close();

                ogrenci_Load(sender, e);
            }
            catch { MessageBox.Show("soyad Güncellenemedi"); }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "update ogrenci set cinsiyet='" + textBox11.Text + "' where ogrno=" + textBox8.Text + "";
                cmd.ExecuteNonQuery();
                con.Close();

                ogrenci_Load(sender, e);
            }
            catch { MessageBox.Show("cinsiyet Güncellenemedi"); }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "update ogrenci set dtarih='" + textBox12.Text + "' where ogrno=" + textBox8.Text + "";
                cmd.ExecuteNonQuery();
                con.Close();

                ogrenci_Load(sender, e);
            }
            catch { MessageBox.Show("dtarih Güncellenemedi"); }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "update ogrenci set sinif='" + textBox13.Text + "' where ogrno=" + textBox8.Text + ""; cmd.ExecuteNonQuery();
                con.Close();

                ogrenci_Load(sender, e);
            }
            catch { MessageBox.Show("sinif Güncellenemedi"); }
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

            string a = "";
            if (radioButton1.Checked == true)
                a = "ograd";
            else if (radioButton2.Checked == true)
                a = "ogrsoyad";
            else if (radioButton4.Checked == true)
                a = "dtarih";
            else if (radioButton5.Checked == true)
                a = "sinif";




            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("{0} LIKE '{1}%'", a, textBox14.Text);

        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
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
                ogrenci_Load(sender, e);
            ///    cmd.Connection = con;
            //  cmd.CommandText = "select * from " + a + " o inner join " + b + " i on o." + c + "=" + "i." + c + "";
            //   cmd.ExecuteNonQuery();
            //     con.Close();


        }

    }
}

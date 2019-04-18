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
    public partial class islem : Form
    {
        public islem()
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
        private void yenile ()
        {
            try
            {
                ds = new DataSet();
                baglan();
                da = new OleDbDataAdapter("Select * from islem", con);
                da.Fill(ds, "islem");
                dataGridView1.DataSource = ds.Tables["islem"];
                kapat();
            }
            catch { MessageBox.Show("Gösteremedi"); }
        }
        private void İslem_Load(object sender, EventArgs e)
        {
            try
            {
                ds = new DataSet();
                baglan();
                da = new OleDbDataAdapter("Select * from islem", con);
                da.Fill(ds, "islem");
                dataGridView1.DataSource = ds.Tables["islem"];
                kapat();
            }
            catch { MessageBox.Show("Gösteremedi"); }
           
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "insert into islem (islemno,ogrno,kitapno,atarih,vtarih) values('"+textBox1.Text+"','"+textBox2.Text+"','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text +"')";
                cmd.ExecuteNonQuery();
                con.Close();

                İslem_Load(sender, e);
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
                cmd.CommandText = "delete from islem where islemno=" + textBox7.Text + "";
                cmd.ExecuteNonQuery();
                con.Close();

                yenile();
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
                cmd.CommandText = "update islem set ogrno='" + textBox9.Text + "',kitapno='" + textBox10.Text + "',atarih='" + textBox11.Text + "',vtarih='" + textBox12.Text +  "' where islemno=" + textBox8.Text + "";
                cmd.ExecuteNonQuery();
                con.Close();

                İslem_Load(sender, e);
            }
            catch { MessageBox.Show("Güncelleyemedi !"); }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

            try
            {
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "update islem set ogrno='" + textBox9.Text + "' where islemno=" + textBox8.Text + "";
                cmd.ExecuteNonQuery();
                con.Close();

                İslem_Load(sender, e);
            }
            catch { MessageBox.Show("Ogr No Güncellenemedi"); }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            try
            {
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "update islem set kitapno='" + textBox10.Text + "' where islemno=" + textBox8.Text + "";
                cmd.ExecuteNonQuery();
                con.Close();

                İslem_Load(sender, e);
            }
            catch { MessageBox.Show("Kitapno Güncellenemedi"); }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            try
            {
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "update islem set atarih='" + textBox11.Text + "' where islemno=" + textBox8.Text + "";
                cmd.ExecuteNonQuery();
                con.Close();

                İslem_Load(sender, e);
            }
            catch { MessageBox.Show("Alış Tarihi Güncellenemedi"); }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            try
            {
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "update islem set vtarih='" + textBox12.Text + "' where islemno=" + textBox8.Text + "";
                cmd.ExecuteNonQuery();
                con.Close();

                İslem_Load(sender, e);
            }
            catch { MessageBox.Show("Veriliş Tarihi Güncellenemedi"); }
        }
        
        

        

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            string a = "", b = "", c = "";

            if (comboBox1.SelectedIndex == 0)
            {
                c = "ogrno";
                a = "islem";
                b = "ogrenci";
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                c = "kitapno";
                a = "kitap";
                b = "islem";
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                c = "yazarno";
                a = "yazar";
                b = "kitap";
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
                İslem_Load(sender, e);
            ///    cmd.Connection = con;
            //  cmd.CommandText = "select * from " + a + " o inner join " + b + " i on o." + c + "=" + "i." + c + "";
            //   cmd.ExecuteNonQuery();
            //     con.Close();


        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}

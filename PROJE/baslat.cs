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
    public partial class baslat : Form
    {
        public baslat()
        {
            InitializeComponent();
        }

        public OleDbDataAdapter da;
        public OleDbCommand cmd;
        public DataSet ds;
        public OleDbConnection con;

      
        

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ogrenci a = new ogrenci();
            a.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            islem b = new islem();
            b.Show();
        }

          private void button3_Click(object sender, EventArgs e)
          {
              kitap c = new kitap();
              c.Show();
          }
       
          private void button4_Click_1(object sender, EventArgs e)
        {
            yazar d = new yazar();
            d.Show();
        }
       
          private void button5_Click_1(object sender, EventArgs e)
        {
            tur f = new tur();
            f.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SQL sql = new SQL();
            sql.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu hafta uğraştığımız Projelerden biri diğerlerini ekleyemedik");
            MessageBox.Show("Jack's or Better oyunu( sağ en alt köşede hile butonu var)");
            Proje.Form1 a = new Proje.Form1();
            a.Show();
        }
    }
}


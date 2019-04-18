using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Oyuncu bakiye = new Oyuncu(Convert.ToInt32(100));
        Dagitici Dagit = new Dagitici();
        Kartlar Kart = new Kartlar();
        Pc Bilgisayar = new Pc();
        string oyuncuad;
        int sayac = 0;
        int ydkbky = 0;
        int sayac2=0;

        private void Form1_Load(object sender, EventArgs e)
        {
            
            label7.Text = bakiye.Bakiye.ToString();//baslangicta bakiyeyi label7 ye yazdiriyoruz
        }





        private void baslat_Click(object sender, EventArgs e)
        {
            sayac++;
            ydkbky = bakiye.Bakiye;
            if (textBox1.Text == "") //burada textbox ın boş olup olmama durmunu kontrol ediyoruz
            {
                MessageBox.Show("Adınızı Bos Birakmayiniz");

            }
            else //eger adını istenilen şekilde yazarsa oyunu başlatıyor
            {
                if (sayac <2)
                liste.Items.Add("Hosgeldiniz " + textBox1.Text);
                if (bakiye.Bakiye < 0)
                {
                    MessageBox.Show("Bakiyeniz bitti !");
                    goto son;
                }
                if (bakiye.Bakiye < 50)
                    MessageBox.Show("Bakiyeniz azalıyor !");
                bakiye.Bakiye -= trackBar1.Value; // bahis miktarına göre bakiyeyi azaltıyor
                label7.Text = bakiye.Bakiye.ToString();
                secim0.Visible = true;
                secim1.Visible = true;
                secim2.Visible = true;
                secim3.Visible = true;
                secim4.Visible = true;
                Degistir.Visible = true;
                trackBar1.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                baslat.Visible = false;
                listBox1.Visible = false;
                textBox1.Visible = false;
                label8.Visible = false;
                int[] yaz = Dagit.Gonderici(5);//random fonksiyonuna gönderiyoruz



                kart0.BackgroundImage = ımageList1.Images[yaz[0]]; //random fonksiyonundan gelen rastgele sayılara göre pictureboxlara kartları ekliyoruz
                kart0.BackgroundImageLayout = ImageLayout.Stretch; // kartları picturebox on içine sığdırıyor
                kart0.Name = Convert.ToString(yaz[0]);             //picturebox on adını kartın numarası yapıyoruz
                kart1.BackgroundImage = ımageList1.Images[yaz[1]];
                kart1.BackgroundImageLayout = ImageLayout.Stretch;
                kart1.Name = Convert.ToString(yaz[1]);
                kart2.BackgroundImage = ımageList1.Images[yaz[2]];
                kart2.BackgroundImageLayout = ImageLayout.Stretch;
                kart2.Name = Convert.ToString(yaz[2]);
                kart3.BackgroundImage = ımageList1.Images[yaz[3]];
                kart3.BackgroundImageLayout = ImageLayout.Stretch;
                kart3.Name = Convert.ToString(yaz[3]);
                kart4.BackgroundImage = ımageList1.Images[yaz[4]];
                kart4.BackgroundImageLayout = ImageLayout.Stretch;
                kart4.Name = Convert.ToString(yaz[4]);

                for (int i = 0; i < 5; i++)//kartların isimlerini label a yazdırıyoruz
                {
                    String isim = Kart.KartSayi(yaz[i]);
                    switch (i)
                    {
                        case 0: secim0.Text = isim; break;
                        case 1: secim1.Text = isim; break;
                        case 2: secim2.Text = isim; break;
                        case 3: secim3.Text = isim; break;
                        case 4: secim4.Text = isim; break;
                        default: break;
                    }
                }


            }
        son:
            if (bakiye.Bakiye < 0)
                Cikis_Click(sender, e);
        }

        private void Degistir_Click(object sender, EventArgs e)
        {
            sayac2++;   //kac tur oynandığını sayiyor
            secim0.Visible = false;
            secim1.Visible = false;
            secim2.Visible = false;
            secim3.Visible = false;
            secim4.Visible = false;
            Degistir.Visible = false;
            trackBar1.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            baslat.Visible = true;
            listBox1.Visible = true;

            int sayac = 0;
            if (secim0.Checked == false)//secili olmayan kartlari sayiyor
            {
                sayac++;
            }
            if (secim1.Checked == false)
            {
                sayac++;
            }
            if (secim2.Checked == false)
            {
                sayac++;
            }
            if (secim3.Checked == false)
            {
                sayac++;
            }
            if (secim4.Checked == false)
            {
                sayac++;
            }
        konum://olan bir kartın tekrar gelme durumunda yeni random kart istemek için buraya dönüyoruz
            int[] yaz = Dagit.Gonderici(sayac);

            for (int i = 0; i < sayac; i++)//değiştirilen kartların daha önce olup olmadığını kontrol ettiriyoruz
            {
                if (kart0.Name == Convert.ToString(yaz[i]))
                {
                    goto konum;
                }
                if (kart1.Name == Convert.ToString(yaz[i]))
                {
                    goto konum;
                }
                if (kart2.Name == Convert.ToString(yaz[i]))
                {
                    goto konum;
                }
                if (kart3.Name == Convert.ToString(yaz[i]))
                {
                    goto konum;
                }
                if (kart4.Name == Convert.ToString(yaz[i]))
                {
                    goto konum;
                }
            }
            int degistirsayac = 0;

            if (secim0.Checked == false)//degistirilmesi gereken kartlari degistiriyoruz
            {
                kart0.BackgroundImage = ımageList1.Images[yaz[degistirsayac]];//picturebox a degistirilecek kartı koyuyor
                kart0.BackgroundImageLayout = ImageLayout.Stretch;
                kart0.Name = Convert.ToString(yaz[degistirsayac]); //adını degistiriyor
                secim0.Text = Convert.ToString(Kart.KartSayi(yaz[degistirsayac]));//label a kartin degerini yaziyor
                degistirsayac++;
            }
            if (secim1.Checked == false)
            {
                kart1.BackgroundImage = ımageList1.Images[yaz[degistirsayac]];
                kart1.BackgroundImageLayout = ImageLayout.Stretch;
                kart1.Name = Convert.ToString(yaz[degistirsayac]);
                secim1.Text = Convert.ToString(Kart.KartSayi(yaz[degistirsayac]));
                degistirsayac++;
            }
            if (secim2.Checked == false)
            {
                kart2.BackgroundImage = ımageList1.Images[yaz[degistirsayac]];
                kart2.BackgroundImageLayout = ImageLayout.Stretch;
                kart2.Name = Convert.ToString(yaz[degistirsayac]);
                secim2.Text = Convert.ToString(Kart.KartSayi(yaz[degistirsayac]));
                degistirsayac++;
            }
            if (secim3.Checked == false)
            {
                kart3.BackgroundImage = ımageList1.Images[yaz[degistirsayac]];
                kart3.BackgroundImageLayout = ImageLayout.Stretch;
                kart3.Name = Convert.ToString(yaz[degistirsayac]);
                secim3.Text = Convert.ToString(Kart.KartSayi(yaz[degistirsayac]));
                degistirsayac++;
            }
            if (secim4.Checked == false)
            {
                kart4.BackgroundImage = ımageList1.Images[yaz[degistirsayac]];
                kart4.BackgroundImageLayout = ImageLayout.Stretch;
                kart4.Name = Convert.ToString(yaz[degistirsayac]);
                secim4.Text = Convert.ToString(Kart.KartSayi(yaz[degistirsayac]));
                degistirsayac++;
            }

            int[] gonderilecek = new int[5];//yeni bes kartimizin numarasini Pc class ına gonderilecek diziye atiyor
            gonderilecek[0] = Convert.ToInt32(kart0.Name);
            gonderilecek[1] = Convert.ToInt32(kart1.Name);
            gonderilecek[2] = Convert.ToInt32(kart2.Name);
            gonderilecek[3] = Convert.ToInt32(kart3.Name);
            gonderilecek[4] = Convert.ToInt32(kart4.Name);
            listBox1.Items.Clear();

            string a = Bilgisayar.Sirala(gonderilecek);//Pc class ına gonderiyoruz ve oradan string bir ifade donuyor
            listBox1.Items.Add(a);//sonucu ekrana yazdiriyoruz
            bakiye.BakiyeDurum(a, trackBar1.Value);//yeni bakiye durumumuzu hesaplatmak icin bahis miktarini gonderiyoruz
            label7.Text = Convert.ToString(bakiye.Bakiye);


            secim0.Checked = false;
            secim1.Checked = false;
            secim2.Checked = false;
            secim3.Checked = false;
            secim4.Checked = false;

        
            if (bakiye.Bakiye - ydkbky > 0)//ekran ciktilari
                liste.Items.Add(oyuncuad + " " + (bakiye.Bakiye - ydkbky) + " kazandınız !");

            else if (bakiye.Bakiye - ydkbky == 0) liste.Items.Add("Bakiyeniz degismedi !");

            else liste.Items.Add(oyuncuad + " " + (ydkbky - bakiye.Bakiye) + " kaybettiniz !");



        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label6.Text = trackBar1.Value.ToString();
        }

        private void Cikis_Click(object sender, EventArgs e)
        {
            MessageBox.Show(oyuncuad+ " " +bakiye.Bakiye + " Bakiyeniz " +sayac2+ " Tur Oynadiniz "+bakiye.Sonuc());//exit butonuna ait ekran ciktisi
            Form1.ActiveForm.Close();
        }

        private void hile_Click(object sender, EventArgs e)//parayi arttirmak icin bizim hile kodumuz
        {
            listBox1.Items.Clear();
            secim0.Visible = false;
            secim1.Visible = false;
            secim2.Visible = false;
            secim3.Visible = false;
            secim4.Visible = false;
            Degistir.Visible = false;
            trackBar1.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            baslat.Visible = true;
            listBox1.Visible = true;
            int[] yaz =new int[5];

            if (trackBar1.Value == 3)
            {
                yaz[0] = 8; yaz[1] = 9; yaz[2] = 10; yaz[3] = 11; yaz[4] = 12;

            }
            else if (trackBar1.Value == 1)
            {
                yaz[0] = 44; yaz[1] = 5; yaz[2] = 24; yaz[3] = 11; yaz[4] = 37;

            }
            else if (trackBar1.Value == 4)
            { 
                yaz[0]=51;yaz[1]=39;yaz[2]=40;yaz[3]=41;yaz[4]=42;
                
            }
            else if (trackBar1.Value == 5)
            {
                yaz[0]=1;yaz[1]=12;yaz[2]=13;yaz[3]=28;yaz[4]=42;
                
            }
            else {yaz[0]=51;yaz[1]=38;yaz[2]=25;yaz[3]=12;yaz[4]=50; 
                 }

            kart0.BackgroundImage = ımageList1.Images[yaz[0]];
            kart0.BackgroundImageLayout = ImageLayout.Stretch;
            kart0.Name = Convert.ToString(yaz[0]);
            secim0.Text = Convert.ToString(Kart.KartSayi(yaz[0]));
            kart1.BackgroundImage = ımageList1.Images[yaz[1]];
            kart1.BackgroundImageLayout = ImageLayout.Stretch;
            kart1.Name = Convert.ToString(yaz[1]);
            secim1.Text = Convert.ToString(Kart.KartSayi(yaz[1]));
            kart2.BackgroundImage = ımageList1.Images[yaz[2]];
            kart2.BackgroundImageLayout = ImageLayout.Stretch;
            kart2.Name = Convert.ToString(yaz[2]);
            secim2.Text = Convert.ToString(Kart.KartSayi(yaz[2]));
            kart3.BackgroundImage = ımageList1.Images[yaz[3]];
            kart3.BackgroundImageLayout = ImageLayout.Stretch;
            kart3.Name = Convert.ToString(yaz[3]);
            secim3.Text = Convert.ToString(Kart.KartSayi(yaz[3]));
            kart4.BackgroundImage = ımageList1.Images[yaz[4]];
            kart4.BackgroundImageLayout = ImageLayout.Stretch;
            kart4.Name = Convert.ToString(yaz[4]);
            secim4.Text = Convert.ToString(Kart.KartSayi(yaz[4]));

            yaz[0] = Convert.ToInt32(kart0.Name);
            yaz[1] = Convert.ToInt32(kart1.Name);
            yaz[2] = Convert.ToInt32(kart2.Name);
            yaz[3] = Convert.ToInt32(kart3.Name);
            yaz[4] = Convert.ToInt32(kart4.Name);
            string a = Bilgisayar.Sirala(yaz);
            listBox1.Items.Add(a);
            bakiye.BakiyeDurum(a, 5);
            label7.Text = Convert.ToString(bakiye.Bakiye);


            secim0.Checked = false;
            secim1.Checked = false;
            secim2.Checked = false;
            secim3.Checked = false;
            secim4.Checked = false;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            oyuncuad = textBox1.Text;
        }

        private void liste_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) //burası textboxun içine harf dışında bir karakter girilmemesi için
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

       




    }
}

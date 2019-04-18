using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje
{
  public abstract class Oyuncu_ //oyuncu class inin abstract class ı
    {
       private int bakiye;
       public int Bakiye 
       {
           get { return bakiye; }
           set
           {
               bakiye = value;
           }
       }
       public Oyuncu_(int bakiye)
       {
           Bakiye = bakiye;
       }
       public void BakiyeDurum(string sonuc,int deger) //degistirilen kartlarin durumuna gore bakiyemizi guncelliyoruz
       {
           if (sonuc == "royal")
           {
               Bakiye += deger * 250;
           }
           if (sonuc == "straight")
           {
               Bakiye += deger * 50;
           }
           if (sonuc == "kent")
           {
               Bakiye += deger * 4;
           }
           if (sonuc == "renk")
           {
               Bakiye += deger * 6;
           }
           if (sonuc == "kare")
           {
               Bakiye += deger * 25;
           }
           if (sonuc == "full")
           {
               Bakiye += deger * 9;
           }
           if (sonuc == "doper")
           {
               Bakiye += deger * 2;
           }
           if (sonuc == "uclu")
           {
               Bakiye += deger * 3;
           }
           if (sonuc == "job")
           {
               Bakiye += deger;
           }
           if (sonuc == "lose")
           {
               Bakiye -= deger * 0;
           }
       }
       public virtual string Sonuc()//override edilecek method
       {
           return "";
       }
    }
}

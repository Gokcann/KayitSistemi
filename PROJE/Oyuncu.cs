using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje
{
    class Oyuncu:Oyuncu_
    {
        public Oyuncu(int bakiye):base(bakiye)
       {
           
       }
        public override string Sonuc() //override edilmis hali
        {
            if (Bakiye > 100) return "Tebrikler Bugün Şanslısınız";
            else return "Şansınız yokmuş malesef :(";

        }
    }
}

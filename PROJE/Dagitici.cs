using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje
{
    class Dagitici : IDagitici//random sayilar ureten class 
    {
        Random rastgele = new Random();
        public int[] Gonderici(int a)
        {


            int[] sayilari = new int[a];
            for (int i = 0; i < a; i++)
            {
                int rast = rastgele.Next(0, 52);
                sayilari[i] = rast;
                for (int j = 0; j < i; j++)
                {
                    if (sayilari[j] == rast)
                        i--;
                }



            }
            return sayilari;
        }

    }
}

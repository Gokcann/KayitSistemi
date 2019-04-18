using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje
{

    class Pc
    {

        public string Sirala(int[] gelenkartlar) //gelen kartlari kucukten buyuge siralayan method
        {
            int yedek;
            for (int i = 0; i < 5; i++)
            {
                for (int j = i + 1; j < 5; j++)
                {
                    if (gelenkartlar[j] % 13 < gelenkartlar[i] % 13)
                    {
                        yedek = gelenkartlar[i];
                        gelenkartlar[i] = gelenkartlar[j];
                        gelenkartlar[j] = yedek;
                    }
                }
            }
            return RenkMi(gelenkartlar);
        }

        private string RenkMi(int[] gelenkartlar)//kartlarin hepsinin ayni renk olup olmadigini kontrol eden method
        {
            if (gelenkartlar[0] / 13 == gelenkartlar[1] / 13 && gelenkartlar[0] / 13 == gelenkartlar[2] / 13 && gelenkartlar[0] / 13 == gelenkartlar[3] / 13 && gelenkartlar[0] / 13 == gelenkartlar[4] / 13)
                return FlushRoyal(gelenkartlar);
            else return StraightFlush(gelenkartlar,false);
        }

        private string FlushRoyal(int[] gelenkartlar)//flushroyal durumunu kontrol eden method
        {
            if (gelenkartlar[0] % 13 == 8 && gelenkartlar[1] % 13 == 9 && gelenkartlar[2] % 13 == 10 && gelenkartlar[3] % 13 == 11 && gelenkartlar[4] % 13 == 12)
                return "royal";
            else return StraightFlush(gelenkartlar, true);

        }

        private string StraightFlush(int[] gelenkartlar, bool renk)//straightflush durumunu kontrol eden method
        {

            if ((((gelenkartlar[0] + 1) % 13 == gelenkartlar[1] % 13) && ((gelenkartlar[1] + 1) % 13 == gelenkartlar[2] % 13) && ((gelenkartlar[2] + 1) % 13 == gelenkartlar[3] % 13) && ((gelenkartlar[3] + 1) % 13 == gelenkartlar[4] % 13)) || ((gelenkartlar[0] + 12) % 13 == gelenkartlar[4] % 13) && ((gelenkartlar[1] + 11) % 13 == gelenkartlar[4] % 13) && ((gelenkartlar[2] + 10) % 13 == gelenkartlar[4] % 13) && ((gelenkartlar[3] + 9) % 13 == gelenkartlar[4] % 13))
            {
                if (renk == true) return "straight";
                else return "kent";//eger renkleri ayni degilse kent degerini donduruyor
            }
            else
            {
                if (renk == true) return "renk";//eger bir el renk ve sirali degilse el mecburen flush olmak zorunda
                else return Kare(gelenkartlar);
            }
        }

        private string Kare(int[] gelenkartlar)//four of the kind olma durumunu kontrol eden method
        {
            if ((gelenkartlar[0] % 13 == gelenkartlar[1] % 13 && gelenkartlar[0] % 13 == gelenkartlar[2] % 13 && gelenkartlar[0] % 13 == gelenkartlar[3] % 13) || (gelenkartlar[1] % 13 == gelenkartlar[2] % 13 && gelenkartlar[1] % 13 == gelenkartlar[3] % 13 && gelenkartlar[1] % 13 == gelenkartlar[4] % 13))
                return "kare";
            else return Full(gelenkartlar);
        }

        private string Full(int[] gelenkartlar)//full durumunu kontrol eden method
        {

            if ((gelenkartlar[0] % 13 == gelenkartlar[1] % 13 && gelenkartlar[0] % 13 == gelenkartlar[2] % 13 && gelenkartlar[3] % 13 == gelenkartlar[4] % 13) || (gelenkartlar[2] % 13 == gelenkartlar[3] % 13 && gelenkartlar[2] % 13 == gelenkartlar[4] % 13 && gelenkartlar[0] % 13 == gelenkartlar[1] % 13))
                return "full";
            else return Uclu(gelenkartlar);


        }

        private string Uclu(int[] gelenkartlar)//three of the kind durumunu kontrol eden method
        {
            if ((gelenkartlar[0] % 13 == gelenkartlar[1] % 13 && gelenkartlar[0] % 13 == gelenkartlar[2] % 13) || (gelenkartlar[1] % 13 == gelenkartlar[2] % 13 && gelenkartlar[1] % 13 == gelenkartlar[3] % 13) || (gelenkartlar[2] % 13 == gelenkartlar[3] % 13 && gelenkartlar[2] % 13 == gelenkartlar[4] % 13))
                return "uclu";
            else return Doper(gelenkartlar);
        }

        private string Doper(int[] gelenkartlar)//two pair durumunu kontrol eden method
        {

            if ((gelenkartlar[0] % 13 == gelenkartlar[1] % 13 && gelenkartlar[2] % 13 == gelenkartlar[3] % 13) || (gelenkartlar[0] % 13 == gelenkartlar[1] % 13 && gelenkartlar[3] % 13 == gelenkartlar[4] % 13) || (gelenkartlar[1] % 13 == gelenkartlar[2] % 13 && gelenkartlar[3] % 13 == gelenkartlar[4] % 13))
                return "doper";
            else return JoB(gelenkartlar);
        }

        private string JoB(int[] gelenkartlar)//jacks or better durumunu kontrol eden method
        {

            if ((gelenkartlar[0] % 13 == gelenkartlar[1] % 13 && gelenkartlar[0] % 13 > 8) || (gelenkartlar[1] % 13 == gelenkartlar[2] % 13 && gelenkartlar[1] % 13 > 8) || (gelenkartlar[2] % 13 == gelenkartlar[3] % 13 && gelenkartlar[2] % 13 > 8) || (gelenkartlar[3] % 13 == gelenkartlar[4] % 13 && gelenkartlar[3] % 13 > 8))
                return "job";
            else return "lose";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje
{
    class Kartlar
    {
        /*  public string[] Deste = { "H2", "H3", "H4", "H5", "H6", "H7", "H8", "H9", "H10", "HJ", "HQ", "HK", "HA",//kupa
                               "S2", "S3", "S4", "S5", "S6", "S7", "S8", "S9", "S10", "SJ", "SQ", "SK", "SA", //maça
                               "D2", "D3", "D4", "D5", "D6", "D7", "D8", "D9", "D10", "DJ", "DQ", "DK", "DA",//karo
                               "C2", "C3", "C4", "C5", "C6", "C7", "C8", "C9", "C10", "CJ", "CQ", "CK", "CA" };//sinek
    */
        public string KartSayi(int kart_numarasi)//gelen kartin numarasini alip adini donduruyoruz
        {
            int sayi = kart_numarasi % 13;
            int tur = kart_numarasi / 13;
            string donen="";
            switch (tur)
            {
                case 0: donen = "H"; break;
                case 1: donen = "S"; break;
                case 2: donen = "D"; break;
                case 3: donen = "C"; break;
                default: break;
            }
            switch (sayi)
            {
                case 0: donen += "2"; break;
                case 1: donen += "3"; break;
                case 2: donen += "4"; break;
                case 3: donen += "5"; break;
                case 4: donen += "6"; break;
                case 5: donen += "7"; break;
                case 6: donen += "8"; break;
                case 7: donen += "9"; break;
                case 8: donen += "10"; break;
                case 9: donen += "J"; break;
                case 10: donen += "Q"; break;
                case 11: donen += "K"; break;
                case 12: donen += "A"; break;
                default: break;
            }
            return donen;
        }
       
    }


}

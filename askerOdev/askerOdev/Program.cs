using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace askerOdev
{
    class Program
    {
        static void Main(string[] args)
        {
            Dosya.DosyaOlustur();
            //A takımı 1 yüzbaşı, 1 teğmen, 5 er
            Yuzbasi yuzbasiA = new Yuzbasi('A', new Point(1, 1));
            Tegmen tegmenA = new Tegmen('A', new Point(0, 0));
            Er er1A = new Er('A', new Point(3, 1));
            Er er2A = new Er('A', new Point(1, 2));
            Er er3A = new Er('A', new Point(1, 3));
            Er er4A = new Er('A', new Point(1, 4));
            Er er5A = new Er('A', new Point(2, 3));
            List<Asker> takimA = new List<Asker> { yuzbasiA, tegmenA, er1A, er2A, er3A, er4A, er5A };
            //B takımı 1 yüzbaşı, 2 teğmen, 4 er
            Yuzbasi yuzbasiB = new Yuzbasi('B', new Point(11, 11));
            Tegmen tegmen1B = new Tegmen('B', new Point(12, 12));
            Tegmen tegmen2B = new Tegmen('B', new Point(12, 13));
            Er er1B = new Er('B', new Point(13, 14));
            Er er2B = new Er('B', new Point(14, 12));
            Er er3B = new Er('B', new Point(11, 15));
            Er er4B = new Er('B', new Point(15, 15));
            List<Asker> takimB = new List<Asker> { yuzbasiB, tegmen1B, tegmen2B, er1B, er2B, er3B, er4B };

            int takimAi = 0;
            int maxAskerA = 7;
            int takimBi = 0;
            int maxAskerB = 7;
            int tur = 0;


            while (Meydan.takimAHayatta > 0 && Meydan.takimBHayatta > 0)
            {
                if (tur == 0) //a takımı oynar
                {
                    takimA[takimAi].OlasilikHesapla();
                    if (takimA[takimAi].hayatta == false)
                    {
                        takimA.Remove(takimA[takimAi]);
                        maxAskerA--;
                        if (maxAskerA == 0) maxAskerA = 1;
                    }
                    takimAi = (takimAi + 1) % maxAskerA;


                }
                else //b takımı oynar
                {


                    takimB[takimBi].OlasilikHesapla();
                    if (takimB[takimBi].hayatta == false)
                    {
                        takimB.Remove(takimB[takimBi]);
                        maxAskerB--;
                        if (maxAskerB == 0) maxAskerB = 1;

                    }
                    takimBi = (takimBi + 1) % maxAskerB;



                }
                tur = (tur + 1) % 2;

            }



            if (Meydan.takimAHayatta == 0)
            {
                Console.WriteLine("Takim A kaybetti..");
                Console.WriteLine("Takim B kazandi..");
            }
            else
            {
                Console.WriteLine("Takim B kaybetti..");
                Console.WriteLine("Takim A kazandi..");
            }
            Dosya.DosyayiKaydet();
            Console.ReadKey();
        }
    }
}

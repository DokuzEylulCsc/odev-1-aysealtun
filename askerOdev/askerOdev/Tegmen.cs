using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace askerOdev
{
    class Tegmen : Asker
    {
        //yukarı hareket %0-10
        //aşağı yürüme %10-20
        //sağa yürüme %20-30
        //sola yürüme %30-40
        //ateş etme %40-90
        //bekleme %90-100
        Random rastgele = new Random();
        double oran;

        public Tegmen(char takim, Point nokta) : base(takim, nokta)
        {
        }

        public override void OlasilikHesapla()
        {
            oran = rastgele.NextDouble();

            if (oran < 0.4)
            {
                HareketEt(oran);
            }

            if (oran > 0.4 && oran < 0.9)
            {
                AtesEt();
            }

            if (oran > 0.9)
            {
                Bekle();
            }
        }

        public override void HareketEt(double oran)
        {
            Dosya.DosyayaYaz(takim + " teğmen hareket ediyor");
            int gidilecekNoktaX = nokta.x;
            int gidilecekNoktaY = nokta.y;

            if (oran < 0.1 && nokta.y <= 14)
            {
                gidilecekNoktaY = nokta.y + 1;
            }

            if (oran > 0.1 && oran < 0.2 && nokta.y >= 1)
            {
                gidilecekNoktaY = nokta.y - 1;
            }

            if (oran > 0.2 && oran < 0.3 && nokta.x <= 14)
            {
                gidilecekNoktaX = nokta.x + 1;
            }

            if (oran > 0.3 && oran < 0.4 && nokta.x >= 1)
            {
                gidilecekNoktaX = nokta.x - 1;
            }
            if (Meydan.meydan[gidilecekNoktaX, gidilecekNoktaY] == null)
            {
                Meydan.meydan[nokta.x, nokta.y] = null;
                nokta.y = gidilecekNoktaY;
                nokta.x = gidilecekNoktaX;
                Meydan.meydan[nokta.x, nokta.y] = this;
            }
        }

        public override void AtesEt()
        {
            Console.WriteLine(takim + " teğmen ates ediyor");
            Dosya.DosyayaYaz(takim + " teğmen ates ediyor");


            double atesOran;
            atesOran = rastgele.NextDouble();
            int gidenCan = 0;
            if (atesOran < .33)
            {
                gidenCan = 10;
            }
            if (atesOran > .33 && atesOran < .66)
            {
                gidenCan = 20;
            }

            if (atesOran > .66)
            {
                gidenCan = 25;
            }
            if (this.nokta.y + 2 <= 15 && Meydan.meydan[this.nokta.x, this.nokta.y + 2] != null && Meydan.meydan[this.nokta.x, this.nokta.y + 2].takim != this.takim)
            {
                Meydan.meydan[this.nokta.x, this.nokta.y + 2].saglikMiktari -= gidenCan;
                Dosya.DosyayaYaz(Meydan.meydan[this.nokta.x, this.nokta.y+2].saglikMiktari.ToString());
                if (Meydan.meydan[this.nokta.x, this.nokta.y + 2].saglikMiktari <= 0)
                {
                    Meydan.meydan[this.nokta.x, this.nokta.y + 2].hayatta = false;

                    Dosya.DosyayaYaz(Meydan.meydan[this.nokta.x, this.nokta.y + 2].takim.ToString() +
                        Meydan.meydan[this.nokta.x, this.nokta.y + 2].GetType().Name.ToString() + " öldü");
                    Console.WriteLine(Meydan.meydan[this.nokta.x, this.nokta.y + 2].takim.ToString() +
                        Meydan.meydan[this.nokta.x, this.nokta.y + 2].GetType().Name.ToString() + " öldü");

                    if (Meydan.meydan[this.nokta.x, this.nokta.y + 2].takim == 'B')
                    {
                        Meydan.takimBHayatta--;
                    }
                    else
                    {
                        Meydan.takimAHayatta--;
                    }
                    Meydan.meydan[this.nokta.x, this.nokta.y + 2] = null; 
                }
                return;
            }
            else if (this.nokta.x + 2 <= 15 && Meydan.meydan[this.nokta.x + 2, this.nokta.y] != null && Meydan.meydan[this.nokta.x + 2, this.nokta.y].takim != this.takim)
            {
                Meydan.meydan[this.nokta.x + 2, this.nokta.y].saglikMiktari -= gidenCan;
                Dosya.DosyayaYaz(Meydan.meydan[this.nokta.x + 2, this.nokta.y].saglikMiktari.ToString());
                if (Meydan.meydan[this.nokta.x + 2, this.nokta.y].saglikMiktari <= 0)
                {
                    Meydan.meydan[this.nokta.x + 2, this.nokta.y].hayatta = false;

                    Dosya.DosyayaYaz(Meydan.meydan[this.nokta.x+2, this.nokta.y].takim.ToString() +
                        Meydan.meydan[this.nokta.x+2, this.nokta.y ].GetType().Name.ToString() + " öldü");
                    Console.WriteLine(Meydan.meydan[this.nokta.x + 2, this.nokta.y].takim.ToString() +
                        Meydan.meydan[this.nokta.x + 2, this.nokta.y].GetType().Name.ToString() + " öldü");

                    if (Meydan.meydan[this.nokta.x+2, this.nokta.y].takim == 'B')
                    {
                        Meydan.takimBHayatta--;
                    }
                    else
                    {
                        Meydan.takimAHayatta--;
                    }
                    Meydan.meydan[this.nokta.x + 2, this.nokta.y] = null;
                   
                }
                return;
            }
            else if (this.nokta.y - 2 >= 0 && Meydan.meydan[this.nokta.x, this.nokta.y - 2] != null && Meydan.meydan[this.nokta.x, this.nokta.y - 2].takim != this.takim)
            {
                Meydan.meydan[this.nokta.x, this.nokta.y - 2].saglikMiktari -= gidenCan;
                Dosya.DosyayaYaz(Meydan.meydan[this.nokta.x , this.nokta.y-2].saglikMiktari.ToString());
                if (Meydan.meydan[this.nokta.x, this.nokta.y - 2].saglikMiktari <= 0)
                {
                    Meydan.meydan[this.nokta.x, this.nokta.y - 2].hayatta = false;

                    Dosya.DosyayaYaz(Meydan.meydan[this.nokta.x, this.nokta.y - 2].takim.ToString() +
                        Meydan.meydan[this.nokta.x, this.nokta.y - 2].GetType().Name.ToString() + " öldü");
                    Console.WriteLine(Meydan.meydan[this.nokta.x, this.nokta.y - 2].takim.ToString() +
                       Meydan.meydan[this.nokta.x, this.nokta.y - 2].GetType().Name.ToString() + " öldü");

                    if (Meydan.meydan[this.nokta.x, this.nokta.y -2].takim == 'B')
                    {
                        Meydan.takimBHayatta--;
                    }
                    else
                    {
                        Meydan.takimAHayatta--;
                    }
                    Meydan.meydan[this.nokta.x, this.nokta.y - 2] = null;
                  
                }
                return;
            }
            else if (this.nokta.x - 2 >= 0 && Meydan.meydan[this.nokta.x - 2, this.nokta.y] != null && Meydan.meydan[this.nokta.x - 2, this.nokta.y].takim != this.takim)
            {
                Meydan.meydan[this.nokta.x - 2, this.nokta.y].saglikMiktari -= gidenCan;
                Dosya.DosyayaYaz(Meydan.meydan[this.nokta.x -2, this.nokta.y].saglikMiktari.ToString());
                if (Meydan.meydan[this.nokta.x - 2, this.nokta.y].saglikMiktari <= 0)
                {
                    Meydan.meydan[this.nokta.x - 2, this.nokta.y].hayatta = false;

                    Dosya.DosyayaYaz(Meydan.meydan[this.nokta.x-2, this.nokta.y].takim.ToString() +
                        Meydan.meydan[this.nokta.x-2, this.nokta.y ].GetType().Name.ToString() + " öldü");

                    Console.WriteLine(Meydan.meydan[this.nokta.x - 2, this.nokta.y].takim.ToString() +
                        Meydan.meydan[this.nokta.x - 2, this.nokta.y].GetType().Name.ToString() + " öldü");

                    if (Meydan.meydan[this.nokta.x-2, this.nokta.y].takim == 'B')
                    {
                        Meydan.takimBHayatta--;
                    }
                    else
                    {
                        Meydan.takimAHayatta--;
                    }
                    Meydan.meydan[this.nokta.x - 2, this.nokta.y] = null;
                    
                }
                return;
            }
        }

        public override void Bekle()
        {
            Dosya.DosyayaYaz(takim + " Tegmen bekliyor");
        }

    }
}

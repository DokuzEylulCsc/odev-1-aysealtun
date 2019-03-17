using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace askerOdev
{
    class Yuzbasi : Asker
    {
        //yukarı hareket %0-5
        //aşağı yürüme %5-10
        //sağa yürüme %10-15
        //sola yürüme %15-20
        //sağ yukarı çapraz hareket %20-25
        //sol yukarı çapraz yürüme %25-30
        //sağ aşağı çapraz yürüme %30-35
        //sol aşağı çapraz yürüme %35-40
        //ateş etme %40-97
        //bekleme %97-100
        Random rastgele = new Random();
        double oran;

        public Yuzbasi(char takim, Point nokta) : base(takim, nokta)
        {
        }

        public override void OlasilikHesapla()
        {
            oran = rastgele.NextDouble();

            if (oran < 0.4)
            {
                HareketEt(oran);
            }

            if (oran > 0.4 && oran < 0.97)
            {
                AtesEt();
            }

            if (oran > 0.97)
            {
                Bekle();
            }
        }

        public override void HareketEt(double oran)
        {
            Dosya.DosyayaYaz(takim + " yuzbasi hareket ediyor");
            int gidilecekNoktaX = nokta.x;
            int gidilecekNoktaY = nokta.y;


            if (oran < 0.05 && nokta.y <= 14)
            {
                gidilecekNoktaY = nokta.y + 1;

            }

            if (oran > 0.05 && oran < 0.1 && nokta.y >= 1)
            {
                gidilecekNoktaY = nokta.y - 1;
            }

            if (oran > 0.1 && oran < 0.15 && nokta.x <= 14)
            {
                gidilecekNoktaX = nokta.x + 1;
            }

            if (oran > 0.15 && oran < 0.2 && nokta.x >= 1)
            {
                gidilecekNoktaX = nokta.x - 1;
            }

            if (oran > 0.2 && oran < 0.25 && nokta.y <= 14 && nokta.x <= 14)
            {
                gidilecekNoktaY = nokta.y + 1;
                gidilecekNoktaX = nokta.x + 1;
            }

            if (oran > 0.25 && oran < 0.3 && nokta.x >= 1 && nokta.y <= 14)
            {
                gidilecekNoktaX = nokta.x - 1;
                gidilecekNoktaY = nokta.y + 1;
            }

            if (oran > 0.3 && oran < 0.35 && nokta.x <= 14 && nokta.y >= 1)
            {
                gidilecekNoktaX = nokta.x + 1;
                gidilecekNoktaY = nokta.y - 1;
            }

            if (oran > 0.35 && oran < 0.4 && nokta.x >= 1 && nokta.y >= 1)
            {
                gidilecekNoktaX = nokta.x - 1;
                gidilecekNoktaY = nokta.y - 1;
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
            Console.WriteLine(takim + " yuzbasi ateş ediyor");
           Dosya.DosyayaYaz(takim + " yuzbasi ateş ediyor");

            double atesOran;
            atesOran = rastgele.NextDouble();
            int gidenCan = 0;
            if (atesOran < .33)
            {
                gidenCan = 15;
            }
            if (atesOran > .33 && atesOran < .66)
            {
                gidenCan = 25;
            }

            if (atesOran > .66)
            {
                gidenCan = 40;
            }
            if (this.nokta.y + 3 <= 15 && Meydan.meydan[this.nokta.x, this.nokta.y + 3] != null && Meydan.meydan[this.nokta.x, this.nokta.y + 3].takim !=this.takim)
            {
                Meydan.meydan[this.nokta.x, this.nokta.y + 3].saglikMiktari -= gidenCan;
                Dosya.DosyayaYaz(Meydan.meydan[this.nokta.x , this.nokta.y+3].saglikMiktari.ToString());
                if (Meydan.meydan[this.nokta.x, this.nokta.y + 3].saglikMiktari <= 0)
                {
                    Meydan.meydan[this.nokta.x, this.nokta.y + 3].hayatta = false;
                    Dosya.DosyayaYaz(Meydan.meydan[this.nokta.x, this.nokta.y + 3].takim.ToString() +
                        Meydan.meydan[this.nokta.x, this.nokta.y + 3].GetType().Name.ToString() + " öldü");
                    Console.WriteLine(Meydan.meydan[this.nokta.x, this.nokta.y + 3].takim.ToString() +
                        Meydan.meydan[this.nokta.x, this.nokta.y + 3].GetType().Name.ToString() + " öldü");
                    if (Meydan.meydan[this.nokta.x, this.nokta.y +3].takim == 'B')
                    {
                        Meydan.takimBHayatta--;
                    }
                    else
                    {
                        Meydan.takimAHayatta--;
                    }
                    Meydan.meydan[this.nokta.x, this.nokta.y + 3] = null;
                   
                }
                return;
            }
            else if (this.nokta.x + 3 <= 15 && Meydan.meydan[this.nokta.x + 3, this.nokta.y] != null && Meydan.meydan[this.nokta.x + 3, this.nokta.y].takim !=this.takim)
            {
                Meydan.meydan[this.nokta.x + 3, this.nokta.y].saglikMiktari -= gidenCan;
                Dosya.DosyayaYaz(Meydan.meydan[this.nokta.x + 3, this.nokta.y].saglikMiktari.ToString());
                if (Meydan.meydan[this.nokta.x + 3, this.nokta.y].saglikMiktari <= 0)
                {
                    Meydan.meydan[this.nokta.x + 3, this.nokta.y].hayatta = false;
                    Dosya.DosyayaYaz(Meydan.meydan[this.nokta.x+3, this.nokta.y ].takim.ToString() +
                        Meydan.meydan[this.nokta.x+3, this.nokta.y ].GetType().Name.ToString() + " öldü");
                    Console.WriteLine(Meydan.meydan[this.nokta.x + 3, this.nokta.y].takim.ToString() +
                        Meydan.meydan[this.nokta.x + 3, this.nokta.y].GetType().Name.ToString() + " öldü");
                    if (Meydan.meydan[this.nokta.x + 3, this.nokta.y].takim == 'B')
                    {
                        Meydan.takimBHayatta--;
                    }
                    else
                    {
                        Meydan.takimAHayatta--;
                    }
                    Meydan.meydan[this.nokta.x + 3, this.nokta.y] = null;
                 
                }
                return;
            }
            else if (this.nokta.y - 3 >= 0 && Meydan.meydan[this.nokta.x, this.nokta.y - 3] != null && Meydan.meydan[this.nokta.x, this.nokta.y - 3].takim != this.takim)
            {
                Meydan.meydan[this.nokta.x, this.nokta.y - 3].saglikMiktari -= gidenCan;
                Dosya.DosyayaYaz(Meydan.meydan[this.nokta.x , this.nokta.y-3].saglikMiktari.ToString());
                if (Meydan.meydan[this.nokta.x, this.nokta.y - 3].saglikMiktari <= 0)
                {
                    Meydan.meydan[this.nokta.x, this.nokta.y - 3].hayatta = false;
                    Dosya.DosyayaYaz(Meydan.meydan[this.nokta.x, this.nokta.y -3].takim.ToString() +
                        Meydan.meydan[this.nokta.x, this.nokta.y -3].GetType().Name.ToString() + " öldü");
                    Console.WriteLine(Meydan.meydan[this.nokta.x, this.nokta.y - 3].takim.ToString() +
                        Meydan.meydan[this.nokta.x, this.nokta.y - 3].GetType().Name.ToString() + " öldü");
                    if (Meydan.meydan[this.nokta.x, this.nokta.y-3].takim == 'B')
                    {
                        Meydan.takimBHayatta--;
                    }
                    else
                    {
                        Meydan.takimAHayatta--;
                    }
                    Meydan.meydan[this.nokta.x, this.nokta.y - 3] = null;
                   
                }
                return;
            }
            else if (this.nokta.x - 3 >= 0 && Meydan.meydan[this.nokta.x - 3, this.nokta.y] != null && Meydan.meydan[this.nokta.x - 3, this.nokta.y].takim != this.takim)
            {
                Meydan.meydan[this.nokta.x - 3, this.nokta.y].saglikMiktari -= gidenCan;
                Dosya.DosyayaYaz(Meydan.meydan[this.nokta.x -3, this.nokta.y].saglikMiktari.ToString());
                if (Meydan.meydan[this.nokta.x - 3, this.nokta.y].saglikMiktari <= 0)
                {
                    Meydan.meydan[this.nokta.x - 3, this.nokta.y].hayatta = false;

                    Dosya.DosyayaYaz(Meydan.meydan[this.nokta.x-3, this.nokta.y ].takim.ToString() +
                        Meydan.meydan[this.nokta.x-3, this.nokta.y].GetType().Name.ToString() + " öldü");
                    Console.WriteLine(Meydan.meydan[this.nokta.x - 3, this.nokta.y].takim.ToString() +
                        Meydan.meydan[this.nokta.x - 3, this.nokta.y].GetType().Name.ToString() + " öldü");

                    if (Meydan.meydan[this.nokta.x-3, this.nokta.y].takim == 'B')
                    {
                        Meydan.takimBHayatta--;
                    }
                    else
                    {
                        Meydan.takimAHayatta--;
                    }
                    Meydan.meydan[this.nokta.x - 3, this.nokta.y] = null; 
                }
                return;
            }
        }

        public override void Bekle()
        {
            Dosya.DosyayaYaz(takim + " Yuzbasi bekliyor");
        }

    }
}

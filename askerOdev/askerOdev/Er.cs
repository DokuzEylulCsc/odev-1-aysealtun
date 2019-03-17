using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace askerOdev
{
    class Er : Asker
    {
        //yukarı hareket %0-25
        //aşağı yürüme %25-50
        //ateş etme %50-90
        //bekleme %90-100
        Random rastgele = new Random();
        double oran;

        public Er(char takim, Point nokta) : base(takim, nokta)
        {
        }

        public override void OlasilikHesapla()
        {
            oran = rastgele.NextDouble();

            if (oran < 0.5)
            {
                HareketEt(oran);
            }

            if (oran > 0.5 && oran < 0.9)
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
           Dosya.DosyayaYaz(takim + " Er hareket ediyor");
            int gidilecekNokta;

            if (oran < 0.25 && nokta.y <= 14)
            {
                gidilecekNokta = nokta.y + 1;
                if (Meydan.meydan[nokta.x, gidilecekNokta] == null)
                {
                    Meydan.meydan[nokta.x, nokta.y] = null;
                    nokta.y = gidilecekNokta;
                    Meydan.meydan[nokta.x, nokta.y] = this;

                }
            }

            if (oran > 0.25 && oran < 0.5 && nokta.y >= 1)
            {
                gidilecekNokta = nokta.y - 1;
                if (Meydan.meydan[nokta.x, gidilecekNokta] == null)
                {
                    Meydan.meydan[nokta.x, nokta.y] = null;
                    nokta.y = gidilecekNokta;
                    Meydan.meydan[nokta.x, nokta.y] = this;
                }
            }

        }

        public override void AtesEt()
        {
            //ates sırası: yukarı - sağ - aşağı - sola
            Dosya.DosyayaYaz(takim + " Er ates ediyor");
            Console.WriteLine(takim + " Er ates ediyor");

            int gidenCan = 0;
            double atesOran;
            atesOran = rastgele.NextDouble();

            if (atesOran < .33)
            {
                gidenCan = 5;
            }
            if (atesOran > .33 && atesOran < .66)
            {
                gidenCan = 10;
            }

            if (atesOran > .66)
            {
                gidenCan = 15;
            }

            if (this.nokta.y + 1 <= 15 && Meydan.meydan[this.nokta.x, this.nokta.y + 1] != null && Meydan.meydan[this.nokta.x, this.nokta.y + 1].takim != this.takim)
            {
                Meydan.meydan[this.nokta.x, this.nokta.y + 1].saglikMiktari -= gidenCan;
                Dosya.DosyayaYaz(Meydan.meydan[this.nokta.x, this.nokta.y + 1].saglikMiktari.ToString());
                if (Meydan.meydan[this.nokta.x, this.nokta.y + 1].saglikMiktari <= 0)
                {
                    Meydan.meydan[this.nokta.x, this.nokta.y + 1].hayatta = false;
                    Dosya.DosyayaYaz(Meydan.meydan[this.nokta.x, this.nokta.y + 1].takim.ToString() +
                        Meydan.meydan[this.nokta.x, this.nokta.y + 1].GetType().Name.ToString() + " öldü");
                    Console.WriteLine(Meydan.meydan[this.nokta.x, this.nokta.y + 1].takim.ToString() +
                       Meydan.meydan[this.nokta.x, this.nokta.y + 1].GetType().Name.ToString() + " öldü");

                    if (Meydan.meydan[this.nokta.x, this.nokta.y + 1].takim == 'B')
                    {
                        Meydan.takimBHayatta--;
                    }
                    else
                    {
                        Meydan.takimAHayatta--;
                    }
                    Meydan.meydan[this.nokta.x, this.nokta.y + 1] = null;
                    

                }
                return;
            }
            else if (this.nokta.x + 1 <= 15 && Meydan.meydan[this.nokta.x + 1, this.nokta.y] != null && Meydan.meydan[this.nokta.x + 1, this.nokta.y].takim != this.takim)
            {
                Meydan.meydan[this.nokta.x + 1, this.nokta.y].saglikMiktari -= gidenCan;
                Dosya.DosyayaYaz(Meydan.meydan[this.nokta.x + 1, this.nokta.y].saglikMiktari.ToString());
                if (Meydan.meydan[this.nokta.x + 1, this.nokta.y].saglikMiktari <= 0)
                {
                    Meydan.meydan[this.nokta.x + 1, this.nokta.y].hayatta = false;
                    Dosya.DosyayaYaz(Meydan.meydan[this.nokta.x+1, this.nokta.y ].takim.ToString() +
                        Meydan.meydan[this.nokta.x+1, this.nokta.y ].GetType().Name.ToString() + " öldü");

                    Console.WriteLine(Meydan.meydan[this.nokta.x + 1, this.nokta.y].takim.ToString() +
                        Meydan.meydan[this.nokta.x + 1, this.nokta.y].GetType().Name.ToString() + " öldü");
                    if (Meydan.meydan[this.nokta.x + 1, this.nokta.y].takim == 'B')
                    {
                        Meydan.takimBHayatta--;
                    }
                    else
                    {
                        Meydan.takimAHayatta--;
                    }
                    Meydan.meydan[this.nokta.x + 1, this.nokta.y] = null;

                    
                }
                return;
            }
            else if (this.nokta.y - 1 >= 0 && Meydan.meydan[this.nokta.x, this.nokta.y - 1] != null && Meydan.meydan[this.nokta.x, this.nokta.y - 1].takim != this.takim)
            {
                Meydan.meydan[this.nokta.x, this.nokta.y - 1].saglikMiktari -= gidenCan;
                Dosya.DosyayaYaz(Meydan.meydan[this.nokta.x , this.nokta.y-1].saglikMiktari.ToString());
                if (Meydan.meydan[this.nokta.x, this.nokta.y - 1].saglikMiktari <= 0)
                {
                    Meydan.meydan[this.nokta.x, this.nokta.y - 1].hayatta = false;
                    Dosya.DosyayaYaz(Meydan.meydan[this.nokta.x, this.nokta.y -1].takim.ToString() +
                        Meydan.meydan[this.nokta.x, this.nokta.y -1].GetType().Name.ToString() + " öldü");

                    Console.WriteLine(Meydan.meydan[this.nokta.x, this.nokta.y - 1].takim.ToString() +
                        Meydan.meydan[this.nokta.x, this.nokta.y - 1].GetType().Name.ToString() + " öldü");
                    if (Meydan.meydan[this.nokta.x, this.nokta.y - 1].takim == 'B')
                    {
                        Meydan.takimBHayatta--;
                    }
                    else
                    {
                        Meydan.takimAHayatta--;
                    }
                    Meydan.meydan[this.nokta.x, this.nokta.y + -1] = null;

                   
                }
                return;
            }
            else if (this.nokta.x - 1 >= 0 && Meydan.meydan[this.nokta.x - 1, this.nokta.y] != null && Meydan.meydan[this.nokta.x - 1, this.nokta.y].takim != this.takim )
            {
                Meydan.meydan[this.nokta.x - 1, this.nokta.y].saglikMiktari -= gidenCan;
                Dosya.DosyayaYaz(Meydan.meydan[this.nokta.x -1, this.nokta.y].saglikMiktari.ToString());
                if (Meydan.meydan[this.nokta.x - 1, this.nokta.y].saglikMiktari <= 0)
                {
                    Meydan.meydan[this.nokta.x - 1, this.nokta.y].hayatta = false;
                    Dosya.DosyayaYaz(Meydan.meydan[this.nokta.x-1, this.nokta.y ].takim.ToString() +
                        Meydan.meydan[this.nokta.x-1, this.nokta.y ].GetType().Name.ToString() + " öldü");

                    Console.WriteLine(Meydan.meydan[this.nokta.x - 1, this.nokta.y].takim.ToString() +
                        Meydan.meydan[this.nokta.x - 1, this.nokta.y].GetType().Name.ToString() + " öldü");

                    if (Meydan.meydan[this.nokta.x-1, this.nokta.y ].takim == 'B')
                    {
                        Meydan.takimBHayatta--;
                    }
                    else
                    {
                        Meydan.takimAHayatta--;
                    }
                    Meydan.meydan[this.nokta.x - 1, this.nokta.y] = null;

                }
                return;
            }
        }

        public override void Bekle()
        {
           Dosya.DosyayaYaz(takim + " Er bekliyor");
        }
    }
}

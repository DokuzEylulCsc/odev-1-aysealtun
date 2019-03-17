using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace askerOdev
{
    class Asker
    {
        public bool hayatta=true; //hayatta ya da ölü
        public char takim;
        public int saglikMiktari = 100;
        public Point nokta;

        public Asker(char takim,Point nokta)
        {
            this.takim = takim;
            this.nokta = nokta;
            Meydan.meydan[nokta.x ,nokta.y] = this;
        }
        public virtual void OlasilikHesapla()
        {

        }
        public virtual void Bekle()
        {

        }

        public virtual void HareketEt(double oran)
        {

        }

        public virtual void AtesEt()
        {

        }


    }
  
}

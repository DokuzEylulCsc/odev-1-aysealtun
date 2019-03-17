using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace askerOdev
{
    class Meydan
    {
        public static Asker[,] meydan = new Asker[16, 16];
        //meydan[x][y] = true ise dolu false ise boştur


        public static int takimAHayatta = 7;
        public static int takimBHayatta = 7;
    }

    class Point
    {
        public int x;
        public int y;

        public Point(int x,int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}

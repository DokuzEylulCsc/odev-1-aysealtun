using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace askerOdev
{
    class Dosya
    {
        static string dosya_yolu ="oyunsonucu.txt";
        static FileStream fs;
        static StreamWriter sw;
        public static void DosyaOlustur()
        {
             fs = new FileStream(dosya_yolu, FileMode.Create, FileAccess.Write);
            sw = new StreamWriter(fs);

        }
        public static void DosyayaYaz(string olay)
        {
            sw.WriteLine(olay);

        }
        public static void DosyayiKaydet()
        {
            sw.Flush();
            sw.Close();
            fs.Close();
        }
       
           
    }
}

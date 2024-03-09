using Deneme.Abstracts;
using Deneme.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme
{
    public abstract class Kitap
    {
        public string ISBN { get; set; }
        public string Baslik { get; set; }
        public string YazarAdi { get; set; }
        public string YazarSoyadi { get; set; }
        public ushort YayinYili { get; set; }
        public Durum KitapDurum { get; set; }

        protected Kitap(string ıSBN, string baslik, string yazarAdi, string yazarSoyadi, ushort yayinYili)
        {
            ISBN = ıSBN;
            Baslik = baslik;
            YazarAdi = yazarAdi;
            YazarSoyadi = yazarSoyadi;
            YayinYili = yayinYili;

            KitapDurum = Durum.Uygun; //default olarak kurucu methodumuzda uygun olarak ayarlansin.
        }

        
        
        



    }
}

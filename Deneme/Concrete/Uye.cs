using Deneme.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme.Concrete
{
    public class Uye : IUye
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public byte UyeNumarasi { get; set; }

        public Uye(string ad, string soyad, byte uyeNumarasi)
        {
            Ad = ad;
            Soyad = soyad;
            UyeNumarasi = uyeNumarasi;
        }

        public List<Kitap> OduncKitaplar { get; set; } = new List<Kitap>();

        public void OduncAl(Kitap kitap)
        {
            OduncKitaplar.Add(kitap);
            kitap.KitapDurum = Durum.Uyede;
        }

        public void TeslimEt(Kitap kitap)
        {
            OduncKitaplar.Remove(kitap);
            kitap.KitapDurum = Durum.Uygun;
        }

        
    }
}

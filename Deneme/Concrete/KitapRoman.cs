using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme.Concrete
{
    public class KitapRoman : Kitap
    {
        public KitapRoman(string ıSBN, string baslik, string yazarAdi, string yazarSoyadi, ushort yayinYili) : base(ıSBN, baslik, yazarAdi, yazarSoyadi, yayinYili)
        {

        }
    }
}

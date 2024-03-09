using Deneme.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme.Concrete
{
    public class KitapBilim : Kitap
    {
        public KitapBilim(string ıSBN, string baslik, string yazarAdi, string yazarSoyadi, ushort yayinYili) : base(ıSBN, baslik, yazarAdi, yazarSoyadi, yayinYili)
        {

        }
    }
}

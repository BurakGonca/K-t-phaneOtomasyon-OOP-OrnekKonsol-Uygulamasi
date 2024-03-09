using Deneme.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme.Abstracts
{
    public interface IUye
    {
        
        string Ad { get; set; }
        string Soyad { get; set; }
        byte UyeNumarasi { get; set; }

        List<Kitap> OduncKitaplar { get; set; }

        void OduncAl(Kitap kitap);
        void TeslimEt(Kitap kitap);



    }
}

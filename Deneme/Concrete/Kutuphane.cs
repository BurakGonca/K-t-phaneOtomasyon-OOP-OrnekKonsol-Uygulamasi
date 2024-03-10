using Deneme.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Deneme.Concrete
{
    public class Kutuphane
    {

        public List<Kitap> kitaplar { get; set; } = new List<Kitap>();
        public List<Uye> uyeler { get; set; } = new List<Uye>();

        public List<KitapBilim> bilimKitaplari { get; set; } = new List<KitapBilim>();
        public List<KitapRoman> romanKitaplari { get; set; } = new List<KitapRoman>();
        public List<KitapTarih> tarihKitaplari { get; set; } = new List<KitapTarih>();
        public List<KitapDiger> digerKitaplar { get; set; } = new List<KitapDiger>();


        public void KitapListeleriniBirlestir()
        {
            kitaplar.AddRange(bilimKitaplari);
            kitaplar.AddRange(romanKitaplari);
            kitaplar.AddRange(tarihKitaplari);
            kitaplar.AddRange(digerKitaplar);
        }




        public void KitapEkle(string tur)
        {
            Kitap kitap;

            Console.Write("ISBN No: ");
            string isbn = Console.ReadLine();
            Console.Write("Baslik: ");
            string baslik = Console.ReadLine();
            Console.Write("YazarAdi: ");
            string yazarAdi = Console.ReadLine();
            Console.Write("YazarSoyadi: ");
            string yazarSoyadi = Console.ReadLine();
            Console.Write("YayinYili: ");
            ushort yayinYili = ushort.Parse(Console.ReadLine());

            switch (tur.ToLower())
            {
                case "bilim":
                    kitap = new KitapBilim(isbn, baslik, yazarAdi, yazarSoyadi, yayinYili);
                    bilimKitaplari.Add((KitapBilim)kitap);
                    kitaplar.Add(kitap);
                    break;
                case "tarih":
                    kitap = new KitapTarih(isbn, baslik, yazarAdi, yazarSoyadi, yayinYili);
                    tarihKitaplari.Add((KitapTarih)kitap);
                    kitaplar.Add(kitap);
                    break;
                case "roman":
                    kitap = new KitapRoman(isbn, baslik, yazarAdi, yazarSoyadi, yayinYili);
                    romanKitaplari.Add((KitapRoman)kitap);
                    kitaplar.Add(kitap);
                    break;
                default:
                    kitap = new KitapDiger(isbn, baslik, yazarAdi, yazarSoyadi, yayinYili);
                    digerKitaplar.Add((KitapDiger)kitap);
                    kitaplar.Add(kitap);
                    Console.WriteLine("Tür belirtilmediği için diğer kitaplar listesine kaydedildi.");
                    break;
            }

            Console.WriteLine("Kitap sisteme başarıyla kaydedildi.");
        }


        public void KitapSil()
        {
            Console.WriteLine("Silmek istediginiz kitap icin;");
            Console.Write("ISBN No: ");
            var isbnNo = Console.ReadLine();
            var bulunanKitap = kitaplar.FirstOrDefault(k => k.ISBN == isbnNo);
            if (bulunanKitap != null)
            {
                kitaplar.Remove(bulunanKitap);
                Console.WriteLine("Kitap genel listeden basariyla silinmistir");
            }
            else if (bulunanKitap == bilimKitaplari.FirstOrDefault(b => b.ISBN == isbnNo))
            {
                bilimKitaplari.Remove((KitapBilim)bulunanKitap);
                Console.WriteLine("Kitap Bilim Kitaplari listesinden basariyla silinmistir");
            }
            else if (bulunanKitap == tarihKitaplari.FirstOrDefault(t => t.ISBN == isbnNo))
            {
                tarihKitaplari.Remove((KitapTarih)bulunanKitap);
                Console.WriteLine("Kitap Tarih Kitaplari listesinden basariyla silinmistir");
            }
            else if (bulunanKitap == romanKitaplari.FirstOrDefault(r => r.ISBN == isbnNo))
            {
                romanKitaplari.Remove((KitapRoman)bulunanKitap);
                Console.WriteLine("Kitap Roman Kitaplari listesinden basariyla silinmistir");
            }
            else
                Console.WriteLine("Bu ISBN no ile kayitli kitap bulunmamaktadir. Tekrar Deneyiniz.");

        }

        public void UyeEkle()
        {
            Console.WriteLine("\n--- Uye Ekle ---");
            Console.Write("Uye No: ");
            byte uyeNo = byte.Parse(Console.ReadLine());
            Console.Write("Ad: ");
            string ad = Console.ReadLine();
            Console.Write("Soyad: ");
            string soyad = Console.ReadLine();

            Uye uye = new Uye(ad, soyad, uyeNo);
            uyeler.Add(uye);
            Console.WriteLine($"{uye.UyeNumarasi} no'lu üye başarıyla kaydedilmiştir.");
        }


        public void UyeSil()
        {
            Console.WriteLine("\n--- Uye Sil ---");
            Console.Write("Uye No: ");
            byte no = byte.Parse(Console.ReadLine());
            var silinecekUye = uyeler.FirstOrDefault(u => u.UyeNumarasi == no);
            if (silinecekUye != null)
            {
                Console.WriteLine($"{silinecekUye.Ad} {silinecekUye.Soyad} isimli üyeyi silmek istediğinize emin misiniz?");
                Console.WriteLine("Evet-1 , Hayır-2");
                Console.Write("Seciminiz: ");
                string secim = Console.ReadLine().ToUpper();
                if (secim == "1" || secim == "EVET")
                {
                    uyeler.Remove(silinecekUye);
                    Console.WriteLine($"{silinecekUye.Ad} {silinecekUye.Soyad} isimli üye başarıyla silinmiştir");
                }
                else if (secim == "2" || secim == "HAYIR")
                    Console.WriteLine("Üye silme işlemi iptal edilmiştir.");
                else
                    Console.WriteLine("Geçerli bir seçim yapmadınız, silme işlemi iptal edilmiştir.");

            }
            else
                Console.WriteLine("Üye sistemde kayıtlı değildir, silme işlemi yapılamaz.");
        }


        public void UyeBilgiGuncelle()
        {
            Console.WriteLine("\n--- Uye Guncelle ---");
            Console.Write("Uye No: ");
            byte no = byte.Parse(Console.ReadLine());
            var bulunanUye = uyeler.FirstOrDefault(u => u.UyeNumarasi == no);
            if (bulunanUye != null)
            {
                Console.Write("Uyenin yeni numarasi: ");
                bulunanUye.UyeNumarasi = byte.Parse(Console.ReadLine());
                Console.Write("Uyenin Adi: ");
                bulunanUye.Ad = Console.ReadLine();
                Console.Write("Uyenin Soyadi: ");
                bulunanUye.Soyad = Console.ReadLine();

            }
            else
                Console.WriteLine("Uye Bulunamadi!");
        }

        /// <summary>
        /// Bu method, genel,bilim,roman ve tarih olarak tüm kitap türleri icin kullanilmayi hedefleyen generic bir methoddur. Kütüphane tarafindan kitap ödünc verme islemini yapar.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uye"></param>
        /// <param name="kitap"></param>
        public void KitapOduncVer<T>(Uye uye, T kitap) where T : Kitap
        {
            if (kitap == kitaplar.FirstOrDefault(k => k.ISBN == kitap.ISBN && k.KitapDurum == Durum.Uygun))
            {
                uye.OduncAl(kitap);
                Console.WriteLine($"{kitap.Baslik} adli kitap, {uye.Ad} {uye.Soyad} isimli üyeye ödünc verilmistir.");
            }
            else
                Console.WriteLine("Kitap uygun degil, ya da kitap kütphanede mevcut degil");
        }


        /// <summary>
        /// Bu method, genel,bilim,roman ve tarih olarak tüm kitap türleri icin kullanilmayi hedefleyen generic bir methoddur. Kütüphane tarafindan kitap iadesini yapar.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uye"></param>
        /// <param name="isbn"></param>
        public void KitapIadeAl<T>(Uye uye, string isbn) where T : Kitap
        {
            var kitap = uye.OduncKitaplar.FirstOrDefault(k => k.ISBN == isbn);

            // Kitap bulunursa ve genel kitaplar listesinde de varsa iade aliniyor.
            if (kitap != null && kitaplar.FirstOrDefault(k => k.ISBN == isbn) != null)
            {
                uye.TeslimEt(kitap);
                Console.WriteLine($"{kitap.Baslik} adlı kitap, {uye.UyeNumarasi} no'lu üyeden iade alınmıştır.");
            }
            else
            {
                Console.WriteLine("Kitap üyede değil, ya da kitap kütüphanede mevcut değil");
            }
        }


        public void MevcutDurumuListele()
        {
            Console.WriteLine("\n----- Kutuphanenin Mevcut Durumu -----");
            Console.WriteLine("\nKitaplar:");
            foreach (var kitap in kitaplar.OrderBy(k => int.Parse(k.ISBN)))
            {
                Console.WriteLine($"{kitap.ISBN} - {kitap.Baslik.PadRight(38)} - {kitap.YazarAdi.PadRight(15)} {kitap.YazarSoyadi.PadRight(10)} - {kitap.KitapDurum}");
            }

            Console.WriteLine("\nUyeler:");
            foreach (var uye in uyeler.OrderBy(u => u.UyeNumarasi))
            {
                Console.WriteLine($"{uye.UyeNumarasi} - {uye.Ad.PadRight(10)} {uye.Soyad}");
            }

            Console.WriteLine("\nSu an odunc verilmis kitaplar: ");
            foreach (var uye in uyeler)
            {
                foreach (var kitap in uye.OduncKitaplar)
                {
                    Console.WriteLine($"Uye: {uye.Ad} {uye.Soyad} ({uye.UyeNumarasi}) - Kitap: {kitap.Baslik} ({kitap.ISBN})");
                }
            }
        }






    }
}

using Deneme;
using Deneme.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane_Otomasyon_OOP
{
    internal class Uygulama
    {
        public static Kutuphane kutupHane = new Kutuphane();
        public static void Calistir()
        {
            Console.WriteLine("-----------Kutuphane Otomasyonuna Hosgeldiniz-----------");
            KütüphaneSahteVeri();
            Islem();
            Console.ReadKey();
        }

        public static void KütüphaneSahteVeri()
        {


            KitapRoman romanKitabi = new KitapRoman("1", "1984", "George", "Orwell", 1949);
            kutupHane.romanKitaplari.Add(romanKitabi);

            KitapBilim bilimKitabi = new KitapBilim("2", "Olasilik ve İstatistige Giris", "Semra Oral", "Erbas", 2005);
            kutupHane.bilimKitaplari.Add(bilimKitabi);

            KitapTarih tarihKitabi = new KitapTarih("3", "Nutuk", "Mustafa Kemal", "Atatürk", 1917);
            kutupHane.tarihKitaplari.Add(tarihKitabi);

            KitapDiger digerKitap = new KitapDiger("4", "İstanbul Hatirasi", "Ahmet", "Ümit", 1995);
            kutupHane.digerKitaplar.Add(digerKitap);

            KitapBilim bilimKitabi2 = new KitapBilim("5", "İstihdam, Para ve İktisadi Politika", "Sadun", "Aren", 2010);
            kutupHane.bilimKitaplari.Add(bilimKitabi2);

            KitapRoman romanKitabi2 = new KitapRoman("6", "Yesil Yol", "Stephen", "King", 1976);
            kutupHane.romanKitaplari.Add(romanKitabi2);

            KitapRoman romanKitabi3 = new KitapRoman("7", "Olasiliksiz", "Adam", "Fawer", 2008);
            kutupHane.romanKitaplari.Add(romanKitabi3);

            KitapTarih tarihKitabi2 = new KitapTarih("8", "Yakin Tarihin Gercekleri", "İlber", "Ortayli", 2012);
            kutupHane.tarihKitaplari.Add(tarihKitabi2);

            KitapDiger digerKitap2 = new KitapDiger("9", "Bilincaltinin Gücü", "Joseph", "Morphy", 2010);
            kutupHane.digerKitaplar.Add(digerKitap2);

            KitapTarih tarihKitabi3 = new KitapTarih("10", "Kisa Osmanli Tarihi", "Halil", "İnancik", 1986);
            kutupHane.tarihKitaplari.Add(tarihKitabi3);

            kutupHane.KitapListeleriniBirlestir();


            Uye uye1 = new Uye("Burak", "Gonca", 1);
            Uye uye2 = new Uye("Ali", "Veli", 2);
            Uye uye3 = new Uye("Ayse", "Fatma", 3);
            Uye uye4 = new Uye("Ahmet", "Yilmaz", 4);
            Uye uye5 = new Uye("Hatice", "Ozdemir", 5);

            kutupHane.uyeler.Add(uye1);
            kutupHane.uyeler.Add(uye2);
            kutupHane.uyeler.Add(uye3);
            kutupHane.uyeler.Add(uye4);
            kutupHane.uyeler.Add(uye5);
        }

        private static void Menu()
        {
            Console.WriteLine("\n1-Kitap Ekle ");
            Console.WriteLine("2-Kitap Sil");
            Console.WriteLine("3-Uye Ekle");
            Console.WriteLine("4-Uye Sil");
            Console.WriteLine("5-Uye Bilgilerini Guncelle");
            Console.WriteLine("6-Kitap Odunc Ver");
            Console.WriteLine("7-Kitap Teslim Al");
            Console.WriteLine("8-Kitabin Mevcut Durumunu Güncelle");
            Console.WriteLine("9-Uyenin Odunc Aldigi Kitaplari Goster");
            Console.WriteLine("10-Kutuphanenin Mevcut Durumunu Listele");
            Console.WriteLine("Cikis icin 'exit' yaziniz.");

        }

        private static void Islem()
        {
            Menu();
            Console.Write("\nSeciminiz: ");
            string secim = Console.ReadLine();

            bool kontrol = true;
            while (kontrol)
            {
                switch (secim)
                {
                    case "1":
                        KitapEkle();
                        Islem();
                        break;
                    case "2":
                        Console.WriteLine("\nKitap Sil");
                        kutupHane.KitapSil();
                        Islem();
                        break;
                    case "3":
                        kutupHane.UyeEkle();
                        Islem();
                        break;
                    case "4":
                        kutupHane.UyeSil();
                        Islem();
                        kontrol = false;
                        break;
                    case "5":
                        kutupHane.UyeBilgiGuncelle();
                        Islem();
                        kontrol = false;
                        break;
                    case "6":
                        OduncVer();
                        Islem();
                        break;
                    case "7":
                        IadeAl();
                        Islem();
                        break;
                    case "8":
                        DurumDegistir();
                        Islem();
                        break;
                    case "9":
                        UyeyeGoreKitaplar();
                        Islem();
                        break;
                    case "10":
                        kutupHane.MevcutDurumuListele();
                        Islem();
                        break;
                    case "exit":
                    case "EXIT":
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Cikis Yapiliyor!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Thread.Sleep(2000);
                        Environment.Exit(0);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nYanlis bir secim yaptiniz!");
                        Console.WriteLine("\nMenüye tekrar yonlendiriliyorsunuz");
                        Console.ForegroundColor = ConsoleColor.White;
                        Islem();
                        break;

                }
            }


        }

        private static void UyeyeGoreKitaplar()
        {
            Console.WriteLine("---Uyeye Gore Odunc Alinan Kitaplar Listesi---");
            Console.Write("\nListeleme yapilacak uyenin no: ");
            byte no = byte.Parse(Console.ReadLine());
            var uye = kutupHane.uyeler.FirstOrDefault(u => u.UyeNumarasi == no);
            if (uye != null)
            {
                Console.WriteLine($"{uye.Ad} {uye.Soyad} isimli uyenin şu an ki odunc almis oldugu kitaplar listesi: ");
                Console.WriteLine("---------------------------------------------------------------");
                foreach (var kitap in uye.OduncKitaplar)
                {
                    Console.WriteLine($"{kitap.Baslik} - {kitap.YazarAdi} {kitap.YazarSoyadi}");
                }
            }
            else
                Console.WriteLine("Uye bulunamadi!");
        }

        private static void DurumDegistir()
        {
            Console.WriteLine("\n--- Kitabin Durumunu Guncelle ---");
            Console.WriteLine("\nDurumunu güncellemek istediginiz kitabın");
            Console.Write("ISBN No'su: ");
            string no = Console.ReadLine();
            var durumKitap = kutupHane.kitaplar.FirstOrDefault(d => d.ISBN == no);
            Console.WriteLine($"{durumKitap.Baslik} adli kitabin durumu icin (1-Uygun,2-Uyede,3-MevcutDegil)");
            Console.WriteLine("\nSeciminiz: ");
            string durumSecim = Console.ReadLine().ToLower();
            switch (durumSecim)
            {
                case "1":
                case "uygun":
                    durumKitap.KitapDurum = Deneme.Abstracts.Durum.Uygun;
                    break;
                case "2":
                case "uyede":
                    durumKitap.KitapDurum = Deneme.Abstracts.Durum.Uyede;
                    break;
                case "3":
                case "mevcutdegil":
                    durumKitap.KitapDurum = Deneme.Abstracts.Durum.MevcutDegil;
                    break;
                default:
                    Console.WriteLine("Gecerli bir islem yapmadiniz, degisiklik yapilmamistir.");
                    break;
            }

            Console.WriteLine("Mevcut durum basariyla güncellenmistir.");
        }

        private static void KitapEkle()
        {
            Console.WriteLine("\nKitap Ekleme");
            Console.WriteLine("Kitap Türleri (BİLİM,TARİH,ROMAN)");
            Console.Write("Eklemek istediginiz kitabin türü: ");
            string tur = Console.ReadLine();
            kutupHane.KitapEkle(tur);
            Console.WriteLine("Kitap Basariyla Eklenmistir.");
        }

        private static void IadeAl()
        {
            Console.WriteLine("\n--- Kitap Teslim Al");
            Console.WriteLine("Kitabı iade almak istediğiniz üyenin numarasını girin: ");
            byte uyeNo = byte.Parse(Console.ReadLine());
            var secilenUye = kutupHane.uyeler.FirstOrDefault(u => u.UyeNumarasi == uyeNo);
            if (secilenUye != null)
            {
                Console.WriteLine("İade etmek istediğiniz kitabın ISBN numarasını girin: ");
                string isbn = Console.ReadLine();
                kutupHane.KitapIadeAl<Kitap>(secilenUye, isbn);
            }
            else
                Console.WriteLine("Geçersiz üye numarası. Uye Bulunamadi");
        }

        private static void OduncVer()
        {
            Console.WriteLine("Kitap ödünç vermek istediğiniz üyenin numarasını girin: ");
            byte uyeNo = byte.Parse(Console.ReadLine());
            var secilenUye = kutupHane.uyeler.FirstOrDefault(u => u.UyeNumarasi == uyeNo);
            if (secilenUye != null)
            {
                Console.Write("Ödünç vermek istediğiniz kitabın ISBN numarasını girin: ");
                string isbn = Console.ReadLine();
                var secilenKitap = kutupHane.kitaplar.FirstOrDefault(k => k.ISBN == isbn);
                if (secilenKitap != null)
                {
                    kutupHane.KitapOduncVer(secilenUye, secilenKitap);
                }
                else
                {
                    Console.WriteLine("Geçersiz ISBN numarası.");
                }
            }
            else
            {
                Console.WriteLine("Geçersiz üye numarası.");
            }
        }
    }
}

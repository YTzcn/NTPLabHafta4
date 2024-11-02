using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var hesap = new BankaHesabi("12345", 1000m);
            hesap.ParaYatir(200);
            hesap.ParaCek(500);
            Console.WriteLine("Bakiye: " + hesap.BakiyeGoruntule());
            Console.WriteLine("----------------------------------------------------");
            // Urun Testi
            var urun = new Urun("Telefon", 3000m);
            urun.Indirim = 25;
            Console.WriteLine("İndirimli Fiyat: " + urun.IndirimliFiyat());
            Console.WriteLine("----------------------------------------------------");
            // KiralikArac Testi
            var arac = new KiralikArac("34AB1234", 100m);
            arac.AraciKirala();
            arac.AraciTeslimEt();
            Console.WriteLine("----------------------------------------------------");
            // Kisi Testi
            var kisi = new Kisi("Ali", "Veli", "123456789");
            Console.WriteLine(kisi.KisiBilgisi());
            Console.WriteLine("----------------------------------------------------");
            // Kutuphane Testi
            var kutuphane = new Kutuphane();
            kutuphane.KitapEkle(new Kitap("Kitap1", "Yazar1"));
            kutuphane.KitaplariListele();
            Console.ReadLine();
        }
    }
    public class BankaHesabi
    {
        public string HesapNumarasi { get; private set; }
        private decimal Bakiye { get; set; }

        public BankaHesabi(string hesapNumarasi, decimal ilkBakiye)
        {
            HesapNumarasi = hesapNumarasi;
            Bakiye = ilkBakiye;
        }

        public void ParaYatir(decimal miktar)
        {
            Bakiye += miktar;
            Console.WriteLine($"Para yatırıldı. Yeni bakiye: {Bakiye}");
        }

        public void ParaCek(decimal miktar)
        {
            if (Bakiye >= miktar)
            {
                Bakiye -= miktar;
                Console.WriteLine($"Para çekildi. Yeni bakiye: {Bakiye}");
            }
            else
            {
                Console.WriteLine("Yetersiz bakiye!");
            }
        }

        public decimal BakiyeGoruntule()
        {
            return Bakiye;
        }
    }

    // Soru 2: Ürün Sınıfı
    public class Urun
    {
        public string Ad { get; set; }
        public decimal Fiyat { get; set; }
        private decimal indirim;

        public decimal Indirim
        {
            get { return indirim; }
            set
            {
                if (value >= 0 && value <= 50)
                    indirim = value;
                else
                    Console.WriteLine("İndirim %0 ile %50 arasında olmalıdır.");
            }
        }

        public Urun(string ad, decimal fiyat)
        {
            Ad = ad;
            Fiyat = fiyat;
            Indirim = 0;
        }

        public decimal IndirimliFiyat()
        {
            return Fiyat * (1 - Indirim / 100);
        }
    }

    // Soru 3: Araç Kiralama Sınıfı
    public class KiralikArac
    {
        public string Plaka { get; private set; }
        public decimal GunlukUcret { get; private set; }
        public bool MusaitMi { get; private set; }

        public KiralikArac(string plaka, decimal gunlukUcret)
        {
            Plaka = plaka;
            GunlukUcret = gunlukUcret;
            MusaitMi = true;
        }

        public void AraciKirala()
        {
            if (MusaitMi)
            {
                MusaitMi = false;
                Console.WriteLine("Araç kiralandı.");
            }
            else
            {
                Console.WriteLine("Araç zaten kirada.");
            }
        }

        public void AraciTeslimEt()
        {
            MusaitMi = true;
            Console.WriteLine("Araç teslim edildi.");
        }
    }

    // Soru 4: Adres Defteri Sınıfı
    public class Kisi
    {
        public string Ad { get; private set; }
        public string Soyad { get; private set; }
        public string TelefonNumarasi { get; private set; }

        public Kisi(string ad, string soyad, string telefonNumarasi)
        {
            Ad = ad;
            Soyad = soyad;
            TelefonNumarasi = telefonNumarasi;
        }

        public string KisiBilgisi()
        {
            return $"{Ad} {Soyad}, Telefon: {TelefonNumarasi}";
        }
    }

    // Soru 5: Kütüphane Sınıfı
    public class Kitap
    {
        public string Ad { get; set; }
        public string Yazar { get; set; }

        public Kitap(string ad, string yazar)
        {
            Ad = ad;
            Yazar = yazar;
        }
    }

    public class Kutuphane
    {
        private List<Kitap> Kitaplar { get; set; }

        public Kutuphane()
        {
            Kitaplar = new List<Kitap>();
        }

        public void KitapEkle(Kitap yeniKitap)
        {
            Kitaplar.Add(yeniKitap);
            Console.WriteLine($"Kitap eklendi: {yeniKitap.Ad} - {yeniKitap.Yazar}");
        }

        public void KitaplariListele()
        {
            Console.WriteLine("Kütüphanedeki Kitaplar:");
            foreach (var kitap in Kitaplar)
            {
                Console.WriteLine($"{kitap.Ad} - {kitap.Yazar}");
            }
        }
    }
}

using System;
using System.Collections.Generic;

// Oda sınıfı: Odanın temel özelliklerini temsil eder
public class Oda
{
    public string OdaTipi { get; private set; }  // Odanın tipi (Örneğin: yatak odası, oturma odası)
    public double Boyut { get; private set; }  // Odanın boyutu (metrekare cinsinden)

    // Oda yapıcısı
    public Oda(string odaTipi, double boyut)
    {
        OdaTipi = odaTipi;
        Boyut = boyut;
    }

    // Odanın bilgilerini döndüren metot
    public override string ToString()
    {
        return $"{OdaTipi} - {Boyut} m²";
    }
}

// Ev sınıfı: Evin temel özelliklerini ve işlevselliğini temsil eder
public class Ev
{
    public int OdaSayisi { get { return Odalar.Count; } }  // Evdeki oda sayısı (Odaların sayısını döndürür)
    public List<Oda> Odalar { get; private set; }  // Evdeki odalar

    // Ev yapıcısı
    public Ev()
    {
        Odalar = new List<Oda>();
    }

    // Evin bir odasını eklemek için metot
    public void OdaEkle(Oda oda)
    {
        if (oda != null)
        {
            Odalar.Add(oda);
            Console.WriteLine($"{oda.OdaTipi} eklendi.");
        }
        else
        {
            Console.WriteLine("Geçersiz oda.");
        }
    }

    // Evin bir odasını kaldırmak için metot
    public void OdaKaldir(Oda oda)
    {
        if (oda != null && Odalar.Contains(oda))
        {
            Odalar.Remove(oda);
            Console.WriteLine($"{oda.OdaTipi} kaldırıldı.");
        }
        else
        {
            Console.WriteLine("Oda bulunamadı.");
        }
    }

    // Evin odalarını görüntüleme metodu
    public void OdalariGoster()
    {
        Console.WriteLine($"Oda Sayısı: {OdaSayisi}");
        foreach (var oda in Odalar)
        {
            Console.WriteLine($"  - {oda}");
        }
    }
}

// Program sınıfı: Uygulamanın ana giriş noktası
public class Program
{
    public static void Main(string[] args)
    {
        // Ev nesnesi oluşturuluyor
        var ev = new Ev();

        // Oda nesneleri oluşturuluyor
        var oda1 = new Oda("Yatak Odası", 15.5);
        var oda2 = new Oda("Oturma Odası", 25.0);
        var oda3 = new Oda("Mutfak", 12.0);

        // Oda ekleniyor
        ev.OdaEkle(oda1);
        ev.OdaEkle(oda2);
        ev.OdaEkle(oda3);

        // Oda listesi gösteriliyor
        ev.OdalariGoster();

        // Oda kaldırılıyor
        ev.OdaKaldir(oda2);

        // Oda listesi tekrar gösteriliyor
        ev.OdalariGoster();
    }
}

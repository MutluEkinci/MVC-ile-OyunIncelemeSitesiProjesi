﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web;
using OyunİncelemeSitesiProjesi.Models;
namespace OyunİncelemeSitesiProjesi.DAL
{
    public class initDB : DropCreateDatabaseIfModelChanges<OyunContext>
    {
        protected override void Seed(OyunContext context)
        {
            context.Turler.Add(new Tur { TurAd = "Aksiyon" });
            context.Turler.Add(new Tur { TurAd = "Macera" });
            context.Turler.Add(new Tur { TurAd = "Dövüş" });
            context.Turler.Add(new Tur { TurAd = "Platform" });
            context.Turler.Add(new Tur { TurAd = "Bulmaca" });
            context.Turler.Add(new Tur { TurAd = "Simulasyon" });
            context.Turler.Add(new Tur { TurAd = "Rol Yapma" });
            context.Turler.Add(new Tur { TurAd = "Spor" });
            context.Turler.Add(new Tur { TurAd = "Strateji" });
            context.Turler.Add(new Tur { TurAd = "Mantıksal" });
            context.Turler.Add(new Tur { TurAd = "Eğitsel" });
            context.Turler.Add(new Tur { TurAd = "Gizlilik" });
            context.SaveChanges();

            context.Platformlar.Add(new Platform { PlatformAd = "Pc" });
            context.Platformlar.Add(new Platform { PlatformAd = "Ps3" });
            context.Platformlar.Add(new Platform { PlatformAd = "Ps4" });
            context.Platformlar.Add(new Platform { PlatformAd = "Ps5" });
            context.Platformlar.Add(new Platform { PlatformAd = "Xbox 360" });
            context.Platformlar.Add(new Platform { PlatformAd = "Xbox One" });
            context.Platformlar.Add(new Platform { PlatformAd = "Xbox X" });
            context.Platformlar.Add(new Platform { PlatformAd = "Xbox S" });
            context.Platformlar.Add(new Platform { PlatformAd = "Nintendo Switch" });
            context.SaveChanges();

            context.Uyeler.Add(new Uye { AdSoyad = "Cevdet Yıldız", Rumuz = "Cevdoy", Sifre = "cvdt11" });
            context.Uyeler.Add(new Uye { AdSoyad = "Mutlu Ekinci", Rumuz = "Admin", Sifre = "mtlknc" });
            context.Uyeler.Add(new Uye { AdSoyad = "Mehmet Yıldıran", Rumuz = "Memet15", Sifre = "memo11" });
            context.Uyeler.Add(new Uye { AdSoyad = "Yıldız Tilbe", Rumuz = "Yıldız", Sifre = "delikanlım" });
            context.Uyeler.Add(new Uye { AdSoyad = "Ahmet Muhterem", Rumuz = "Muhterem71", Sifre = "şifre11" });
            context.Uyeler.Add(new Uye { AdSoyad = "Buse Kandıra", Rumuz = "BSKandıra", Sifre = "kandıralar" });
            context.Uyeler.Add(new Uye { AdSoyad = "Samet Yılmaz", Rumuz = "SmtYılmaz", Sifre = "ylmz11" });
            context.Uyeler.Add(new Uye { AdSoyad = "Serhat Yüksel", Rumuz = "Caferserhat", Sifre = "boyum110" });
            context.Uyeler.Add(new Uye { AdSoyad = "Caner Kırmızı", Rumuz = "Canerred", Sifre = "red11" });
            context.Uyeler.Add(new Uye { AdSoyad = "Yılmaz Gobel", Rumuz = "Gobel1", Sifre = "gobelgobel" });
            context.SaveChanges();

            context.Oyunlar.Add(new Oyun { OyunAd = "Red Dead Redemption 2", CikisYili = DateTime.ParseExact("20/12/2018","dd/MM/yyyy", System.Globalization.CultureInfo.GetCultureInfo("tr_TR").DateTimeFormat), Resim = "", İnceleme = "a", Puan = 5 });
            context.Oyunlar.Add(new Oyun { OyunAd = "GTA V", CikisYili = DateTime.Parse("17/09/2013", System.Globalization.CultureInfo.GetCultureInfo("tr_TR").DateTimeFormat), Resim = "", İnceleme = "a", Puan = 5 });
            context.Oyunlar.Add(new Oyun { OyunAd = "God Of War", CikisYili = DateTime.Parse("20/04/2018", System.Globalization.CultureInfo.GetCultureInfo("tr_TR").DateTimeFormat), Resim = "", İnceleme = "a", Puan = 5 });
            context.Oyunlar.Add(new Oyun { OyunAd = "The Last Of Us", CikisYili = DateTime.Parse("14/06/2013", System.Globalization.CultureInfo.GetCultureInfo("tr_TR").DateTimeFormat), Resim = "", İnceleme = "a", Puan = 5 });
            context.Oyunlar.Add(new Oyun { OyunAd = "The Last Of Us 2", CikisYili = DateTime.Parse("19/06/2020", System.Globalization.CultureInfo.GetCultureInfo("tr_TR").DateTimeFormat), Resim = "", İnceleme = "a", Puan = 5 });
            context.Oyunlar.Add(new Oyun { OyunAd = "Spider-Man", CikisYili = DateTime.Parse("07/09/2018", System.Globalization.CultureInfo.GetCultureInfo("tr_TR").DateTimeFormat), Resim = "", İnceleme = "a", Puan = 5 });
            context.Oyunlar.Add(new Oyun { OyunAd = "Uncharted:Drake's Fortune", CikisYili = DateTime.Parse("19/11/2007", System.Globalization.CultureInfo.GetCultureInfo("tr_TR").DateTimeFormat), Resim = "", İnceleme = "a", Puan = 3 });
            context.Oyunlar.Add(new Oyun { OyunAd = "Uncharted 2:Among Thieves", CikisYili = DateTime.Parse("13/10/2009", System.Globalization.CultureInfo.GetCultureInfo("tr_TR").DateTimeFormat), Resim = "", İnceleme = "a", Puan = 3 });
            context.Oyunlar.Add(new Oyun { OyunAd = "Uncharted 3:Drake'S Deception", CikisYili = DateTime.Parse("01/11/2011", System.Globalization.CultureInfo.GetCultureInfo("tr_TR").DateTimeFormat), Resim = "", İnceleme = "a", Puan = 4 });
            context.Oyunlar.Add(new Oyun { OyunAd = "Uncharted 4:A Thief's End", CikisYili = DateTime.Parse("10/05/2016", System.Globalization.CultureInfo.GetCultureInfo("tr_TR").DateTimeFormat), Resim = "", İnceleme = "a", Puan = 4 });
            context.Oyunlar.Add(new Oyun { OyunAd = "Call of Duty 2", CikisYili = DateTime.Parse("17/11/2005", System.Globalization.CultureInfo.GetCultureInfo("tr_TR").DateTimeFormat), Resim = "", İnceleme = "a", Puan = 3 });
            context.Oyunlar.Add(new Oyun { OyunAd = "Call of Duty 3", CikisYili = DateTime.Parse("13/11/2005", System.Globalization.CultureInfo.GetCultureInfo("tr_TR").DateTimeFormat), Resim = "", İnceleme = "a", Puan = 3 });
            context.Oyunlar.Add(new Oyun { OyunAd = "Call of Duty 4:Modern Warfare", CikisYili = DateTime.Parse("12/10/2007", System.Globalization.CultureInfo.GetCultureInfo("tr_TR").DateTimeFormat), Resim = "", İnceleme = "a", Puan = 3 });
            context.Oyunlar.Add(new Oyun { OyunAd = "Call of Duty 5:World At War", CikisYili = DateTime.Parse("21/11/2008", System.Globalization.CultureInfo.GetCultureInfo("tr_TR").DateTimeFormat), Resim = "", İnceleme = "a", Puan = 3 });
            context.SaveChanges();

            context.OyunTurleri.Add(new OyunTur { OyunID = 1, TurID = 1 });
            context.OyunTurleri.Add(new OyunTur { OyunID = 1, TurID = 2 });
            context.SaveChanges();

            context.OyunPlatformları.Add(new OyunPlatform { OyunID = 1, PlatformID = 1 });
            context.OyunPlatformları.Add(new OyunPlatform { OyunID = 1, PlatformID = 2 });
            context.OyunPlatformları.Add(new OyunPlatform { OyunID = 1, PlatformID = 3 });
            context.OyunPlatformları.Add(new OyunPlatform { OyunID = 1, PlatformID = 4 });
            context.OyunPlatformları.Add(new OyunPlatform { OyunID = 1, PlatformID = 5 });
            context.OyunPlatformları.Add(new OyunPlatform { OyunID = 1, PlatformID = 6 });
            context.OyunPlatformları.Add(new OyunPlatform { OyunID = 1, PlatformID = 7 });
            context.OyunPlatformları.Add(new OyunPlatform { OyunID = 1, PlatformID = 8 });
            context.SaveChanges();

            context.Yorumlar.Add(new Yorum { UyeID = 1, OyunID = 1, YorumYazı = "Çok güzel bir oyun kesinlikle oynanması gerekiyor.İnsanın hayatında bir kere yaşaması gereken bir deneyim.", Tarih = DateTime.Parse("14/02/2022", System.Globalization.CultureInfo.GetCultureInfo("tr_TR").DateTimeFormat) });
            context.Yorumlar.Add(new Yorum { UyeID = 2, OyunID = 1, YorumYazı = "Harika bir oyun kesinlikle oynanması gerekiyor.İnsanın hayatında bir kere yaşaması gereken bir deneyim.", Tarih = DateTime.Parse("18/02/2022", System.Globalization.CultureInfo.GetCultureInfo("tr_TR").DateTimeFormat) });
            context.Yorumlar.Add(new Yorum { UyeID = 3, OyunID = 1, YorumYazı = "Mükemmel bir oyun kesinlikle oynanması gerekiyor.İnsanın hayatında bir kere yaşaması gereken bir deneyim.", Tarih = DateTime.Parse("16/02/2022", System.Globalization.CultureInfo.GetCultureInfo("tr_TR").DateTimeFormat) });
            context.Yorumlar.Add(new Yorum { UyeID = 4, OyunID = 1, YorumYazı = "Çok iyi bir oyun kesinlikle oynanması gerekiyor.İnsanın hayatında bir kere yaşaması gereken bir deneyim.", Tarih = DateTime.Parse("17/02/2022", System.Globalization.CultureInfo.GetCultureInfo("tr_TR").DateTimeFormat) });
            context.Yorumlar.Add(new Yorum { UyeID = 5, OyunID = 1, YorumYazı = "Müthiş bir oyun kesinlikle oynanması gerekiyor.İnsanın hayatında bir kere yaşaması gereken bir deneyim.", Tarih = DateTime.Parse("19/02/2022", System.Globalization.CultureInfo.GetCultureInfo("tr_TR").DateTimeFormat) });
            context.Yorumlar.Add(new Yorum { UyeID = 6, OyunID = 1, YorumYazı = "Muazzam bir oyun kesinlikle oynanması gerekiyor.İnsanın hayatında bir kere yaşaması gereken bir deneyim.", Tarih = DateTime.Parse("15/02/2022", System.Globalization.CultureInfo.GetCultureInfo("tr_TR").DateTimeFormat) });
            context.SaveChanges();

            context.Sepet.Add(new Sepet { UyeID = 1, OyunID = 1 });
            context.Sepet.Add(new Sepet { UyeID = 2, OyunID = 1 });
            context.Sepet.Add(new Sepet { UyeID = 3, OyunID = 1 });
            context.Sepet.Add(new Sepet { UyeID = 4, OyunID = 1 });
            context.Sepet.Add(new Sepet { UyeID = 5, OyunID = 1 });
            context.SaveChanges();





        }
    }
}
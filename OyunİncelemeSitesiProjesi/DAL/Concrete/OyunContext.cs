using OyunİncelemeSitesiProjesi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OyunİncelemeSitesiProjesi.DAL
{
    public class OyunContext : DbContext
    {
        public OyunContext()
        {
            Database.SetInitializer(new initDB());
        }

        public DbSet<Oyun> Oyunlar { get; set; }
        public DbSet<OyunPlatform> OyunPlatformları { get; set; }
        public DbSet<OyunTur> OyunTurleri { get; set; }
        public DbSet<Platform> Platformlar { get; set; }
        public DbSet<Sepet> Sepet { get; set; }
        public DbSet<Tur> Turler { get; set; }
        public DbSet<Uye> Uyeler { get; set; }
        public DbSet<Yorum> Yorumlar { get; set; }
    }
}
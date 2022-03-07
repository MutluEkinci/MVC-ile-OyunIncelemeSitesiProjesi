using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OyunİncelemeSitesiProjesi.Models.ViewModel
{
    public class Oyun_VM
    {
        public Oyun OyunEntity { get; set; }
        public IEnumerable<Oyun> OyunList { get; set; }
        public SelectList OyunSelectList { get; set; }


        public OyunPlatform OyunPlatfromEntity { get; set; }
        public IEnumerable<OyunPlatform> OyunPlatformList { get; set; }


        public OyunTur OyunTurEntity { get; set; }
        public IEnumerable<OyunTur> OyunTurList { get; set; }


        public Platform PlatformEntity { get; set; }
        public IEnumerable<Platform> PlatformList { get; set; }
        public SelectList PlatformSelectList { get; set; }


        public Sepet SepetEntity { get; set; }
        public IEnumerable<Sepet> SepetList { get; set; }

        public Tur TurEntity { get; set; }
        public IEnumerable<Tur> TurList { get; set; }
        public SelectList TurSelectList { get; set; }

        public Uye UyeEntity { get; set; }
        public IEnumerable<Uye> UyeList { get; set; }


        public Yorum YorumEntity { get; set; }
        public IEnumerable<Yorum> YorumList { get; set; }




    }
}
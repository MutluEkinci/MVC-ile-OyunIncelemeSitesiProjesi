using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OyunİncelemeSitesiProjesi.Models
{
    public class Oyun
    {
        [Key]
        public int OyunID { get; set; }

        [Required(ErrorMessage = "Oyun adı boş olamaz!")]
        [Display(Name = "Oyun Adı")]
        [StringLength(30, ErrorMessage = "Oyun adı 30 karakterden fazla olamaz!")]
        public string OyunAd { get; set; }


        //[Display(Name = "Oyun Türü")]
        //public int TurID { get; set; }


        //[Display(Name = "Platform")]
        //public int PlatformID { get; set; }


        [StringLength(500, ErrorMessage = "Resim yolu 500 karakterden fazla olamaz!")]
        public string Resim { get; set; }


        //[Required(ErrorMessage = "Çıkış yılı boş olamaz!")]
        //[StringLength(20, ErrorMessage = "Çıkış yılı 20 karakterden fazla olamaz!")]
        [Required(ErrorMessage ="Tarih Boş Olamaz!")]
        [Display(Name = "Çıkış Yılı")]
        public DateTime CikisYili { get; set; }
        

        [StringLength(1000, ErrorMessage = "İnceleme yazısı 1000 karakterden fazla olamaz!")]
        [Required(ErrorMessage = "İncelemeyi boş bırakamazsınız!")]
        public string İnceleme { get; set; }

        [Range(0, 5, ErrorMessage = "Puan 0 ila 5 arasında olmalıdır!")]
        [Required(ErrorMessage = "Puanı boş bırakamazsınız!")]
        public byte Puan { get; set; }



        //Navigation prop
        public ICollection<Tur> Turler { get; set; }
        public ICollection<Platform> Platformlar { get; set; }


        



    }
}
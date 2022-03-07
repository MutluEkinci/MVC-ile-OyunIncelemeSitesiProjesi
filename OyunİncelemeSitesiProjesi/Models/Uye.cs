using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OyunİncelemeSitesiProjesi.Models
{
    public class Uye
    {
        [Key]
        public int UyeID { get; set; }

        [Required(ErrorMessage = "Ad Soyad boş olamaz!")]
        [StringLength(50, ErrorMessage = "Ad ve soyad 50 karakterden fazla olamaz!")]
        [Display(Name = "Ad Soyad")]
        public string AdSoyad { get; set; }

        [Required(ErrorMessage = "Mail boş olamaz!")]
        [StringLength(500)]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Rumuz boş olamaz!")]
        [StringLength(20, ErrorMessage = "Rumuz 20 karakterden fazla olamaz!")]
        [Display(Name = "Kullanıcı Adı")]
        public string Rumuz { get; set; }

        [Required(ErrorMessage = "Şifre boş olamaz!")]
        [StringLength(500)]
        [Display(Name = "Şifre")]
        public string Sifre { get; set; }
        [StringLength(5)]
        public string Rol { get; set; } = "user";
    }
}
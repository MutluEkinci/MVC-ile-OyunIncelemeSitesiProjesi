using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OyunİncelemeSitesiProjesi.Models
{
    public class Yorum
    {
        [Key]
        public int YorumID { get; set; }
        [Display(Name = "Üye Adı")]
        public int UyeID { get; set; }
        [Display(Name = "Oyun Adı")]
        public int OyunID { get; set; }
        [Required(ErrorMessage = "Yorum yazısı boş olamaz!")]
        [StringLength(500, ErrorMessage = "Yorum yazısı 500 karakterden uzun olamaz!")]
        [Display(Name ="Yorum Yazısı")]
        public string YorumYazı { get; set; }
        //[Required(ErrorMessage = "Tarih boş olamaz!")]
        //[StringLength(20, ErrorMessage = "Tarih 20 karakterden fazla olamaz!")]
        public DateTime Tarih { get; set; }



        //Navigation prop
        public virtual Uye Uye { get; set; }
        public virtual Oyun Oyun { get; set; }

    }
}
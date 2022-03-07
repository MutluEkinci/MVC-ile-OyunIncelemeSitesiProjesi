using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OyunİncelemeSitesiProjesi.Models
{
    public class Platform
    {
        [Key]
        public int PlatformID { get; set; }

        [Required(ErrorMessage = "Platform adı boş olamaz!")]
        [StringLength(20, ErrorMessage = "Platform adı 20 karakterden fazla olamaz!")]
        [Display(Name ="Platform Adı")]
        public string PlatformAd { get; set; }




        //Navigation prop
        public ICollection<Oyun> Oyunlar { get; set; }

    }
}
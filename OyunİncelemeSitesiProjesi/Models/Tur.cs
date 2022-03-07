using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OyunİncelemeSitesiProjesi.Models
{
    public class Tur
    {
        [Key]
        public int TurID { get; set; }
        [Required(ErrorMessage = "Tür adı boş olamaz!")]
        [StringLength(20, ErrorMessage = "Tür adı 20 karakterden fazla olamaz!")]
        [Display(Name ="Tür Adı")]
        public string TurAd { get; set; }



        //Navigation prop
        public ICollection<Oyun> Oyunlar { get; set; }


    }
}
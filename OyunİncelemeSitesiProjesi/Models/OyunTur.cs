using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OyunİncelemeSitesiProjesi.Models
{
    public class OyunTur
    {
        [Key]
        public int OyunTurID { get; set; }
        [Display(Name = "Oyun Adı")]
        public int OyunID { get; set; }
        [Display(Name = "Türler")]
        public int TurID { get; set; }



        //Navigation prop
        public virtual Oyun Oyun { get; set; }
        public virtual Tur Tur { get; set; }
    }
}
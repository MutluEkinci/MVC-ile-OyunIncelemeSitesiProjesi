using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OyunİncelemeSitesiProjesi.Models
{
    public class OyunPlatform
    {
        [Key]
        public int OyunPlatformID { get; set; }
        [Display(Name = "Oyun Adı")]
        public int OyunID { get; set; }
        [Display(Name = "Platformlar")]
        public int PlatformID { get; set; }



        //Navigation prop
        public virtual Oyun Oyun { get; set; }
        public virtual Platform Platform { get; set; }
    }
}
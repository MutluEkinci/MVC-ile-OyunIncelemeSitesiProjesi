using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OyunİncelemeSitesiProjesi.Models
{
    public class Sepet
    {
        [Key]
        public int SepetID { get; set; }
        public int OyunID { get; set; }
        public int UyeID { get; set; }



        //Navigation prop
        public virtual Oyun Oyun { get; set; }
        public virtual Uye Uye { get; set; }

    }
}
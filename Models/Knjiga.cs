using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EvidencijaKnjiga.Models
{
    public class Knjiga
    {
        public int ID { get; set; }

        public string Naziv { get; set; }

        [Display(Name ="Godina izdanja")]
        public int GodinaIzdanja { get; set; }

        [Display(Name ="Autor")]
        public int AutorID { get; set; }

        public virtual Autor Autor { get; set; }
    }
}

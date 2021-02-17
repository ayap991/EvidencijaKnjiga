using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EvidencijaKnjiga.Models
{
    public class Autor
    {
        public int ID { get; set; }

        [Display(Name ="Ime i prezime autora")]
        public string Ime { get; set; }
    }
}

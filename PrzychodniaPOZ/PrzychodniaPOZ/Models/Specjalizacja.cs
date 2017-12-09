using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrzychodniaPOZ.Models
{
    public class Specjalizacja
    {
        public int SpecjalizacjaId { get; set; }
        public string Nazwa { get; set; }

        public virtual ICollection<LekSpec> LekSpec { get; set; }
    }
}
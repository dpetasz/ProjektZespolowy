using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrzychodniaPOZ.Models
{
    public class LekSpec
    {
        public int LekSpecId { get; set; }
        public int LekarzId { get; set; }
        public int SpecjalizacjaId { get; set; }

        public virtual Lekarz Lekarz { get; set; }
        public virtual Specjalizacja Specjalizacja { get; set; }
    }
}
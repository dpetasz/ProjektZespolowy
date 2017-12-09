using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrzychodniaPOZ.Models
{
    public class Lekarz
    {
        public int LekarzId { get; set; }
        public string Nazwisko { get; set; }
        public string Imie { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }

        public virtual ICollection<LekSpec> LekSpec { get; set; }
        public virtual ICollection<WizytaLekarz> WizytaLekarz { get; set; }
    }
}
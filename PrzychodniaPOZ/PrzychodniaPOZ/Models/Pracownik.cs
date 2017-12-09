using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrzychodniaPOZ.Models
{
    public class Pracownik
    {
        public int PracownikId { get; set; }
        public string Nazwisko { get; set; }
        public string Imie { get; set; }
        public string Login { get; set; }
        public string Haslo { get; set; }
    }
}
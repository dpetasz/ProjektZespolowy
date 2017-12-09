using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrzychodniaPOZ.Models
{
    public class Pracownik
    {
        public int PracownikId { get; set; }
        public string Nazwisko { get; set; }
        public string Imie { get; set; }
        [Display(Name = "Login")]
        [Required(ErrorMessage = "Musisz wprowadzić Login")]
        public string Login { get; set; }


        [Required(ErrorMessage = "Musisz wprowadzić hasło")]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Haslo { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrzychodniaPOZ.Models
{
    public class Pacjent
    {
        public int PacjentId { get; set; }

        [Required(ErrorMessage = "Musisz wprowadzić Nazwisko")]
        [Display(Name = "Nazwisko ")]
        public string Nazwisko { get; set; }

        [Required(ErrorMessage = "Musisz wprowadzić Imię")]
        [Display(Name = "Imię ")]
        public string Imie { get; set; }

        //[Required(ErrorMessage = "Musisz wprowadzić Adres zamieszkania")]
        [Display(Name = "Adres zamieszkania ")]
        public string Adres { get; set; }


        public string Telefon { get; set; }

        [Required(ErrorMessage = "Musisz wprowadzić email")]
        [EmailAddress]
        public string Email { get; set; }

        public string Pesel { get; set; }
        public string Login { get; set; }

        [Required(ErrorMessage = "Musisz wprowadzić hasło")]
        [StringLength(30, ErrorMessage = "{0} musi mieć co najmniej {2} znaków.", MinimumLength = 2)]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Haslo { get; set; }

        [Display(Name = "Potwierdź Hasło")]
        [DataType(DataType.Password)]
        [Compare("Haslo")]
        public string ConfirmHaslo { get; set; }

        public virtual ICollection<WizytaBadanie> WizytaBadanie { get; set; }
        public virtual ICollection<WizytaLekarz> WizytaLekarz { get; set; }
    }
}
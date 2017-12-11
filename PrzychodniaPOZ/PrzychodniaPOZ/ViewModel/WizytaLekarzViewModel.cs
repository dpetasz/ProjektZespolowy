using PrzychodniaPOZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrzychodniaPOZ.ViewModel
{
    public class WizytaLekarzViewModel
    {
        public WizytaLekarz wizytaLekarz { get; set; }
        public Lekarz lekarz { get; set; }
        public LekSpec lekSpec { get; set; }
        public Specjalizacja specjalizacja { get; set; }

    }
   
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrzychodniaPOZ.Models
{
    public partial class WizytaLekarz
    {
        public int WizytaLekarzId { get; set; }
        public int LekarzId { get; set; }
        public int SpecjalizacjaId { get; set; }
        public Nullable<int> PacjenId { get; set; }

        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:D}", ApplyFormatInEditMode = true)]
        public System.DateTime DataWizyty { get; set; }

        //[DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:g}")]        
        public System.TimeSpan GodzinaWizyty { get; set; }
        public Nullable<bool> Status { get; set; }

        public virtual Lekarz Lekarz { get; set; }
        public virtual Pacjent Pacjent { get; set; }
        public virtual Specjalizacja Specjalizacja { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrzychodniaPOZ.Models
{
    public partial class WizytaLekarz
    {
        public int WizytaLekarzId { get; set; }
        public int LekarzId { get; set; }
        public Nullable<int> PacjenId { get; set; }
        public System.DateTime DataWizyty { get; set; }
        public System.TimeSpan GodzinaWizyty { get; set; }
        public Nullable<bool> Status { get; set; }

        public virtual Lekarz Lekarz { get; set; }
        public virtual Pacjent Pacjent { get; set; }
    }
}
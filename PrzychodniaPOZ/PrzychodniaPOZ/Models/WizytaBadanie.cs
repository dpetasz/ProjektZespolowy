using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrzychodniaPOZ.Models
{
    public partial class WizytaBadanie
    {
        public int WizytaBadanieId { get; set; }
        public int BadanieId { get; set; }
        public Nullable<int> PacjentId { get; set; }
        public System.DateTime DataBadanie { get; set; }
        public System.TimeSpan GodzinaBadanie { get; set; }
        public Nullable<bool> Status { get; set; }

        public virtual Badanie Badanie { get; set; }
        public virtual Pacjent Pacjent { get; set; }
    }
}
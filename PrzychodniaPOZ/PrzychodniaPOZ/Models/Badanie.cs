using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrzychodniaPOZ.Models
{
    public class Badanie
    {
        public int BadanieId { get; set; }
        public string Nazwa { get; set; }

        public virtual ICollection<WizytaBadanie> WizytaBadanie { get; set; }
    }
}
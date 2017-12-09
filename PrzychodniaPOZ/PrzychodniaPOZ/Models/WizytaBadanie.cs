using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrzychodniaPOZ.Models
{
    public partial class WizytaBadanie
    {
        public int WizytaBadanieId { get; set; }
        public int BadanieId { get; set; }
        public Nullable<int> PacjentId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:D}", ApplyFormatInEditMode = true)]
        public System.DateTime DataBadanie { get; set; }

        [DisplayFormat(DataFormatString = "{0:g}")]
        [DataType(DataType.Time)]
        public System.TimeSpan GodzinaBadanie { get; set; }
        public Nullable<bool> Status { get; set; }

        public virtual Badanie Badanie { get; set; }
        public virtual Pacjent Pacjent { get; set; }
    }
}
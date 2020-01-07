using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Nowosc
    {
        public int IdNowosc { get; set; }
        public DateTime OdKiedy { get; set; }
        public DateTime DoKiedy { get; set; }
        public int ProduktIdProdukt { get; set; }

        public virtual Produkt ProduktIdProduktNavigation { get; set; }
    }
}

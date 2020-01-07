using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Dodatek
    {
        public int IdProdukt { get; set; }
        public string RodzajDodatku { get; set; }

        public virtual Produkt IdProduktNavigation { get; set; }
    }
}

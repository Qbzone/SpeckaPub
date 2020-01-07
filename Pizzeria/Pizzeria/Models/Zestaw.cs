using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Zestaw
    {
        public int IdZestaw { get; set; }
        public int IdProdukt { get; set; }
        public int IdZamowienia { get; set; }

        public virtual Produkt IdProduktNavigation { get; set; }
        public virtual Zamowienie IdZamowieniaNavigation { get; set; }
    }
}

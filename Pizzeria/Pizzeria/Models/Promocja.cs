using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Promocja
    {
        public Promocja()
        {
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int IdPromocja { get; set; }
        public string NazwaPromocja { get; set; }
        public DateTime OdKiedy { get; set; }
        public DateTime DoKiedy { get; set; }
        public int IleProcent { get; set; }
        public int ProduktIdProdukt { get; set; }

        public virtual Produkt ProduktIdProduktNavigation { get; set; }
        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}

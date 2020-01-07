using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Produkt
    {
        public Produkt()
        {
            Nowosc = new HashSet<Nowosc>();
            Promocja = new HashSet<Promocja>();
            Zestaw = new HashSet<Zestaw>();
        }

        public int IdProdukt { get; set; }
        public int Nazwa { get; set; }

        public virtual Dodatek Dodatek { get; set; }
        public virtual Pizza Pizza { get; set; }
        public virtual ICollection<Nowosc> Nowosc { get; set; }
        public virtual ICollection<Promocja> Promocja { get; set; }
        public virtual ICollection<Zestaw> Zestaw { get; set; }
    }
}

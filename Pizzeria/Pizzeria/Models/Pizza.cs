using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            SkladPizzy = new HashSet<SkladPizzy>();
        }

        public int IdProdukt { get; set; }
        public string Rozmiar { get; set; }
        public int CzyWlasna { get; set; }

        public virtual Produkt IdProduktNavigation { get; set; }
        public virtual ICollection<SkladPizzy> SkladPizzy { get; set; }
    }
}

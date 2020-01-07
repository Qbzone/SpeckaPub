using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Klient
    {
        public Klient()
        {
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int IdKlient { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string NrTelefonu { get; set; }

        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}

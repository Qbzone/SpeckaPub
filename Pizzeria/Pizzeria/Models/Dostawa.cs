using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Dostawa
    {
        public int IdPracownik { get; set; }
        public int IdZamowienia { get; set; }
        public DateTime StartDostawy { get; set; }
        public DateTime KoniecDostawy { get; set; }

        public virtual Pracownik IdPracownikNavigation { get; set; }
        public virtual Zamowienie IdZamowieniaNavigation { get; set; }
    }
}

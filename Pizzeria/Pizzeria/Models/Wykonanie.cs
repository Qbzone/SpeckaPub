using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Wykonanie
    {
        public int IdWykonanie { get; set; }
        public int IdPracownik { get; set; }
        public int IdZamowienia { get; set; }

        public virtual Pracownik IdPracownikNavigation { get; set; }
        public virtual Zamowienie IdZamowieniaNavigation { get; set; }
    }
}

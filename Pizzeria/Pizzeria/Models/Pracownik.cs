using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Pracownik
    {
        public Pracownik()
        {
            Dostawa = new HashSet<Dostawa>();
            Wykonanie = new HashSet<Wykonanie>();
        }

        public int IdPracownik { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTime DataUrodzenia { get; set; }
        public string Pesel { get; set; }
        public int Pensja { get; set; }
        public int Premia { get; set; }

        public virtual ICollection<Dostawa> Dostawa { get; set; }
        public virtual ICollection<Wykonanie> Wykonanie { get; set; }
    }
}

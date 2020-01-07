using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Zamowienie
    {
        public Zamowienie()
        {
            Dostawa = new HashSet<Dostawa>();
            Wykonanie = new HashSet<Wykonanie>();
            Zestaw = new HashSet<Zestaw>();
        }

        public int IdZamowienia { get; set; }
        public DateTime PrzyjecieZamowienia { get; set; }
        public int CzasDostawy { get; set; }
        public string AdresZamowienia { get; set; }
        public string Stan { get; set; }
        public int Cena { get; set; }
        public int IdKlient { get; set; }
        public int IdPlatnosc { get; set; }
        public int IdPromocja { get; set; }

        public virtual Klient IdKlientNavigation { get; set; }
        public virtual Platnosc IdPlatnoscNavigation { get; set; }
        public virtual Promocja IdPromocjaNavigation { get; set; }
        public virtual ICollection<Dostawa> Dostawa { get; set; }
        public virtual ICollection<Wykonanie> Wykonanie { get; set; }
        public virtual ICollection<Zestaw> Zestaw { get; set; }
    }
}

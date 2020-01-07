using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class SkladPizzy
    {
        public int IdProdukt { get; set; }
        public int IdSkladnik { get; set; }
        public int IloscSkladnikow { get; set; }

        public virtual Pizza IdProduktNavigation { get; set; }
        public virtual Skladnik IdSkladnikNavigation { get; set; }
    }
}

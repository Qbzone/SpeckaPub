using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Skladnik
    {
        public Skladnik()
        {
            SkladPizzy = new HashSet<SkladPizzy>();
        }

        public int IdSkladnik { get; set; }
        public string Nazwa { get; set; }

        public virtual ICollection<SkladPizzy> SkladPizzy { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace SipItApp.API.Models
{
    public partial class Flavor
    {
        public Flavor()
        {
            SanpetefavoritesFlavor = new HashSet<SanpetefavoritesFlavor>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Issyrup { get; set; }
        public bool Issugarfree { get; set; }
        public bool Isfresh { get; set; }
        public bool Ispuree { get; set; }
        public bool Isenergy { get; set; }

        public virtual ICollection<SanpetefavoritesFlavor> SanpetefavoritesFlavor { get; set; }
    }
}

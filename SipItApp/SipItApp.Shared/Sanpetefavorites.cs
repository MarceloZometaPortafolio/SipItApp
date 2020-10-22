using System;
using System.Collections.Generic;

namespace SipItApp.Shared
{
    public partial class Sanpetefavorites
    {
        public Sanpetefavorites()
        {
            SanpetefavoritesFlavor = new HashSet<SanpetefavoritesFlavor>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Baseid { get; set; }

        public virtual Base Base { get; set; }
        public virtual ICollection<SanpetefavoritesFlavor> SanpetefavoritesFlavor { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace SipItApp.API.Models
{
    public partial class Base
    {
        public Base()
        {
            Sanpetefavorites = new HashSet<Sanpetefavorites>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Sanpetefavorites> Sanpetefavorites { get; set; }
    }
}

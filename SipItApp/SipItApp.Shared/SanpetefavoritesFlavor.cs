using System;
using System.Collections.Generic;

namespace SipItApp.Shared
{
    public partial class SanpetefavoritesFlavor
    {
        public int Id { get; set; }
        public int? SanpetefavoritesId { get; set; }
        public int? FlavorId { get; set; }

        public virtual Flavor Flavor { get; set; }
        public virtual Sanpetefavorites Sanpetefavorites { get; set; }
    }
}

using SipItApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SipItApp.API.Data
{
    public class DataService : IDataService
    {
        private readonly sipitContext sipit;

        public IQueryable<Base> Bases => sipit.Bases;

        public IQueryable<Flavor> Flavors => sipit.Flavors;

        public IQueryable<Sanpetefavorites> Sanpetefavorites => sipit.Sanpetefavorites;

        public IQueryable<SanpetefavoritesFlavor> SanpetefavoritesFlavors => sipit.SanpetefavoritesFlavors;

        public IQueryable<Size> Sizes => sipit.Sizes;

        public DataService(sipitContext sipit)
        {
            this.sipit = sipit ?? throw new ArgumentNullException(nameof(sipit));
        }
    }
}

using SipItApp.API.Models;
using SipItApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SipItApp.API.Data
{
    public interface IDataService
    {
        IQueryable<Base> Bases { get; }
        IQueryable<Flavor> Flavors { get; }
        IQueryable<Sanpetefavorites> Sanpetefavorites { get; }
        IQueryable<SanpetefavoritesFlavor> SanpetefavoritesFlavors { get; }

        IQueryable<Size> Sizes { get; }
    }
}

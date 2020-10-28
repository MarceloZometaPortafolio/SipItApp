using Refit;
using SipItApp.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SipItApp.Data
{
    public interface IAPIService
    {
        [Get("/menu/getbases")]
        Task<Base> GetBase();

        [Get("/menu/getflavors")]
        Task<Base> GetFlavors();

        [Get("/menu/getsanpetefavorites")]
        Task<IEnumerable<Sanpetefavorites>> GetSanpeteFavorites();

        [Get("/menu/getsanpetefavoritesflavors")]
        Task<Base> GetSanpetefavoritesFlavors();

        [Get("/menu/getsizes")]
        Task<Base> GetSizes();
    }
}

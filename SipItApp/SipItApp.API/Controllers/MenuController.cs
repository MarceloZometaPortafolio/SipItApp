using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SipItApp.API.Data;
using SipItApp.Shared;

namespace SipItApp.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IDataService service;

        public MenuController(IDataService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet("[action]")]
        public async Task<List<Base>> GetBases()
        {
            var bases = await service.Bases.ToListAsync();
            return bases;
        }

        [HttpGet("[action]")]
        public async Task<List<Flavor>> GetFlavors()
        {
            var flavors = await service.Flavors.ToListAsync();
            return flavors;
        }

        [HttpGet("[action]")]
        public async Task<List<Sanpetefavorites>> GetSanpetefavorites()
        {
            var sanpetefavorites = await service.Sanpetefavorites.ToListAsync();
            return sanpetefavorites;
        }

        [HttpGet("[action]")]
        public async Task<List<SanpetefavoritesFlavor>> GetSanpetefavoritesFlavors()
        {
            var sanpetefavoritesFlavors = await service.SanpetefavoritesFlavors.ToListAsync();
            return sanpetefavoritesFlavors;
        }

        [HttpGet("[action]")]
        public async Task<List<SipItApp.Shared.Size>> GetSizes()
        {
            var sizes= await service.Sizes.ToListAsync();
            return sizes;
        }
    }
}

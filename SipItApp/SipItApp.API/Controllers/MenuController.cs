using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SipItApp.API.Data;
using SipItApp.API.Models;

namespace SipItApp.API.Controllers
{
    [Route("api/[controller]")]
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
    }
}

using Refit;
using SipItApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SipItApp.Services
{
    public interface ISipItService
    {
        [Get("/customer")]
        Task<IEnumerable<Customer>> GetCustomersAsync();
    }
}

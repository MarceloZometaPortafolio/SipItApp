using Refit;
using SipItApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SipItApp.Services
{
    //JUST WHAT IS THIIIISSSS. DELETE IT!
    public interface ISipItService
    {
        [Get("/customer")]
        Task<IEnumerable<Customer>> GetCustomersAsync();
    }
}

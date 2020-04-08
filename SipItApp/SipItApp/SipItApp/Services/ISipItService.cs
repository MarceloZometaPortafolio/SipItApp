using Refit;
using SipItApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SipItApp.Services
{
    public interface ISipItService
    {
        [Get("/customer")]
        IEnumerable<Customer> GetCustomers();
    }
}

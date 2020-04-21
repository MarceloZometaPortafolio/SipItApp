using SipItApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SipItApp.Services
{
    public interface ILoginService
    {
        void setCurrentCustomer(Customer customer);
        Customer getCurrentCustomer();
    }
}

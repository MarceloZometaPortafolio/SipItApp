using SipItApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SipItApp.Services
{
    public class LoginService : ILoginService
    {
        private Customer customer;

        public LoginService()
        {
            //customer = new Customer();
        }

        public Customer getCurrentCustomer()
        {
            return customer;
        }

        public void setCurrentCustomer(Customer customer)
        {
            this.customer = customer;
        }

    }
}

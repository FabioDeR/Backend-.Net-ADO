using MovieDAL.Models;
using MovieDAL.Services;
using MovielRental.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovielRental.Models.Service
{
    public class AuthService : IAuthService
    {
        private CustomerService _service;

        public AuthService()
        {
            _service = new CustomerService();
        }

        public bool Check(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Customer Login(string email, string passwd)
        {
            Customer bob = new Customer();
            bob.Email = email;
            bob.Passwd = passwd;
            return _service.GetCheck(bob);
        }

        public int Register(Customer customer)
        {
            return _service.Insert(customer);
        }
    }
}

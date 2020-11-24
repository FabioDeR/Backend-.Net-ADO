using MovieDAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDAL.Services
{
    interface IAuthService
    {
        Customer Login(string email, string passwd);

        int Register(Customer customer);

        bool Check(Customer customer);
    }
}

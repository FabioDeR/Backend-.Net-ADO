﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieDAL.Models;
using MovieDAL.Services;
using MovielRental.Infrastructure.Security;
using MovielRental.Models.Forms;
using MovielRental.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovielRental.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly TokenService _tokenService;



        public CustomerController()
        {
            _authService = new AuthService();
            _tokenService = new TokenService();
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterForm form)
        {
            if (ModelState.IsValid)
            {
                Customer customer = new Customer()
                {
                    LastName = form.LastName,
                    FirstName = form.FirstName,
                    Email = form.Email,
                    Passwd = form.Passwd
                };
                _authService.Register(customer);
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginForm form)
        {
            if (ModelState.IsValid)
            {
                Customer customer = _authService.Login(form.Email, form.Passwd);

                if (customer is null)
                {
                    return NotFound();
                }

                customer.Token = _tokenService.GenerateToken(customer);

                return Ok(customer);
            }

            return BadRequest();
        }


    }

}

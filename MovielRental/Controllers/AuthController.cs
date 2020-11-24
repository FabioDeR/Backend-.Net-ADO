using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieDAL.Models;
using MovielRental.Infrastructure.Security;
using MovielRental.Models.Forms;
using MovielRental.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovielRental.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ITokenService _tokenService;


        public AuthController(IAuthService authService, ITokenService tokenService)
        {
            _authService = authService;
            _tokenService = tokenService;
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
    

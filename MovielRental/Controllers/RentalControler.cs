using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieDAL.Services;
using MovieDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovielRental.Controllers
{
    [Route("api/[controller]")]
    
    public class RentalControler : ControllerBase
    {
        private RentalService _service;

        public RentalControler()
        {
            _service = new RentalService();
        }

        [HttpPost]
        [Route("Location")]
        public IActionResult post(Rental rent, int[] fi)
        {

            return Ok(_service.Insertion(rent, fi));
        }
    }
}

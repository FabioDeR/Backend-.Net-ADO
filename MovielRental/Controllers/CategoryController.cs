using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieDAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovielRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ServiceCategory _service;



        public CategoryController()
        {
            _service = new ServiceCategory();
        }




        [HttpGet]
        public IActionResult getAll()
        {
            return Ok(_service.GetAll());
        }

    }
}


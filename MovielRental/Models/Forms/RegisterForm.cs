﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovielRental.Models.Forms
{
    public class RegisterForm
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]

        public string LastName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(328)]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        public string Passwd { get; set; }
    }
}

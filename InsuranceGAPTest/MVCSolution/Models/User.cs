﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSolution.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }        
        public string Username { get; set; }
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
        public string Password { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HW.Models
{
    public class User
    {
        [Key]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "User Name must be 3 to 15 characters")]
        public string UserName { get; set; }



        [Required]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Password must be 3 to 15 characters")]
        public string Password { get; set; }

    }
}
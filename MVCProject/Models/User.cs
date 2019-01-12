using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCProject.Models
{
    //A class that represents the user.
    public class User
    {
        [Key]
        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Username must be 5 to 20 characters")]
        public string username { get; set; }
        [Required]
        [StringLength(65, MinimumLength = 5, ErrorMessage = "Password must be 5 to 65 characters")]
        public string password { get; set; }
    }
}
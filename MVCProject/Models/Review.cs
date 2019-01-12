using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    //A class that represents the Review option.
    public class Review
    {
        public string name { get; set; }
        [Required]
        [Key]
        [StringLength(200, MinimumLength = 0, ErrorMessage = "Maximum 200 chars.")]
        public string review { get; set; }
    }
}
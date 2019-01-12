using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    //A class that represents the Report option.
    public class Complaint
    {
        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Username must be 5 to 20 characters")]
        public string username { get; set; }
        [Key]
        [Required]
        [StringLength(400, MinimumLength = 5, ErrorMessage = "Complain must be 5 to 400 characters")]
        public string complaint { get; set; }
    }
}
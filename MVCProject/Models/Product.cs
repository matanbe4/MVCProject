using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    //A class that represents the products of the shop.
    public class Product
    {   
        [Key]
        [Required]
        public string name { get; set; }
        [Required]
        public double price{ get; set; }
    }
}
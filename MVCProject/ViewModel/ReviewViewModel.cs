using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCProject.Models;

namespace MVCProject.ViewModel
{
    //A View Model for Reviews.
    public class ReviewViewModel
    {
        public Review review { get; set; }
        public List<Review> reviews { get; set; }
    }
}
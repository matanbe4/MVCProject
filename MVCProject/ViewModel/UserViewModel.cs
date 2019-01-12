using MVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProject.ViewModel
{
    //A View Model for Users.
    public class UserViewModel
    {
        public User user { get; set; }
        public List<User> users { get; set; }
    }
}
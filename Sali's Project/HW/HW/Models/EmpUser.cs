using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW.Models
{
    public class EmpUser
    {
     

        public EmpUser(Employee employee, User user)
        {
            this.emp = employee;
            this.usr = user;
        }

        public Employee emp { get; set; }
        public User usr { get; set; }

        
    }
}
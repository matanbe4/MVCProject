using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HW.Models
{
    public class Employee
    {
        [Key, Column(Order = 0)]
        [Required]
        public string FirstName { get; set; }

        [Key, Column(Order = 1)]
        [Required]
        public string LastName { get; set; }

        [Required]
        public bool Sun { get; set; }

        [Required]
        public bool Mon { get; set; }

        [Required]
        public bool Tue { get; set; }

        [Required]
        public bool Wed { get; set; }

        [Required]
        public bool Thu { get; set; }

        [Required]
        public bool Fri { get; set; }

        [Required]
        public bool Sat { get; set; }

        public void setShifts(Employee emp)
        {
            Sun = emp.Sun;
            Mon = emp.Mon;
            Tue = emp.Tue;
            Wed = emp.Wed;
            Thu = emp.Thu;
            Fri = emp.Fri;
            Sat = emp.Sat;
        }
    }
}
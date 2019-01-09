using HW.Dal;
using HW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW.ModelView
{
    public class EmployeeViewModel
    {
        private Employee employee;
        private User user;

        public EmployeeViewModel(Employee employee, User user)
        {
            this.employee = employee;
            this.user = user;
            this.emps = (new EmployeeDal()).Employees.ToList<Employee>();
        }

        public EmployeeViewModel()
        {
            this.emps = (new EmployeeDal()).Employees.ToList<Employee>();
        }

        public Employee emp { get; set; }
        public List<Employee> emps { get; set; }
        public User usr { get; set; }
    }
}
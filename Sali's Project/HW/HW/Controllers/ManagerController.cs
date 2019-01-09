using HW.Models;
using HW.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HW.Dal;
using HW.Classes;
using static HW.FilterConfig;

namespace HW.Controllers
{
    public class ManagerController : Controller
    {

        public ActionResult ManagMenu(Manager mng)
        {
            // after login with a manager user getting into this menu
            return View(mng);
        }


       
        public ActionResult AddEmp()
        {
            EmployeeViewModel emp = new EmployeeViewModel(new Employee(), new User());

            // Creates an emp obj and user obj to use when creating a new employee
            return View(emp);
        }

        [HttpPost]
        public ActionResult EditEmp(Employee emp , User usr)
        {
            UserDal dal = new UserDal();
            Encryption enc = new Encryption();
            usr.Password = enc.CreateHash(usr.Password);
            dal.Users.Add(usr);// in local mermory adding
            dal.SaveChanges(); // save changes in DB

            EmployeeDal.empToChange = emp;
            return View(emp); // return to editing shifts view
        }



        public ActionResult SubmitAdd (Employee emp)
        {
            Employee Curemp = EmployeeDal.empToChange;
            Curemp.setShifts(emp);

            EmployeeDal dal = new EmployeeDal();
            dal.Employees.Add(Curemp);
            dal.SaveChanges(); // save changes in DB


            return View(Curemp);
        }


        [NoDirectAccess]
        public ActionResult ShowShifts()
        {
            return View(new EmployeeDal());
        }


        public ActionResult GetEmployees()
        {
            EmployeeDal dal = new EmployeeDal();
            List<Employee> emps = dal.Employees.ToList();
            return Json(emps, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Vieww()
        {

            List<Employee> emps = (new EmployeeDal()).Employees.ToList<Employee>();
            return View(emps);
        }

    }
}
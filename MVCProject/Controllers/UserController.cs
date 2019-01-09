using MVCProject.Dal;
//using MVCProject.ModelBinders;
using MVCProject.Models;
//using MVCProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProject.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /Customer/
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult ShowSearch()
        //{
        //    CustomerViewModel cvm = new CustomerViewModel();
        //    cvm.customer = new Customer();
        //    cvm.customers = new List<Customer>();
        //    return View("SearchCustomer", cvm);
        //}

        //public ActionResult SearchCustomer()
        //{
        //    CustomerDal dal = new CustomerDal();
        //    CustomerViewModel cvm = new CustomerViewModel();

        //    string searchVal = Request.Form["txtFirstName"].ToString();
        //    List<Customer> objCustomers = (from x in dal.Customers
        //                                   where x.FirstName.Contains(searchVal)
        //                                   select x).ToList<Customer>();

        //    Customer objCust = new Customer();
        //    objCust.FirstName = searchVal;
        //    cvm.customer = objCust;
        //    cvm.customers = objCustomers;

        //    return View(cvm);


        //}

        //public ActionResult Enter()
        //{
        //    CustomerDal dal = new CustomerDal();
        //    CustomerViewModel cvm = new CustomerViewModel();
        //    cvm.customer = new Customer();
        //    cvm.customers = dal.Customers.ToList<Customer>();
        //    return View(cvm);
        //}

        public ActionResult Register()
        {
            return View(new User());
        }

        public ActionResult SubmitRegister(User user)
        {
            UsersDal dal = new UsersDal();

            if (ModelState.IsValid)
            {
                dal.users.Add(user);
                dal.SaveChanges();
                user = new User();
            }
            return View("Register", user);
        }

        public ActionResult UserLogin()
        {
            return View(new User());
        }

        public ActionResult AdminLogin()
        {
            return View();
        }

        public ActionResult SubmitLogin(User user)
        {
            UsersDal dal = new UsersDal();
            List<User> users = dal.users.ToList<User>();
            bool exists = false;
            foreach(User u in users)
                if(u.username == user.username && u.password == user.password)
                {
                    exists = true;
                    break;
                }
            if (exists == true)
            {
                
            }
            return View("UserLogin", user);
        }
    }
}
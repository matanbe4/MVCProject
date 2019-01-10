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
                return RedirectToAction("Index", "Home");
            }
            return View("Register", user);
        }

        public ActionResult UserLogin()
        {
            if(Session["loggedOn"] == null)
            {
                return View(new User());
            }
            return RedirectToAction("Logout", "User");
        }

        public ActionResult AdminLogin()
        {
            if (Session["loggedOn"] == null)
            {
                return View(new Admin());
            }
            return RedirectToAction("Logout", "User");
        }

        public ActionResult Logout()
        {
            if(Session["loggedOn"] == null)
            {
                Session["LogoutStatus"] = "No user is logged on.";
            }
            return View();
        }

        public ActionResult LogoutAction()
        {
            Session["loggedOn"] = null;
            Session["LogoutStatus"] = null;
            Session["userType"] = null;
            return RedirectToAction("Index","Home");
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
                Session["username"] = user.username;
                Session["loggedOn"] = "true";
                TempData["LoginStatus"] = "";
                Session["userType"] = "user";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["LoginStatus"] = "Username or Password are incorrect.";
                return View("UserLogin", user);
            }
        }

        public ActionResult SubmitAdminLogin(Admin user)
        {
            AdminsDal dal = new AdminsDal();
            List<Admin> users = dal.users.ToList<Admin>();
            bool exists = false;
            foreach (Admin u in users)
                if (u.username == user.username && u.password == user.password)
                {
                    exists = true;
                    break;
                }
            if (exists == true)
            {
                Session["username"] = user.username;
                Session["loggedOn"] = "true";
                Session["userType"] = "admin";
                TempData["LoginStatus"] = "";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["LoginStatus"] = "Username or Password are incorrect.";
                return View("AdminLogin", user);
            }
        }
    }
}
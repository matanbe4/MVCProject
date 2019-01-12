using MVCProject.Dal;
//using MVCProject.ModelBinders;
using MVCProject.Models;
using MVCProject.ViewModel;
//using MVCProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCProject.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            if (Session["userType"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(new User());
        }

        public ActionResult SubmitRegister(User user)
        {
            UsersDal dal = new UsersDal();
            if (ModelState.IsValid)
            {
                try
                {
                    dal.users.Add(user);
                    dal.SaveChanges();
                    TempData["LoginStatus"] = null;
                }
                catch (DbUpdateException e)
                {
                    TempData["LoginStatus"] = "Username already exists.";
                    return View("Register", user);
                }
                return RedirectToAction("Index", "Home");
            }
            return View("Register", user);
        }

        public ActionResult UserLogin()
        {
            if (Session["loggedOn"] == null)
            {
                Session["LogoutStatus"] = null;
                return View(new User());
            }
            return RedirectToAction("Logout", "User");
        }

        public ActionResult AdminLogin()
        {
            if (Session["loggedOn"] == null)
            {
                Session["LogoutStatus"] = null;
                return View(new Admin());
            }
            return RedirectToAction("Logout", "User");
        }

        public ActionResult Logout()
        {
            if (Session["loggedOn"] == null)
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
            return RedirectToAction("Index", "Home");
        }

        public ActionResult SubmitLogin(User user)
        {
            UsersDal dal = new UsersDal();
            List<User> users = dal.users.ToList<User>();
            bool exists = false;
            foreach (User u in users)
                if (u.username == user.username && u.password == user.password)
                {
                    exists = true;
                    break;
                }
            if (exists == true)
            {
                FormsAuthentication.SetAuthCookie("cookie", true);
                Session["username"] = user.username;
                Session["loggedOn"] = "true";
                TempData["LoginStatus"] = null;
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
                FormsAuthentication.SetAuthCookie("cookie", true);
                Session["username"] = user.username;
                Session["loggedOn"] = "true";
                Session["userType"] = "admin";
                TempData["LoginStatus"] = null;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["LoginStatus"] = "Username or Password are incorrect.";
                return View("AdminLogin", user);
            }
        }

        public ActionResult AdminTools()
        {
            if (Session["userType"] == null || Session["userType"].ToString() != "admin")
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult ManageUsers()
        {
            UserViewModel uvm = new UserViewModel();
            uvm.user = new User();
            uvm.users = new List<User>();
            return View("SearchUser", uvm);
        }

        public ActionResult SearchUser()
        {
            UsersDal dal = new UsersDal();
            UserViewModel uvm = new UserViewModel();
            if (Request.Form["username"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            string searchVal = Request.Form["username"].ToString();
            List<User> objUsers = (from x in dal.users
                                   where x.username.Contains(searchVal)
                                   select x).ToList<User>();
            User objUser = new User();
            objUser.username = searchVal;
            uvm.user = objUser;
            uvm.users = objUsers;
            return View(uvm);
        }

        public ActionResult AddAdmin()
        {
            if (Session["userType"] != null && Session["userType"].ToString() == "admin")
            {
                return View(new Admin());
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult SubmitAdminRegister(Admin admin)
        {
            AdminsDal dal = new AdminsDal();
            if (ModelState.IsValid)
            {
                try
                {
                    dal.users.Add(admin);
                    dal.SaveChanges();
                    TempData["LoginStatus"] = null;
                }
                catch (DbUpdateException e)
                {
                    TempData["LoginStatus"] = "Username already exists.";
                    return View("AddAdmin", admin);
                }
                return RedirectToAction("Index", "Home");
            }
            return View("AddAdmin", admin);
        }

    }
}
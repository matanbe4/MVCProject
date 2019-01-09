using HW.Classes;
using HW.Dal;
using HW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HW.Controllers
{
    // [Authorize]
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Index()
        {
            //TODO change it later.
            return View("UserLogin");
        }

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult UserAuthenticate(User usr)
        {//Here we will check if there a user with the details that been sent,we dont need model binder cause the name as the prop
            UserDal Udal = new UserDal();
            if (ModelState.IsValid)//Entered pass and username!
            {
                Encryption enc = new Encryption();
                //Code to check if user==pass and exits on the db
                //Transfer to homepage
                //Linq Query:
                List<User> userValid = (from u in Udal.Users
                                        where (u.UserName == usr.UserName)
                                        select u).ToList<User>();

                if (userValid != null)
                {
                    if (enc.ValidatePassword(usr.Password, userValid[0].Password))  //user authenicated succesfully we have only 1 user like this,UserName is a Key.
                    {
                        //Making cookies to save the logged user inside the system,and saves the authenction
                        FormsAuthentication.SetAuthCookie("cookie", true);
                        //will send here to HomePage for search a worker and to add new worker
                        return RedirectToRoute("UserDefaltPage");
                    }

                    else
                    {
                        //  ViewBag["Authenticateon field"];
                        return View("UserLogin", usr);
                    }
                }
                else
                {
                    //  ViewBag["Authenticateon field"];
                    return View("UserLogin", usr);
                }
            }

            else
            {
                //  ViewBag["Authenticateon field"];
                return View("UserLogin", usr);
            }

            
        }

        public ActionResult ManagerAuthenticate(Manager mgn)
        {//Here we will check if there a user with the details that been sent,we dont need model binder cause the name as the prop
            ManagerDal Mdal = new ManagerDal();
            if (ModelState.IsValid)//Entered pass and username was valid.
            {
                //Code to check if user==pass and exits on the db
                //Transfer to homepage
                //Linq Query:
                List<Manager> ManagerValid = (from u in Mdal.Managers
                                              where ((u.UserName == mgn.UserName) && (u.Password == mgn.Password))
                                              select u).ToList<Manager>();


                if (ManagerValid.Count == 1) //user authenicated succesfully we have only 1 user like this.

                {
                    //Making cookies to save the logged user inside the system,and saves the authenction
                    FormsAuthentication.SetAuthCookie("cookie", true);
                    //will send here to HomePage for search a worker and to add new worker
                    return RedirectToRoute("ManagerDefaltPage");

                }
                else
                {
                    //  ViewBag["Authenticateon field"];
                    return View("ManagerLogin", mgn);
                }


            }
            else
            {
                return View("ManagerLogin", mgn);
            }


        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();

        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }





}

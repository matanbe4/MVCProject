using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject.Models;
using MVCProject.ViewModel;
using MVCProject.Dal;

namespace MVCProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public ActionResult ReviewAction()
        {
            return View(new ReviewViewModel());
        }
        public ActionResult AddReview(ReviewViewModel rev)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            ReviewsDal dal = new ReviewsDal();
            Review review = new Review();
            if (ModelState.IsValid)
            {
                review = rev.review;
                review.name = Session["username"].ToString();
                dal.reviews.Add(review);
                dal.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View("Contact");
        }
    }
}
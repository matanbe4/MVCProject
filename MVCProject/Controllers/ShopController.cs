using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject.Models;
using MVCProject.ViewModel;
using MVCProject.Dal;
using System.Data.Entity.Infrastructure;
using System.Threading;

namespace MVCProject.Controllers
{
    [Authorize]
    public class ShopController : Controller
    {
        public ActionResult ShopProducts()
        {
            ProductViewModel pvm = new ProductViewModel();
            pvm.product = new Product();
            pvm.products = new List<Product>();
            return View("SearchProduct", pvm);
        }

        public ActionResult SearchProduct()
        {
            ProductsDal dal = new ProductsDal();
            ProductViewModel pvm = new ProductViewModel();
            if (Request.Form["name"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            string searchVal = Request.Form["name"].ToString();
            List<Product> objProducts = (from x in dal.products
                                         where x.name.Contains(searchVal)
                                         select x).ToList<Product>();
            Product objProduct = new Product();
            objProduct.name = searchVal;
            pvm.product = objProduct;
            pvm.products = objProducts;
            return View(pvm);
        }

        public ActionResult GetProductsByJason()
        {
            ProductsDal dal = new ProductsDal();
            //Thread.Sleep(2000);
            List<Product> objProducts = dal.products.ToList<Product>();
            return Json(objProducts, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ManageProducts()
        {
            if (Session["userType"] == null || Session["userType"].ToString() != "admin")
            {
                return RedirectToAction("Index", "Home");
            }
            ProductViewModel pvm = new ProductViewModel();
            pvm.product = new Product();
            pvm.products = (new ProductsDal()).products.ToList<Product>();
            return View("ProductAction", pvm);
        }

        public ActionResult ProductAction()
        {
            TempData["ProductErr"] = null;
            ProductsDal dal = new ProductsDal();
            ProductViewModel pvm = new ProductViewModel();
            pvm.product = new Product();
            pvm.products = dal.products.ToList<Product>();
            if (Request.Form["name"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            string newName = Request.Form["name"].ToString();
            if(newName == "")
            {
                TempData["ProductErr"] = "Please fill product name.";
                return View(pvm);
            }
            double newPrice = double.Parse(Request.Form["price"].ToString());
            Product objProduct = new Product();
            objProduct.name = newName;
            objProduct.price = newPrice;
            pvm.product = objProduct;
            try
            {
                dal.products.Add(objProduct);
                dal.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                TempData["ProductErr"] = "Product already exists.";
                return View(pvm);
            }

            List<Product> objProducts = (from x in dal.products
                                         select x).ToList<Product>();
            pvm.product = objProduct;
            pvm.products = objProducts;
            return View(pvm);
        }
    }
}
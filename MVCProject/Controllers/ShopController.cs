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
    [Authorize]
    public class ShopController : Controller
    {

        public ActionResult ManageProducts()
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
    }
}
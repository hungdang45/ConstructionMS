using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConstructionMS.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddProduct()
        {
            return View();
        }

        public ActionResult EditProduct()
        {
            return View();
        }

        public ActionResult DeleteProduct()
        {
            return View();
        }
    }
}
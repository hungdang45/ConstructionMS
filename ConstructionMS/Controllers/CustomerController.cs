using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConstructionMS.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddOrder()
        {
            return View();
        }

        public ActionResult EditOrder()
        {
            return View();
        }

        public ActionResult DeleteOrder()
        {
            return View();
        }

        public ActionResult AddReceipt()
        {
            return View();
        }

        public ActionResult EditReceipt()
        {
            return View();
        }

        public ActionResult DeleteReceipt()
        {
            return View();
        }
    }
}
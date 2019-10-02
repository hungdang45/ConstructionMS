using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConstructionMS.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddBlog()
        {
            return View();
        }

        public ActionResult EditBlog()
        {
            return View();
        }

        public ActionResult DeleteBlog()
        {
            return View();
        }

        public ActionResult AddProductCategory()
        {
            return View();
        }

        public ActionResult EditProductCategory()
        {
            return View();
        }

        public ActionResult DeleteProductCategory()
        {
            return View();
        }
    }
}
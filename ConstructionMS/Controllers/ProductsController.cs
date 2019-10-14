using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ConstructionMS;
using Image = System.Drawing.Image;

namespace ConstructionMS.Controllers
{

    public static class HtmlExtensions
    {
        public static MvcHtmlString Image(this HtmlHelper html, byte[] image)
        {
            var img = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(image));
            return new MvcHtmlString("<img src='" + img + "' />");
        }

    

    }
    public class ProductsController : Controller
    {
        private CMSEntities db = new CMSEntities();

       
        [HttpGet]       
        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.CategoryType).Include(p => p.Manager);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryTypeID = new SelectList(db.CategoryTypes, "CategoryTypeID", "TypeName");
            ViewBag.ManagerID = new SelectList(db.Managers, "ManagerID", "ManagerName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        //Safe Code here
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ProductName,Brand,Size,Description,Price,ProductCode,Quantity,Status,Height,CategoryTypeID,ManagerID,Material,ProductImage,ImageUpload")] Product product, HttpPostedFileBase file)
        {
            string fileContent = string.Empty;
            string fileContentType = string.Empty;

            byte[] bytes;
            using (BinaryReader br = new BinaryReader(file.InputStream))
            {
                bytes = br.ReadBytes(file.ContentLength);
            }

            CMSEntities entities = new CMSEntities();
            entities.Products.Add(new Product
            {
                ProductID=product.ProductID,
                ProductName=product.ProductName,
                ProductCode = product.ProductCode,
                Brand = product.Brand,
                Size = product.Size,
                Description = product.Description,
                Price = product.Price,
              
                Quantity= product.Quantity,
                Status=product.Status,
                Height=product.Height,
                CategoryTypeID=product.CategoryTypeID,
                Material=product.Material,
                ImageUpload = bytes

            });
            entities.SaveChanges();

            if (file != null && file.ContentLength > 0)
            {
                
                // extract only the fielname
                var fileName = Path.GetFileName(file.FileName);
                // store the file inside ~/App_Data/uploads folder
                product.ImageUpload = new byte[file.ContentLength];
                file.InputStream.Read(product.ImageUpload, 0, file.ContentLength);

                var path = Path.Combine(Server.MapPath("~/Content/Uploads/"), fileName);
                file.SaveAs(path);
            }

            if (ModelState.IsValid)
            {
                // Converting to bytes.
               
                product.ImageUpload = new byte[file.ContentLength];
                
                file.InputStream.Read(product.ImageUpload, 0, file.ContentLength);

                //db.Entry(product).State = EntityState.Modified;

                //Original add product code
                //db.Products.Add(product);
                //await db.SaveChangesAsync();
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryTypeID = new SelectList(db.CategoryTypes, "CategoryTypeID", "TypeName", product.CategoryTypeID);
            ViewBag.ManagerID = new SelectList(db.Managers, "ManagerID", "ManagerName", product.ManagerID);
            return View(product);
        }



        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryTypeID = new SelectList(db.CategoryTypes, "CategoryTypeID", "TypeName", product.CategoryTypeID);
            ViewBag.ManagerID = new SelectList(db.Managers, "ManagerID", "ManagerName", product.ManagerID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductName,Brand,Size,Description,Price,ProductCode,ProductImage,Quantity,Status,Height,CategoryTypeID,ManagerID,Material")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryTypeID = new SelectList(db.CategoryTypes, "CategoryTypeID", "TypeName", product.CategoryTypeID);
            ViewBag.ManagerID = new SelectList(db.Managers, "ManagerID", "ManagerName", product.ManagerID);
            return View(product);
        }

        //GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
                     
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
            return View(product);
            
        }

        // POST: Products/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Product product = db.Products.Find(id);
        //    db.Products.Remove(product);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

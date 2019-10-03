using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ConstructionMS;

namespace ConstructionMS.Controllers
{
    public class OrdersController : Controller
    {
        private CMSEntities db = new CMSEntities();

        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Customer).Include(o => o.Guest).Include(o => o.Receipt).Include(o => o.Staff);
            return View(orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.StaffID = new SelectList(db.Customers, "CustomerID", "CustomerName");
            ViewBag.GuestID = new SelectList(db.Guests, "GuestID", "GuestName");
            ViewBag.ReceiptID = new SelectList(db.Receipts, "ReceiptID", "ReceiptName");
            ViewBag.StaffID = new SelectList(db.Staffs, "StaffID", "StaffName");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,OrderName,ReceiptID,StaffID,TotalOrder,CustomerID,GuestID")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StaffID = new SelectList(db.Customers, "CustomerID", "CustomerName", order.StaffID);
            ViewBag.GuestID = new SelectList(db.Guests, "GuestID", "GuestName", order.GuestID);
            ViewBag.ReceiptID = new SelectList(db.Receipts, "ReceiptID", "ReceiptName", order.ReceiptID);
            ViewBag.StaffID = new SelectList(db.Staffs, "StaffID", "StaffName", order.StaffID);
            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.StaffID = new SelectList(db.Customers, "CustomerID", "CustomerName", order.StaffID);
            ViewBag.GuestID = new SelectList(db.Guests, "GuestID", "GuestName", order.GuestID);
            ViewBag.ReceiptID = new SelectList(db.Receipts, "ReceiptID", "ReceiptName", order.ReceiptID);
            ViewBag.StaffID = new SelectList(db.Staffs, "StaffID", "StaffName", order.StaffID);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,OrderName,ReceiptID,StaffID,TotalOrder,CustomerID,GuestID")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StaffID = new SelectList(db.Customers, "CustomerID", "CustomerName", order.StaffID);
            ViewBag.GuestID = new SelectList(db.Guests, "GuestID", "GuestName", order.GuestID);
            ViewBag.ReceiptID = new SelectList(db.Receipts, "ReceiptID", "ReceiptName", order.ReceiptID);
            ViewBag.StaffID = new SelectList(db.Staffs, "StaffID", "StaffName", order.StaffID);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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

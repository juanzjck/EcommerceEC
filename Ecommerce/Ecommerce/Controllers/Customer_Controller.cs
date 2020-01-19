using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ecommerce.Models;

namespace Ecommerce.Controllers
{
    public class Customer_Controller : Controller
    {
        private EcommerceECDBEntities db = new EcommerceECDBEntities();

        // GET: Customer_
        public ActionResult Index()
        {
            return View(db.Customer_.ToList());
        }

        // GET: Customer_/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_ customer_ = db.Customer_.Find(id);
            if (customer_ == null)
            {
                return HttpNotFound();
            }
            return View(customer_);
        }

        // GET: Customer_/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer_/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCustomer,userName,firstName,lastName,email")] Customer_ customer_)
        {
            if (ModelState.IsValid)
            {
                db.Customer_.Add(customer_);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer_);
        }

        // GET: Customer_/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_ customer_ = db.Customer_.Find(id);
            if (customer_ == null)
            {
                return HttpNotFound();
            }
            return View(customer_);
        }

        // POST: Customer_/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCustomer,userName,firstName,lastName,email")] Customer_ customer_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer_).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer_);
        }

        // GET: Customer_/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_ customer_ = db.Customer_.Find(id);
            if (customer_ == null)
            {
                return HttpNotFound();
            }
            return View(customer_);
        }

        // POST: Customer_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer_ customer_ = db.Customer_.Find(id);
            db.Customer_.Remove(customer_);
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

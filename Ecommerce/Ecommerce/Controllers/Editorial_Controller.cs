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
    public class Editorial_Controller : Controller
    {
        private EcommerceECDBEntities db = new EcommerceECDBEntities();

        // GET: Editorial_
        public ActionResult Index()
        {
            return View(db.Editorial_.ToList());
        }

        // GET: Editorial_/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Editorial_ editorial_ = db.Editorial_.Find(id);
            if (editorial_ == null)
            {
                return HttpNotFound();
            }
            return View(editorial_);
        }

        // GET: Editorial_/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Editorial_/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEditorial")] Editorial_ editorial_)
        {
            if (ModelState.IsValid)
            {
                db.Editorial_.Add(editorial_);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(editorial_);
        }

        // GET: Editorial_/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Editorial_ editorial_ = db.Editorial_.Find(id);
            if (editorial_ == null)
            {
                return HttpNotFound();
            }
            return View(editorial_);
        }

        // POST: Editorial_/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEditorial")] Editorial_ editorial_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(editorial_).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(editorial_);
        }

        // GET: Editorial_/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Editorial_ editorial_ = db.Editorial_.Find(id);
            if (editorial_ == null)
            {
                return HttpNotFound();
            }
            return View(editorial_);
        }

        // POST: Editorial_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Editorial_ editorial_ = db.Editorial_.Find(id);
            db.Editorial_.Remove(editorial_);
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

﻿using System;
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
    public class Category_Controller : Controller
    {
        private EcommerceECDBEntities db = new EcommerceECDBEntities();

        // GET: Category_
        public ActionResult Index()
        {
            return View(db.Category_.ToList());
        }

        // GET: Category_/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category_ category_ = db.Category_.Find(id);
            if (category_ == null)
            {
                return HttpNotFound();
            }
            return View(category_);
        }

        // GET: Category_/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category_/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCategory,categoryName,categoryDescripton")] Category_ category_)
        {
            if (ModelState.IsValid)
            {
                db.Category_.Add(category_);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category_);
        }

        // GET: Category_/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category_ category_ = db.Category_.Find(id);
            if (category_ == null)
            {
                return HttpNotFound();
            }
            return View(category_);
        }

        // POST: Category_/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCategory,categoryName,categoryDescripton")] Category_ category_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category_).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category_);
        }

        // GET: Category_/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category_ category_ = db.Category_.Find(id);
            if (category_ == null)
            {
                return HttpNotFound();
            }
            return View(category_);
        }

        // POST: Category_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category_ category_ = db.Category_.Find(id);
            db.Category_.Remove(category_);
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

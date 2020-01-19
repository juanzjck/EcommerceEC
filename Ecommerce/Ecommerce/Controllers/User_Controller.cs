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
    public class User_Controller : Controller
    {
        private EcommerceECDBEntities db = new EcommerceECDBEntities();

        // GET: User_
        public ActionResult Index()
        {
            return View(db.User_.ToList());
        }

        // GET: User_/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_ user_ = db.User_.Find(id);
            if (user_ == null)
            {
                return HttpNotFound();
            }
            return View(user_);
        }

        // GET: User_/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User_/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idUsuario,userName,firstName,lastName,email,passwordUser")] User_ user_)
        {
            if (ModelState.IsValid)
            {
                db.User_.Add(user_);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user_);
        }

        // GET: User_/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_ user_ = db.User_.Find(id);
            if (user_ == null)
            {
                return HttpNotFound();
            }
            return View(user_);
        }

        // POST: User_/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idUsuario,userName,firstName,lastName,email,passwordUser")] User_ user_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user_);
        }

        // GET: User_/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_ user_ = db.User_.Find(id);
            if (user_ == null)
            {
                return HttpNotFound();
            }
            return View(user_);
        }

        // POST: User_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User_ user_ = db.User_.Find(id);
            db.User_.Remove(user_);
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

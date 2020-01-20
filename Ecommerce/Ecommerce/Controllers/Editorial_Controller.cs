using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ecommerce.Models;

namespace Ecommerce.Controllers
{
    public class Editorial_Controller : Controller
    {
        private EcommerceECDBEntities1 db = new EcommerceECDBEntities1();

        // GET: Editorial_
        public async Task<ActionResult> Index()
        {
            return View(await db.Editorial_.ToListAsync());
        }

        // GET: Editorial_/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Editorial_ editorial_ = await db.Editorial_.FindAsync(id);
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
        public async Task<ActionResult> Create([Bind(Include = "idEditorial")] Editorial_ editorial_)
        {
            if (ModelState.IsValid)
            {
                db.Editorial_.Add(editorial_);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(editorial_);
        }

        // GET: Editorial_/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Editorial_ editorial_ = await db.Editorial_.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "idEditorial")] Editorial_ editorial_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(editorial_).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(editorial_);
        }

        // GET: Editorial_/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Editorial_ editorial_ = await db.Editorial_.FindAsync(id);
            if (editorial_ == null)
            {
                return HttpNotFound();
            }
            return View(editorial_);
        }

        // POST: Editorial_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Editorial_ editorial_ = await db.Editorial_.FindAsync(id);
            db.Editorial_.Remove(editorial_);
            await db.SaveChangesAsync();
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

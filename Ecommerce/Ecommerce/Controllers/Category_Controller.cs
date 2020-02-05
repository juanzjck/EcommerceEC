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
using System.IO;
namespace Ecommerce.Controllers
{
    public class Category_Controller : Controller
    {
        private EcommerceECDBEntities2 db = new EcommerceECDBEntities2();

        // GET: Category_
        public async Task<ActionResult> Index()
        {
            return View(await db.Category_.ToListAsync());
        }

        // GET: Category_/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category_ category_ = await db.Category_.FindAsync(id);
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
        public async Task<ActionResult> Create([Bind(Include = "idCategory,categoryName,categoryDescripton")] Category_ category_)
        {
            if (ModelState.IsValid)
            {
                db.Category_.Add(category_);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(category_);
        }

        // GET: Category_/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category_ category_ = await db.Category_.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "idCategory,categoryName,categoryDescripton")] Category_ category_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category_).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(category_);
        }

        // GET: Category_/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category_ category_ = await db.Category_.FindAsync(id);
            if (category_ == null)
            {
                return HttpNotFound();
            }
            return View(category_);
        }

        // POST: Category_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Category_ category_ = await db.Category_.FindAsync(id);
            db.Category_.Remove(category_);
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

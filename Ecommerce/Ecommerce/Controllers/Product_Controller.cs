using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Ecommerce.Models;

namespace Ecommerce.Controllers
{
    public class Product_Controller : Controller
    {
        private EcommerceECDBEntities1 db = new EcommerceECDBEntities1();

        // GET: Product_
        public async Task<ActionResult> Index()
        {

            var product_ = db.Product_.Include(p => p.Editorial_);
            return View(await product_.ToListAsync());
        }

        // GET: Product_/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_ product_ = await db.Product_.FindAsync(id);
            if (product_ == null)
            {
                return HttpNotFound();
            }
            return View(product_);
        }

        // GET: Product_/Create
        public ActionResult Create()
        {
            ViewBag.idEditorial = new SelectList(db.Editorial_, "idEditorial", "idEditorial");
            return View();
        }

        // POST: Product_/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create( Product_ product_)
        {

             string fileName = Path.GetFileNameWithoutExtension(product_.productImageFile.FileName);
            string extension = Path.GetExtension(product_.productImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmfff") + extension;
            product_.productImage = "../image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/image/"),fileName);
            product_.productImageFile.SaveAs(fileName);
            if (ModelState.IsValid)
            {
                db.Product_.Add(product_);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idEditorial = new SelectList(db.Editorial_, "idEditorial", "idEditorial", product_.idEditorial);
            return View(product_);
        }

        // GET: Product_/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_ product_ = await db.Product_.FindAsync(id);
            if (product_ == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEditorial = new SelectList(db.Editorial_, "idEditorial", "idEditorial", product_.idEditorial);
            return View(product_);
        }

        // POST: Product_/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idProduct,productName,Sku,stock,productDescription,idEditorial,price,productImage")] Product_ product_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product_).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idEditorial = new SelectList(db.Editorial_, "idEditorial", "idEditorial", product_.idEditorial);
            return View(product_);
        }

        // GET: Product_/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_ product_ = await db.Product_.FindAsync(id);
            if (product_ == null)
            {
                return HttpNotFound();
            }
            return View(product_);
        }

        // POST: Product_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Product_ product_ = await db.Product_.FindAsync(id);
            db.Product_.Remove(product_);
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

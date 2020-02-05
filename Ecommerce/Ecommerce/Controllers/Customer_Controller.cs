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
    public class Customer_Controller : Controller
    {
        private EcommerceECDBEntities2 db = new EcommerceECDBEntities2();

        // GET: Customer_
        public async Task<ActionResult> Index()
        {
            var customer_ = db.Customer_.Include(c => c.User_);
            return View(await customer_.ToListAsync());
        }

        // GET: Customer_/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_ customer_ = await db.Customer_.FindAsync(id);
            if (customer_ == null)
            {
                return HttpNotFound();
            }
            return View(customer_);
        }

        // GET: Customer_/Create
        public ActionResult Create()
        {
            ViewBag.idUser = new SelectList(db.User_, "idUsuario", "userName");
            return View();
        }

        // POST: Customer_/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idCustomer,Dirrecion,Telefono,idUser")] Customer_ customer_)
        {
            if (ModelState.IsValid)
            {
                db.Customer_.Add(customer_);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idUser = new SelectList(db.User_, "idUsuario", "userName", customer_.idUser);
            return View(customer_);
        }

        // GET: Customer_/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_ customer_ = await db.Customer_.FindAsync(id);
            if (customer_ == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUser = new SelectList(db.User_, "idUsuario", "userName", customer_.idUser);
            return View(customer_);
        }

        // POST: Customer_/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idCustomer,Dirrecion,Telefono,idUser")] Customer_ customer_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer_).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idUser = new SelectList(db.User_, "idUsuario", "userName", customer_.idUser);
            return View(customer_);
        }

        // GET: Customer_/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_ customer_ = await db.Customer_.FindAsync(id);
            if (customer_ == null)
            {
                return HttpNotFound();
            }
            return View(customer_);
        }

        // POST: Customer_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Customer_ customer_ = await db.Customer_.FindAsync(id);
            db.Customer_.Remove(customer_);
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

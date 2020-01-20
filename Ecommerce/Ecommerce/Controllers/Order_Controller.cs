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
    public class Order_Controller : Controller
    {
        private EcommerceECDBEntities1 db = new EcommerceECDBEntities1();

        // GET: Order_
        public async Task<ActionResult> Index()
        {
            var order_ = db.Order_.Include(o => o.Customer_);
            return View(await order_.ToListAsync());
        }

        // GET: Order_/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_ order_ = await db.Order_.FindAsync(id);
            if (order_ == null)
            {
                return HttpNotFound();
            }
            return View(order_);
        }

        // GET: Order_/Create
        public ActionResult Create()
        {
            ViewBag.idCustomer = new SelectList(db.Customer_, "idCustomer", "userName");
            return View();
        }

        // POST: Order_/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idOrder,idCustomer")] Order_ order_)
        {
            if (ModelState.IsValid)
            {
                db.Order_.Add(order_);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idCustomer = new SelectList(db.Customer_, "idCustomer", "userName", order_.idCustomer);
            return View(order_);
        }

        // GET: Order_/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_ order_ = await db.Order_.FindAsync(id);
            if (order_ == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCustomer = new SelectList(db.Customer_, "idCustomer", "userName", order_.idCustomer);
            return View(order_);
        }

        // POST: Order_/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idOrder,idCustomer")] Order_ order_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order_).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idCustomer = new SelectList(db.Customer_, "idCustomer", "userName", order_.idCustomer);
            return View(order_);
        }

        // GET: Order_/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_ order_ = await db.Order_.FindAsync(id);
            if (order_ == null)
            {
                return HttpNotFound();
            }
            return View(order_);
        }

        // POST: Order_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Order_ order_ = await db.Order_.FindAsync(id);
            db.Order_.Remove(order_);
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

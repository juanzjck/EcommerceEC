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
    public class Order_preorderController : Controller
    {
        private EcommerceECDBEntities1 db = new EcommerceECDBEntities1();

        // GET: Order_preorder
        public async Task<ActionResult> Index()
        {
            var order_preorder = db.Order_preorder.Include(o => o.Product_).Include(o => o.Customer_);
            return View(await order_preorder.ToListAsync());
        }

        // GET: Order_preorder/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_preorder order_preorder = await db.Order_preorder.FindAsync(id);
            if (order_preorder == null)
            {
                return HttpNotFound();
            }
            return View(order_preorder);
        }

        // GET: Order_preorder/Create
        public ActionResult Create()
        {
            ViewBag.idProduct = new SelectList(db.Product_, "idProduct", "productName");
            ViewBag.idCustomer = new SelectList(db.Customer_, "idCustomer", "userName");
            return View();
        }

        // POST: Order_preorder/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idOrder_preorder,idProduct,quantity,idCustomer")] Order_preorder order_preorder)
        {
            if (ModelState.IsValid)
            {
                db.Order_preorder.Add(order_preorder);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idProduct = new SelectList(db.Product_, "idProduct", "productName", order_preorder.idProduct);
            ViewBag.idCustomer = new SelectList(db.Customer_, "idCustomer", "userName", order_preorder.idCustomer);
            return View(order_preorder);
        }

        // GET: Order_preorder/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_preorder order_preorder = await db.Order_preorder.FindAsync(id);
            if (order_preorder == null)
            {
                return HttpNotFound();
            }
            ViewBag.idProduct = new SelectList(db.Product_, "idProduct", "productName", order_preorder.idProduct);
            ViewBag.idCustomer = new SelectList(db.Customer_, "idCustomer", "userName", order_preorder.idCustomer);
            return View(order_preorder);
        }

        // POST: Order_preorder/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idOrder_preorder,idProduct,quantity,idCustomer")] Order_preorder order_preorder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order_preorder).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idProduct = new SelectList(db.Product_, "idProduct", "productName", order_preorder.idProduct);
            ViewBag.idCustomer = new SelectList(db.Customer_, "idCustomer", "userName", order_preorder.idCustomer);
            return View(order_preorder);
        }

        // GET: Order_preorder/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_preorder order_preorder = await db.Order_preorder.FindAsync(id);
            if (order_preorder == null)
            {
                return HttpNotFound();
            }
            return View(order_preorder);
        }

        // POST: Order_preorder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Order_preorder order_preorder = await db.Order_preorder.FindAsync(id);
            db.Order_preorder.Remove(order_preorder);
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

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
    public class User_Controller : Controller
    {
        private EcommerceECDBEntities1 db = new EcommerceECDBEntities1();

        // GET: User_
        public async Task<ActionResult> Index()
        {
            if (Session["autho"] != null)
            {
                if (Session["autho"].Equals("true"))
                {
                    return View(await db.User_.ToListAsync());
                }
            }

                    return RedirectToAction("Index", "Home");
                            
        }

        // GET: User_/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (Session["autho"] != null)
            {
                if (Session["autho"].Equals("true"))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                User_ user_ = await db.User_.FindAsync(id);
                if (user_ == null)
                {
                    return HttpNotFound();
                }
                return View(user_);
            }

            }
            return RedirectToAction("Index", "Home");
           
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
        public async Task<ActionResult> Create([Bind(Include = "idUsuario,userName,firstName,lastName,email,passwordUser")] User_ user_)
        {
            if (ModelState.IsValid)
            {
                db.User_.Add(user_);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(user_);
        }

        // GET: User_/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (Session["autho"] != null)
            {
                if (Session["autho"].Equals("true"))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                User_ user_ = await db.User_.FindAsync(id);
                if (user_ == null)
                {
                    return HttpNotFound();
                }
                return View(user_);
            }
            }
            return RedirectToAction("Index", "Home");
          
        }

        // POST: User_/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idUsuario,userName,firstName,lastName,email,passwordUser")] User_ user_)
        {
            if (Session["autho"] != null)
            {
                if (Session["autho"].Equals("true"))
                {
                    if (ModelState.IsValid)
                    {
                        db.Entry(user_).State = EntityState.Modified;
                        await db.SaveChangesAsync();
                        return RedirectToAction("Index");
                    }
                    return View(user_);
                }

            }
                return RedirectToAction("Index", "Home");
           
        }

        // GET: User_/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (Session["autho"] != null)
            {
                if (Session["autho"].Equals("true"))
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    User_ user_ = await db.User_.FindAsync(id);
                    if (user_ == null)
                    {
                        return HttpNotFound();
                    }
                    return View(user_);
                }
            }
            
                return RedirectToAction("Index", "Home");
            
        }

        // POST: User_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            if (Session["autho"] != null)
            {
                if (Session["autho"].Equals("true"))
                {
                    User_ user_ = await db.User_.FindAsync(id);
                    db.User_.Remove(user_);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
              
            }
           
                return RedirectToAction("Index", "Home");
            
        }

        protected override void Dispose(bool disposing)
        {
            if (Session["autho"] != null) { 
            
            if (Session["autho"].Equals("true")) {
                if (disposing)
                {
                    db.Dispose();
                }
    
          
            base.Dispose(disposing);
                }
            }
        }
        [HttpGet]
        public ActionResult Login() {


            String mensaje = "";
            return View((object)mensaje);
        }
        [HttpPost]
        public async Task<ActionResult> Login(string email, string password)
        {

            foreach(User_ u in await db.User_.ToListAsync()) {
                if (email ==u.email && password == u.passwordUser)
                {
                    Session["user"] = u;
                    Session["autho"] = "true";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    String mensaje = "Credenciales invalidas";
                    return View((object) mensaje);
                }
            }


            return View();



        }
    }
}

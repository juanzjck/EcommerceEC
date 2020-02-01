using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
namespace Ecommerce.Controllers
{
    public class HomeController : Controller
    {
        private EcommerceECDBEntities1 db = new EcommerceECDBEntities1();
        public async Task<ActionResult> Index()
        {
            var product_ = db.Product_.Include(p => p.Editorial_);
            var products_ = await product_.ToListAsync();

            return View(products_);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
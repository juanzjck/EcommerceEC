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
using System.Web.Services;

namespace Ecommerce.Controllers
{
    public class ProductController : Controller
    {
        private EcommerceECDBEntities1 db = new EcommerceECDBEntities1();
      
        // GET: Product
        public async Task<ActionResult> Index()
        {
            var product_ = db.Product_.Include(p => p.Editorial_);
            var products_ = await product_.ToListAsync();
        
            return View(products_);
        }

        
    }
}
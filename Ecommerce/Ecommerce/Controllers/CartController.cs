using Ecommerce.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    public class CartController : Controller
    {
        List<Product_> products_OnCart = new List<Product_>();
        private EcommerceECDBEntities1 db = new EcommerceECDBEntities1();
        // GET: Cart
        public ActionResult Index()
        {

            return View((List<Product_>)Session["ProductsOnCart"]);
        }
        //AJAX WEB METHOD FOR ADD PRODUCTO TO CART
        [HttpPost]

        public ActionResult addToCart(int Product)
        {
            string message = "";


            foreach (Product_ p in db.Product_.ToList())
            {

                if (p.idProduct == Product)
                {

                    products_OnCart = (List<Product_>)Session["ProductsOnCart"];
                    if (products_OnCart == null)
                    {
                        products_OnCart = new List<Product_>();
                    }

                    products_OnCart.Add(p);
                    Session["ProductsOnCart"] = products_OnCart;


                }
            }
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });

        }

        [HttpPost]
        public ActionResult removeFromCart(int Product)
        {
            string message = "";
            products_OnCart = (List<Product_>)Session["ProductsOnCart"];
            Product_ productselected = null;
            if (products_OnCart != null)
            {
                foreach (Product_ p in products_OnCart)
                {
                    if (p.idProduct == Product)
                    {
                        productselected = p;
                    }
                }

                if (productselected != null)
                {
                    products_OnCart.Remove(productselected);
                    Session["ProductsOnCart"] = products_OnCart;
                }

            }






            return Json(new { Message = message, JsonRequestBehavior.AllowGet });


        }


    }
}
using Ecommerce.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    public class CartController : Controller
    {
        List<Order_preorder> products_OnCart = new List<Order_preorder>();
        private EcommerceECDBEntities1 db = new EcommerceECDBEntities1();
        // GET: Cart
        public async Task<ActionResult> Index()
        {

            var order_preorder = db.Order_preorder.Include(o => o.Product_).Include(o => o.Customer_);
           List<Order_preorder> preorders =await order_preorder.ToListAsync();
            foreach (Order_preorder o in preorders) { 
            
            }
            return View();
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

                    products_OnCart = (List<Order_preorder>) Session["ProductsOnCart"];
                    if (products_OnCart == null)
                    {
                        products_OnCart = new List<Order_preorder>();
                    }
                    Order_preorder preorder = new Order_preorder() ;
                    preorder.idProduct = p.idProduct;
                    preorder.idCustomer = 1;
                    products_OnCart.Add(preorder);
                    Session["ProductsOnCart"] = products_OnCart;
                    
                    if ((List<int>)Session["cuantity"] == null)
                    {
                        List<int> cuantity = new List<int>();
                        cuantity.Add(1);
                        Session["cuantity"] = cuantity;

                    }
                    else {
                        List<int> cuantyty = (List<int>) Session["cuantity"];
                        cuantyty.Add(1);
                    }
                   

                }
            }
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });

        }

        [HttpPost]
        public ActionResult removeFromCart(int Product)
        {
            string message = "";
            products_OnCart = (List<Order_preorder>)Session["ProductsOnCart"];
            Order_preorder productselected = null;
            if (products_OnCart != null)
            {
                foreach (Order_preorder p in products_OnCart)
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
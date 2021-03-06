﻿using Ecommerce.Models;
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
        private EcommerceECDBEntities2 db = new EcommerceECDBEntities2();
        // GET: Cart
        public async Task<ActionResult> Index()
        {


            return View((List<Order_preorder>)Session["ProductsOnCart"]);

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

                    products_OnCart = (List<Order_preorder>)Session["ProductsOnCart"];

                    if (products_OnCart == null)
                    {
                        products_OnCart = new List<Order_preorder>();
                    }
                    Order_preorder preorder = new Order_preorder();
                    preorder.idProduct = p.idProduct;
                    preorder.quantity = 1;

                    preorder.Product_ = p;
                    products_OnCart.Add(preorder);
                    Session["ProductsOnCart"] = products_OnCart;




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

        [HttpGet]

        public ActionResult pay() {

            if (Session["autho"] != null)
            {

                if (Session["autho"].Equals("true"))
                {
                    if (findCustomer() != null)
                    {

                        return View(findCustomer());
                    }
                    else
                    {
                        return View();
                    }
                  
                }
                else {
                    return RedirectToAction("login", "User_");
                }
            }
            else {

                return RedirectToAction("login", "User_");
            }
                  
          
         
         
           
        }
        public Customer_ findCustomer() {
            foreach (Customer_ c in db.Customer_.ToList())
            {
                if (((User_)Session["user"]).idUsuario.Equals(c.idUser))
                {
                    return c;
                }
            }
            return null;
        }
        public int genetrateIdOrder() {
            int id = 0;
            foreach ( Customer_ c in db.Customer_.ToList()) {
                id = c.idCustomer + 1;
            }
            return id;
        }
        [HttpPost]
        public async Task<ActionResult> purchase(Customer_ customer) {

            if (findCustomer() != null && findCustomer().Cedula.Equals(customer.Cedula))
            {
                Order_ order = new Order_();
                order.idCustomer = findCustomer().idCustomer;
                db.Order_.Add(order);
                await db.SaveChangesAsync();
                foreach (Order_preorder p in (List<Order_preorder>)Session["ProductsOnCart"]) {
                    Order_Detail order_detail = new Order_Detail();
                    order_detail.idOrder = order.idOrder;
                    order_detail.idProduct = p.idProduct;
                    order_detail.quantity = p.quantity;
                    db.Order_Detail.Add(order_detail);
                    await db.SaveChangesAsync();
                }
                return View();
            }
            else
            {
                customer.idUser = ((User_)Session["user"]).idUsuario;
                customer.idCustomer = genetrateIdOrder();
                db.Customer_.Add(customer);
                await db.SaveChangesAsync();
                Order_ order = new Order_();
                order.idCustomer = customer.idCustomer;
                db.Order_.Add(order);
                await db.SaveChangesAsync();
                foreach (Order_preorder p in (List<Order_preorder>)Session["ProductsOnCart"])
                {
                    Order_Detail order_detail = new Order_Detail();
                    order_detail.idOrder = order.idOrder;
                    order_detail.idProduct = p.idProduct;
                    order_detail.quantity = p.quantity;
                    db.Order_Detail.Add(order_detail);
                    await db.SaveChangesAsync();
                }

                return View();
            }
           
        }

      

    }
}
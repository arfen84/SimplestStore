using loudclothes.net.Models;
using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;
using System;

namespace loudclothes.net.Controllers
{
    public class PortfolioController : Controller
    {
        private StoreContext db = new StoreContext();

        public ActionResult OneColumn()
        {
            List<Product> productList = new List<Product>();
            productList = db.Products.ToList();

            return View(productList);
        }

        public ActionResult Details(int ProductId)
        {
            Product pr;
            Order order = new Order();
            pr = db.Products.FirstOrDefault(m => m.ProductId == ProductId);
            order.Product = pr;
            if (Session["User"] as AppUser != null)
            {
                order.User = Session["User"] as AppUser; //lub UserId
            }
            else
            {
                RedirectToAction("Login","Service");
            }
            return View(order);
        }

        public ActionResult Summary(Order order)
        {
            Product prod = db.Products.FirstOrDefault(x => x.ProductId == order.ProductId);
            //Order ord = db.Orders.FirstOrDefault(x => x.OrderedProducts.FirstOrDefault().ProductId == ProductId);
            //int price = ord.OrderedProducts.FirstOrDefault().Price;
            //order.TotalPrice = order.Quantity * price;
            order.Product = prod;
            order.TotalPrice = prod.Price * order.Quantity;
            order.DateCreated = DateTime.Now;
            AppUser au = Session["User"] as AppUser;
            order.User = au;
            order.UserId = au.AppUserId.ToString();
            db.Orders.Add(order);
            db.SaveChanges();
            return View(order);
        }

   
    }
}

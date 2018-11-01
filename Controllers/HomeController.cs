using loudclothes.net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace loudclothes.net.Controllers
{
    public class HomeController : Controller
    {
        private StoreContext db = new StoreContext();

        public ActionResult Index()
        {
            //InitialiseDB();

            return View();
        }

        public ActionResult Admin()
        {

            return View();
        }

        public ActionResult Products()
        {
            check();
            return View(db.Products.ToList());
        }

        public ActionResult EditProduct(int ProductId)
        {
            check();
            Product pr = db.Products.FirstOrDefault(x => x.ProductId == ProductId);

            return View(pr);
        }

        [HttpPost]
        public ActionResult EditProduct(Product pr)
        {
            check();
            Product prod = db.Products.FirstOrDefault(x => x.ProductId == pr.ProductId);
            db.Entry(prod).CurrentValues.SetValues(pr);
            db.SaveChanges();
            Response.Redirect("/Home/Products");
            return View(pr);
        }

        public ActionResult DeleteProduct(int ProductId)
        {
            check();
            Product pr = db.Products.FirstOrDefault(x => x.ProductId == ProductId);
            db.Products.Remove(pr);
            db.SaveChanges();

           // Response.Redirect("/Home/Products");
            return View();
        }

        public ActionResult AddProduct()
        {
            check();
            Product pr = new Product();

            return View(pr);
        }

        [HttpPost]
        public ActionResult AddProduct(Product pr)
        {
            check();
            db.Products.Add(pr);
            db.SaveChanges();

            Response.Redirect("/Home/Products");
            return View();
        }

        public ActionResult Orders()
        {
            check();

            return View(db.Orders.ToList());
        }

        public ActionResult EditOrder(int OrderId)
        {
            check();

            Order ord = db.Orders.FirstOrDefault(x => x.OrderId == OrderId);
            Product prod = db.Products.FirstOrDefault(x => x.ProductId == ord.ProductId);
            ord.Product = prod;
            int orderId = Int32.Parse(ord.UserId.ToString());
            AppUser au = db.Users.FirstOrDefault(x => x.AppUserId == orderId);
            ord.User = au;
            return View(ord);
        }

        [HttpPost]
        public ActionResult EditOrder(Order order)
        {
            check();

            Order ord = db.Orders.FirstOrDefault(x => x.OrderId == order.OrderId);
            db.Entry(ord).CurrentValues.SetValues(order);
            db.SaveChanges();
            Response.Redirect("/Home/Orders");
            return View(ord);
        }

        public ActionResult DeleteOrder(int OrderId)
        {
            check();

            Order ord = db.Orders.FirstOrDefault(x => x.OrderId == OrderId);
            db.Orders.Remove(ord);
            db.SaveChanges();
            Response.Redirect("/Home/Orders");
            return View(ord);
        }

        public RedirectResult check()
        {
            AppUser au = Session["User"] as AppUser;
           // if (au != null && au.Email != "") return null;
            Response.Redirect("/Services/Login");
            return null;
        }

        public void InitialiseDB()
        {
            Product pr = new Product();
            pr.Name = "Sukienka";
            pr.Manufacturer = "Chiny";
            pr.Price = 10;
            pr.Image = "~/images/retro damskie lookbook.jpg";
            pr.Quantity = 10;
            pr.Size = "M";
            pr.Description = "Recent proposals Loud Clothes for autumn-winter 2015 women primarily three lines: 1970's LOOKBOOK, Girly Street and Modern Utility. Lines complement each other and form a really interesting fashion proposals for the cooler months.";

            db.Products.Add(pr);

            pr = new Product();
            pr.Name = "T-shirt";
            pr.Manufacturer = "Europa";
            pr.Price = 20;
            pr.Quantity = 5;
            pr.Size = "S";

            db.Products.Add(pr);
            db.SaveChanges();
        }
    }
}
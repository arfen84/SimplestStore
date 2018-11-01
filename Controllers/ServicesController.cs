using loudclothes.net.Models;
using System.Web.Mvc;
using System.Linq;

namespace loudclothes.net.Controllers
{
    public class ServicesController : Controller
    {
        private StoreContext db = new StoreContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            AppUser ap = new AppUser();
            return View(ap);
        }

        [HttpPost]
        public ActionResult Register(AppUser au)
        {
            //AppUser ap = new AppUser();
            db.Users.Add(au);
            db.SaveChanges();
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(string  email, string  password)
        {
            AppUser au =  db.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
            if (au!=null)
            {
                Session["User"] = au;
                RedirectToAction("Index", "Home");
            }
            else
            {
                RedirectToAction("Login");
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session["User"] = null;

            RedirectToAction("Index", "Home");
            return View();
        }
    }
}
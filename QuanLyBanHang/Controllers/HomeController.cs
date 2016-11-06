using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyBanHang.Helper;
using QuanLyBanHang.Models;

namespace QuanLyBanHang.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
        // GET: Home
        public ActionResult Index()
        {
            var products = db.Product.Take(8).ToList();
            return View(products);
            return View();
        }

        public ActionResult contact()
        {
            return View();
        }

        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult login(User user)
        {
            user.password = Encryption.encryp(user.password);
            User _user = db.User.FirstOrDefault(t => t.username == user.username && t.password == user.password);
            if (_user == null || _user.Id == 0)
            {
                TempData["error"] = new string[] { "Usename or Password not math!" };
                return RedirectToAction("login");
            }
            Auth auth = new Auth();
            Response.Cookies["auth"].Value = auth.Encode(_user);

            Response.Cookies["auth"].Expires = DateTime.Now.AddDays(10);
            return RedirectToAction("index");
        }

        public ActionResult logout()
        {

            Response.Cookies["auth"].Value = "";
            Response.Cookies["auth"].Expires = DateTime.Now.AddDays(-1);
            return RedirectToAction("login");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user, string repassword)
        {
            if (ModelState.IsValid)
            {
                if (user.password == repassword)
                {
                    user.password = Encryption.encryp(user.password);

                    db.User.Add(user);
                    db.SaveChanges();
                    db.User_Role.Add(new User_Role() { User_Id = user.Id, Role_Id = 2 });
                    db.SaveChanges();
                    return RedirectToAction("login");
                }
                ViewBag.error = new string[] { "Not Math Password! " };
            }
            return View(user);
        }
    }
}
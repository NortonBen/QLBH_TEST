using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyBanHang.Models;
using QuanLyBanHang.Helper;

namespace QuanLyBanHang.Controllers
{
    public class ProductController : Controller
    {
        DataContext db = new DataContext();
        // GET: Product
        public ActionResult Index(int id)
        {
            Product product = db.Product.Find(id);
            return View(product);
        }
    }
}
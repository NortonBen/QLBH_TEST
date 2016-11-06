using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyBanHang.Models;
using QuanLyBanHang.Helper;

namespace QuanLyBanHang.Controllers
{
    public class CategoryController : Controller
    {
        DataContext db = new DataContext();
        // GET: Category
        public ActionResult Index(int id)
        {
            var datas = db.Product.Where(
                delegate (Product product)
                {
                    if (product.Product_Category.Where(t => t.Category_Id == id).ToList().Count > 0)
                    {
                        return true;
                    }
                    return false;
                }).ToList();
            return View(datas);
        }
    }
}
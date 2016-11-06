using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyBanHang.Models;
using QuanLyBanHang.Helper;

namespace QuanLyBanHang.Controllers.Adminstrator
{
    [RoutePrefix("administrator/products")]
    [Route("{action=index}")]
    public class ProductAdminController : Controller
    {
        private DataContext db = new DataContext();

        // GET: ProductAdmin
        public ActionResult Index(int page =0, int part = 30)
        {
            var total = db.Product.Count() / part;
            var paginate = Paginate.create(page, part, total);
            var data = db.Product.OrderBy(p => p.Id).Skip(paginate["page"] * part).Take((paginate["page"] + 1) * part).ToList();
            ViewBag.paginate = paginate;
            return View(data);
        }

        // GET: ProductAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: ProductAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,image,describe,detail,price,status,extension")] Product product, int[] categores)
        {
            if (ModelState.IsValid)
            {
                product.date = DateTime.Now;
                db.Product.Add(product);
                db.SaveChanges();
                foreach(int id in categores)
                {
                    Product_Category category = new Product_Category();
                    category.Category_Id = id;
                    category.Product_Id = product.Id;
                    db.Product_Category.Add(category);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: ProductAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: ProductAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,image,describe,detail,price,status,extension")] Product product, int[] categores)
        {
            if (ModelState.IsValid)
            {
                product.date = DateTime.Now;
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();

                List<Product_Category> datas =  product.Product_Category.ToList();
                foreach (Product_Category data in datas)
                {
                    if (categores.Where(i => i == data.Id) == null)
                    {
                        db.Product_Category.Remove(data);
                    }
                }
                foreach (int id in categores)
                {
                    Product_Category val = db.Product_Category.FirstOrDefault(t => t.Category_Id == id && t.Product_Id == product.Id);
                    if (val == null)
                    {
                        Product_Category Product_Category = new Product_Category();
                        Product_Category.Category_Id = id;
                        Product_Category.Product_Id = product.Id;
                        product.Product_Category.Add(Product_Category);
                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: ProductAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: ProductAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Product.Find(id);
            db.Product.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

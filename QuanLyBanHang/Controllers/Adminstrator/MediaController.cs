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
using System.IO;

namespace QuanLyBanHang.Controllers.Adminstrator
{
    [RoutePrefix("mediaFile")]
    [Route("{action=index}")]
    public class MediaController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Media
        public ActionResult index(int page = 0, int part = 30)
        {
            var total = db.Media.Count() / part;
            var paginate = Paginate.create(page, part, total);
            var data = db.Media.OrderBy(p => p.Id).Skip(paginate["page"] * part).Take((paginate["page"] + 1) * part).ToList();
            ViewBag.paginate = paginate;
            return View(data);
        }

        [HttpPost]
        public JsonResult Upload(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                int size = file.ContentLength;
                var fileName = Path.GetFileName(file.FileName);
                var prefix = DateTime.Now.ToString("DDmmYYHHmmss");
                var path = Path.Combine(Server.MapPath("~/Media/"), prefix+"_"+fileName);
                file.SaveAs(path);

                string tpe =  file.ContentType;
                Media media = new Media();
                media.url = "/Media/" + prefix + "_" + fileName;
                media.name = fileName;
                media.size = size;
                media.date = DateTime.Now;
                db.Media.Add(media);
                db.SaveChanges();
                return new JsonResult() { Data = new { success = true, data = media }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            return new JsonResult(){ Data = new { success = false }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult Select(int page = 0, int part = 30)
        {
            var total = db.Media.Count() / part;
            var paginate = Paginate.create(page, part, total);
            var data = db.Media.OrderBy(p => p.Id).Skip(paginate["page"] * part).Take((paginate["page"] + 1) * part).ToList();
            ViewBag.paginate = paginate;
            return View(data);
        }

        public ActionResult del(int? id)
        {
            Media file = db.Media.Find(id);
            if(file != null)
            {
                db.Media.Remove(file);
                db.SaveChanges();
                var path = Path.Combine(Server.MapPath("~/Media/"), file.url);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }
            return RedirectToAction("index");
        }

        public ActionResult delselect(int? id)
        {
            Media file = db.Media.Find(id);
            if (file != null)
            {
                db.Media.Remove(file);
                db.SaveChanges();
                var path = Path.Combine(Server.MapPath("~/Media/"), file.url);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }
            return RedirectToAction("Select");
        }
        
    }
}

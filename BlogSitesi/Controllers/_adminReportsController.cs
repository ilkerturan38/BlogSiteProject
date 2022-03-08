using Business.ConCrete;
using Entity.ConCrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSitesi.Controllers
{
    public class _adminReportsController : Controller
    {
        BlogManager bm = new BlogManager();
        public ActionResult Reports()
        {
            var sorgu = bm.GetAll();
            return View(sorgu);
        }

        public ActionResult Reports2()
        {
            var sorgu = bm.GetAll();
            return View(sorgu);
        }

        [HttpGet]
        public ActionResult testImage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult testImage(testImage p)
        {
            if (Request.Files.Count > 0) // istekler arasında dosya mevcut ise ;
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName); // DosyaAdını al
                string uzanti = Path.GetExtension(Request.Files[0].FileName); // Dosyanın uzantısını al
                string yol = "~/Uploads/Blog/" + dosyaAdi + uzanti; // Proje içi kayıt yeri
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.MyProperty = "/Uploads/Blog/" + dosyaAdi + uzanti;  // veritabanı kayıt yeri
            }
            bm.testImageAdd(p);
            try
            {
                return RedirectToAction("adminBlogList1", "_adminBlog");
            }
            catch
            {
                ViewBag.hata = "HATA!";
            }
            return View();
        }
    }
}
using BlogSitesi.Models;
using DataAccess.ConCrete;
using Entity.ConCrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSitesi.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Chart1()
        {
            return View();
        }

        public ActionResult VisualizeResult() // Görselleştirme Sonucu
        {
            return Json(categoryList(), JsonRequestBehavior.AllowGet); // categoryList isminde Metot Döndürülcek
        }

        public List<Class1> categoryList() // categoryList Metodu
        {
            List<Class1> c = new List<Class1>(); // Statik Veri Listeleme
            c.Add(new Class1()
            {
                categoryName = "Teknoloji",
                BlogCount = 14
            });
            c.Add(new Class1()
            {
                categoryName = "Spor",
                BlogCount = 10
            });
            c.Add(new Class1()
            {
                categoryName = "Kitap",
                BlogCount = 16
            });
            return c;
        }



        public ActionResult Chart2() // View Sayfası
        {
            return View();
        }

        public ActionResult VisualizeResult2()
        {
            return Json(blogList(), JsonRequestBehavior.AllowGet); // blogList isminde Metot Döndürülcek
        }
        public List<Class2> blogList() // BlogList Metodu
        {
            List<Class2> c = new List<Class2>();  // Dinamik Veri Listeleme
            using (Context db = new Context())
            {
                c = db.blogs.Select(x => new Class2 
                {
                    blogName=x.Title, // Class2 sınıfındaki değerleri getir,seç ve getirilen değerlere blog Tablosundaki alanları ata.
                    Rating =x.blogRating
                }).ToList();
            }
            return c;
        }


        public ActionResult Chart3() // View Sayfası
        {
            return View();
        }


        public ActionResult Chart4() // View Sayfası
        {
            return View();
        }
    }
}
using Business.ConCrete;
using DataAccess.ConCrete;
using Entity.ConCrete;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSitesi.Controllers
{
    [AllowAnonymous] // Controller (Sınıf) Bazlı Tanımlama.Burada [AllowAnonymous] tanımlaması yaparak aşağıdaki tüm Controller için Authorize giriş yapma zorunluluğu olmuycak.
    public class BlogController : Controller
    {
        BlogManager bg = new BlogManager();
        Context db = new Context();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BlogListPV(int? page)
        {
            var sorgu = bg.GetAll().ToPagedList(page ?? 1,3);
            return PartialView(sorgu);
        }
        
        public ActionResult FeaturedPostPV() // Öne Çıkan Postlar
        {
            // Birden Fazla Aynı CategoryID'li,Blog Kaydı Var ise ; (OrderByDescending) ile Tersten Sıralama yapıp,Son Kaydı Getirdik Sadece.

            ViewBag.postTitle1 = bg.GetAll().OrderByDescending(z => z.blogID).Where(x => x.categoryID == 1).Select(y => y.Title).FirstOrDefault();
            ViewBag.postImage1 = bg.GetAll().OrderByDescending(z => z.blogID).Where(x => x.categoryID == 1).Select(y => y.ImageURL).FirstOrDefault();
            ViewBag.BlogDate1 = bg.GetAll().OrderByDescending(z => z.blogID).Where(x => x.categoryID == 1).Select(y => y.Date).FirstOrDefault();

            ViewBag.blogPostID1 = bg.GetAll().OrderByDescending(x => x.blogID).Where(y => y.categoryID == 1).Select(z => z.blogID).FirstOrDefault();

            ViewBag.postTitle2 = bg.GetAll().OrderByDescending(z => z.blogID).Where(x => x.categoryID == 2).Select(y => y.Title).FirstOrDefault();
            ViewBag.postImage2 = bg.GetAll().OrderByDescending(z => z.blogID).Where(x => x.categoryID == 2).Select(y => y.ImageURL).FirstOrDefault();
            ViewBag.BlogDate2 = bg.GetAll().OrderByDescending(z => z.blogID).Where(x => x.categoryID == 2).Select(y => y.Date).FirstOrDefault();

            ViewBag.blogPostID2 = bg.GetAll().OrderByDescending(x => x.blogID).Where(y => y.categoryID == 2).Select(z => z.blogID).FirstOrDefault();

            ViewBag.postTitle3 = bg.GetAll().OrderByDescending(z => z.blogID).Where(x => x.categoryID == 3).Select(y => y.Title).FirstOrDefault();
            ViewBag.postImage3 = bg.GetAll().OrderByDescending(z => z.blogID).Where(x => x.categoryID == 3).Select(y => y.ImageURL).FirstOrDefault();
            ViewBag.BlogDate3 = bg.GetAll().OrderByDescending(z => z.blogID).Where(x => x.categoryID == 3).Select(y => y.Date).FirstOrDefault();

            ViewBag.blogPostID3 = bg.GetAll().OrderByDescending(x => x.blogID).Where(y => y.categoryID == 3).Select(z => z.blogID).FirstOrDefault();

            ViewBag.postTitle4 = bg.GetAll().OrderByDescending(z => z.blogID).Where(x => x.categoryID == 4).Select(y => y.Title).FirstOrDefault();
            ViewBag.postImage4 = bg.GetAll().OrderByDescending(z => z.blogID).Where(x => x.categoryID == 4).Select(y => y.ImageURL).FirstOrDefault();
            ViewBag.BlogDate4 = bg.GetAll().OrderByDescending(z => z.blogID).Where(x => x.categoryID == 4).Select(y => y.Date).FirstOrDefault();

            ViewBag.blogPostID4 = bg.GetAll().OrderByDescending(x => x.blogID).Where(y => y.categoryID == 4).Select(z => z.blogID).FirstOrDefault();

            ViewBag.postTitle5 = bg.GetAll().OrderByDescending(z => z.blogID).Where(x => x.categoryID == 5).Select(y => y.Title).FirstOrDefault();
            ViewBag.postImage5 = bg.GetAll().OrderByDescending(z => z.blogID).Where(x => x.categoryID == 5).Select(y => y.ImageURL).FirstOrDefault();
            ViewBag.BlogDate5 = bg.GetAll().OrderByDescending(z => z.blogID).Where(x => x.categoryID == 5).Select(y => y.Date).FirstOrDefault();

            ViewBag.blogPostID5 = bg.GetAll().OrderByDescending(x => x.blogID).Where(y => y.categoryID == 5).Select(z => z.blogID).FirstOrDefault();

            return PartialView();
        }

        public ActionResult OtherFeaturedPostPV()
        {

            return PartialView();
        }

        
        public ActionResult BlogDetails()
        {
            return View();
        }


        // ****************** QueryString Yöntemi ******************

        /*
        public ActionResult BlogCoverPV()
        {
            int gelenID = int.Parse(Request.QueryString["ID"]);
            var sorgu = bg.GetBlogByID(gelenID);
            return PartialView(sorgu);
        }
        */

        // ****************** QueryString Yöntemi ******************



        // Parametreden gelen ID'ye göre Yöntem
        public ActionResult BlogCoverPV(int id) // (Üst Bilgi) Bloğa ait bilgilerin olduğu PV
        {
            var sorgu = bg.GetBlogByID(id);
            return PartialView(sorgu);
        }

        public ActionResult BlogReadAllPV(int id) // Bloğa ait bilgilerin olduğu PV
        {
            var sorgu = bg.GetBlogByID(id);
            return PartialView(sorgu);
        }


        // Tıklanan Bir Kategori'den URL ile gelen ID bilgisine göre ; O kategoriye ait Tüm Blog Kayıtlarını Listeleme İşlemi..

        // Yöntem 1

        public ActionResult BlogByCategory(int id, int? page) // CategoryID
        {
            //var sorgu = bg.GetAll().ToPagedList(page ?? 1, 3);
            var sorgu = bg.GetBlogByCategoryID(id).ToPagedList(page?? 1,3);

            // Aynı kategoriID Birden Fazla Blog Kaydına tanımlanmış olabilir.Blog Tablosunda Tanımlı KategoryID sayısı kadar döndürmek yerine ;
            // FirstOrDefault ile Sadece Birdefa kategori ismi döndürdük.
            
            ViewBag.categoryName = sorgu.Select(x => x.category.categoryName).FirstOrDefault(); 
            return View(sorgu); 
        }

        // Yöntem 2

        //public ActionResult BlogByCategory(int id) // URL'den Gelen kategoriID değerini al 
        //{
        //    var sorgu = bg.GetAll().OrderBy(x=>x.blogID).Where(x => x.categoryID == id); // Tablodaki kategoriID ile karşılaştır.
        //    return View(sorgu);
        //}

    }
}
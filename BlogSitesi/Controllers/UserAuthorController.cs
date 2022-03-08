using Business.ConCrete;
using DataAccess.ConCrete;
using Entity.ConCrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BlogSitesi.Controllers
{
    
    public class UserAuthorController : Controller // Sisteme giriş yapan Yazar'a ait bilgilerin Tutulduğu Controller
    {
        AuthorProfileManager authorProfile = new AuthorProfileManager();
        BlogManager bm = new BlogManager();
        Context db = new Context();
        public ActionResult Profil()
        {
            return View();
        }

        public ActionResult ProfilPV1(string p) // Dışardan (p) parametresi aldık ,(İlk başta NULL)
        {
            p = (string)Session["mail"]; // Sisteme giriş yapan Yazar'ın mail adresine göre diğer bilgilerini getirdik.
            var sorgu = authorProfile.FindAuthor(p);
            return PartialView(sorgu);
        }

        // Yöntem 1
        
        public ActionResult blogList(string p) // Yazara ait Tüm Blog Kayıtlarını getirme
        {
            p = (string)Session["mail"];
            var id = db.authors.Where(x => x.email == p).Select(x => x.authorID).FirstOrDefault(); 
            var sorgu = authorProfile.GetAuthorByID(id); // GetAuthorByID Blog'ları listeliyor,Ama Şart olarak AuthorID'ye göre işlemi gerçekleştiriyor.
            return View(sorgu);
        }


        // Yöntem 2

        //public ActionResult blogList() // Yazara ait Tüm Blog Kayıtlarını getirme
        //{
        //    var p = (int)Session["ID"];
        //    var id = bm.GetAll().Where(x => x.authorID == p).Select(x => x.authorID).FirstOrDefault();
        //    var sorgu = authorProfile.GetAuthorByID((int)id);
        //    return View(sorgu);
        //}


        [HttpGet]
        public ActionResult Insert()
        {
            Context c = new Context();
            List<SelectListItem> icerik = (from item in c.Categories.ToList() // Kategoriler tablosunun bütün değerlerini al
                                           select new SelectListItem // yukarıdaki liste öğesini seç
                                           {
                                               // DropdownList'in aldığı parametreler
                                               Text = item.categoryName, // Seçilen değerin İçeriği
                                               Value = item.categoryID.ToString() // Seçilen değerin ID'si
                                           }).ToList();
            ViewBag.Category = icerik;
            
            return View();
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Insert(Blog b)
        {
            bm.blogAddBL(b);
            try
            {
                return RedirectToAction("blogList", "UserAuthor");
            }
            catch
            {
                ViewBag.hata = "HATA!";
            }

            return View(b);
        }


        [HttpGet]
        public ActionResult Update(int id)
        {
            Context c = new Context();
            List<SelectListItem> icerik = (from item in c.Categories.ToList() // Kategoriler tablosunun bütün değerlerini al
                                           select new SelectListItem // yukarıdaki liste öğesini seç
                                           {
                                               // DropdownList'in aldığı parametreler
                                               Text = item.categoryName, // Seçilen değerin İçeriği
                                               Value = item.categoryID.ToString() // Seçilen değerin ID'si
                                           }).ToList();
            ViewBag.Category = icerik;

            List<SelectListItem> icerik2 = (from item in c.authors.ToList()
                                            select new SelectListItem
                                            {
                                                Text = item.authorNameSurname,
                                                Value = item.authorID.ToString()
                                            }).ToList();
            ViewBag.Author = icerik2;
            Blog blog = bm.FindBlog(id);
            return View(blog);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(int id,Blog p)  // Yazar'a ait olan Blog bilgilerinin olduğu Update View (Sayfası)
        {
            bm.UpdateBlog(id,p);
            return RedirectToAction("blogList", "UserAuthor");
        }


        [HttpPost]
        public ActionResult UpdateAuthorProfil(Author p) // Yazar Profil Bilgilerinin olduğu Update
        {
            authorProfile.UpdateAuthor(p);
            return RedirectToAction("Profil", "UserAuthor");
        }


        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("authorLogin", "Login");
        }

    }

}
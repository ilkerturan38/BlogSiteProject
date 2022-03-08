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
    [AllowAnonymous] // Global.asax Sayfasında tanımladığımız,(Bütün Proje Sayfaları için geçerli) Authorize işlemini, Login Controller içerisinde bulunan Metotlara uygulama! 
    public class LoginController : Controller
    {
        Context db = new Context();

        [HttpGet]
        public ActionResult authorLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult authorLogin(Author p)
        {
            var sorgu = db.authors.Where(x => x.email == p.email && x.password == p.password).FirstOrDefault();
            if(sorgu!=null)
            {
                FormsAuthentication.SetAuthCookie(sorgu.email, false); // mail adresi Cookie değeri - Cookie oluşturulmasın (false)
                Session["mail"] = sorgu.email.ToString();
                Session["ID"] = sorgu.authorID;
                Session["yazarAdSoyad"] = sorgu.authorNameSurname;
                return RedirectToAction("Profil", "UserAuthor");
            }
            ViewBag.hata = "Kullanıcı Adı veya Şifre Hatalı";
            return View();
        }

        [HttpGet]
        public ActionResult adminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult adminLogin(Admin p)
        {
            var sorgu = db.admins.Where(x => x.username == p.username && x.password == p.password).FirstOrDefault();
            if (sorgu != null)
            {
                FormsAuthentication.SetAuthCookie(sorgu.username, false);
                Session["mail"] = sorgu.username.ToString();
                Session["ID"] = sorgu.adminID;
                return RedirectToAction("adminBlogList1", "_adminBlog");
            }
            ViewBag.hata = "Kullanıcı Adı veya Şifre Hatalı";
            return View();
        }


        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Blog");
        }
    }
}
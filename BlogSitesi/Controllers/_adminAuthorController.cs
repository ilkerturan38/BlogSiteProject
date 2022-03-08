using Business.ConCrete;
using DataAccess.ConCrete.Abstract;
using DataAccess.EntityFramework;
using Entity.ConCrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSitesi.Controllers
{
    public class _adminAuthorController : Controller
    {
        AuthorManager am = new AuthorManager(new EFAuthorDAL());
        BlogManager bm = new BlogManager();
        public ActionResult adminAuthorList()
        {
            var sorgu = am.GetList();
            return View(sorgu);
        }

        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAuthor(Author p)
        {
            am.authorAdd(p);
            return RedirectToAction("adminAuthorList");
        }

        [HttpGet]
        public ActionResult UpdateAuthor(int id)
        {
            Author author = am.GetByID(id);
            return View(author);
        }

        [HttpPost]
        public ActionResult UpdateAuthor(Author p)
        {
            am.authorUpdate(p);
            return RedirectToAction("adminAuthorList");
        }

        public ActionResult AuthorBlogList(int id) // Yazara ait Tüm Blog Kayıtlarını getirme id=YazarID
        {
            var sorgu = bm.GetBlogByAuthorID(id); // GetAuthorByID Blog'ları listeliyor,Ama Şart olarak AuthorID'ye göre işlemi gerçekleştiriyor.
            return View(sorgu);
        }
    }
}
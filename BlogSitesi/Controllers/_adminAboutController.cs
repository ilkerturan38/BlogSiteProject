using Business.ConCrete;
using DataAccess.EntityFramework;
using Entity.ConCrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSitesi.Controllers
{
    public class _adminAboutController : Controller
    {
        AboutManager abm = new AboutManager();
        AuthorManager autMan = new AuthorManager(new EFAuthorDAL());

        public ActionResult adminAboutList() // Aynı Sayfa üzerinde Güncelleme yapılıcak
        {
            var sorgu = abm.GetAll();
            return View(sorgu);

        }

        //[HttpGet]
        //public ActionResult Update(int id)
        //{
        //    var sorgu = abm.FindAbout(id);
        //    return View(sorgu);
        //}

        [HttpPost]
        public ActionResult Update(About p)  // Farklı Sayfada Güncellersek Find Metodu kullanılmalı [HttpGet] kısmında id değeri lazım. 
        {
            abm.UpdateAbout(p);
            return RedirectToAction("adminAboutList", "_adminAbout");
            
        }
    }
}
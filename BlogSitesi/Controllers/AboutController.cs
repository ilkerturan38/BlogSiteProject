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
    [AllowAnonymous]
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager();
        AuthorManager autMan = new AuthorManager(new EFAuthorDAL());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AboutPV()
        {
            var sorgu = abm.GetAll();
            return PartialView(sorgu);
        }

        public ActionResult MeetTheTeam()
        {
            var sorgu = autMan.GetList().Take(5); // Yazar Tablosundan İlk 5 Kaydı Listele..
            return PartialView(sorgu);
        }

        public ActionResult FooterPV()
        {

            var sorgu = abm.GetAll();
            return PartialView(sorgu);
        }


    }
}
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
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EFContactDAL());

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContactPV()
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult ContactMessageFormPV()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult ContactMessageFormPV(Contact c)
        {
            cm.Insert(c);
            return PartialView(c);
        }


        public ActionResult SendBox()
        {
            var sorgu = cm.GetAll();
            return View(sorgu);
        }


        public ActionResult MessageDetails(int id)
        {
            var sorgu = cm.GetByID(id);
            return View(sorgu);
        }
    }
}
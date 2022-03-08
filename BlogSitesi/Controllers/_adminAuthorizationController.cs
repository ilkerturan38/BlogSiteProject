using Business.ConCrete;
using Entity.ConCrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSitesi.Controllers
{
    public class _adminAuthorizationController : Controller
    {
        AdminManager adm = new AdminManager();
        public ActionResult adminUserList()
        {
            var sorgu = adm.adminTableList();
            return View(sorgu);
        }


        [HttpGet]
        public ActionResult adminUserInsert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult adminUserInsert(Admin p)
        {
            adm.adminUserInsert(p);
            return RedirectToAction("adminUserList","_adminAuthorization");
        }


        [HttpGet]
        public ActionResult adminUserUpdate(int id)
        {
            var sorgu=adm.FindAdmin(id);
            return View(sorgu);
        }

        [HttpPost]
        public ActionResult adminUserUpdate(Admin p)
        {
            adm.adminUserUpdate(p);
            return RedirectToAction("adminUserList", "_adminAuthorization");
        }

        public ActionResult StatusUpdateFalse(int id)
        {
            adm.StatusUpdateFalse(id);
            return RedirectToAction("adminUserList", "_adminAuthorization");
        }
        public ActionResult StatusUpdateTrue(int id)
        {
            adm.StatusUpdateTrue(id);
            return RedirectToAction("adminUserList", "_adminAuthorization");
        }
    }
}
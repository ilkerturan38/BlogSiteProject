using Business.ConCrete;
using Entity.ConCrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSitesi.Controllers
{
    [AllowAnonymous]
    public class SubscribeMailController : Controller
    {
        SubscribeMailManager cm = new SubscribeMailManager();

        [HttpGet]
        public ActionResult AddMailPV()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult AddMailPV(SubscribeMail p)
        {
            cm.businessLayerAdd(p);
            return PartialView(p);
        }
    }
}
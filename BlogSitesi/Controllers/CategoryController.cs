using Business.ConCrete;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSitesi.Controllers
{
    [AllowAnonymous]
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryDAL());

        public ActionResult BlogDetailsCategoryListPv()
        {
            var sorgu = cm.GetList();
            return PartialView(sorgu);
        }
        
    }
}
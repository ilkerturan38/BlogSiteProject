using Business.ConCrete;
using Business.ValidationRules;
using DataAccess.EntityFramework;
using Entity.ConCrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSitesi.Controllers
{
    public class _adminCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryDAL());
        CategoryValidator categoryVal = new CategoryValidator();

        [Authorize(Roles = "A")]  // Yetkilendirme İşlemi => Admin Tablosunda Yetkisi Sadece "A" olan hesap,Yeni bir Blog Ekleme işlemi sayfasına gidebilecek.
        public ActionResult adminCategoryList()
        {
            var sorgu = cm.GetList();
            return View(sorgu);
        }

        [HttpGet]
        public ActionResult adminCategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult adminCategoryAdd(Category p)
        {

            ValidationResult result = categoryVal.Validate(p); // Parametreden gelen değeri kontrol et
            if (result.IsValid) // Sonuçlar geçerli ise
            {

                cm.categoryAdd(p);
                try
                {
                    return RedirectToAction("adminCategoryList", "_adminCategory");
                }
                catch
                {
                    ViewBag.hata = "HATA!";
                }
            }
            else
            {
                foreach (var item in result.Errors) // Sonuçların hatalı olması durumunda ; Hata kısmından okuma işlemi gerçekleştir.
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage); // Model Durumu içerisine Hata veren Property ismi ve Hata Mesajını ekle.
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult adminCategoryUpdate(int id)
        {
            var sorgu = cm.FindCategory(id);
            return View(sorgu);
        }

        [HttpPost]
        public ActionResult adminCategoryUpdate(Category p)
        {
            ValidationResult result = categoryVal.Validate(p);
            if (result.IsValid)
            {
                try
                {
                    cm.categoryUpdate(p);
                    ViewBag.uyari = "Güncelleme işlemi başarılı bir şekilde gerçekleşti..";
                }
                catch
                {
                    ViewBag.hata = "HATA!";
                }
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

        public ActionResult categoryStatusUpdateFalse(int id)
        {
            cm.CategoryStatusFalseUpdate(id);
            TempData["uyari"] = "Seçilen Kategori durumu False tipinde güncellendi..";

            return RedirectToAction("adminCategoryList", "_adminCategory");
            //return new RedirectResult(@"~\_adminCategory\adminCategoryList");
        }

        public ActionResult categoryStatusUpdateTrue(int id)
        {
            cm.CategoryStatusTrueUpdate(id);
            TempData["uyari"] = "Seçilen Kategori durumu True tipinde güncellendi..";

            return RedirectToAction("adminCategoryList", "_adminCategory");
        }
    }
}
using Business.ConCrete;
using Entity.ConCrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSitesi.Controllers
{
    public class CommentController : Controller
    {
        // GET: Comment

        CommentManager cm = new CommentManager();

        [AllowAnonymous] // Controller Bazlı Tanımlama. Burada [AllowAnonymous] tanımlaması yaparak Tanımlanan Controller için Authorize giriş yapma zorunluluğu olmuycaktır.
        public ActionResult CommentListPV(int ID) // BlogDetay Sayfasından gelen BlogID
        {
            var sorgu = cm.CommentByBlog(ID);
            ViewBag.yorumSayisi = sorgu.Count(); // Sorgu'da belirtilen BlogID'ye kaç tane yorum yapıldıysa onun sayısını getir.
            return PartialView(sorgu);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult LeaveCommentPV(int ID) 
        {
            ViewBag.blogID = ID; // BlogID'yi aldık.
            return PartialView();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LeaveCommentPV(Comment c) // BlogDetay Sayfası -- Yeni Yorum Ekleme
        {
            cm.CommentAdd(c);
            TempData["uyari"] = "Yorumunuz gönderildi.Kontrol edildikten sonra yayınlanıcaktır.";
            return PartialView(c);
            //return RedirectToAction("Index","Blog"); // Eğer Form Action'da Link tanımlarsak Burda Yönlendirme Yapmamız Lazım,Yoksa Partial View Sayfası Temasız şekilde açılıyor.
        }


        // Admin Paneli Yorum Kısmı

        public ActionResult CommentStatusTrueList()
        {
            var sorgu = cm.StatusTrue();
            return View(sorgu);
        }

        public ActionResult CommentStatusFalseList()
        {
            var sorgu = cm.StatusFalse();
            return View(sorgu);
        }

        public ActionResult UpdateStatusTrue(int id)
        {
            cm.UpdateStatusTrue(id);
            return RedirectToAction("CommentStatusTrueList", "Comment");
        }

        public ActionResult UpdateStatusFalse(int id)
        {
            cm.UpdateStatusFalse(id);
            return RedirectToAction("CommentStatusFalseList", "Comment");
        }
    }
}
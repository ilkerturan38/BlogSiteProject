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
    public class AuthorController : Controller
    {

        BlogManager bm = new BlogManager();
        AuthorManager am = new AuthorManager(new EFAuthorDAL());

        // (Parametre ile gelen BlogID'ye göre Belirtilen Bloğu Yazan,Yazarın Bilgileri gelir.)
        public ActionResult AuthorAboutPV(int id) // ID ; Bir Blog yazısının Detay sayfasına Tıklanıldığında URL adresinden gelen BlogID 'dir.
        {
            var sorgu = bm.GetBlogByID(id); // BlogID
            return PartialView(sorgu);
        }

        public ActionResult AuthorPopularPostPV(int id) // Yazara Ait Tüm Blog Yazılarını Listeleme
        {
            // Parametreden gelen BlogID'ye göre,Yazarın ID bilgisini seçtik.

            var sorgu1 = bm.GetBlogByID(id).Select(y => y.authorID).FirstOrDefault();
            //var sorgu1 = bm.GetAll().Where(x => x.blogID == id).Select(y => y.authorID).FirstOrDefault();

            var sorgu2 = bm.GetBlogByAuthorID((int)sorgu1); // sorgu1'deki yazarID'yi,BlogManager'da bulunan GetBlogByAuthorID Listesine parametre olarak gönder.

            return PartialView(sorgu2);
        }
    }
}
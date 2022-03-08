using Business.ConCrete;
using Business.ValidationRules;
using DataAccess.ConCrete;
using Entity.ConCrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSitesi.Controllers
{

    public class _adminBlogController : Controller
    {
        BlogManager bg = new BlogManager();
        BlogValidator blogVal = new BlogValidator();
        Context db = new Context();

        // Search işlemi Linq Yöntemi ile Yapımı

        /*
        public ActionResult adminBlogList1(string p)
        {
            var search = from x in db.blogs select x; // x parametre'den gelen değeri karşılayacak olan yapı.
            if(!string.IsNullOrEmpty(p)) // parametreden gelen değer boş değilse
            {
                search = search.Where(y => y.Title.Contains(p)); // gelen değeri kontrol et veritabanındaki Title alanında Contains ile ara eğer var ise search değişkenine ata.
            }
            return View(search.ToList()); // Aranan kayıt bulunamassa tablodaki tüm kayıtları getir.
        }

        */

        // Search işlemi Katmanlı Mimariye Göre Yapımı

        public ActionResult adminBlogList1(string p)
        {
            var search = bg.SearchBlogTitle(p);
            if (search.Count > 0)
            {
                return View(search);
            }

            return View(bg.GetAll());

            /*
            
            if(!string.IsNullOrEmpty(p))
            {
                return View(search);
            }
            
            */
        }

        public ActionResult adminBlogList2()
        {
            var sorgu = bg.GetAll();
            return View(sorgu);
        }


        [HttpGet]
        public ActionResult Insert()
        {
            Context c = new Context();
            List<SelectListItem> icerik = (from item in c.Categories.ToList() // Kategoriler tablosunun bütün değerlerini al
                                           select new SelectListItem // yukarıdaki liste öğesini seç
                                           {
                                               // DropdownList'in aldığı parametreler
                                               Text = item.categoryName, // Seçilen değerin İçeriği
                                               Value = item.categoryID.ToString() // Seçilen değerin ID'si
                                           }).ToList();
            ViewBag.categoryID = icerik;

            List<SelectListItem> icerik2 = (from item in c.authors.ToList()
                                            select new SelectListItem
                                            {
                                                Text = item.authorNameSurname,
                                                Value = item.authorID.ToString()
                                            }).ToList();
            ViewBag.authorID = icerik2;

            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Insert(Blog b,HttpPostedFileBase ImageURL)
        {

            ValidationResult result = blogVal.Validate(b); // Parametreden gelen değeri kontrol et
            if (result.IsValid) // Sonuçlar geçerli ise
            {
                FileInfo file = new FileInfo(ImageURL.FileName);
                int iFileSize = ImageURL.ContentLength;
                if (iFileSize < (1024 * 1024 * 5))
                {
                    var dosyayoluKontrol = System.IO.Path.Combine(Server.MapPath("~/Uploads/Blog/") + file);
                    ImageURL.SaveAs(dosyayoluKontrol);
                    b.ImageURL = "/Uploads/Blog/" + file;
                    bg.blogAddBL(b);
                    try
                    {
                        return RedirectToAction("adminBlogList1", "_adminBlog");
                    }
                    catch
                    {
                        ViewBag.hata = "HATA!";
                    }
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


        public ActionResult Delete(int id)
        {
            bg.DeleteBlog(id);
            return RedirectToAction("adminBlogList1", "_adminBlog");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            Context c = new Context();
            List<SelectListItem> icerik = (from item in c.Categories.ToList() // Kategoriler tablosunun bütün değerlerini al
                                           select new SelectListItem // yukarıdaki liste öğesini seç
                                           {
                                               // DropdownList'in aldığı parametreler
                                               Text = item.categoryName, // Seçilen değerin İçeriği
                                               Value = item.categoryID.ToString() // Seçilen değerin ID'si
                                           }).ToList();
            ViewBag.Category = icerik;

            List<SelectListItem> icerik2 = (from item in c.authors.ToList()
                                            select new SelectListItem
                                            {
                                                Text = item.authorNameSurname,
                                                Value = item.authorID.ToString()
                                            }).ToList();
            ViewBag.Author = icerik2;
            Blog blog = bg.FindBlog(id);
            return View(blog);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(int id, Blog p) // Update Sayfasında,Form Kısmında id Tanımlaması yaparsak ActionResult içinde id vermeye gerek kalmaz.
        {
            bg.UpdateBlog(id, p);
            return RedirectToAction("adminBlogList1", "_adminBlog");
        }


        public ActionResult GetCommentByBlog(int id) // Bloğa Göre,Yorum Getirme
        {
            CommentManager cm = new CommentManager();
            var sorgu = cm.CommentByBlog(id);
            return View(sorgu);
        }

    }
}
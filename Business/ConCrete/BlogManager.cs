using DataAccess.ConCrete;
using Entity.ConCrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ConCrete
{
    public class BlogManager
    {
        GenericRepository<Blog> repoBlog = new GenericRepository<Blog>();
        GenericRepository<testImage> repotestImage = new GenericRepository<testImage>();
        public List<Blog> GetAll()
        {
            return repoBlog.List();
        }

        public List<Blog> GetBlogByID(int id) // Expression ile Oluşan List Metodu.
        {
            return repoBlog.List(x => x.blogID == id);
        }

        //public List<Blog> BlogByID(int id) // Bu yapıda çalışıyor Ama Solid Yapısı Çiğnenmiş oluyor,Business Katmanında Entity Framework'un CRUD metotları (Add,Update,Remove,ToList) kullanılmamalı
        //{
        //    return repoBlog.List().Where(x => x.blogID == id).ToList();
        //}

        public List<Blog> GetBlogByAuthorID(int id)  // YazarID'ye göre Blog Kayıtlarını Listeleme
        {
            return repoBlog.List(x => x.authorID == id);
        }

        public List<Blog> GetBlogByCategoryID(int id) // CategoryID'ye göre Blog Kayıtlarını Listeleme
        {
            return repoBlog.List(x => x.categoryID==id);
        }

        public List<Blog> SearchBlogTitle(string p) // Parametreden gelen değeri Al, BlogTitle 'a göre Arama yaptır, Bulduğun Sonuçları Listele 
        {
            return repoBlog.List(x => x.Title.Contains(p)); // Tablodaki Title alanı,Parametreden gelen değeri içermeli
        }

        public void blogAddBL(Blog b)
        {
            repoBlog.Insert(b);
        }

        public void DeleteBlog(int id)
        {
            var sorgu = repoBlog.Find(x => x.blogID == id); // Repository içerisindeki Find metodu ile ID'yi bul eşleştir
            repoBlog.Delete(sorgu);  // Repository içerisindeki Delete metodu ile Sorgudan gelen ID'yi sil
        }

        public Blog FindBlog(int id)
        {
            return repoBlog.Find(x => x.blogID == id); // Parametreden Gelen ID değerine göre Tek Bir Kaydın Bilgileri Getirilcek
        }

        public void UpdateBlog(int id,Blog p)
        {
            //var sorgu = repoBlog.Find(x => x.blogID == id);
            var sorgu = repoBlog.GetByID(id);

            // Eğer ID tanımlanırsa Form tarafında veri gönderirken bu yöntem kullanılabilir.Hata vermez.(Parametre içerisinde Extradan id tanımlamaya gerek kalmaz)
            //var sorgu = repoBlog.Find(x => x.blogID == p.blogID); // ID'yi parametre içerisindeki Blog sınıfından türetilmiş olan p değişkeninden alıyoruz.

            sorgu.Title = p.Title;
            sorgu.Content = p.Content;
            sorgu.ImageURL = p.ImageURL;
            sorgu.Date = p.Date;
            sorgu.authorID = p.authorID;
            sorgu.categoryID = p.categoryID;
            repoBlog.Update(sorgu);
        }

        public void testImageAdd(testImage p)
        {
            repotestImage.Insert(p);
        }
    }
}

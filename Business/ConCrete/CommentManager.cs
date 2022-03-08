using DataAccess.ConCrete;
using Entity.ConCrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ConCrete
{
    
    public class CommentManager
    {
        GenericRepository<Comment> repoComment = new GenericRepository<Comment>();

        public List<Comment> StatusTrue()
        {
            return repoComment.List(x => x.commentStatus == true);
        }

        public List<Comment> StatusFalse()
        {
            return repoComment.List(x => x.commentStatus == false);
        }

        public void UpdateStatusTrue(int id)
        {
            var sorgu = repoComment.Find(x => x.commentID == id);
            sorgu.commentStatus = true;
            repoComment.Update(sorgu);
        }

        // Tanımlama yaparken Comment Sınıfından yeni bir Nesne oluşturulmadı ; Güncellenecek veriler Ayrıyeten Update Sayfasından parametre olarak alınmıycak.
        public void UpdateStatusFalse(int id) 
        {
            var sorgu = repoComment.GetByID(id); // CommentID
            sorgu.commentStatus = false; 
            repoComment.Update(sorgu);
        }

        public List<Comment> CommentByBlog(int ID) // BlogDetay Sayfası -- Yapılan Yorumlar'dan Sadece Onaylı Olanları, BlogId'ye göre Listeleme işlemi.
        {
            return repoComment.List(x => x.blogID == ID && x.commentStatus==true);
        }

        public void CommentAdd(Comment c) // BlogDetay Sayfası -- Yeni Yorum Ekleme
        {
            repoComment.Insert(c);
        }

       
    }
}

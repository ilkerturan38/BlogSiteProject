using DataAccess.ConCrete;
using Entity.ConCrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ConCrete
{
    public class AuthorProfileManager
    {
        GenericRepository<Author> repoAuthor = new GenericRepository<Author>();
        GenericRepository<Blog> repoBlog = new GenericRepository<Blog>();

        public List<Blog> GetAuthorByID(int id) // Yazar ait Tüm Blog Kayıtlarını Getirme (Birden Fazla Kayıt getirilceği zaman bu Yöntem kullanılır)
        {
            return repoBlog.List(x => x.authorID == id);
        }

        public Author FindAuthor(string mail) // Mail adresine göre,Yazar bilgisini getirme (Sadece Tek bir Yazar bilgisini getirir.)
        {
            return repoAuthor.Find(x => x.email == mail);
        }

        public void UpdateAuthor(Author p)
        {
            Author author = repoAuthor.Find(x => x.authorID == p.authorID);
            author.authorNameSurname = p.authorNameSurname;
            author.imageURL = p.imageURL;
            author.about = p.about;
            author.authorTitle = p.authorTitle;
            author.authorShort = p.authorShort;
            author.email = p.email;
            author.password = p.password;
            author.phoneNumber = p.phoneNumber;
            repoAuthor.Update(author);
        }
    }
}

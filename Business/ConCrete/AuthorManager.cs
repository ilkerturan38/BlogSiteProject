using Business.Abstract;
using DataAccess.ConCrete;
using DataAccess.ConCrete.Abstract;
using Entity.ConCrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ConCrete
{
    public class AuthorManager: IAuthorService
    {
        GenericRepository<Author> repoAuthor = new GenericRepository<Author>();

        IauthorDAL _authorDAL;

        public AuthorManager(IauthorDAL authorDAL)
        {
            _authorDAL = authorDAL;
        }

        public void authorAdd(Author p)
        {
            _authorDAL.Insert(p);
        }

        public void authorDelete(Author p)
        {
            _authorDAL.Delete(p);
        }

        public void authorUpdate(Author p)
        {
            _authorDAL.Update(p);
        }

        public Author GetByID(int id)
        {
            return _authorDAL.GetByID(id);
        }

        public List<Author> GetList()
        {
            return _authorDAL.List();
        }


        // Generic Repository Yöntemi ile Yapımı

        /*
         
        public List<Author> GetAll()
        {
            return repoAuthor.List();
        }

        public void AddAuthor(Author p)
        {
            repoAuthor.Insert(p);
        }

        public Author FindAuthor(int id)
        {
            return repoAuthor.Find(x => x.authorID == id);
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
            repoAuthor.Update(p);
        }

        */
    }
}

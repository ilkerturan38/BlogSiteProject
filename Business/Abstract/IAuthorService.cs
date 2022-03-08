using Entity.ConCrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthorService
    {
        List<Author> GetList();
        void authorAdd(Author p);
        void authorUpdate(Author p);
        void authorDelete(Author p);
        Author GetByID(int id);
    }
}

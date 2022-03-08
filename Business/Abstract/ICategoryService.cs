using Entity.ConCrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetList();
        void categoryAdd(Category p);
        void categoryUpdate(Category p);
        void categoryDelete(Category p);
        Category GetByID(int id);

        // Category Find(Expression<Func<Category, bool>> filter);
        // List<Category> List(Expression<Func<Category, bool>> filter);

    }
}

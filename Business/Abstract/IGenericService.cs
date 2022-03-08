using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGenericService<T>
    {
        List<T> GetAll();
        void Insert(T p);
        void Update(T p);
        void Delete(T p);
        T GetByID(int id);

        // T Find(Expression<Func<T, bool>> filter);
    }
}

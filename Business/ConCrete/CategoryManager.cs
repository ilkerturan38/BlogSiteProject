using Business.Abstract;
using DataAccess.ConCrete;
using DataAccess.ConCrete.Abstract;
using Entity.ConCrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.ConCrete
{
    public class CategoryManager:ICategoryService 
    {
        GenericRepository<Category> repoCategory = new GenericRepository<Category>();

        IcategoryDAL _categorydal; // IcategoryDAL Interface'sinden değişken oluşturduk.
        public CategoryManager(IcategoryDAL categorydal) // IcategoryDAL Interface'sini implement etmiş Sınıflar aşağıdaki _categorydal isimli değişken içine atılcak
        {
            _categorydal = categorydal; 
        }

        public void categoryAdd(Category p)
        {
            _categorydal.Insert(p);
        }

        public void categoryDelete(Category p)
        {
            _categorydal.Delete(p);
        }

        public void categoryUpdate(Category p)
        {
            _categorydal.Update(p);
        }

        public Category GetByID(int id)
        {
            return _categorydal.GetByID(id);
        }

        public List<Category> GetList()
        {
            return _categorydal.List();
        }


        // Generic Repository Kısmını ait Bölüm

        public Category FindCategory(int id)
        {
            return repoCategory.Find(x => x.categoryID == id);
        }

        public void CategoryStatusFalseUpdate(int id)
        {
            var sorgu = repoCategory.GetByID(id);
            sorgu.categoryStatus = false;
            repoCategory.Update(sorgu);
        }
        public void CategoryStatusTrueUpdate(int id)
        {
            var sorgu = repoCategory.GetByID(id);
            sorgu.categoryStatus = true;
            repoCategory.Update(sorgu);
        }
    }
}

using DataAccess.ConCrete.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ConCrete
{
    // Irepository sıfındaki metotlar için,gelicek olan Sınıf adına göre <T> ,GenericRepository sınıfında CRUD işlemleri yapılıcak.
    public class GenericRepository<T> : Irepository<T> where T : class // Irepository<SınıfAdi> ve T bir Sınıf olmalı
    {
        Context c = new Context(); // Sınıfların Türetildiği Veritabanına gönderildiği,Sınıfa erişim sağladık.
        DbSet<T> _object; // Dışardan Entity Parametresi (Context içerisinde Tanımlanan Sınıf) almak için kullandığımız Entity Framework Metodudur.

        public GenericRepository()
        {
            _object = c.Set<T>();  // Context üzerinden göndermiş olduğumuz işlem yapılıcak olan Sınıfımızı,Object isimdeki Field'ımıza (değişken'izime) ata.
        }

        public void Delete(T p)
        {
            var deletedEntity = c.Entry(p);
            deletedEntity.State = EntityState.Deleted;
            //_object.Remove(p);  // Göndermiş olduğumuz,Tabloya ait parametreden gelen değeri Remove metodu ile sil.
            c.SaveChanges();
        }

        public T Find(Expression<Func<T, bool>> filter)
        {
            /*  return _object.Where(filter).FirstOrDefault();*/ // Parametreden Gelen Sarta göre Tek Bir Değeri Dönder.
            return _object.FirstOrDefault(filter);
        }


        public T GetByID(int ID)
        {
            return _object.Find(ID);
        }

        public void Insert(T p)
        {
            var AddedEntity = c.Entry(p); // Entry içerisine,Gelicek olan Parametre yazılır. (Entry : Giriş anlamına gelir)
            AddedEntity.State = EntityState.Added;  // AddedEntity isimli değişkenin durumu = Ekleme işlemi
            // _object.Add(p);
            c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
           
            return _object.Where(filter).ToList(); // Parametre'den gelen değere göre Listeleme yap.
        }

        public void Update(T p)
        {
            var updatedEntity = c.Entry(p);
            updatedEntity.State = EntityState.Modified;
            c.SaveChanges();
        }
    }
}

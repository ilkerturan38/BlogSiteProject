using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ConCrete.Abstract
{
    public interface Irepository<T> // Parametre içerisine Entity değeri (Tablo) gönderilcek 
    {
        // CRUD işlemlerini Tek Nokta üzerinden gerçekleştirebilmek için Irepository isimli Interface oluşturduk.İçerisinde CRUD işlemlerine ait metotları tutuyor.

        /*
           IRepository Interface'si ve içerisindeki bulunan özellikleri kullanabilmek için 2 Yöntem vardır ; 
               - Her bir sınıf için ayrı bir tane yeni Interface oluşturulur.
               - Generic Repository Yapısı oluşturulur.
        */

        List<T> List();

        void Insert(T p);
        void Update(T p); 
        void Delete(T p);

        T GetByID(int ID); // Tablodaki bir kaydı güncelleme yapabilmek için gelen ID değerine göre işlemler gerçekleşicek.

        List<T> List(Expression<Func<T,bool>>filter); // İstenilen herhangi bir şarta göre arama veya Liste halinde kayıt getirme işlemi gerçekleştirilebilicek.BusinessLayer Tarafında CRUD metotları (Add,Remove,Update) kullanmaya gerek kalmıycak.

        T Find(Expression<Func<T, bool>> filter); // İstenilen Şarta göre ID'yi ara,bul (Tablodan Tek bir Kaydı getirme işlemi gerçekleştirilir.)

    }
}

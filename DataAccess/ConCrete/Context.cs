using Entity.ConCrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ConCrete
{
    public class Context:DbContext
    {
        // Veritabanına tabloyu eklerken,Tablo isminin sonundaki 's' takısını kaldırmak için kullanılır.
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<About> abouts { get; set; } 
        public DbSet<Admin> admins { get; set; }
        public DbSet<Author> authors { get; set; }
        public DbSet<Blog> blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<SubscribeMail> subscribeMails { get; set; } 
        public DbSet<testImage> testImage { get; set; } 

        // Sol Kısım Visual Studio içerisinde oluşturulan Sınıf'ı Temsil Eder. -- Sağ Kısım (s takılı olan ) Veritabanındaki Tablolarımızı Temsil Eder.
    }
}

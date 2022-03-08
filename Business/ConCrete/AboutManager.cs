using DataAccess.ConCrete;
using Entity.ConCrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ConCrete
{
    public class AboutManager
    {
        GenericRepository<About> repoAbout = new GenericRepository<About>();

        public List<About> GetAll()
        {
            return repoAbout.List();
        }

        public About FindAbout(int id) 
        {
            return repoAbout.Find(x => x.aboutID == id);
        }

        public void UpdateAbout(About p)
        {
            var sorgu = repoAbout.Find(x=>x.aboutID==p.aboutID);
            sorgu.Content1 = p.Content1;
            sorgu.Content2 = p.Content2;
            sorgu.ImageURL1 = p.ImageURL1;
            sorgu.ImageURL2 = p.ImageURL2;
            repoAbout.Update(sorgu);
        }
    }
}

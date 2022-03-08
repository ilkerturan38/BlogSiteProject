using DataAccess.ConCrete;
using Entity.ConCrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ConCrete
{
    public class AdminManager
    {
        GenericRepository<Admin> repoAdmin = new GenericRepository<Admin>();

        public List<Admin> adminTableList()
        {
            return repoAdmin.List();
        }

        public void adminUserInsert(Admin p)
        {
            repoAdmin.Insert(p);
        }

        public Admin FindAdmin(int id)
        {
            return repoAdmin.Find(x => x.adminID == id);
        }

        public void adminUserUpdate(Admin p)
        {
            var sorgu = repoAdmin.Find(x => x.adminID == p.adminID);
            sorgu.username = p.username;
            sorgu.password = p.password;
            sorgu.adminRole = p.adminRole;
            repoAdmin.Update(sorgu);
        }

        public void StatusUpdateTrue(int id)
        {
            var sorgu = repoAdmin.Find(x => x.adminID == id);
            sorgu.adminStatus = true;
            repoAdmin.Update(sorgu);
        }

        public void StatusUpdateFalse(int id)
        {
            var sorgu = repoAdmin.GetByID(id);
            sorgu.adminStatus = false;
            repoAdmin.Update(sorgu);
        }

    }
}

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
    public class ContactManager : IContactService
    {
        IcontactDAL _contactdal;

        public ContactManager(IcontactDAL contactdal)
        {
            this._contactdal = contactdal;
        }

        public void Delete(Contact p)
        {
            _contactdal.Delete(p);
        }

        public List<Contact> GetAll()
        {
            return _contactdal.List();
        }

        public Contact GetByID(int id)
        {
            return _contactdal.GetByID(id);
        }

        public void Insert(Contact p)
        {
            _contactdal.Insert(p);
        }

        public void Update(Contact p)
        {
            _contactdal.Update(p);
        }


        /*
        GenericRepository<Contact> repoContact = new GenericRepository<Contact>();

        public List<Contact> GetAll()
        {
            return repoContact.List();
        }

        public void ContactAdd(Contact c)
        {
            repoContact.Insert(c);
        }

        public Contact GetContactDetails(int id)
        {
            return repoContact.Find(x => x.contactID == id);
        }
        */
    }
}

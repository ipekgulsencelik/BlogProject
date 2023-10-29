using BlogProject.BusinessLayer.Abstract;
using BlogProject.DataAccessLayer.Abstract;
using BlogProject.DataAccessLayer.EntityFramework;
using BlogProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace BlogProject.BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        private IContactDAL _contactDAL;

        public ContactManager(IContactDAL contactDAL)
        {
            _contactDAL = contactDAL;
        }

        public void ContactAdd(Contact contact)
        {
            _contactDAL.Insert(contact);
        }

        public void ContactDelete(Contact contact)
        {
            _contactDAL.Delete(contact);
        }

        public void ContactUpdate(Contact contact)
        {
            _contactDAL.Update(contact);
        }

        public Contact GetByID(int id)
        {
            return _contactDAL.Get(x => x.ContactID == id);
        }

        public Contact GetByIDAndSetRead(int id, bool read)
        {
            return _contactDAL.Get(x => x.ContactID == id && x.IsRead == true);
        }

        public List<Contact> GetList()
        {
            return _contactDAL.List();
        }
    }
}

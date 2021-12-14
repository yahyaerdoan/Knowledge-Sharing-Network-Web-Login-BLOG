using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        readonly IContactDal _contactDal;
        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void Add(Contact contact)
        {
            _contactDal.Add(contact);
        }

        public void Delete(Contact contact)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Contact contact)
        {
            throw new System.NotImplementedException();
        }

        public Contact GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Contact> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public List<Contact> ListAll(Expression<Func<Contact, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Contact GetByFilter(Expression<Func<Contact, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public int GetByCount(Expression<Func<Contact, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}

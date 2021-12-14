using System;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        readonly IAboutDal _aboutDal;
        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void Add(About about)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(About about)
        {
            throw new System.NotImplementedException();
        }

        public List<About> GetAll()
        {
           return _aboutDal.GetAll();
        }

        public List<About> ListAll(Expression<Func<About, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public About GetByFilter(Expression<Func<About, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public int GetByCount(Expression<Func<About, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public About GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(About about)
        {
            throw new System.NotImplementedException();
        }
    }
}

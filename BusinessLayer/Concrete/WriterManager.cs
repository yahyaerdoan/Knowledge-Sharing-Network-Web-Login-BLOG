using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        readonly IWriterDal _writerDal;
        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public void Add(Writer writer)
        {
            _writerDal.Add(writer);
        }

        public void Delete(Writer writer)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Writer writer)
        {
            throw new System.NotImplementedException();
        }

        public Writer GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Writer> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public List<Writer> ListAll(Expression<Func<Writer, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}

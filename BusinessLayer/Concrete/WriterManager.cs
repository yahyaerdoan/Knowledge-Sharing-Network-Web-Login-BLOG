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
            _writerDal.Delete(writer);
        }

        public void Update(Writer writer)
        {
            _writerDal.Update(writer);
        }

        public Writer GetById(int id)
        {
            return _writerDal.GetById(id);
        }

        public List<Writer> GetAll()
        {
            return _writerDal.GetAll();
        }

        public List<Writer> ListAll(Expression<Func<Writer, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Writer> GetWriterById(int id)
        {
            return _writerDal.ListAll(x=> x.WriterId == id);
        }
    }
}

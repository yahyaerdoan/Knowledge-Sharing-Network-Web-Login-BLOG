using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        void Add(T t);
        void Delete(T t);
        void Update(T t);
        T GetById(int id);
        List<T> GetAll();      
        List<T> ListAll(Expression<Func<T, bool>> filter);
        T GetByFilter(Expression<Func<T, bool>> filter = null);
        int GetByCount(Expression<Func<T, bool>> filter = null);
    }
}

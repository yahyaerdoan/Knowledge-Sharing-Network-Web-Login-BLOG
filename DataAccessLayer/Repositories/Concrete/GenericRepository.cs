using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.Repositories.Abstract;

namespace DataAccessLayer.Repositories.Concrete
{
    public class GenericRepository<T> : IGenericDal<T> where T : class

    {
        public void Add(T t)
        {
            using var c = new WebLogContext();
            c.Add(t);
            c.SaveChanges();
        }

        public void Delete(T t)
        {
            using var c = new WebLogContext();
            c.Remove(t);
            c.SaveChanges();
        }

        public List<T> GetAll()
        {
            using var c = new WebLogContext();
            return c.Set<T>().ToList();
        }
               
        public T GetById(int id)
        {
            using var c = new WebLogContext();
            return c.Set<T>().Find(id);
        }

        public List<T> ListAll(Expression<Func<T, bool>> filter)
        {
            using var c = new WebLogContext();
            return c.Set<T>().Where(filter).ToList();
        }

        public T GetByFilter(Expression<Func<T, bool>> filter = null)
        {
            using var c = new WebLogContext();
            if (filter == null)
            {
                return c.Set<T>().FirstOrDefault();

            }
            else
            {
                return c.Set<T>().FirstOrDefault(filter);
            }
        }

        public int GetByCount(Expression<Func<T, bool>> filter = null)
        {
            using var c = new WebLogContext();
            if (filter == null)
            {
                return c.Set<T>().Count();

            }
            else
            {
                return c.Set<T>().Where(filter).Count();
            }
        }

        public void Update(T t)
        {
            using var c = new WebLogContext();
            c.Update(t);
            c.SaveChanges();
        }
    }
}

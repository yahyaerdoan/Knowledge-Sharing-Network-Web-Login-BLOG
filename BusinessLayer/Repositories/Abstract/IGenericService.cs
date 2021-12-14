using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repositories.Abstract
{
    public interface IGenericService<T>
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

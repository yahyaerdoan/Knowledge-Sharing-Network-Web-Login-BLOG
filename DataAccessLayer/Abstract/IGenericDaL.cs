using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDaL<T> where T : class
    {
        void Add(T t);
        void Delete(T t);
        void Update(T t);
        T GetById(int id);
        List<T> GetAll(T t);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class AdministratorManager : IAdministratorService
    {
        readonly IAdministratorDal _administratorDal;

        public AdministratorManager(IAdministratorDal administratorDal)
        {
            _administratorDal = administratorDal;
        }

        public void Add(Administrator administrator)
        {
            _administratorDal.Add(administrator);
        }

        public void Delete(Administrator administrator)
        {
            _administratorDal.Delete(administrator);
        }

        public void Update(Administrator administrator)
        {
            _administratorDal.Update(administrator);
        }

        public Administrator GetById(int id)
        {
            return _administratorDal.GetById(id);
        }

        public List<Administrator> GetAll()
        {
            return _administratorDal.GetAll();
        }

        public List<Administrator> ListAll(Expression<Func<Administrator, bool>> filter)
        {
           return _administratorDal.ListAll(filter);
        }

        public Administrator GetByFilter(Expression<Func<Administrator, bool>> filter = null)
        {
           return _administratorDal.GetByFilter(filter);
        }

        public int GetByCount(Expression<Func<Administrator, bool>> filter = null)
        {
            return _administratorDal.GetByCount(filter);
        }
    }
}

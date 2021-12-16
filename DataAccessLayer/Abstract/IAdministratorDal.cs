using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repositories.Abstract;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IAdministratorDal : IGenericDal<Administrator>
    {
    }
}

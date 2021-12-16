using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Repositories.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IAdministratorService : IGenericService<Administrator>
    {
    }
}

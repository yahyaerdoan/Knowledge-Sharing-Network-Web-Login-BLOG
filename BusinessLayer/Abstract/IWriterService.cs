using EntityLayer.Concrete;
using System.Collections.Generic;
using BusinessLayer.Repositories.Abstract;

namespace BusinessLayer.Abstract
{
    public interface IWriterService : IGenericService<Writer>
    {
        List<Writer> GetWriterById(int id);
    }
}

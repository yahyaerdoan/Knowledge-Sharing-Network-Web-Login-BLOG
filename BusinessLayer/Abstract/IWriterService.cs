using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        void Add(Writer writer);

        //void Delete(Writer writer);
        //void Update(Writer writer);
        //Writer GetById(int id);
        //List<Writer> GetAll();
        //List<Writer> GetAllWithCategory();
        //List<Writer> GetListBlogById(int id);
    }
}

using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IBlogService
    {
        void Add(Blog blog);
        void Delete(Blog blog);
        void Update(Blog blog);
        Blog GetById(int id);
        List<Blog> GetAll();
        List<Blog> GetAllWithCategory();
        List<Blog> GetListBlogById(int id);
        List<Blog> GetBlogListByWriterId(int id);
    }
}

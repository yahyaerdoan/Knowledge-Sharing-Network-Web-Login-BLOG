using EntityLayer.Concrete;
using System.Collections.Generic;
using BusinessLayer.Repositories.Abstract;

namespace BusinessLayer.Abstract
{
    public interface IBlogService : IGenericService<Blog>
    {
        List<Blog> GetAllWithCategory();
        List<Blog> GetListBlogById(int id);
        List<Blog> GetBlogListByWriterId(int id);
    }
}

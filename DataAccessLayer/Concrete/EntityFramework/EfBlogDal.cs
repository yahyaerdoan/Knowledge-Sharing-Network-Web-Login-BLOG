using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Repositories.Concrete;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfBlogDal : GenericRepository<Blog>, IBlogDal
    {
        public List<Blog> GetAllWithCategory()
        {
            using var c = new WebLogContext();
            {
                return c.Blogs.Include(x => x.Category).ToList();
            }             
        }
    }
}

using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.Context;

namespace DataAccessLayer.Repository
{
    public class CategoryRepository : ICategoryDal
    {
        WebLogContext c = new WebLogContext();
        public void Add(Category category)
        {
            c.Add(category);
            c.SaveChanges();
        }

        public void Delete(Category category)
        {
            c.Remove(category);
            c.SaveChanges();
        }

        public List<Category> GetAll()
        {
            return c.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return c.Categories.Find(id);
        }

        public void Update(Category category)
        {
            c.Update(category);
            c.SaveChanges();
        }
    }
}

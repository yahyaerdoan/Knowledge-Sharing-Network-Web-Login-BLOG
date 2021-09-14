﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class BlogRepository : IBlogDal
    {
        
        public void Add(Blog blog)
        {
            using var c = new WebLogContext();
            c.Add(blog);
            c.SaveChanges();
        }

        public void Delete(Blog blog)
        {
            using var c = new WebLogContext();
            c.Remove(blog);
            c.SaveChanges();
        }

        public List<Blog> GetAll()
        {
            using var c = new WebLogContext();
            return c.Blogs.ToList();
        }

        public Blog GetById(int id)
        {
            using var c = new WebLogContext();
            return c.Blogs.Find(id);
        }

        public void Update(Blog blog)
        {
            using var c = new WebLogContext();
            c.Update(blog);
            c.SaveChanges();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Knowledge_Sharing_Network_weB_LOGin_BLOG.ViewComponents.Blog
{
    public class PartialGetLastThreeBlogs : ViewComponent
    {
        BlogManager blogManager = new BlogManager(new EfBlogDal());

        public IViewComponentResult Invoke()
        {
            var values = blogManager.GetLastThreeBlogs();
            return View(values);
        }
    }
}

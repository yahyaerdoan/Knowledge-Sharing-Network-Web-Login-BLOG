using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Knowledge_Sharing_Network_weB_LOGin_BLOG.ViewComponents.Blog
{
    public class PartialBlogListDashboard : ViewComponent
    {
        BlogManager blogManager = new BlogManager(new EfBlogDal());

        public IViewComponentResult Invoke()
        {
            var values = blogManager.GetAllWithCategory().OrderByDescending(x=>x.BlogId).Take(10).ToList();
            return View(values);
        }
    }
}

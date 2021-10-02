using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Knowledge_Sharing_Network_weB_LOGin_BLOG.ViewComponents.Blog
{
    public class PartialWriterLastBlogs : ViewComponent
    {
        BlogManager blogManager = new BlogManager(new EfBlogDal());
    
        public IViewComponentResult Invoke()
        {
            var values = blogManager.GetBlogListByWriterId(1);
            return View(values);
        }
    }
}

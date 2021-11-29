using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authorization;

namespace Knowledge_Sharing_Network_weB_LOGin_BLOG.Controllers
{
    public class DashboardController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogDal());
        
        public IActionResult Index()
        {
            WebLogContext webLogContext = new WebLogContext();
            ViewBag.TotalNumberofBlogs = webLogContext.Blogs.Count().ToString();

            ViewBag.CountofBlogsIvePosted = webLogContext.Blogs.Where(x => x.WriterId == 1).Count();
           
            ViewBag.CountofTrueBlogsIvePosted = webLogContext.Blogs
                .Where(x => x.WriterId == 1).Where(x => x.BlogStatus == true).Count(); 
            ViewBag.CountofFalseBlogsIvePosted = webLogContext.Blogs
                .Where(x => x.WriterId == 1).Where(x => x.BlogStatus == false).Count();

            ViewBag.TotalNumberofCategories = webLogContext.Categories.Count();
            return View();
        }
    }
}
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Knowledge_Sharing_Network_weB_LOGin_BLOG.Areas.Administrator.ViewComponents.Statistic
{
    public class PartialStatistic : ViewComponent
    {
        private readonly BlogManager blogManager = new BlogManager(new EfBlogDal());
        private readonly WebLogContext webLogContext = new WebLogContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.blogTotalCount = blogManager.GetAll().Count();
            ViewBag.newMessageCount = webLogContext.Contacts.Count();
            ViewBag.commetTotalCount = webLogContext.Comments.Count();
            return View();
        }
    }
}

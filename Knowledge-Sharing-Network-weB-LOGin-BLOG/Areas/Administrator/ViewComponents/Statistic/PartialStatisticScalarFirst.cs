using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Knowledge_Sharing_Network_weB_LOGin_BLOG.Areas.Administrator.ViewComponents.Statistic
{
    public class PartialStatisticScalarFirst : ViewComponent
    {
        private readonly IBlogService _blogService;

        //private readonly BlogManager blogManager = new BlogManager(new EfBlogDal());
        private readonly WebLogContext webLogContext = new WebLogContext();

        public PartialStatisticScalarFirst(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.blogTotalCount = _blogService.GetByCount();
            ViewBag.newMessageCount = webLogContext.Contacts.Count();
            ViewBag.commetTotalCount = webLogContext.Comments.Count();
            return View();
        }
    }
}

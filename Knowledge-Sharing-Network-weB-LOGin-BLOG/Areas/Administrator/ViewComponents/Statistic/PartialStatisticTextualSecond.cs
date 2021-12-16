using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using Microsoft.AspNetCore.Mvc;

namespace Knowledge_Sharing_Network_weB_LOGin_BLOG.Areas.Administrator.ViewComponents.Statistic
{
    public class PartialStatisticTextualSecond : ViewComponent
    {
        private readonly IBlogService _blogService;

        private readonly WebLogContext webLogContext = new WebLogContext();

        public PartialStatisticTextualSecond(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.blogTotalCount = _blogService.GetAll()
                .OrderByDescending(x => x.BlogId)
                .Select(b => b.BlogTitle)
                .Take(1).FirstOrDefault();
            ViewBag.newMessageCount = webLogContext.Contacts.Count();
            ViewBag.commetTotalCount = webLogContext.Comments.Count();
            return View();
        }
    }
}

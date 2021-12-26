using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
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

            #region Havadurumu Api

            string weatherApi = "14ad2aba611dbef9c504b82a127794c5";
            string connection =
                "http://api.openweathermap.org/data/2.5/weather?q=Uşak&mode=xml&lang=tr&units=metric&appid=" +
                weatherApi;
            XDocument document = XDocument.Load(connection);
            ViewBag.todayWeather = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            ViewBag.cityWeather = document.Descendants("city").ElementAt(0).Attribute("name").Value;

            #endregion
            return View();
        }
    }
}

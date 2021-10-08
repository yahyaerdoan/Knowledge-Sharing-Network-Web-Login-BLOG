using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Knowledge_Sharing_Network_weB_LOGin_BLOG.Controllers
{
    public class NewsLettersController : Controller
    {
        NewsLetterManager newsLetterManager = new NewsLetterManager(new EfNewsLetterDal());

        [HttpGet]
        public IActionResult PartialSubscribeMail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PartialSubscribeMail(NewsLetter newsLetter)
        {
            newsLetter.MailStatus = true;
            newsLetterManager.Add(newsLetter);
            return RedirectToAction("Index", "Blogs");
        }
    }
}

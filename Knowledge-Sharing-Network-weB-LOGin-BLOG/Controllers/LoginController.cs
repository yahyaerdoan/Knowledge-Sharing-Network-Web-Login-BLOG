using DataAccessLayer.Concrete.Context;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Knowledge_Sharing_Network_weB_LOGin_BLOG.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Index(Writer writer)
        {
            WebLogContext webLogContext = new WebLogContext();
            var datavalue = webLogContext.Writers.FirstOrDefault(x => x.WriterMail == x.WriterMail && x.WriterPassword == x.WriterPassword);
            if (datavalue != null)
            {
                HttpContext.Session.SetString("username", writer.WriterMail);
                return RedirectToAction("Index", "Writers");
            }
            else
            {
                return View();
            }
        }
    }
}

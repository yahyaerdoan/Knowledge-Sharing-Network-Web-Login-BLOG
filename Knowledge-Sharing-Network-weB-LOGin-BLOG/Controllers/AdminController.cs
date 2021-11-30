using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Knowledge_Sharing_Network_weB_LOGin_BLOG.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
       
        public PartialViewResult PartialAdminNavbar()
        {
            return PartialView();
        }
    }
}

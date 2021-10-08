using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Knowledge_Sharing_Network_weB_LOGin_BLOG.Controllers
{
    public class ErrorPagesController : Controller
    {
        public IActionResult ErrorNotFoundPage(int code)
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace Knowledge_Sharing_Network_weB_LOGin_BLOG.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class AdministratorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
       
        public PartialViewResult PartialAdministratorNavbar()
        {
            return PartialView();
        }
    }
}

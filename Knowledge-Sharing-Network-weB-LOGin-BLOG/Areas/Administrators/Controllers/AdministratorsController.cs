using Microsoft.AspNetCore.Mvc;

namespace Knowledge_Sharing_Network_weB_LOGin_BLOG.Areas.Administrators.Controllers
{
    [Area("Administrators")]
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

using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using X.PagedList.Mvc.Core;

namespace Knowledge_Sharing_Network_weB_LOGin_BLOG.Areas.Administrators.Controllers
{
    [Area("Administrators")]
    public class CategoriesController : Controller
    {
        readonly CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

        [Route("Administrators/[Controller]/[Action]/{page?}")]
        public IActionResult Index(int page = 1)
        {
            return View(categoryManager.GetAll().ToPagedList(page, 6));
        }
    }
}

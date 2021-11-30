using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace Knowledge_Sharing_Network_weB_LOGin_BLOG.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class CategoriesController : Controller
    {
        readonly CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        readonly CategoryValidator categoryValidator = new CategoryValidator();

        [Route("Administrator/[Controller]/[Action]/{page?}")]
        public IActionResult Index(int page = 1)
        {
            return View(categoryManager.GetAll().ToPagedList(page, 6));
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [Route("Administrator/[Controller]/[Action]/")]
        public IActionResult Add(Category category)
        {
            ValidationResult results = categoryValidator.Validate(category);
            if (results.IsValid)
            {
                category.CategoryStatus = true;
                categoryManager.Add(category);
                return RedirectToAction("Index", "Categories");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(category);
        }
        public IActionResult Delete(int id)
        {
            var values = categoryManager.GetById(id);
            categoryManager.Delete(values);
            return RedirectToAction("Index");
        }
    }
}

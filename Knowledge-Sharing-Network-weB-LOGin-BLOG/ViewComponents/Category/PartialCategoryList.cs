using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Knowledge_Sharing_Network_weB_LOGin_BLOG.ViewComponents.Category
{
    public class PartialCategoryList : ViewComponent
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

        public IViewComponentResult Invoke()
        {
            var values = categoryManager.GetAll();
            return View(values);
        }
    }
}

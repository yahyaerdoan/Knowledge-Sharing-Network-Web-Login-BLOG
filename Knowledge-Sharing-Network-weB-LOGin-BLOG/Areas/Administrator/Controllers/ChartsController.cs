using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Knowledge_Sharing_Network_weB_LOGin_BLOG.Areas.Administrator.Models;

namespace Knowledge_Sharing_Network_weB_LOGin_BLOG.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class ChartsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryChart()
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
            List<CategoryModel> categoryModels = new List<CategoryModel>();
            categoryModels.Add(new CategoryModel
            {
                categoryname = "Teknoloji",
                categorycount = 23

            });
            categoryModels.Add(new CategoryModel
            {
                categoryname = "Kimya",
                categorycount = 26

            });
            categoryModels.Add(new CategoryModel
            {
                categoryname = "Tatlı",
                categorycount = 28

            });
            categoryModels.Add(new CategoryModel
            {
                categoryname = "İçecek",
                categorycount = 22

            });
            categoryModels.Add(new CategoryModel
            {
                categoryname = "Oyuncak",
                categorycount = 14

            });
            return Json(new {jsoncategoryModels = categoryModels});
        }
    }
}

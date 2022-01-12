using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Knowledge_Sharing_Network_weB_LOGin_BLOG.Areas.Administrator.Models;
using Newtonsoft.Json;

namespace Knowledge_Sharing_Network_weB_LOGin_BLOG.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class WritersController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetWriterById(int id)
        {
            var getWriter = writerModels.FirstOrDefault(x => x.Id == id);
            var jsonWriters = JsonConvert.SerializeObject(getWriter);
            return Json(jsonWriters);
        }
        public IActionResult GetWriterList()
        {
            var jsonWriters = JsonConvert.SerializeObject(writerModels);
            return Json(jsonWriters);
        }

        public static readonly List<WriterModel> writerModels = new List<WriterModel>
        {
            new WriterModel
            {
                Id = 1,
                Name = "Yahya"
            },
            new WriterModel
            {
                Id = 2,
                Name = "Kerem"
            },
            new WriterModel
            {
                Id = 3,
                Name = "Ayşe"
            }
        };
    }
}

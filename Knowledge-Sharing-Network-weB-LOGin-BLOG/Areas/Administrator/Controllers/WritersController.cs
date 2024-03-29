﻿using Microsoft.AspNetCore.Mvc;
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
        [HttpPost]
        public IActionResult Add(WriterModel writerModel)
        {
            writerModels.Add(writerModel);
            var jsonWriters = JsonConvert.SerializeObject(writerModel);
            return Json(jsonWriters);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var deletewriter = writerModels.FirstOrDefault(x => x.Id == id);
            writerModels.Remove(deletewriter);
            return Json(deletewriter);
        }
        [HttpPut]
        public IActionResult Update(WriterModel writerModel)
        {
            var updatewriter = writerModels.FirstOrDefault(x => x.Id == writerModel.Id);
            updatewriter.Name = writerModel.Name;
            var jsonWriters = JsonConvert.SerializeObject(writerModel);
            return Json(jsonWriters);
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

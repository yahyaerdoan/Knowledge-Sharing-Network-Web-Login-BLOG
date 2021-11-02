using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Knowledge_Sharing_Network_weB_LOGin_BLOG.ViewComponents.Writer
{
    public class PartialWriterAboutOnDashboard : ViewComponent
    {
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        public IViewComponentResult Invoke()
        {
            var values = writerManager.GetWriterById(1);
            return View(values);
        }
    }
}

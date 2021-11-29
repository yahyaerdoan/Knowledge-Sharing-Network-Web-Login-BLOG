using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Knowledge_Sharing_Network_weB_LOGin_BLOG.ViewComponents.Writer
{
    public class PartialWriterAboutOnDashboard : ViewComponent
    {
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        WebLogContext webLogContext = new WebLogContext();
        public IViewComponentResult Invoke()
        {
            var writerMail = User.Identity.Name;
            var writerId = webLogContext.Writers
                .Where(x => x.WriterMail == writerMail)
                .Select(y => y.WriterId)
                .FirstOrDefault();
            var values = writerManager.GetWriterById(writerId);
            return View(values);
        }
    }
}

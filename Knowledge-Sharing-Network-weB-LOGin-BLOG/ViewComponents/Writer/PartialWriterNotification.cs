using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Knowledge_Sharing_Network_weB_LOGin_BLOG.ViewComponents.Writer
{
    public class PartialWriterNotification : ViewComponent
    {
        NotificationManager notificationManager = new NotificationManager(new EfNotificationDal());

        public IViewComponentResult Invoke()
        {
            var values = notificationManager.GetAll();
            return View(values);
        }
    }
}

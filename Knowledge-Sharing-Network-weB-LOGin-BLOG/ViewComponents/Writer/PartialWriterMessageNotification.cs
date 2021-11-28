using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Knowledge_Sharing_Network_weB_LOGin_BLOG.ViewComponents.Writer
{
    public class PartialWriterMessageNotification : ViewComponent
    {
        readonly MessageManager messageManager = new MessageManager(new EfMessageDal());
        public IViewComponentResult Invoke()
        {
            int id = 1;
            var values = messageManager.GetInBoxMessageListByWriterId(1);
            return View(values);
        }
    }
}

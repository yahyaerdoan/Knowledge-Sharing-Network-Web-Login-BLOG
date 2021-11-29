using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authorization;

namespace Knowledge_Sharing_Network_weB_LOGin_BLOG.Controllers
{
    public class MessagesController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        [AllowAnonymous]
        public IActionResult InBox()
        {
            int id = 1;
            var values = messageManager.GetInBoxMessageListByWriterId(id);
            return View(values);
        }
        [AllowAnonymous]
        public IActionResult MessageDetails(int id)
        {
            var values = messageManager.GetById(id);
            return View(values);
        }
    }
}

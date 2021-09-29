using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Knowledge_Sharing_Network_weB_LOGin_BLOG.Controllers
{
    public class CommentsController : Controller
    {
        CommentManager commentManager = new CommentManager(new EfCommentDal());
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }
        public PartialViewResult PartialCommentListByBlog(int id)
        {
            var values = commentManager.GetListCommentById(id);
            return PartialView(values);
        }
    }
}

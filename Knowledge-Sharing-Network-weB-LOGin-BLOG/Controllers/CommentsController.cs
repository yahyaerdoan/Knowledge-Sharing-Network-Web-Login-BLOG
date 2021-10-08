using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
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

        [HttpGet]
        public IActionResult PartialAddComment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PartialAddComment(Comment comment)
        {
            comment.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            comment.CommentStatus = true;
            comment.BlogId = 18;
            commentManager.Add(comment);
            return RedirectToAction("BlogReadAll", "Blogs", new { id = comment.BlogId });
        }
        public PartialViewResult PartialCommentListByBlog(int id)
        {
            var values = commentManager.GetListCommentById(id);
            return PartialView(values);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using FluentValidation.Results;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Knowledge_Sharing_Network_weB_LOGin_BLOG.Models;
using Microsoft.AspNetCore.Http;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Knowledge_Sharing_Network_weB_LOGin_BLOG.Controllers
{
    public class WritersController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        WebLogContext webLogContext = new WebLogContext();
        [Authorize]
        public IActionResult Index()
        {
            var writerMail = User.Identity.Name;
            ViewBag.writerMail = writerMail;

            
            var WriterName = webLogContext.Writers
                .Where(x => x.WriterMail == writerMail)
                .Select(y => y.WriterName)
                .FirstOrDefault();
            ViewBag.writerName = WriterName;
            return View();
        }
        public IActionResult WriterProfile()
        {
            return View();
        }
        public IActionResult WriterMail()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Deneme()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult PartialWriterNavbar()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult PartialWriterFooter()
        {
            return PartialView();
        }
       [HttpGet]
        public IActionResult UpdateProfile()
        {
            var writerMail = User.Identity.Name;
            var writerId = webLogContext.Writers
                .Where(x => x.WriterMail == writerMail)
                .Select(y => y.WriterId)
                .FirstOrDefault();
            var values = writerManager.GetById(writerId);
            return View(values);
        }
       [HttpPost]
        public IActionResult UpdateProfile(Writer writer, 
            string PasswordControl,
            IFormFile imageFile)
        {
            AddImage addImage = new AddImage();
            WriterValidator writerValidator = new WriterValidator();
            var values = writerManager.GetById(writer.WriterId);
            if (writer.WriterPassword == null)
            {
                writer.WriterPassword = values.WriterPassword;
                PasswordControl = writer.WriterPassword;
            }
            ValidationResult results = writerValidator.Validate(writer);
            if (results.IsValid && writer.WriterPassword == PasswordControl)
            {
                if (imageFile == null)
                {
                    writer.WriterImage = values.WriterImage;
                }
                else
                {
                    addImage.AddPicture(imageFile, out string fileName);
                    writer.WriterImage = fileName;
                }

                writer.WriterImage = values.WriterImage;
                writerManager.Update(writer);
                return RedirectToAction("Index", "Dashboard");
            }
            else if (!results.IsValid)
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            else
            {
                ModelState.AddModelError("WriterPassword", "Girmiş olduğunuz şifreniz uyuşmamaktadır, yeniden deneyin!");
            }

            return View();
        }
    }
}

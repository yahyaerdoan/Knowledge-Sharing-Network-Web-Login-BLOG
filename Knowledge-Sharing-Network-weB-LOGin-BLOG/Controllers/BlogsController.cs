using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BusinessLayer.ValidationRules.FluentValidation;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Knowledge_Sharing_Network_weB_LOGin_BLOG.Controllers
{
    [AllowAnonymous]
    public class BlogsController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogDal());
        public IActionResult Index()
        {
            var values = blogManager.GetAllWithCategory();
            return View(values);
        }
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var values = blogManager.GetListBlogById(id);
            return View(values);
        }

        public IActionResult BlogListByWriter()
        {
            var values = blogManager.GetAllWithCategoryByWriterId(1);
            Thread.Sleep(10000);
            return View(values);
        }
        [HttpGet]
        public IActionResult Add()
        {
            //CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            //List<SelectListItem> selectListItems = (from x in categoryManager.GetAll()
            //                                        select new SelectListItem
            //                                        {
            //                                            Text = x.CategoryName,
            //                                            Value = x.CategoryId.ToString()
            //                                        })

            //                                       .ToList();
            //ViewBag.categoryvalues = selectListItems;
            ViewBag.categoryvalues = Category();
            return View();
        }
        [HttpPost]
        public IActionResult Add(Blog blog)
        {
            BlogValidator validationRules = new BlogValidator();
            ValidationResult results = validationRules.Validate(blog);
            if (results.IsValid)
            {
                blog.BlogStatus = true;
                blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterId = 1;
                blogManager.Add(blog);
                return RedirectToAction("BlogListByWriter", "Blogs");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                ViewBag.categoryvalues = Category();
            }
            return View(blog);
        }
        public IActionResult Delete(int id)
        {
            var value = blogManager.GetById(id);
            blogManager.Delete(value);
            return RedirectToAction("BlogListByWriter");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = blogManager.GetById(id);
            ViewBag.categoryvalues = Category();
            return View(value);
        }
        [HttpPost]
        public IActionResult Update(Blog blog)
        {
            BlogValidator validationRules = new BlogValidator();
            ValidationResult results = validationRules.Validate(blog);
            if (results.IsValid)
            {
                var value = blogManager.GetById(blog.BlogId);
                blog.WriterId = 1;
                blog.BlogId = value.BlogId;
                blog.BlogCreateDate = value.BlogCreateDate; //DateTime.Parse(DateTime.Now.ToShortDateString());
                //TODO : Ödev : Güncelleme tarihinin yayınlama tarihi olarak kalması sağlanacak, yeni bir değişken atama yöntemiyle default değer çağırması yapıldı.
                blogManager.Update(blog);
                return RedirectToAction("BlogListByWriter");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                ViewBag.categoryvalues = Category();
            }
            return View();
        }
        public List<SelectListItem> Category()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            List<SelectListItem> selectListItems = (from x in categoryManager.GetAll()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.CategoryName,
                                                        Value = x.CategoryId.ToString()
                                                    })
                .ToList();
            return selectListItems;
        }
    }
}

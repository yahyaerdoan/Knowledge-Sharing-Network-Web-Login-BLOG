using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ClosedXML.Excel;
using DataAccessLayer.Concrete.Context;
using EntityLayer.Concrete;
using Knowledge_Sharing_Network_weB_LOGin_BLOG.Areas.Administrator.Models;

namespace Knowledge_Sharing_Network_weB_LOGin_BLOG.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class BlogsController : Controller
    {
        public IActionResult ExportStaticExcelBlogsList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Bloglar Listesi");
                worksheet.Cell(1, 1).Value = "Blog Id";
                worksheet.Cell(1, 2).Value = "Blog Adı";

                int BlogRowCount = 2;
                foreach (var item in GetBlogsList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.BlogId;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogTitle;
                    BlogRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Bloglar Listesi.xlsx");
                }
            }
        }

        public List<BlogModel> GetBlogsList()
        {
            List<BlogModel> blogModels = new List<BlogModel>()
            {
                new BlogModel {BlogId = 1, BlogTitle = "Yahya ERDOĞAN'ın yemek tarifleri"},
                new BlogModel {BlogId = 2, BlogTitle = "Yahya ERDOĞAN'ın gezi tarifleri"},
                new BlogModel {BlogId = 3, BlogTitle = "Yahya ERDOĞAN'ın eğlence tarifleri"},
                new BlogModel {BlogId = 4, BlogTitle = "Yahya ERDOĞAN'ın kod tarifleri"},
                new BlogModel {BlogId = 5, BlogTitle = "Yahya ERDOĞAN'ın çay tarifleri"}
            };
            return blogModels;
        }


        public IActionResult BlogsListExcel()
        {
            return View();
        }

        public IActionResult ExportDynamicExcelBlogsList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Bloglar Listesi");
                worksheet.Cell(1, 1).Value = "Blog Id";
                worksheet.Cell(1, 2).Value = "Blog Adı";
                worksheet.Cell(1, 3).Value = "Blog İçeriği";
                worksheet.Cell(1, 4).Value = "Blog Tarih";
                worksheet.Cell(1, 5).Value = "Blog Durum";

                int BlogRowCount = 2;
                foreach (var item in BlogsTitleList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.BlogId;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogTitle;
                    worksheet.Cell(BlogRowCount, 3).Value = item.BlogContent;
                    worksheet.Cell(BlogRowCount, 4).Value = item.BlogCreateDate;
                    worksheet.Cell(BlogRowCount, 5).Value = item.BlogStatus;
                    BlogRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Bloglar Listesi.xlsx");
                }
            }
        }

        public List<BlogModel> BlogsTitleList()
        {
            List<BlogModel> blogsModel = new List<BlogModel>();
            using (var context = new WebLogContext())
            {
                blogsModel = context.Blogs.Select(x => new BlogModel()
                {
                    BlogId = x.BlogId,
                    BlogTitle = x.BlogTitle,
                    BlogContent = x.BlogContent,
                    BlogCreateDate = x.BlogCreateDate,
                    BlogStatus = x.BlogStatus

                }).ToList();
            }
            return blogsModel;
        }

        public IActionResult BlogsTitleListExcel()
        {
            return View();
        }
    }
}

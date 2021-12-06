using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ClosedXML.Excel;
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
    }
}

using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Knowledge_Sharing_Network_weB_LOGin_BLOG.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Knowledge_Sharing_Network_weB_LOGin_BLOG.Controllers
{
    public class RegisterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            GetCityList();
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Index(Writer writer, 
            string PasswordControl, 
            string cityViewModel, 
            IFormFile imageFile)
        {
            AddImage addImage = new AddImage();
            WriterValidator validationRules = new WriterValidator();
            ValidationResult results = validationRules.Validate(writer);
            if (results.IsValid && writer.WriterPassword == PasswordControl)
            {
                
                writer.WriterStatus = true;
                writer.WriterAbout = "Deneme Test";
                addImage.AddPicture(imageFile, out string fileName);
                writer.WriterImage = fileName;
                writerManager.Add(writer);
                return RedirectToAction("Index", "Blogs");
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

            GetCityList();
            return View();
        }

        public void GetCityList()
        {
            List<SelectListItem> cities = (from x in GetCities()
                                           select new SelectListItem
                                           {
                                               Text = x,
                                               Value = x
                                           }).ToList();
            ViewBag.Cities = cities;
        }

        public List<string> GetCities()
        {
            String[] Cities = new String[] { "Adana", "Adıyaman", "Afyon", "Ağrı", "Aksaray", "Amasya", "Ankara", "Antalya", "Ardahan", "Artvin", "Aydın", "Bartın", "Batman", "Balıkesir", "Bayburt", "Bilecik", "Bingöl", "Bitlis", "Bolu", "Burdur", "Bursa", "Çanakkale", "Çankırı", "Çorum", "Denizli", "Diyarbakır", "Düzce", "Edirne", "Elazığ", "Erzincan", "Erzurum", "Eskişehir", "Gaziantep", "Giresun", "Gümüşhane", "Hakkari", "Hatay", "Iğdır", "Isparta", "İçel", "İstanbul", "İzmir", "Karabük", "Karaman", "Kars", "Kastamonu", "Kayseri", "Kırıkkale", "Kırklareli", "Kırşehir", "Kilis", "Kocaeli", "Konya", "Kütahya", "Malatya", "Manisa", "Kahramanmaraş", "Mardin", "Muğla", "Muş", "Nevşehir", "Niğde", "Ordu", "Osmaniye", "Rize", "Sakarya", "Samsun", "Siirt", "Sinop", "Sivas", "Tekirdağ", "Tokat", "Trabzon", "Tunceli", "Şanlıurfa", "Şırnak", "Uşak", "Van", "Yalova", "Yozgat", "Zonguldak" };
            return new List<string>(Cities);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Knowledge_Sharing_Network_weB_LOGin_BLOG.Areas.Administrator.ViewComponents.Statistic
{
    public class PartialStatisticAboutFourth : ViewComponent
    {
        readonly IAdministratorService _administratorService;

        public PartialStatisticAboutFourth(IAdministratorService administratorService)
        {
            _administratorService = administratorService;
        }

        public IViewComponentResult Invoke()
        {
            var value = _administratorService.GetByFilter(x => x.AdministratorId == 1);

            ViewBag.AdministratorName = value.AdministratorFirstLastName;
            ViewBag.AdministratorImage = value.AdministratorImageUrl;
            ViewBag.AdministratorShortDecription = value.AdministratorShortDescription;
                
            return View();
        }
    }
}

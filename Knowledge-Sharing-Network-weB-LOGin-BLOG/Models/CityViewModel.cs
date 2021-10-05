using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Knowledge_Sharing_Network_weB_LOGin_BLOG.Models
{
    public class CityViewModel
    {
        public string CityName { get; set; }
        public List<SelectListItem> Cities { get; set; }
        public List<CityViewModel> cityViewModels { get; set; }
    }
}

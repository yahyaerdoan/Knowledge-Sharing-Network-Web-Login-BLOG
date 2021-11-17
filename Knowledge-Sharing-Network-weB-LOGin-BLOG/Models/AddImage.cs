using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Knowledge_Sharing_Network_weB_LOGin_BLOG.Models
{
    public class AddImage
    {
        public void AddPicture(IFormFile image, out string fileName)
        {
            var extension = Path.GetExtension(image.FileName);
            var createnewimagename = Guid.NewGuid() + extension;
            var location = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot/ProfilePhotos/", createnewimagename);
            var stream = new FileStream(location, FileMode.Create);
            image.CopyTo(stream);
            fileName = createnewimagename;
        }
    }
}

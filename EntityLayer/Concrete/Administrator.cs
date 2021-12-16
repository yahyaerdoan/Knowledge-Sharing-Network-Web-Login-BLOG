using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Administrator
    {
        [Key]
        public int AdministratorId { get; set; }
        public string AdministratorUserName { get; set; }
        public string AdministratorPassword { get; set; }
        public string AdministratorFirstLastName { get; set; }
        public string AdministratorShortDescription { get; set; }
        public string AdministratorImageUrl { get; set; }
        public string AdministratorRole { get; set; }
    }
}

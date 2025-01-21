using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Eventique.Models
{
    public class Member
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string ImagePath { get; set; }
        [NotMappedAttribute]
        public List<IFormFile> ImageFilePath { get; set; }
        public string About { get; set; }
        public IdentityUser Users{ get; set; }


        public Member()
        {
            ImagePath = "/Images/user_avatar.jpg";
        }
    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Eventique.Models
{
    public class Image
    {
        [Key]
        public int Img_Id { get; set; }
        public string Img_Name { get; set; }
        public string Img_Path { get; set; }
        [NotMappedAttribute]
        public List<IFormFile> ImageFilePath { get; set; }
    }
}

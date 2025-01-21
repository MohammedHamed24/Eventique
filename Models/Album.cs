using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Eventique.Models
{
    public class Album
    {
        [Key]
        public int Al_Id { get; set; }
        public string Al_Title { get; set; }
        public List<Image> MyProperty { get; set; }
        [NotMappedAttribute]
        public List<IFormFile> ImageFilePath { get; set; }
    }
}

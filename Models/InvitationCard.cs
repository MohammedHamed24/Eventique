using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Eventique.Models
{
    public class InvitationCard
    {
        [Key]
        public int Inv_Id { get; set; }
        public Image Img { get; set; }
        public float Inv_Price { get; set; }
        public string Inv_Title { get; set; }
        [NotMappedAttribute]
        public List<IFormFile> ImageFilePath { get; set; }
    }
}

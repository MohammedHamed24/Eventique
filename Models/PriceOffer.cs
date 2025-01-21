using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Eventique.Models
{
    public class PriceOffer
    {
        [Key]
        public int Of_ID { get; set; }
        public string OfferTitle { get; set; }
        public string OfferDetails { get; set; }
        public int OffersPrice { get; set; }
        public string OfferEndDate { get; set; }
        public string OfferImgPath { get; set; }
        [NotMappedAttribute]
        public List<IFormFile> ImageFilePath { get; set; } 
    }
}

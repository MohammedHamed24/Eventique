using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
namespace Eventique.Models
{
    public class Photographer
    {

        [Key]
        public int Ph_Id { get; set; }
        public string Ph_Name  { get; set; }
        public float Rate { get; set; }
        public List<Album> ListAlbum { get; set; }
        public float Ph_Price { get; set; }
        public string Ph_Offers { get; set; }
        public string Ph_Address { get; set; }
        public string Ph_PhoneNumber { get; set; }
        public List<AvailableDate> Ph_AvailableDate { get; set; }
        public string Ph_CameraType { get; set; }
        public List<Review> Ph_Reviews { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        [NotMappedAttribute]
        public List<IFormFile> ImageFilePath{ get; set; }
        public List<PhotographerRequest> Ph_Requests { get; set; }
        public IdentityUser Users { get; set; }
        public string TestDate { get; set; }
        public List<PriceOffer> OffersList { get; set; }
        public Photographer()
        {
            ImagePath = "/Images/pho_avatar.jpg";
            ListAlbum = new List<Album>();
            Ph_AvailableDate = new List<AvailableDate>();
            Ph_Reviews = new List<Review>();
            Ph_Requests = new List<PhotographerRequest>();
            OffersList = new List<PriceOffer>();
        }
    }
}

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
    public class WeddingHall
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string Hall_ImgPath { get; set; }
        public string Address { get; set; }
        public float Hall_Price { get; set; }
        public string Offers { get; set; }
        public List<Review> HallsReview { get; set; }
        public int Capacity { get; set; }
        public float Rate { get; set; }
        public string OtherServices { get; set; }
        public string HallType { get; set; }
        public List<AvailableDate> AvailbleDates { get; set; }
        public string TestDate { get; set; }
        public Album Album { get; set; }
        public List<WeddingHallsRequest> HotelRequest { get; set; }
        public IdentityUser Users { get; set; }
        [NotMappedAttribute]
        public List<IFormFile> ImageFilePath { get; set; }
        [NotMappedAttribute]
        public List<IFormFile> ImageFilePathAlbum { get; set; }
        public List<weddingHallsOffers> weddingHallsOffers { get; set; }
        public WeddingHall()
        {
            HallsReview = new List<Review>();
            HotelRequest = new List<WeddingHallsRequest>();
            weddingHallsOffers = new List<weddingHallsOffers>();
        }

        //public WeddingHall()
        //{
        //    HallsReview = new List<Review>();
        //    HotelRequest = new List<WeddingHallsRequest>();
        //}

    }
}

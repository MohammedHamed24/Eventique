using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eventique.Models
{
    public class WeddingHallsRequest
    {
        [Key]
        public int ID { get; set; }
        public string Date { get; set; }
        public Member RequestUser { get; set; }
        public WeddingHall RequestHotel { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public weddingHallsOffers Offer { get; set; }
        public DateTime Time { get; set; }

        public WeddingHallsRequest()
        {
            Time = DateTime.Now;
        }
    }
}

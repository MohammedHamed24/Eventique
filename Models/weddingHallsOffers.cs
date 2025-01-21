using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventique.Models
{
    public class weddingHallsOffers
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Capacity { get; set; }
        public string Dinner { get; set; }
        public string otherServices { get; set; }
        public int Price { get; set; }
        public DateTime EndDate { get; set; }
    }
}

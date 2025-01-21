using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eventique.Models
{
    public class Recommendation
    {
        [Key]
        public int ID { get; set; }
        public Photographer RecommendedPhotographer { get; set; }
        public Designer RecommendedDesigner { get; set; }
        public WeddingHall RecommendedWeddingHall { get; set; }
        public InvitationCard RecommendedInvitation { get; set; }
        public PriceOffer phOffer { get; set; }
        public weddingHallsOffers hallsOffers { get; set; }
        public string Date { get; set; }
        public float Save { get; set; }
        public int InvQuantity { get; set; }
    }
}

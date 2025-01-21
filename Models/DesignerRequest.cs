using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eventique.Models
{
    public class DesignerRequest
    {
        [Key]
        public int ID { get; set; }
        public string Date { get; set; }
        public Member RequestUser { get; set; }
        public Designer RequestHotel { get; set;}
        public string Status { get; set; }
        public string Message { get; set; }
        public int Quantity { get; set; }
        public InvitationCard InvitationStyle{ get; set; }
        public DateTime Time { get; set; }

        public DesignerRequest()
        {
            Time = DateTime.Now;
        }

        public float price()
        {
            float x = Quantity;
            float y = InvitationStyle.Inv_Price;
            float p = (x * y);
            return p;
        }
    }

}

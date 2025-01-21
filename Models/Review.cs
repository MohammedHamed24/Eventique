using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eventique.Models
{
    public class Review
    {
        [Key]
        public int R_Id { get; set; }
        public int DeleverTime { get; set; }
        public int TimeManagement { get; set; }
        public int Quality { get; set; }
        public string ReviewMessage { get; set; }
        public Member ReviewedMember { get; set; }
        public DateTime ReviewDate { get; set; }

        public float Avg()
        {
            float avg = (float)(Quality + TimeManagement + DeleverTime) / 3;
            avg = (float)Math.Floor(avg * 10) / 10;
            return (avg);
        }

    }
}

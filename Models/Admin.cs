using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eventique.Models
{
    public class Admin
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public IdentityUser Users { get; set; }

    }
}

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
    public class Designer
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public string ShopName { get; set; }
        public float Rate { get; set; }
        public string Designer_ImgPath { get; set; }
        public string Offers { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Album> ListAlbums { get; set; }
        public List<DesignerRequest> DesignerRequest { get; set; }
        public List<InvitationCard> Invitations { get; set; }
        public IdentityUser Users { get; set; }
        [NotMappedAttribute]
        public List<IFormFile> ImageFilePath { get; set; }
        public Designer()
        {
            Reviews = new List<Review>();
            DesignerRequest = new List<DesignerRequest>();
            Invitations = new List<InvitationCard>();
        }
    }
}

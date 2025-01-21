using System;
using System.Collections.Generic;
using System.Text;
using Eventique.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Eventique.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Photographer> Photographers { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Designer> Designers { get; set; }
        public DbSet<WeddingHall> Hotels { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<InvitationCard> InvitationCards{ get; set; }
        public DbSet<PhotographerRequest> PhotographerRequests { get; set; }
        public DbSet<WeddingHallsRequest> WeddingHallsRequests { get; set; }
        public DbSet<DesignerRequest> DesignerRequests { get; set; }
        public DbSet<Recommendation> Recommendations{ get; set; }
        public DbSet<PriceOffer> PriceOffers{ get; set; }
        public DbSet<weddingHallsOffers> weddingHallsOffers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}

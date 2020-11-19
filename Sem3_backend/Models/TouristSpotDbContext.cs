using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sem3_backend.Models
{
    public class TouristSpotDbContext : DbContext
    {
        public TouristSpotDbContext() : base("name=DefaultConnection")
        {
            Database.SetInitializer(new DbInitializer());
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Resort> Resorts { get; set; }
        public DbSet<Restaurent> Restaurents { get; set; }
        public DbSet<TouristSpot> TouristSpots { get; set; }
        public DbSet<Transport> Transports { get; set; }
        public DbSet<Travel> Travels { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }

    }
}

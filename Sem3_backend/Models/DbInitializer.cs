using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sem3_backend.Models
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<TouristSpotDbContext>
    {
        protected override void Seed(TouristSpotDbContext context)
        {
            List<TouristSpot> touristSpots = new List<TouristSpot>()
            {
                new TouristSpot(){ Name="aa", Destination="bbb",Content="ads" },
            };

            List<Restaurent> restaurents = new List<Restaurent>()
            {
                new Restaurent(){ Name="Jame",ImageUrl="aa",Content="bb",TouristSpotId=1},
  
            };

            context.Restaurents.AddRange(restaurents);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
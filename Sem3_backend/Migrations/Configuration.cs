namespace Sem3_backend.Migrations
{
    using Sem3_backend.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Sem3_backend.Models.TouristSpotDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Sem3_backend.Models.TouristSpotDbContext context)
        {
            List<Restaurent> restaurents = new List<Restaurent>()
            {
                new Restaurent(){ Name="Jame",ImageUrl="aa",Content="bb",TouristSpotId=1},

            };

            context.Restaurents.AddRange(restaurents);
            context.SaveChanges();
            base.Seed(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}

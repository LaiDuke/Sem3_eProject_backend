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
            base.Seed(context);
        }
    }
}
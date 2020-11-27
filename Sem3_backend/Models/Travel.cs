using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sem3_backend.Models
{
    public class Travel
    {
        public int TravelID { get; set; }
        public string ImageUrl { get; set; }

        public string Name { get; set; }
        [AllowHtml]
        public string Content { get; set; }
        public int TouristSportID { get; set; }

        public TouristSpot TouristSpot { get; set; }
        public virtual ICollection<Transport> Transports { get; set; }

    }
}
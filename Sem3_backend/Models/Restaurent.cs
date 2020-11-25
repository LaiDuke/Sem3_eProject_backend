using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sem3_backend.Models
{
    public class Restaurent
    {
        public int RestaurentId { get; set; }
        public int TouristSpotId { get; set; }
        public string ImageUrl { get; set; }
        [AllowHtml]
        public string Content { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Quality { get; set; }
        public string Location { get; set; }
        public TouristSpot TouristSpot { get; set; }
    }
}
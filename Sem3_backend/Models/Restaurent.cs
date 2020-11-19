using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sem3_backend.Models
{
    public class Restaurent
    {
        public int Id { get; set; }
        public int TouristSpotId { get; set; }
        public string ImageUrl { get; set; }
        public string Content { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Quality { get; set; }
        public string Location { get; set; }
    }
}
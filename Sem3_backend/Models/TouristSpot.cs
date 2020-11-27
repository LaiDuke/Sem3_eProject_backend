using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sem3_backend.Models
{
    public class TouristSpot
    {
       
        public int TouristSpotID { get; set; }
        public string Name { get; set; }
        [AllowHtml]
        public string Content { get; set; }
        public string Destination { get; set; }
        public string ImageUrl { get; set; }
        public virtual ICollection<Restaurent> Restaurents { get; set; }
        public virtual ICollection<Resort> Resorts { get; set; }
        public virtual ICollection<Travel> Travels { get; set; }
        public virtual ICollection<Hotel> Hotels { get; set; }

    }
}
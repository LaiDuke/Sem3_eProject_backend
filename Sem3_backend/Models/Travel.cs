using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sem3_backend.Models
{
    public class Travel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }

        public string Name { get; set; }
        public string Content { get; set; }
        public int TouristSportId { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sem3_backend.Models
{
    public class Transport
    {
        public int TransportId { get; set; }
        public int TravelId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Content { get; set; }
        public Travel Travel { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sem3_backend.Models
{
    public class Transport
    {
        public int TransportID { get; set; }

        public string Name { get; set; }
        public string ImageUrl { get; set; }
        [AllowHtml]
        public string Content { get; set; }

        public int TravelID { get; set; }
        public Travel Travel { get; set; }
    }
}
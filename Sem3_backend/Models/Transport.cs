using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sem3_backend.Models
{
    public class Transport
    {
        public int TransportID { get; set; }
        [Required(ErrorMessage = "Please enter name")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please upload image")]
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Please enter content")]
        [MaxLength(2000)]
        [AllowHtml]
        public string Content { get; set; }
        
        public int TravelID { get; set; }
        public Travel Travel { get; set; }
    }
}
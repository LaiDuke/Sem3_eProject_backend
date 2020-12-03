using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sem3_backend.Models
{
    public class Resort
    {
        public int ResortID { get; set; }

        [Required(ErrorMessage = "Please upload image")]
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Please enter content")]
        [MaxLength(2000)]
        [AllowHtml]
        public string Content { get; set; }
        [Required(ErrorMessage = "Please enter name")]
        [MaxLength(50)]
        public string Name { get; set; }
        public double Price { get; set; }
        [Required(ErrorMessage = "Please enter quality")]
        public double Quality { get; set; }

        [Required(ErrorMessage = "Please upload location")]
        public string Location { get; set; }
        public int TouristSpotID { get; set; }
        public TouristSpot TouristSpot { get; set; }
    }
}
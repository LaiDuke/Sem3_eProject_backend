using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sem3_backend.Models
{
    public class TouristSpot
    {
       
        public int TouristSpotID { get; set; }
        [Required(ErrorMessage ="Please enter name")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage ="Please enter content")]
        [MaxLength(2000)]
        [AllowHtml]
        public string Content { get; set; }
        [Required(ErrorMessage ="Please enter destination")]
        [MaxLength(200)]
        public string Destination { get; set; }
        [Required(ErrorMessage ="Please upload image")]
        public string ImageUrl { get; set; }
        public virtual ICollection<Restaurent> Restaurents { get; set; }
        public virtual ICollection<Resort> Resorts { get; set; }
        public virtual ICollection<Travel> Travels { get; set; }
        public virtual ICollection<Hotel> Hotels { get; set; }

    }
}
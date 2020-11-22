using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sem3_backend.Models
{
    public class FeedBack
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string UserEmail { get; set; }
    }
}
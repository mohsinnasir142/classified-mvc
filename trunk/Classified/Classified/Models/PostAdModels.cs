using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Classified.Models
{
    public class PostAdModels
    {
    }
    public class AutosModel
    {
        [Required]
        public string title { get; set; }

        public string category { get; set; }
        public string subCategory { get; set; }
        public string city { get; set; }
        [Required]
        public string price { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string  condition { get; set; }
        public string postedBy { get; set; }
        public string postedDate { get; set; }
        [Required]
        public string description { get; set; }
        public string images { get; set; }
        public string warranty { get; set; }
        public string userType { get; set; }
        public string adType { get; set; }
        public string address { get; set; }
        public string altitude { get; set; }
        public string latitude { get; set; }
        public string unCommonAttributes { get; set; }

    }

}
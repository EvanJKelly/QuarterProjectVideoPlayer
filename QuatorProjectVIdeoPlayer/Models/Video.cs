using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace QuatorProjectVIdeoPlayer.Models
{
    public class Video
    {
        public int VideoId { get; set; }

        public string VideoLink {get; set;}

        public string VideoTitle { get; set; }

        public bool Rating { get; set; }

        public string ThumbnailUrl { get; set; }

        [NotMapped]
        public IFormFile Thumbnail { get; set; }

        public string Comments { get; set; }

        public int AccountId { get; set; }
    }
}

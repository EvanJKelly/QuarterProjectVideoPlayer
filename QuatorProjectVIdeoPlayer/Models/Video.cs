using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuatorProjectVIdeoPlayer.Models
{
    public class Video
    {
        public int VideoId { get; set; }

        public string VideoLink { get; set; }

        public string VideoTitle { get; set; }

        public bool Rating { get; set; }

        public string Thumbnail { get; set; }

        public string Comments { get; set; }
    }
}

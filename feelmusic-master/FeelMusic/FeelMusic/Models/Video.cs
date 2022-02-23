using System;
using System.Collections.Generic;

namespace FeelMusic.Models
{
    public partial class Video
    {
        public int IdVideo { get; set; }
        public string Title { get; set; }
        public string VideoUrl { get; set; }
        public double Sadness { get; set; }
        public double Joy { get; set; }
        public double Fear { get; set; }
        public double Disgust { get; set; }
        public double Anger { get; set; }
    }
}

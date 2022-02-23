using System;
using System.Collections.Generic;

namespace FeelMusic.Models
{
    public partial class VideoEmotions
    {
        public int IdVideoEmotions { get; set; }
        public int? IdVideo { get; set; }
        public double Sadness { get; set; }
        public double Joy { get; set; }
        public double Fear { get; set; }
        public double Disgust { get; set; }
        public double Anger { get; set; }

        public Video IdVideoNavigation { get; set; }
    }
}

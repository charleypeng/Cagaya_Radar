using System;

namespace Cagaya.Controls.RadarBase.Models
{
    public class Target
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CallSign { get; set; }
        public double PosX { get; set; }
        public double PosY { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public string StrokeColor { get; set; }
    }
}


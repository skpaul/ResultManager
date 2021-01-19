using System;
using System.Collections.Generic;

namespace ResultManager.Models
{
    public partial class Marks
    {
        public int Id { get; set; }
        public int Roll { get; set; }
        public double Written { get; set; }
        public double Viva { get; set; }
        public double Total { get; set; }
    }
}

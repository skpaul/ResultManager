using System;
using System.Collections.Generic;

namespace ResultManager.Models
{
    public partial class Districts
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Division { get; set; }
        public double Percentage { get; set; }
    }
}

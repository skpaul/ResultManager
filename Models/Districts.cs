using System;
using System.Collections.Generic;

namespace ResultManager.Models
{
    public partial class Districts
    {
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public string DivisionName { get; set; }
        public double Percentage { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace ResultManager.Models
{
    public partial class DistrictQuota
    {
        public int Id { get; set; }
        public string DistrictName { get; set; }
        public double DecimalQuantity { get; set; }
        public int RoundedQuantity { get; set; }
        public int FoundQuantity { get; set; }
        public int NotFoundQuantity { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace ResultManager.Models
{
    public partial class DivisionQuota
    {
        public int Id { get; set; }
        public string DivisionName { get; set; }
        public double DecimalQuantity { get; set; }
        public int RoundedQuantity { get; set; }
        public int FoundQuantity { get; set; }
        public int NotFoundQuantity { get; set; }
    }
}

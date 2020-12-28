using System;
using System.Collections.Generic;

namespace ResultManager.Models
{
    public partial class PostQuotaDivisionDistrict
    {
        public int Id { get; set; }
        public string PostName { get; set; }
        public string QuotaName { get; set; }
        public string DivisionName { get; set; }
        public string DistrictName { get; set; }
        public double DecimalQuantity { get; set; }
    }
}

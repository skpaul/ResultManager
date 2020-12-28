using System;
using System.Collections.Generic;

namespace ResultManager.Models
{
    public partial class PostQuotaDistribution
    {
        public int Id { get; set; }
        public string PostName { get; set; }
        public string QuotaName { get; set; }
        public float DecimalQuantity { get; set; }
        public float RoundedQuantity { get; set; }
        public int ApplicantFound { get; set; }
    }
}

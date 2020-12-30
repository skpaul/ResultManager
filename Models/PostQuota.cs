using System;
using System.Collections.Generic;

namespace ResultManager.Models
{
    public partial class PostQuota
    {
        public int Id { get; set; }
        public string PostName { get; set; }
        public string QuotaName { get; set; }
        public double DecimalQuantity { get; set; }
        public double RoundedQuantity { get; set; }
        public int ApplicantFound { get; set; }
        public int ApplicantTransferredToGeneral { get; set; }
        public int SearchCount { get; set; }
    }
}

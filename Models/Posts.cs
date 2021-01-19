using System;
using System.Collections.Generic;

namespace ResultManager.Models
{
    public partial class Posts
    {
        public int PostId { get; set; }
        public string PostName { get; set; }
        public bool IsEligibleForQuota { get; set; }
        public int Vacancies { get; set; }
        public double TotalQuotaPercentage { get; set; }
        public int MaximumQuotaQuantity { get; set; }
        public int QuotaFoundQuantity { get; set; }
        public int GeneralQuantity { get; set; }
        public int GeneralFoundQuantity { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace ResultManager.Models
{
    public partial class Posts
    {
        public int PostId { get; set; }
        public string PostName { get; set; }
        public int Vacancies { get; set; }
        public double TotalQuotaPercentage { get; set; }
        public double TotalQuotaQuantity { get; set; }
    }
}

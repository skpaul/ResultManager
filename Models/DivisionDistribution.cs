using System;
using System.Collections.Generic;

namespace ResultManager.Models
{
    public partial class DivisionDistribution
    {
        public int Id { get; set; }
        public int DivisionId { get; set; }
        public string DivisionName { get; set; }
        public int TotalVacancy { get; set; }
        public double Percentage { get; set; }
        public double DecimalQuantity { get; set; }
        public int RoundedQuantity { get; set; }
        public int FoundQuantity { get; set; }
        public int NotFoundQuantity { get; set; }
    }
}

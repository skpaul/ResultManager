using System;
using System.Collections.Generic;

namespace ResultManager.Models
{
    public partial class View1
    {
        public int ApplicantId { get; set; }
        public string UserId { get; set; }
        public string PostName { get; set; }
        public int Roll { get; set; }
        public string Ffq { get; set; }
        public string PermanentDistrict { get; set; }
        public bool IsSelected { get; set; }
        public int SelectionRank { get; set; }
        public bool HasConsidered { get; set; }
        public string SelectionCriteria { get; set; }
        public double Total { get; set; }
    }
}

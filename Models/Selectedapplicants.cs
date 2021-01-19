using System;
using System.Collections.Generic;

namespace ResultManager.Models
{
    public partial class SelectedApplicants
    {
        public int SelectionId { get; set; }
        public int ApplicantId { get; set; }
        public int Roll { get; set; }
        public string UserId { get; set; }
        public string PostName { get; set; }
        public int SelectionRank { get; set; }
        public string SelectionCriteria { get; set; }
        public string PermanentDistrict { get; set; }
        public string PermanentDivision { get; set; }
        public double Written { get; set; }
        public double Viva { get; set; }
        public double Total { get; set; }
    }
}

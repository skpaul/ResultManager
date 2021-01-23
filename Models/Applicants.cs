using System;
using System.Collections.Generic;

namespace ResultManager.Models
{
    public partial class Applicants
    {
        public int ApplicantId { get; set; }
        public string UserId { get; set; }
        public int Roll { get; set; }
        public int? PostCode { get; set; }
        public string PostName { get; set; }
        public string Name { get; set; }
        public string Dob { get; set; }
        public int? Sex { get; set; }
        public string Religion { get; set; }
        public string Ffq { get; set; }
        public string PresentDistrict { get; set; }
        public string PermanentDistrict { get; set; }
        public bool IsSelected { get; set; }
        public string SelectionCriteria { get; set; }
        public string RejectedCriteria { get; set; }
    }
}

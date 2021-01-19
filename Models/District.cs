using System;
using System.Collections.Generic;

namespace ResultManager.Models
{
    public partial class District
    {
        public int DistCode { get; set; }
        public string DistName { get; set; }
        public int? DivCodeId { get; set; }
    }
}

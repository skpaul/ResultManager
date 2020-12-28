using System;
using System.Collections.Generic;

namespace ResultManager.Models
{
    public partial class Quotas
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Percentage { get; set; }
        public int Priority { get; set; }
    }
}

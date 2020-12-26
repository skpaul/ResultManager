using System;
using System.Collections.Generic;

namespace ResultManager.Models
{
    public partial class PostCalculation
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int DistQuantity { get; set; }
        public int DistFound { get; set; }
        public int DistTransferred { get; set; }
        public int FemaleQuantity { get; set; }
        public int FemaleFound { get; set; }
        public int FemaleTransferred { get; set; }
        public int FreedomFighterQuantity { get; set; }
        public int FreedomFighterFound { get; set; }
        public int FreedomFighterTransferred { get; set; }
        public int TribalQuantity { get; set; }
        public int TribalFound { get; set; }
        public int TribalTransferred { get; set; }
        public int GeneralQuota { get; set; }
    }
}

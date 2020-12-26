using System;
using System.Collections.Generic;

namespace ResultManager.Models
{
    public partial class Posts
    {
        public int PostId { get; set; }
        public string PostName { get; set; }
        public int Vacancies { get; set; }
        public int DistrictQuota { get; set; }
        public int FemaleQuota { get; set; }
        public int FreedomFighterQuota { get; set; }
        public int TribalQuota { get; set; }
    }
}

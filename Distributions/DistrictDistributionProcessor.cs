using System;
using ResultManager.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Collections.Generic;

namespace ResultManager{
    public class DistrictDistributionProcessor{
        private result_managerContext db ;
        public DistrictDistributionProcessor(result_managerContext context){
            db=context;
        }


        //OK
        public void TruncateTable()
        {
            var commandText = "TRUNCATE TABLE district_distribution";
            db.Database.ExecuteSqlRaw(commandText);
            Console.WriteLine("district_distribution table truncated");

        }

        //OK

        public void Prepare(int totalPostsQuantity, DivisionDistribution divisionDist)
        {
            var districts = db.Districts.Where(m => m.DivisionName == divisionDist.DivisionName).OrderByDescending(k => k.Percentage).ToList();
            foreach (var district in districts)
            {
                double decimalQuantity = ((double)district.Percentage / 100) * totalPostsQuantity;
                // double fraction = decimalQuantity - Math.Truncate(decimalQuantity);
                int rounded = (int)Math.Round(decimalQuantity);
                DistrictDistribution dist = new DistrictDistribution()
                {
                    TotalVacancy = totalPostsQuantity,
                    DivisionId = divisionDist.DivisionId,
                    DivisionName = divisionDist.DivisionName,
                    DivisionalQuantity = divisionDist.RoundedQuantity,
                    DistrictId = district.DistrictId,
                    DistrictName = district.DistrictName,
                    DistrictPercentage = district.Percentage,
                    DecimalQuantity = decimalQuantity,
                    RoundedQuantity = rounded,
                    FoundQuantity = 0,
                };

                db.DistrictDistribution.Add(dist);
                db.SaveChanges();
            }
        }
    }
}
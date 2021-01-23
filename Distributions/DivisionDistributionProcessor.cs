using System;
using ResultManager.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Collections.Generic;

namespace ResultManager
{

    public class DivisionDistributionProcessor
    {
        private result_managerContext db ;
        public DivisionDistributionProcessor(result_managerContext context){
            db=context;
        }

         //OK
        #region Division Distribution
        //Ok
        private void TruncateTable()
        {
            var commandText = "TRUNCATE TABLE division_distribution";
            db.Database.ExecuteSqlRaw(commandText);
            Console.WriteLine("division_distribution table truncated");
        }

        //OK
        public void Prepare()
        {
            this.TruncateTable();
            var totalVacancies = db.Posts.Sum(k => k.Vacancies);
            int totalDistribution = 0;
            List<DivisionDistribution> divisionDistributions = new List<DivisionDistribution>();

            var divisions = db.Divisions.OrderByDescending(k => k.Percentage).ToList();
            var totalDivisions = divisions.Count();

            DistrictDistributionProcessor distProcessor = new DistrictDistributionProcessor(db);
            distProcessor.TruncateTable();
            
            foreach (var division in divisions)
            {
                double decimalQuantity = ((double)division.Percentage / 100) * totalVacancies;
                double fraction = decimalQuantity - Math.Truncate(decimalQuantity);

                int rounded = 0;
                if (fraction > 0.5)
                {
                    rounded = (int)Math.Ceiling(decimalQuantity);
                    if (totalDistribution + rounded <= totalVacancies)
                    {
                        totalDistribution += rounded;
                    }
                    else
                    {
                        rounded = (int)Math.Floor(decimalQuantity);
                        if (totalDistribution + rounded <= totalVacancies)
                        {
                            totalDistribution += rounded;
                        }
                        else
                        {
                            rounded = totalVacancies - totalDistribution;
                            totalDistribution += rounded;
                        }
                    }
                } //fraction > 0.5
                else
                {
                    rounded = (int)Math.Floor(decimalQuantity);
                    if (totalDistribution + rounded <= totalVacancies)
                    {
                        totalDistribution += rounded;
                    }
                    else
                    {
                        rounded = totalVacancies - totalDistribution;
                        totalDistribution += rounded;
                    }
                }

                DivisionDistribution dist = new DivisionDistribution()
                {
                    DivisionId = division.DivisionId,
                    DivisionName = division.DivisionName,
                    Percentage = division.Percentage,
                    DecimalQuantity = decimalQuantity,
                    RoundedQuantity = rounded,
                    FoundQuantity = 0,
                    TotalVacancy = totalVacancies
                };
                
                db.DivisionDistribution.Add(dist);
                db.SaveChanges();
                distProcessor.Prepare(totalVacancies, dist);
                
            }
        }

        #endregion
    }
}

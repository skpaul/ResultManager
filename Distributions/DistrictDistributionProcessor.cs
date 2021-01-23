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

                #region District Distribution
        //OK
        public static void TruncateTable(result_managerContext db)
        {
            var commandText = "TRUNCATE TABLE district_distribution";
            db.Database.ExecuteSqlRaw(commandText);
        }

        //OK

        public void Prepare(int totalPostsQuantity, DivisionDistribution divisionDist)
        {
            var districts = db.Districts.Where(m => m.DivisionName == divisionDist.DivisionName).OrderByDescending(k => k.Percentage).ToList();
            foreach (var district in districts)
            {
                double decimalQuantity = ((double)district.Percentage / 100) * totalPostsQuantity;
                double fraction = decimalQuantity - Math.Truncate(decimalQuantity);
                int rounded = (int)Math.Round(decimalQuantity);
                DistrictDistribution dist = new DistrictDistribution()
                {
                    TotalVacancy = totalPostsQuantity,
                    DivisionId = divisionDist.DivisionId,
                    DivisionName = divisionDist.DivisionName,
                    DivisionTotal = divisionDist.RoundedQuantity,
                    DistrictId = district.DistrictId,
                    DistrictName = district.DistrictName,
                    Percentage = district.Percentage,
                    DecimalQuantity = decimalQuantity,
                    RoundedQuantity = rounded,
                    FoundQuantity = 0,
                    NotFoundQuantity = 0
                };

                db.DistrictDistribution.Add(dist);
                db.SaveChanges();
            }
        }



        static void prepareDistrictDistribution_OLD(int totalPostsQuantity, DivisionDistribution divisionDist, result_managerContext db)
        {

            int totalDistribution = 0;
            var districts = db.Districts.Where(m => m.DivisionName == divisionDist.DivisionName).OrderByDescending(k => k.Percentage).ToList();
            foreach (var district in districts)
            {
                double decimalQuantity = ((double)district.Percentage / 100) * totalPostsQuantity;
                double fraction = decimalQuantity - Math.Truncate(decimalQuantity);

                int rounded = 0;
                if (fraction > 0.5)
                {
                    rounded = (int)Math.Ceiling(decimalQuantity);
                    if (totalDistribution + rounded <= totalPostsQuantity)
                    {
                        totalDistribution += rounded;
                    }
                    else
                    {
                        rounded = (int)Math.Floor(decimalQuantity);
                        if (totalDistribution + rounded <= totalPostsQuantity)
                        {
                            totalDistribution += rounded;
                        }
                        else
                        {
                            rounded = totalPostsQuantity - totalDistribution;
                            totalDistribution += rounded;
                        }
                    }

                } //fraction > 0.5
                else
                {
                    rounded = (int)Math.Floor(decimalQuantity);
                    if (rounded > 0)
                    {
                        if (totalDistribution + rounded <= totalPostsQuantity)
                        {
                            totalDistribution += rounded;
                        }
                        else
                        {
                            rounded = totalPostsQuantity - totalDistribution;
                            totalDistribution += rounded;
                        }
                    }

                }


                DistrictDistribution dist = new DistrictDistribution()
                {
                    TotalVacancy = totalPostsQuantity,
                    DivisionId = divisionDist.DivisionId,
                    DivisionName = divisionDist.DivisionName,
                    DivisionTotal = divisionDist.RoundedQuantity,
                    DistrictId = district.DistrictId,
                    DistrictName = district.DistrictName,
                    Percentage = district.Percentage,
                    DecimalQuantity = decimalQuantity,
                    RoundedQuantity = rounded,
                    FoundQuantity = 0,
                    NotFoundQuantity = 0
                };

                db.DistrictDistribution.Add(dist);
                db.SaveChanges();
            }

            // if (totalDistribution < totalPostsQuantity)
            // {
            //     int remains = totalPostsQuantity - totalDistribution;
            //     var x = db.DistrictDistribution.Where(m => m.RoundedQuantity == 0 && m.DivisionId == divisionDist.DivisionId).FirstOrDefault();
            //     if (x != null)
            //     {
            //         x.RoundedQuantity = remains;
            //         db.SaveChanges();
            //     }
            // }
        }


        #endregion
    }
}
using System;
using ResultManager.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Collections.Generic;

namespace ResultManager{
    public class PostDistributionProcessor{
        private result_managerContext db;

        public PostDistributionProcessor(result_managerContext context){
            db = context;
        }

         #region Post Distribution
        static void truncatePostDistribution(result_managerContext db)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            typewritter("TRUNCATING post_distribution ...");
            Thread.Sleep(1000);
            var commandText = "TRUNCATE TABLE post_distribution";
            db.Database.ExecuteSqlRaw(commandText);

        }

        static void preparePostDistribution(result_managerContext db)
        {
            typewritter("Preparing post_distribution ...", 20);

            var quotas = db.Quotas.OrderBy(o => o.Priority).ToList();
            var quotaCount = quotas.Count();
            var posts = db.Posts.Where(k => k.IsEligibleForQuota == true).ToList();

            foreach (var post in posts)
            {
                int total = 0;
                var loopCount = 1;
                foreach (var quota in quotas)
                {
                    string quotaName = quota.Name;
                    int rounded = 0;
                    double decimalQuantity = ((double)quota.Percentage / 100) * post.Vacancies;
                    if (loopCount < quotaCount)
                    {
                        loopCount++;
                        double fraction = decimalQuantity - Math.Truncate(decimalQuantity);
                        //condition 1 --->
                        if (fraction > 0.5)
                        {
                            rounded = (int)Math.Ceiling(decimalQuantity);
                            if (total + rounded <= post.MaximumQuotaQuantity)
                            {
                                total = total + rounded;
                            }
                            else
                            {
                                rounded = (int)Math.Floor(decimalQuantity);
                                if (total + rounded <= post.MaximumQuotaQuantity)
                                {
                                    total = total + rounded;
                                }
                                else
                                {
                                    var remaining = post.MaximumQuotaQuantity - total;
                                    rounded = (int)remaining;
                                    total = total + rounded;
                                }
                            }
                        }
                        else
                        {
                            rounded = (int)Math.Floor(decimalQuantity);
                            if (total + rounded <= post.MaximumQuotaQuantity)
                            {
                                total = total + rounded;
                            }
                            else
                            {
                                var remaining = post.MaximumQuotaQuantity - total;
                                rounded = (int)remaining;
                                total = total + rounded;
                            }
                        }
                        //condition 1 <---
                    }
                    else
                    {
                        var remaining = post.MaximumQuotaQuantity - total;
                        rounded = (int)remaining;
                        total = total + rounded;
                    }

                    var postDist = new PostDistribution()
                    {
                        PostId = post.PostId,
                        PostName = post.PostName,
                        Vacancies = post.Vacancies,
                        QuotaName = quota.Name,
                        QuotaPercentage = quota.Percentage,
                        DecimalQuantity = decimalQuantity,
                        RoundedQuantity = rounded,
                        ApplicantFound = 0,
                        ApplicantTransferredToGeneral = 0,
                        SearchCount = 0
                    };

                    db.PostDistribution.Add(postDist);
                    db.SaveChanges();
                }
            }

            typewritter("Post Quota Distribution done.", 20);
            Console.WriteLine();

        }
        #endregion

    }
}
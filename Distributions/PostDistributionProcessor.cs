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

        
        void TruncateTable()
        {
            var commandText = "TRUNCATE TABLE post_distribution";
            db.Database.ExecuteSqlRaw(commandText);
            Console.WriteLine("post_distribution table truncated.");

        }


        public void Prepare()
        {
            this.TruncateTable();
            var quotas = db.Quotas.OrderBy(o => o.Priority).ToList();
            var quotaCount = quotas.Count();
            var posts = db.Posts.Where(k => k.IsEligibleForQuota == true).ToList();

            foreach (var post in posts)
            {
                int totalDistribution = 0;
                foreach (var quota in quotas)
                {
                    string quotaName = quota.Name;
                    int rounded = 0;
                    double decimalQuantity = ((double)quota.Percentage / 100) * post.Vacancies;
                double fraction = decimalQuantity - Math.Truncate(decimalQuantity);
                   
                     
                if (fraction > 0.5)
                {
                    rounded = (int)Math.Ceiling(decimalQuantity);
                    if (totalDistribution + rounded <= post.MaximumQuotaQuantity)
                    {
                        totalDistribution += rounded;
                    }
                    else
                    {
                        rounded = (int)Math.Floor(decimalQuantity);
                        if (totalDistribution + rounded <= post.MaximumQuotaQuantity)
                        {
                            totalDistribution += rounded;
                        }
                        else
                        {
                            rounded = post.MaximumQuotaQuantity - totalDistribution;
                            totalDistribution += rounded;
                        }
                    }
                } //fraction > 0.5
                else
                {
                    rounded = (int)Math.Floor(decimalQuantity);
                    if (totalDistribution + rounded <= post.MaximumQuotaQuantity)
                    {
                        totalDistribution += rounded;
                    }
                    else
                    {
                        rounded = post.MaximumQuotaQuantity - totalDistribution;
                        totalDistribution += rounded;
                    }
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
                    };

                    db.PostDistribution.Add(postDist);
                    db.SaveChanges();
                }
            }
            Console.WriteLine("Post Quota Distribution done.");
        }
        
    }
}
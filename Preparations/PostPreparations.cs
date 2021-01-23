using System;
using ResultManager.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Collections.Generic;


namespace ResultManager{
    public class PostPreparation{
        private result_managerContext db ;
        public PostPreparation(result_managerContext context){
            db=context;
        }
        
        //reset posts table
        private void resetPostTable()
        {
            var commandText = "UPDATE posts SET totalQuotaPercentage=0, maximumQuotaQuantity=0, quotaFoundQuantity=0, generalQuantity=0, generalFoundQuantity=0";
            db.Database.ExecuteSqlRaw(commandText);
            Console.WriteLine("posts table has been reset.");
        }

        ///This method breakdowns vacancies into totalQuotaPercentage and totalQuotaQuantity.
        public void preparePosts()
        {
            this.resetPostTable();
            var quotaTotal = db.Quotas.Sum(s => s.Percentage);

            var posts = db.Posts.OrderBy(o => o.PostId).ToList();
            foreach (var post in posts)
            {
                if (post.IsEligibleForQuota)
                {
                    post.TotalQuotaPercentage = quotaTotal;
                    double d = (double)quotaTotal / 100;
                    double v = (double)d * post.Vacancies;
                    double quantity = v;
                    post.MaximumQuotaQuantity = (int)Math.Round(v);
                    post.GeneralQuantity = post.Vacancies - (int)post.MaximumQuotaQuantity;
                }
                else
                {
                    post.GeneralQuantity = post.Vacancies;
                }
            }
            db.SaveChanges();
        }


       
    }
}


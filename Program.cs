﻿//dotnet add package Microsoft.EntityFrameworkCore -v 3.1.10
//dotnet add package Microsoft.EntityFrameworkCore.Tools -v 3.1.10
//dotnet add package MySql.Data -v 8.0.22
//dotnet add package MySql.Data.EntityFrameworkCore -v 8.0.22
//dotnet tool install --global dotnet-ef

//Create the model
//dotnet ef dbcontext scaffold "server=localhost;userid=root;password=;database=result_manager;" MySql.Data.EntityFrameworkCore -o Models

//Update the model. re-scaffold the model by running the command that you originally ran with the -Force option added. That will result in the contents of the specified folder being over-written.
//dotnet ef dbcontext scaffold "server=localhost;userid=root;password=;database=result_manager;" MySql.Data.EntityFrameworkCore -o Models -f

using System;
using ResultManager.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ResultManager
{
    class Program
    {
        static void Main(string[] args)
        {
         
          
            var db = new result_managerContext();
            
            try
            {
                resetPostTable(db);
                preparePosts(db);
                truncatePostQuotaDistribution(db);
                preparePostQuotaDistribution(db);
            }
            catch (System.Exception exp)
            {
                writeLine($"Message- {exp.Message}", ConsoleColor.Black, ConsoleColor.Red);
                writeLine($"Message- {exp.InnerException.Message}", ConsoleColor.Black, ConsoleColor.Red);
            }
        }

        static void writeLine(string message, ConsoleColor background=ConsoleColor.Black, ConsoleColor foreground = ConsoleColor.White){
            Console.BackgroundColor = background;
            Console.ForegroundColor = foreground;
            Console.WriteLine(message);
            Console.ResetColor();
            System.Threading.Thread.Sleep(300);
        }

        static void write(string message, ConsoleColor background=ConsoleColor.Black, ConsoleColor foreground = ConsoleColor.White){
            Console.BackgroundColor = background;
            Console.ForegroundColor = foreground;
            Console.Write(" " + message);
            Console.ResetColor();
            System.Threading.Thread.Sleep(300);
        }


        //reset posts table
        static void resetPostTable(result_managerContext db){
            var commandText = "update posts set totalQuotaPercentage=0.00, totalQuotaQuantity=0";
            db.Database.ExecuteSqlRaw(commandText);
            writeLine("Posts table has been reset.", ConsoleColor.Black, ConsoleColor.Blue);
        }

        //This method breakdowns vacancies into totalQuotaPercentage and totalQuotaQuantity.
        static void preparePosts(result_managerContext db){
            Console.WriteLine("breakdowns vacancies into totalQuotaPercentage and totalQuotaQuantity ... ");
            var quotaTotal = db.Quotas.Sum(s=>s.Percentage);
            writeLine("Total quota - " + quotaTotal);

            writeLine("Reading posts ...");
            var posts = db.Posts.OrderBy(o=>o.PostName).ToList();
            foreach (var post in posts)
            {
                writeLine($"Current post name-{post.PostName}");
                post.TotalQuotaPercentage = quotaTotal;
                double d = (double)quotaTotal/100;
                double v = (double) d* post.Vacancies;
                double quantity = v;
                post.TotalQuotaQuantity = Math.Round(v);
                writeLine($"Total quota quantity-{quantity}");
            }

            db.SaveChanges();
        }

        #region Post quota distribution
         static void truncatePostQuotaDistribution(result_managerContext db){
            var commandText = "TRUNCATE TABLE post_quota_distribution";
            db.Database.ExecuteSqlRaw(commandText);
            writeLine("post_quota_distribution table has been TRUNCATED.", ConsoleColor.Black, ConsoleColor.Blue);
        }

        static void preparePostQuotaDistribution(result_managerContext db){
            writeLine("Preparing post quota distribution ...", ConsoleColor.DarkGreen, ConsoleColor.Black);
            
            var quotas = db.Quotas.OrderBy(o=>o.Priority).ToList();
            var posts = db.Posts.ToList();

            foreach (var post in posts)
            {
                Console.WriteLine($"Post name-{post.PostName}, \tVacancy-{post.Vacancies},\tMax Quantity- {post.TotalQuotaQuantity}");
                var maxQuantityFromQuota = post.TotalQuotaQuantity;
                var vacancy = post.Vacancies;
                foreach (var quota in quotas)
                {
                    string quotaName = quota.Name;
                    double percentage = quota.Percentage;
                    double d = (double) percentage/100;
                    double c = d*vacancy;
                    // var newPostQuotaDist = new PostQuotaDistribution();
                    // newPostQuotaDist.PostName = post.PostName;
                    // newPostQuotaDist.QuotaName = quota.Name;
                    // newPostQuotaDist.DecimalQuantity = c;
                    // db.PostQuotaDistribution.Add(newPostQuotaDist);
                    // writeLine($"\t Quota- {quota.Name}, {c}");
                }
                db.SaveChanges();
            }

            writeLine("Post Quota Distribution done.");

        }
        #endregion
    }
}

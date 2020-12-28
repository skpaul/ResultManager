//dotnet add package Microsoft.EntityFrameworkCore -v 3.1.10
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
            }
            catch (System.Exception exp)
            {
                write($"Message- {exp.Message}", ConsoleColor.Black, ConsoleColor.Red);
                write($"Message- {exp.InnerException.Message}", ConsoleColor.Black, ConsoleColor.Red);
            }
        }

        static void write(string message, ConsoleColor background=ConsoleColor.Black, ConsoleColor foreground = ConsoleColor.White){
             Console.BackgroundColor = background;
            Console.ForegroundColor = foreground;
            Console.WriteLine(message);
            System.Threading.Thread.Sleep(300);
        }

        //reset posts table
        static void resetPostTable(result_managerContext db){
            var commandText = "update posts set totalQuotaPercentage=0.00, totalQuotaQuantity=0";
            db.Database.ExecuteSqlRaw(commandText);
            write("Posts table has been reset.", ConsoleColor.Black, ConsoleColor.Blue);
        }

        //This method breakdowns vacancies into totalQuotaPercentage and totalQuotaQuantity.
        static void preparePosts(result_managerContext db){
            Console.WriteLine("breakdowns vacancies into totalQuotaPercentage and totalQuotaQuantity ... ");
            var quotaTotal = db.Quotas.Sum(s=>s.Percentage);
            write("Total quota - " + quotaTotal);

            write("Reading posts ...");
            var posts = db.Posts.OrderBy(o=>o.PostName).ToList();
            foreach (var post in posts)
            {
                write($"Current post name-{post.PostName}");
                post.TotalQuotaPercentage = quotaTotal;
                double d = (double)quotaTotal/100;
                double v = (double) d* post.Vacancies;
                double quantity = v;
                post.TotalQuotaQuantity = Math.Round(v);
                write($"Total quota quantity-{quantity}");
            }

            db.SaveChanges();
        }

        #region Post quota distribution
         static void truncatePostQuotaDistribution(result_managerContext db){
            var commandText = "TRUNCATE TABLE post_quota_distribution";
            db.Database.ExecuteSqlRaw(commandText);
            write("post_quota_distribution table has been TRUNCATED.", ConsoleColor.Black, ConsoleColor.Blue);
        }
        #endregion
    }
}

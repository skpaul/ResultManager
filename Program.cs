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
using System.Threading;

namespace ResultManager
{
    class Program
    {
        static void Main(string[] args)
        {
         
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("###  DIA Data Mining System ###");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
             Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Press any key to continue ...");
            Console.ResetColor();
            Console.ReadLine();

            var db = new result_managerContext();
            
            try
            {
                resetPostTable(db);
                preparePosts(db);
                 truncatePostQuota(db);
                // preparePostQuota(db);

                // truncatePostQuotaDivision(db);
                // preparePostQuotaDivision(db);

                Console.WriteLine("Success");
                Console.WriteLine("Press any key to exit...");
                Console.ReadLine();
            }
            catch (System.Exception exp)
            {
                writeLine($"Message- {exp.Message}", ConsoleColor.Black, ConsoleColor.Red);
                writeLine($"Message- {exp.InnerException.Message}", ConsoleColor.Black, ConsoleColor.Red);
            }
        }

        static void WriteFullLine(string value)
        {
            // Write an entire line to the console with the string.
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(value.PadRight(Console.WindowWidth - 1));
            // Reset the color.
            Console.ResetColor();
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Resetting post table...");
            Thread.Sleep(300);
            var commandText = "update posts set totalQuotaPercentage=0.00, totalQuotaQuantity=0";
            db.Database.ExecuteSqlRaw(commandText);
            Console.Write("\t\t");
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.Write("success");
            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("");
        }

        //This method breakdowns vacancies into totalQuotaPercentage and totalQuotaQuantity.
        static void preparePosts(result_managerContext db){
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Preparing posts ... "); Console.ResetColor();
            var quotaTotal = db.Quotas.Sum(s=>s.Percentage);
           
            var posts = db.Posts.OrderBy(o=>o.PostName).ToList();
            foreach (var post in posts)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"\t{post.PostName}-");
                Console.ForegroundColor = ConsoleColor.Cyan;              
                Console.Write($" Vacancy-{post.Vacancies}");
                post.TotalQuotaPercentage = quotaTotal;
                double d = (double)quotaTotal/100;
                double v = (double) d* post.Vacancies;
                double quantity = v;
                post.TotalQuotaQuantity = Math.Round(v);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($" Quota-{quantity}");
                Console.WriteLine();
                Thread.Sleep(200);
            }

            db.SaveChanges();
        }

        #region Post quota
         static void truncatePostQuota(result_managerContext db){
            Console.WriteLine(); 
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("TRUNCATING post quotas...");
            Thread.Sleep(300);
            var commandText = "TRUNCATE TABLE post_quota";
            db.Database.ExecuteSqlRaw(commandText);
             Console.Write("\t");
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("success");
            Console.ResetColor();
            Console.WriteLine();
        }

        static void preparePostQuota(result_managerContext db){
            writeLine("Preparing post quota ...", ConsoleColor.DarkGreen, ConsoleColor.Black);
            
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
                    var newPostQuotaDist = new PostQuota();
                    newPostQuotaDist.PostName = post.PostName;
                    newPostQuotaDist.QuotaName = quota.Name;
                    newPostQuotaDist.DecimalQuantity = c;
                    db.PostQuota.Add(newPostQuotaDist);
                    writeLine($"\t Quota- {quota.Name}, {c}");
                }
                db.SaveChanges();
            }

            writeLine("Post Quota Distribution done.");

        }
        #endregion

        #region Post Quota Division
        static void truncatePostQuotaDivision(result_managerContext db)
        {
            var commandText = "TRUNCATE TABLE post_quota_division";
            db.Database.ExecuteSqlRaw(commandText);
            writeLine("post_quota_division has been truncated.", ConsoleColor.Black, ConsoleColor.Blue);
        }

        static void preparePostQuotaDivision(result_managerContext db){
            var divisions = db.Divisions.OrderByDescending(d=>d.Percentage).ToList();
            var postQuotas = db.PostQuota.OrderBy(k=>k.PostName).ThenBy(t=>t.QuotaName).ToList();
            foreach (var postQuota in postQuotas)
            {
                var decimalQuantity = postQuota.DecimalQuantity;
                foreach (var division in divisions)
                {
                    var percentage = division.Percentage;
                    var d = (double) percentage/100;
                    var q = (double) d*decimalQuantity;
                    var newPostQuotaDivision = new PostQuotaDivision();
                    newPostQuotaDivision.PostName = postQuota.PostName;
                    newPostQuotaDivision.QuotaName = postQuota.QuotaName;
                    newPostQuotaDivision.DivisionName = division.Name;
                    newPostQuotaDivision.DecimalQuantity = q;
                    db.PostQuotaDivision.Add(newPostQuotaDivision);
                    db.SaveChanges();
                }
            }
        }

        #endregion
    }

}

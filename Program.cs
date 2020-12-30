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
            // Console.ReadLine();

            var db = new result_managerContext();
            
            try
            {
                // resetApplicantTable(db);
                //  resetPostTable(db);
                // preparePosts(db);
                
                 truncatePostQuota(db);
                preparePostQuota(db);


                // truncatePostQuotaDivision(db);
                // preparePostQuotaDivision(db);

                // preparePostQuotaDivisionDistrict(db);
                // prepareMarks(db);

                // selectFreedomFighters(db);

                //  var floatNumber = 12.5523;

                //     var x = floatNumber - Math.Truncate(floatNumber);
                //     Console.WriteLine(x);
                Console.WriteLine("Data mining completed.");
                // Console.WriteLine("Press any key to exit...");
                // Console.ReadLine();
            }
            catch (System.Exception exp)
            {
                writeLine($"Message- {exp.Message}", ConsoleColor.Black, ConsoleColor.Red);
                writeLine($"Message- {exp.InnerException.Message}", ConsoleColor.Black, ConsoleColor.Red);
                Console.WriteLine(exp.StackTrace);
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

        #region applicants table
        /// <summary>Resets all isSelected=0 in applicant table.</summary>
        static void resetApplicantTable(result_managerContext db){
             Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Resetting applicants table...");
            Thread.Sleep(300);
            var commandText = "update applicants set isSelected=0, selectionRank=0";
            db.Database.ExecuteSqlRaw(commandText);
            Console.Write("\t");
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.Write("success");
            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("");
        }
        #endregion

        //reset posts table
        static void resetPostTable(result_managerContext db){
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Resetting post table...");
            Thread.Sleep(300);
            var commandText = "update posts set totalQuotaPercentage=0, maximumQuotaQuantity=0, quotaFoundQuantity=0, generalQuantity=0, generalFoundQuantity=0";
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
               
                post.TotalQuotaPercentage = quotaTotal;
                double d = (double)quotaTotal/100;
                double v = (double) d* post.Vacancies;
                double quantity = v;
                post.MaximumQuotaQuantity = Math.Round(v);
                post.GeneralQuantity  = post.Vacancies - (int) post.MaximumQuotaQuantity;
                db.SaveChanges();

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"\t{post.PostName}-");
                Console.ForegroundColor = ConsoleColor.Cyan;              
                Console.Write($" Vacancy-{post.Vacancies}");

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($" Quota-{post.MaximumQuotaQuantity}");
                 Console.ForegroundColor = ConsoleColor.Magenta;              
                Console.Write($" General-{post.GeneralQuantity}");
                Console.WriteLine();
                Thread.Sleep(2000);
            }
            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine();
            
        }

        #region Post quota
         static void truncatePostQuota(result_managerContext db){
            Console.WriteLine(); 
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("TRUNCATING post quotas...");
            Thread.Sleep(2000);
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
           
           
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Preparing post quota...");
            Thread.Sleep(1000); Console.ResetColor(); Console.WriteLine();
            var quotas = db.Quotas.OrderBy(o=>o.Priority).ToList();
            var quotaCount = quotas.Count();
            var posts = db.Posts.Where(k=>k.IsEligibleForQuota == true).ToList();

            foreach (var post in posts)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\t");
                Console.Write($"{post.PostName}");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write($" Vacancy-{post.Vacancies}");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($" Max Quota- {post.MaximumQuotaQuantity}");
                Console.ResetColor(); Console.WriteLine();
               
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



                    var newPostQuota = new PostQuota();
                    newPostQuota.PostName = post.PostName;
                    newPostQuota.QuotaName = quota.Name;
                    newPostQuota.DecimalQuantity = decimalQuantity;
                    newPostQuota.RoundedQuantity = rounded;
                    db.PostQuota.Add(newPostQuota);
                    // writeLine($"\t\t{quota.Name} ({quota.Percentage}%), Decimal-{decimalQuantity} Rounded-{Math.Round(decimalQuantity)}");

                    db.SaveChanges();
                    Thread.Sleep(2000);
                }
                Console.Write("\t\t");
                for (int i = 0; i < 20; i++)
                {
                    Console.Write("-"); Thread.Sleep(50);
                }
                Console.WriteLine();
                Console.WriteLine($"\t\tTotal - {total}");
                Console.WriteLine();
                Thread.Sleep(2000);


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

        static void preparePostQuotaDivisionDistrict(result_managerContext db){

            var commandText = "TRUNCATE TABLE post_quota_division_district";
            db.Database.ExecuteSqlRaw(commandText);
            writeLine("post_quota_division_district has been truncated.", ConsoleColor.Black, ConsoleColor.Blue);

            
            var postQuotaDivisions = db.PostQuotaDivision.OrderBy(k=>k.PostName).ThenBy(t=>t.QuotaName).ThenBy(k=>k.DivisionName).ToList();
            foreach (var postQuotaDivision in postQuotaDivisions)
            {
                var districts = db.Districts.Where(d=>d.Division == postQuotaDivision.DivisionName).OrderByDescending(k=>k.Percentage).ToList();

                var decimalQuantity = postQuotaDivision.DecimalQuantity;
                foreach (var district in districts)
                {
                    var percentage = district.Percentage;
                    var d = (double) percentage/100;
                    var q = (double) d*decimalQuantity;
                    var newPostQuotaDivisionDistrict = new PostQuotaDivisionDistrict()
                    {
                        PostName = postQuotaDivision.PostName,
                        QuotaName = postQuotaDivision.QuotaName,
                        DivisionName = postQuotaDivision.DivisionName,
                        DistrictName = district.Name,
                        DecimalQuantity = q
                    };
                    db.PostQuotaDivisionDistrict.Add(newPostQuotaDivisionDistrict);
                }

                db.SaveChanges();
            }
        }

        #endregion

        #region Temporary
        static void prepareMarks(result_managerContext db){
        
            Console.WriteLine("Preparing marks ....");
            var commandText = "TRUNCATE TABLE marks";
            db.Database.ExecuteSqlRaw(commandText);
            var applicants = db.Applicants.ToList();
            foreach (var applicant in applicants)
            {
                Random written = new Random();
                Random viva = new Random();
                var mark = new Marks()
                {
                    Roll= applicant.Roll,
                    Written = written.Next(1,100),
                    Viva = viva.Next(1,100)
                    
                };
                
                mark.Total = mark.Written + mark.Viva;
                db.Marks.Add(mark);
            }

            db.SaveChanges();

            Console.WriteLine("Marks input completed");
        }
        #endregion

        #region applicant selection
        static void selectFreedomFighters(result_managerContext db){
            //get posts and quota names from post_quota where decimal quantity greater than applicantFound+applicantNotFound
            var postQuota = (from c in db.PostQuota where c.DecimalQuantity > (c.ApplicantFound + c.ApplicantTransferredToGeneral) && c.QuotaName=="Freedom Fighter" orderby c.Id select c).FirstOrDefault();
            if(postQuota != null){
                var postName = postQuota.PostName;
                var applicant = (from a in db.Applicants join m in db.Marks on a.Roll equals m.Roll join dist in db.Districts on a.PresentDistrict equals dist.Name join div in db.Divisions on dist.Division equals div.Name  where a.IsSelected==false && a.PostName== postName  && (a.Ffq=="Child of Freedom Fighter" || a.Ffq=="Grand Child of Freedom Fighter") orderby m.Total orderby div.Name orderby dist.Name descending select a).FirstOrDefault();

                if(applicant != null){
                    Console.WriteLine(applicant.Roll);
                    applicant.IsSelected = true;
                    postQuota.ApplicantFound++;
                }
                else{
                    postQuota.ApplicantTransferredToGeneral++;
                }

                    db.SaveChanges();
                    Thread.Sleep(1000);
                    selectFreedomFighters(db);
            }
           
            
        }
        #endregion
    }

}

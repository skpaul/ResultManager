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
            typewritter("Press any key to continue ...");
            Console.ResetColor();
            Console.WriteLine();
            // Console.ReadLine();

            var db = new result_managerContext();
            
            try
            {
                resetApplicantTable(db); //ok
                resetPostTable(db); //ok
                 preparePosts(db);
                
                truncatePostQuota(db);
                preparePostQuota(db);

                truncateDivisionQuota(db); 
                prepareDivisionQuota(db);

                truncateDistrictQuota(db); 
                prepareDistrictQuota(db);


                // truncatePostQuotaDivision(db);
                // preparePostQuotaDivision(db);

                // preparePostQuotaDivisionDistrict(db);
                // prepareMarks(db);

                selectFreedomFighters(db);

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
            typewritter("Resetting applicants table...");
            Thread.Sleep(300);
            var commandText = "update applicants set isSelected=0, selectionRank=0, hasConsidered=0";
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
            typewritter("Resetting post table...");
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
            typewritter("Preparing posts ... "); Console.ResetColor(); Console.WriteLine();
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
            typewritter("TRUNCATING post quotas...");
            Thread.Sleep(1000);
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
           
            string str = "";
            Console.ForegroundColor = ConsoleColor.Magenta;
            typewritter("Preparing post quota...",20);
            Thread.Sleep(1000); Console.ResetColor(); Console.WriteLine();
            var quotas = db.Quotas.OrderBy(o=>o.Priority).ToList();
            var quotaCount = quotas.Count();
            var posts = db.Posts.Where(k=>k.IsEligibleForQuota == true).ToList();

            foreach (var post in posts)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\t");
                typewritter($"{post.PostName}",20);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                typewritter($" Vacancy-{post.Vacancies}",20);
                Console.ForegroundColor = ConsoleColor.Magenta;
                typewritter($" Max Quota- {post.MaximumQuotaQuantity}",20);
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

                    db.SaveChanges();
                    Console.Write("\t\t");
                    str = $"-> {quota.Name} ({quota.Percentage}%)";
                    typewritter(str,20);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    str = $" Post Allocated - {newPostQuota.RoundedQuantity}";
                    typewritter(str);
                    Console.ResetColor();
                    Console.WriteLine();
                    Thread.Sleep(1000);
                }
                Console.Write("\t\t");
                for (int i = 0; i < 30; i++)
                {
                    Console.Write("-"); Thread.Sleep(50);
                }
                Console.WriteLine();
                Console.Write("\t\t");
                str = $"Total Allocation - {total}";
                typewritter(str,50);
                Console.WriteLine();
                Console.WriteLine();
                Thread.Sleep(2000);


            }

            typewritter("Post Quota Distribution done.",20);
            Console.WriteLine();

        }
        #endregion

        #region Division Quoa
        static void truncateDivisionQuota(result_managerContext db)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            typewritter("TRUNCATING division_quota...");
            Thread.Sleep(1000);
            var commandText = "TRUNCATE TABLE division_quota";
            db.Database.ExecuteSqlRaw(commandText);
            Console.Write("\t");
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("success");
            Console.ResetColor();
            Console.WriteLine();
        }

        static void prepareDivisionQuota(result_managerContext db){
           string str = "";
            Console.ForegroundColor = ConsoleColor.Magenta;
            typewritter("Preparing division quota...");
            Thread.Sleep(1000); Console.ResetColor(); 
            var vacancies = db.Posts.Sum(k=>k.Vacancies);
            Console.ForegroundColor = ConsoleColor.Blue;
            typewritter($"Total vacancies-{vacancies}");
            Console.ResetColor(); 
            Console.WriteLine();
            var divisions = db.Divisions.OrderByDescending(k=>k.Percentage).ToList();
            var divisionCount = divisions.Count();

            int total = 0;
            var loopCount = 1;
            foreach (var division in divisions)
            {
                double decimalQuantity = ((double)division.Percentage / 100) * vacancies;

                int rounded = 0;
                 if (loopCount < divisionCount)
                    {
                        loopCount++;
                        double fraction = decimalQuantity - Math.Truncate(decimalQuantity);
                        //condition 1 --->
                        if (fraction > 0.5)
                        {
                            rounded = (int)Math.Ceiling(decimalQuantity);
                            if (total + rounded <= vacancies)
                            {
                                total = total + rounded;
                            }
                            else
                            {
                                rounded = (int)Math.Floor(decimalQuantity);
                                if (total + rounded <= vacancies)
                                {
                                    total = total + rounded;
                                }
                                else
                                {
                                    var remaining = vacancies - total;
                                    rounded = (int)remaining;
                                    total = total + rounded;
                                }
                            }
                        }
                        else
                        {
                            rounded = (int)Math.Floor(decimalQuantity);
                            if (total + rounded <= vacancies)
                            {
                                total = total + rounded;
                            }
                            else
                            {
                                var remaining = vacancies - total;
                                rounded = (int)remaining;
                                total = total + rounded;
                            }
                        }
                        //condition 1 <---
                    }
                    else
                    {
                        var remaining = vacancies - total;
                        rounded = (int)remaining;
                        total = total + rounded;
                    } 
               
                var divisionQuota = new DivisionQuota();
                divisionQuota.DivisionName = division.Name;
                divisionQuota.DecimalQuantity = decimalQuantity;
                divisionQuota.RoundedQuantity = rounded;
                db.DivisionQuota.Add(divisionQuota);
               
               db.SaveChanges();
                    Console.Write("\t");
                    str = $"-> {division.Name} ({division.Percentage}%)";
                    typewritter(str);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    str = $" Post Allocated - {divisionQuota.RoundedQuantity}";
                    typewritter(str);
                    Console.ResetColor();
                    Console.WriteLine();
                    Thread.Sleep(1000);
            }

                Console.Write("\t");
                for (int i = 0; i < 40; i++)
                {
                    Console.Write("-"); Thread.Sleep(50);
                }
                Console.WriteLine();
                Console.Write("\t");
                str = $"Total Allocation - {total}";
                typewritter(str);
                Console.WriteLine();
                Console.WriteLine();
                Thread.Sleep(2000);

            typewritter("Division Quota Distribution done.");
            Console.WriteLine();

        }
        #endregion


        #region District Quoa
        static void truncateDistrictQuota(result_managerContext db)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            typewritter("TRUNCATING district_quota...");
            Thread.Sleep(1000);
            var commandText = "TRUNCATE TABLE district_quota";
            db.Database.ExecuteSqlRaw(commandText);
            Console.Write("\t");
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("success");
            Console.ResetColor();
            Console.WriteLine();
        }

        static void prepareDistrictQuotaOld(result_managerContext db){
           string str = "";
            Console.ForegroundColor = ConsoleColor.Magenta;
            typewritter("Preparing district quota...");
            Thread.Sleep(1000); Console.ResetColor(); 
            var vacancies = db.Posts.Sum(k=>k.Vacancies);
            Console.ForegroundColor = ConsoleColor.Blue;
            typewritter($"Total vacancies-{vacancies}");
            Console.ResetColor(); 
            Console.WriteLine();
            var districts = db.Districts.OrderByDescending(k=>k.Percentage).ToList();
            var districtCount = districts.Count();

            int total = 0;
            var loopCount = 1;
            foreach (var district in districts)
            {
                double decimalQuantity = ((double)district.Percentage / 100) * vacancies;

                int rounded = 0;
                 if (loopCount < districtCount)
                    {
                        loopCount++;
                        double fraction = decimalQuantity - Math.Truncate(decimalQuantity);
                        //condition 1 --->
                        if (fraction > 0.5)
                        {
                            rounded = (int)Math.Ceiling(decimalQuantity);
                            if (total + rounded <= vacancies)
                            {
                                total = total + rounded;
                            }
                            else
                            {
                                rounded = (int)Math.Floor(decimalQuantity);
                                if (total + rounded <= vacancies)
                                {
                                    total = total + rounded;
                                }
                                else
                                {
                                    var remaining = vacancies - total;
                                    rounded = (int)remaining;
                                    total = total + rounded;
                                }
                            }
                        }
                        else
                        {
                            rounded = (int)Math.Floor(decimalQuantity);
                            if (total + rounded <= vacancies)
                            {
                                total = total + rounded;
                            }
                            else
                            {
                                var remaining = vacancies - total;
                                rounded = (int)remaining;
                                total = total + rounded;
                            }
                        }
                        //condition 1 <---
                    }
                    else
                    {
                        var remaining = vacancies - total;
                        rounded = (int)remaining;
                        total = total + rounded;
                    } 
               
                var districtQuota = new DistrictQuota(){
                    DistrictName = district.Name,
                    DecimalQuantity = decimalQuantity,
                    RoundedQuantity = rounded
                };
               
                db.DistrictQuota.Add(districtQuota);
               
               db.SaveChanges();
                    Console.Write("\t");
                    str = $"-> {district.Name} ({district.Percentage}%)";
                    typewritter(str);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    str = $" Post Allocated - {districtQuota.RoundedQuantity}";
                    typewritter(str);
                    Console.ResetColor();
                    Console.WriteLine();
                    Thread.Sleep(500);
            }

                Console.Write("\t");
                for (int i = 0; i < 40; i++)
                {
                    Console.Write("-"); Thread.Sleep(50);
                }
                Console.WriteLine();
                Console.Write("\t");
                str = $"Total Allocation - {total}";
                typewritter(str);
                Console.WriteLine();
                Console.WriteLine();
                Thread.Sleep(2000);

            typewritter("Division Quota Distribution done.",20);
            Console.WriteLine();

        }
        
         static void prepareDistrictQuota(result_managerContext db){
            string str = "";
            Console.ForegroundColor = ConsoleColor.Magenta;
            typewritter("Preparing district quota...");
            Thread.Sleep(1000); Console.ResetColor(); 
            var vacancies = db.Posts.Sum(k=>k.Vacancies);
            Console.ForegroundColor = ConsoleColor.Blue;
            typewritter($"Total vacancies-{vacancies}");
            Console.ResetColor(); 
            Console.WriteLine();
            var districts = db.Districts.OrderByDescending(k=>k.Percentage).ToList();

            int total = 0;
            int serialNo = 0;
            foreach (var district in districts)
            {
                serialNo++;
                double decimalQuantity = ((double)district.Percentage / 100) * vacancies;
               
                 int rounded = 0;
                if (decimalQuantity < 1)
                {
                    var fraction = decimalQuantity - Math.Truncate(decimalQuantity);
                    if (fraction < 0.5)
                    {
                        rounded = (int)Math.Ceiling(decimalQuantity);
                    }
                    else
                    {
                        rounded = (int)Math.Round(decimalQuantity);
                    }
                }
                else
                {
                    rounded = (int) Math.Round(decimalQuantity);
                }
               
       
               total += rounded;
                var districtQuota = new DistrictQuota(){
                    DistrictName = district.Name,
                    DecimalQuantity = decimalQuantity,
                    RoundedQuantity = rounded
                };
               
                db.DistrictQuota.Add(districtQuota);
               
               db.SaveChanges();
                    Console.Write("\t");
                    str = $"-> {serialNo}. {district.Name} ({district.Percentage}%)";
                    typewritter(str);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    str = $" Post Allocated - {districtQuota.RoundedQuantity} (fraction value-{decimalQuantity.ToString("N2")})";
                    typewritter(str, 20);
                    Console.ResetColor();
                    Console.WriteLine();
                    Thread.Sleep(200);
            }

                Console.Write("\t");
                for (int i = 0; i < 40; i++)
                {
                    Console.Write("-"); Thread.Sleep(50);
                }
                Console.WriteLine();
                Console.Write("\t");
                str = $"Total Allocation - {total}";
                typewritter(str);
                Console.WriteLine();
                Console.WriteLine();
                Thread.Sleep(2000);

            typewritter("Division Quota Distribution done.");
            Console.WriteLine();

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
            var postQuota = (from c in db.PostQuota 
                             where c.RoundedQuantity > (c.ApplicantFound + c.ApplicantTransferredToGeneral) && 
                                   c.QuotaName=="Freedom Fighter" 
                             orderby c.Id 
                             select c).FirstOrDefault();
            if(postQuota == null){
                //Do nothing.
            }
            else
            { //postQuota found ---->
                postQuota.SearchCount++;
                db.SaveChanges();

                var applicant =(from a in db.Applicants join m in db.Marks on a.Roll equals m.Roll  
                                where a.HasConsidered == false &&
                                      a.PostName == postQuota.PostName  && 
                                      (a.Ffq=="Child of Freedom Fighter" || a.Ffq=="Grand Child of Freedom Fighter") 
                                orderby m.Total descending
                                select a).FirstOrDefault();
                var post = db.Posts.Where(d=>d.PostName == postQuota.PostName).Single();
                if(applicant == null){
                    postQuota.ApplicantTransferredToGeneral++;
                    post.GeneralQuantity++;
                    db.SaveChanges();
                }
                else
                { //applicant found --->
                    applicant.HasConsidered = true;
                    db.SaveChanges();

                    //check his division quota
                    var district = db.Districts.Where(d=>d.Name == applicant.PermanentDistrict).First();
                    var divisionQuota = db.DivisionQuota.Where(q=>q.DivisionName == district.Division).Single();
                    if(divisionQuota.RoundedQuantity > divisionQuota.FoundQuantity){
                        var districtQuota = db.DistrictQuota.Where(d=>d.DistrictName == applicant.PermanentDistrict).First();
                        if(districtQuota.RoundedQuantity > districtQuota.FoundQuantity){
                            divisionQuota.FoundQuantity++;
                            districtQuota.FoundQuantity++;
                            applicant.IsSelected = true;
                            applicant.SelectionRank = db.Applicants.Max(d=>d.SelectionRank) + 1;
                            
                            postQuota.ApplicantFound++;
                            post.QuotaFoundQuantity++;
                            db.SaveChanges();
                            Console.WriteLine($"Selected ff from div-{divisionQuota.DivisionName}, dist-{districtQuota.DistrictName}");
                        }
                        // else{
                        //     selectFreedomFighters(db);
                        // }
                    }
                    // else{
                    //     selectFreedomFighters(db);
                    // }
                     selectFreedomFighters(db);
                } //<--- applicant found
            }//<---- postQuota found
        }
        #endregion

        static void typewritter(string str, int sleep = 100)
        {
            char[] chars = str.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                Console.Write(chars[i]);
                Thread.Sleep(sleep);
            }
        }
    }

}

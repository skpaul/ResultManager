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
using System.Collections.Generic;

namespace ResultManager
{
    class Program
    {
        static void Main(string[] args)
        {
         
           

            var db = new result_managerContext();
            
            try
            {
                // resetApplicantTable(db); //ok
                resetPostTable(db); //ok
                 preparePosts(db);
                
                truncatePostDistribution(db); //OK
                preparePostDistribution(db); //OK

                truncateDistrictQuota(db); //OK
                truncateDivisionDistribution(db); //OK 
                prepareDivisionDistribution(db); //OK
              

                // truncatePostQuotaDivision(db);
                // preparePostQuotaDivision(db);

                // preparePostQuotaDivisionDistrict(db);
                // prepareMarks(db);

                // selectFreedomFighters(db);
                // selectAnsarVDP(db);
                // selectHandicapped(db);
                // selectGeneral(db);
                
               
                typewritter("Press any key to exit...", 50);
                Console.ReadLine();
            }
            catch (System.Exception exp)
            {
                Console.WriteLine($"Message- {exp.Message}");
                Console.WriteLine($"Message- {exp.InnerException.Message}");
                Console.WriteLine(exp.StackTrace);
            }
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
        }

        //This method breakdowns vacancies into totalQuotaPercentage and totalQuotaQuantity.
        static void preparePosts(result_managerContext db){
           
            var quotaTotal = db.Quotas.Sum(s=>s.Percentage);
           
            var posts = db.Posts.Where(d=>d.IsEligibleForQuota == true).OrderBy(o=>o.PostName).ToList();
            foreach (var post in posts)
            {
               
                post.TotalQuotaPercentage = quotaTotal;
                double d = (double)quotaTotal/100;
                double v = (double) d* post.Vacancies;
                double quantity = v;
                post.MaximumQuotaQuantity =(int) Math.Round(v);
                post.GeneralQuantity  = post.Vacancies - (int) post.MaximumQuotaQuantity;
                db.SaveChanges();
            }
            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine();
            
        }

        #region Post quota
         static void truncatePostDistribution(result_managerContext db){
            Console.WriteLine(); 
            Console.ForegroundColor = ConsoleColor.Red;
            typewritter("TRUNCATING post_distribution ...");
            Thread.Sleep(1000);
            var commandText = "TRUNCATE TABLE post_distribution";
            db.Database.ExecuteSqlRaw(commandText);
          
        }

        static void preparePostDistribution(result_managerContext db){
            typewritter("Preparing post_distribution ...",20);
            
            var quotas = db.Quotas.OrderBy(o=>o.Priority).ToList();
            var quotaCount = quotas.Count();
            var posts = db.Posts.Where(k=>k.IsEligibleForQuota == true).ToList();

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
                        PostId = post.PostId, PostName = post.PostName,
                        Vacancies = post.Vacancies,
                        QuotaName = quota.Name, QuotaPercentage = quota.Percentage,
                        DecimalQuantity = decimalQuantity, RoundedQuantity = rounded,
                        ApplicantFound = 0, ApplicantTransferredToGeneral = 0, SearchCount = 0
                    };

                db.PostDistribution.Add(postDist);
                    db.SaveChanges();
                }
            }

            typewritter("Post Quota Distribution done.",20);
            Console.WriteLine();

        }
        #endregion

        //OK
        #region Division Quoa
        //Ok
        static void truncateDivisionDistribution(result_managerContext db)
        {
            var commandText = "TRUNCATE TABLE division_distribution";
            db.Database.ExecuteSqlRaw(commandText);
        }

        //OK
        static void prepareDivisionDistribution(result_managerContext db){
            var totalVacancies = db.Posts.Sum(k=>k.Vacancies);
            int totalDistribution = 0;
            List<DivisionDistribution> divisionDistributions = new List<DivisionDistribution>();

            var divisions = db.Divisions.OrderByDescending(k=>k.Percentage).ToList();
            var totalDivisions = divisions.Count();
          
            foreach (var division in divisions)
            {
                double decimalQuantity = ((double)division.Percentage / 100) * totalVacancies;
                double fraction = decimalQuantity - Math.Truncate(decimalQuantity);

                int rounded = 0;
                if (fraction > 0.5)
                { 
                    rounded = (int)Math.Ceiling(decimalQuantity);
                    if(totalDistribution + rounded <= totalVacancies)
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
                    if(totalDistribution + rounded <= totalVacancies)
                    {
                        totalDistribution+= rounded;
                    }
                    else{
                        rounded = totalVacancies - totalDistribution;
                        totalDistribution+= rounded;
                    }
                }

                 DivisionDistribution dist = new DivisionDistribution(){
                            DivisionId = division.DivisionId,
                            DivisionName = division.DivisionName,
                            Percentage = division.Percentage,
                            DecimalQuantity = decimalQuantity,
                            RoundedQuantity = rounded,
                            FoundQuantity = 0, NotFoundQuantity = 0,
                            TotalVacancy = totalVacancies
                        };
                        // divisionDistributions.Add(dist);
                        db.DivisionDistribution.Add(dist);
                        db.SaveChanges();
                prepareDistrictDistribution(totalVacancies, dist, db);
            }
        }
        
        #endregion

        //OK
        #region District Quoa
        //OK
        static void truncateDistrictQuota(result_managerContext db)
        {
            var commandText = "TRUNCATE TABLE district_distribution";
            db.Database.ExecuteSqlRaw(commandText);
        }

        //OK
        static void prepareDistrictDistribution(int totalPostsQuantity, DivisionDistribution divisionDist, result_managerContext db){
           
            int totalDistribution = 0;
            var districts = db.Districts.Where(m=>m.DivisionName == divisionDist.DivisionName).OrderByDescending(k=>k.Percentage).ToList();
            foreach (var district in districts)
            {
                double decimalQuantity = ((double)district.Percentage / 100) * totalPostsQuantity;
                double fraction = decimalQuantity - Math.Truncate(decimalQuantity);

                int rounded = 0;
                if (fraction > 0.5)
                { 
                    rounded = (int)Math.Ceiling(decimalQuantity);
                    if(totalDistribution + rounded <= divisionDist.RoundedQuantity)
                    {
                       totalDistribution += rounded;
                    }
                    else{
                        rounded = (int)Math.Floor(decimalQuantity);
                        if (totalDistribution + rounded <= divisionDist.RoundedQuantity)
                        {
                            totalDistribution += rounded;
                        }
                        else
                        {
                            rounded = divisionDist.RoundedQuantity - totalDistribution;
                            totalDistribution += rounded;
                        }
                    }

                } //fraction > 0.5
                else
                {
                    rounded = (int)Math.Floor(decimalQuantity);
                    if (rounded > 0)
                    {
                        if (totalDistribution + rounded <= divisionDist.RoundedQuantity)
                        {
                            totalDistribution += rounded;
                        }
                        else
                        {
                            rounded = divisionDist.RoundedQuantity - totalDistribution;
                            totalDistribution += rounded;
                        }
                    }

                }


                DistrictDistribution dist = new DistrictDistribution(){
                    TotalVacancy = totalPostsQuantity,
                    DivisionId = divisionDist.DivisionId, DivisionName = divisionDist.DivisionName,
                    DivisionTotal = divisionDist.RoundedQuantity,
                    DistrictId = district.DistrictId, DistrictName = district.DistrictName,
                    Percentage = district.Percentage,
                    DecimalQuantity = decimalQuantity, RoundedQuantity = rounded,
                    FoundQuantity = 0, NotFoundQuantity = 0
                };
                
                db.DistrictDistribution.Add(dist);
                db.SaveChanges();
            }

            if(totalDistribution < divisionDist.RoundedQuantity){
                int remains = divisionDist.RoundedQuantity - totalDistribution;
                var x = db.DistrictDistribution.Where(m=>m.RoundedQuantity == 0 && m.DivisionId == divisionDist.DivisionId).FirstOrDefault();
                if(x !=null){
                    x.RoundedQuantity = remains;
                    db.SaveChanges();
                }
            }
        }
        
        
        #endregion


        #region Post Quota Division
        static void truncatePostQuotaDivision(result_managerContext db)
        {
            var commandText = "TRUNCATE TABLE post_quota_division";
            db.Database.ExecuteSqlRaw(commandText);
            // writeLine("post_quota_division has been truncated.", ConsoleColor.Black, ConsoleColor.Blue);
        }

        // static void preparePostQuotaDivision(result_managerContext db){
        //     var divisions = db.Divisions.OrderByDescending(d=>d.Percentage).ToList();
        //     var postQuotas = db.PostQuota.OrderBy(k=>k.PostName).ThenBy(t=>t.QuotaName).ToList();
        //     foreach (var postQuota in postQuotas)
        //     {
        //         var decimalQuantity = postQuota.DecimalQuantity;
        //         foreach (var division in divisions)
        //         {
        //             var percentage = division.Percentage;
        //             var d = (double) percentage/100;
        //             var q = (double) d*decimalQuantity;
        //             var newPostQuotaDivision = new PostQuotaDivision();
        //             newPostQuotaDivision.PostName = postQuota.PostName;
        //             newPostQuotaDivision.QuotaName = postQuota.QuotaName;
        //             newPostQuotaDivision.DivisionName = division.Name;
        //             newPostQuotaDivision.DecimalQuantity = q;
        //             db.PostQuotaDivision.Add(newPostQuotaDivision);
        //             db.SaveChanges();
        //         }
        //     }
        // }

        // static void preparePostQuotaDivisionDistrict(result_managerContext db){

        //     var commandText = "TRUNCATE TABLE post_quota_division_district";
        //     db.Database.ExecuteSqlRaw(commandText);
        //     writeLine("post_quota_division_district has been truncated.", ConsoleColor.Black, ConsoleColor.Blue);

            
        //     var postQuotaDivisions = db.PostQuotaDivision.OrderBy(k=>k.PostName).ThenBy(t=>t.QuotaName).ThenBy(k=>k.DivisionName).ToList();
        //     foreach (var postQuotaDivision in postQuotaDivisions)
        //     {
        //         var districts = db.Districts.Where(d=>d.Division == postQuotaDivision.DivisionName).OrderByDescending(k=>k.Percentage).ToList();

        //         var decimalQuantity = postQuotaDivision.DecimalQuantity;
        //         foreach (var district in districts)
        //         {
        //             var percentage = district.Percentage;
        //             var d = (double) percentage/100;
        //             var q = (double) d*decimalQuantity;
        //             var newPostQuotaDivisionDistrict = new PostQuotaDivisionDistrict()
        //             {
        //                 PostName = postQuotaDivision.PostName,
        //                 QuotaName = postQuotaDivision.QuotaName,
        //                 DivisionName = postQuotaDivision.DivisionName,
        //                 DistrictName = district.Name,
        //                 DecimalQuantity = q
        //             };
        //             db.PostQuotaDivisionDistrict.Add(newPostQuotaDivisionDistrict);
        //         }

        //         db.SaveChanges();
        //     }
        // }

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
        // static void selectFreedomFighters(result_managerContext db){

        //     Console.ForegroundColor= ConsoleColor.Blue;
        //     typewritter("Searching Freedom Fighter  ",10);
        //     Console.ForegroundColor = ConsoleColor.White;
        //     typewritter(".......",200);
           
        //     Console.WriteLine();

        //     //get posts and quota names from post_quota where decimal quantity greater than applicantFound+applicantNotFound
        //     var postQuota = (from c in db.PostQuota 
        //                      where c.RoundedQuantity > (c.ApplicantFound + c.ApplicantTransferredToGeneral) && 
        //                            c.QuotaName=="Freedom Fighter" 
        //                      orderby c.Id 
        //                      select c).FirstOrDefault();
        //     if(postQuota == null){
        //         Console.ForegroundColor = ConsoleColor.White;
        //         typewritter("\tNot applicable",50);
        //         Console.WriteLine();
        //     }
        //     else
        //     { //postQuota found ---->
        //         Console.ForegroundColor = ConsoleColor.Magenta;
        //         typewritter($"\t{postQuota.PostName}-",50);

        //         Console.ForegroundColor = ConsoleColor.White;
        //         typewritter(" Required quantity",50);
        //         Console.WriteLine();
        //         Console.ForegroundColor = ConsoleColor.Cyan;
        //         typewritter($" {postQuota.RoundedQuantity - (postQuota.ApplicantFound+postQuota.ApplicantTransferredToGeneral)}",250);
        //         Console.WriteLine();

        //         postQuota.SearchCount++;
        //         db.SaveChanges();

        //         var applicant =(from a in db.Applicants join m in db.Marks on a.Roll equals m.Roll  
        //                         where a.HasConsidered == false &&
        //                               a.PostName == postQuota.PostName  && 
        //                               (a.Ffq=="Child of Freedom Fighter" || a.Ffq=="Grand Child of Freedom Fighter") 
        //                         orderby m.Total descending
        //                         select a).FirstOrDefault();
        //         var post = db.Posts.Where(d=>d.PostName == postQuota.PostName).Single();
        //         if(applicant == null){
        //             postQuota.ApplicantTransferredToGeneral++;
        //             post.GeneralQuantity++;
        //             db.SaveChanges();

        //             Console.ForegroundColor= ConsoleColor.Red;
        //             typewritter("\tNot found. Transferred to general quota",10);
        //             Console.WriteLine();
        //             Thread.Sleep(500);
        //         }
        //         else
        //         { //applicant found --->
        //             applicant.HasConsidered = true;
        //             db.SaveChanges();

        //             //check his division quota
        //             var district = db.Districts.Where(d=>d.Name == applicant.PermanentDistrict).First();
        //             var divisionQuota = db.DivisionQuota.Where(q=>q.DivisionName == district.Division).Single();
        //             if(divisionQuota.RoundedQuantity > divisionQuota.FoundQuantity){
        //                 var districtQuota = db.DistrictQuota.Where(d=>d.DistrictName == applicant.PermanentDistrict).First();
        //                 if(districtQuota.RoundedQuantity > districtQuota.FoundQuantity){
        //                     divisionQuota.FoundQuantity++;
        //                     districtQuota.FoundQuantity++;
        //                     applicant.IsSelected = true;
        //                     applicant.SelectionRank = db.Applicants.Max(d=>d.SelectionRank) + 1;
                            
        //                     postQuota.ApplicantFound++;
        //                     post.QuotaFoundQuantity++;
        //                     db.SaveChanges();

        //                     Console.ForegroundColor= ConsoleColor.Green;
        //                     typewritter($"\tSelected for {postQuota.PostName} from",10);
        //                     Console.ForegroundColor= ConsoleColor.White;
        //                     typewritter($" {districtQuota.DistrictName}, {divisionQuota.DivisionName}",100);
        //                     Console.WriteLine();
        //                     Thread.Sleep(500);
        //                 }
        //                 // else{
        //                 //     selectFreedomFighters(db);
        //                 // }
        //             }
        //             // else{
        //             //     selectFreedomFighters(db);
        //             // }
        //              selectFreedomFighters(db);
        //         } //<--- applicant found
        //     }//<---- postQuota found
        // }

        // static void selectAnsarVDP(result_managerContext db){

        //     Console.ForegroundColor= ConsoleColor.Blue;
        //     typewritter("Searching Ansar-VDP  ",10);
        //     Console.ForegroundColor = ConsoleColor.White;
        //     typewritter(".......",200);
        //     Console.WriteLine();

        //     //get posts and quota names from post_quota where decimal quantity greater than applicantFound+applicantNotFound
        //     var postQuota = (from c in db.PostQuota 
        //                      where c.RoundedQuantity > (c.ApplicantFound + c.ApplicantTransferredToGeneral) && 
        //                            c.QuotaName=="Ansar-VDP" 
        //                      orderby c.Id 
        //                      select c).FirstOrDefault();
        //     if(postQuota == null){
        //         Console.ForegroundColor = ConsoleColor.White;
        //         typewritter("\tNot applicable",50);
        //         Console.WriteLine();
        //     }
        //     else
        //     { //postQuota found ---->
        //         Console.ForegroundColor = ConsoleColor.Magenta;
        //         typewritter($"\t{postQuota.PostName}-",250);

        //         Console.ForegroundColor = ConsoleColor.White;
        //         typewritter(" Required quantity",50);
        //         Console.WriteLine();
        //         Console.ForegroundColor = ConsoleColor.Cyan;
        //         typewritter($" {postQuota.RoundedQuantity - (postQuota.ApplicantFound+postQuota.ApplicantTransferredToGeneral)}",250);
        //         Console.WriteLine();

        //         postQuota.SearchCount++;
        //         db.SaveChanges();

        //         var applicant =(from a in db.Applicants join m in db.Marks on a.Roll equals m.Roll  
        //                         where a.HasConsidered == false &&
        //                               a.PostName == postQuota.PostName  && 
        //                               (a.Ffq=="Ansar-VDP") 
        //                         orderby m.Total descending
        //                         select a).FirstOrDefault();
        //         var post = db.Posts.Where(d=>d.PostName == postQuota.PostName).Single();
        //         if(applicant == null){
        //             postQuota.ApplicantTransferredToGeneral++;
        //             post.GeneralQuantity++;
        //             db.SaveChanges();

        //             Console.ForegroundColor= ConsoleColor.Red;
        //             typewritter("\tNot found. Transferred to general quota",10);
        //             Console.WriteLine();
        //             Thread.Sleep(500);
        //         }
        //         else
        //         { //applicant found --->
        //             applicant.HasConsidered = true;
        //             db.SaveChanges();

        //             //check his division quota
        //             var district = db.Districts.Where(d=>d.Name == applicant.PermanentDistrict).First();
        //             var divisionQuota = db.DivisionQuota.Where(q=>q.DivisionName == district.Division).Single();
        //             if(divisionQuota.RoundedQuantity > divisionQuota.FoundQuantity){
        //                 var districtQuota = db.DistrictQuota.Where(d=>d.DistrictName == applicant.PermanentDistrict).First();
        //                 if(districtQuota.RoundedQuantity > districtQuota.FoundQuantity){
        //                     divisionQuota.FoundQuantity++;
        //                     districtQuota.FoundQuantity++;
        //                     applicant.IsSelected = true;
        //                     applicant.SelectionRank = db.Applicants.Max(d=>d.SelectionRank) + 1;
                            
        //                     postQuota.ApplicantFound++;
        //                     post.QuotaFoundQuantity++;
        //                     db.SaveChanges();

        //                     Console.ForegroundColor= ConsoleColor.Green;
        //                     typewritter($"\tSelected for {postQuota.PostName} from ",10);
        //                     Console.ForegroundColor= ConsoleColor.White;
        //                     typewritter($" {districtQuota.DistrictName}, {divisionQuota.DivisionName}",100);
        //                     Console.WriteLine();
        //                     Thread.Sleep(500);
        //                 }
        //                 // else{
        //                 //     selectFreedomFighters(db);
        //                 // }
        //             }
        //             // else{
        //             //     selectFreedomFighters(db);
        //             // }
        //              selectAnsarVDP(db);
        //         } //<--- applicant found
        //     }//<---- postQuota found
        // }

        // static void selectHandicapped(result_managerContext db){

        //     Console.ForegroundColor= ConsoleColor.Blue;
        //     typewritter("Searching Physically Handicapped  ",10);
        //     Console.ForegroundColor = ConsoleColor.White;
        //     typewritter(".......",200);
        //     Console.WriteLine();

        //     //get posts and quota names from post_quota where decimal quantity greater than applicantFound+applicantNotFound
        //     var postQuota = (from c in db.PostQuota 
        //                      where c.RoundedQuantity > (c.ApplicantFound + c.ApplicantTransferredToGeneral) && 
        //                            c.QuotaName=="Physically Handicapped" 
        //                      orderby c.Id 
        //                      select c).FirstOrDefault();
        //     if(postQuota == null){
        //         Console.ForegroundColor = ConsoleColor.White;
        //         typewritter("\tNot applicable",50);
        //         Console.WriteLine();
        //     }
        //     else
        //     { //postQuota found ---->
        //         Console.ForegroundColor = ConsoleColor.Magenta;
        //         typewritter($"\t{postQuota.PostName}-", 250);

        //         Console.ForegroundColor = ConsoleColor.White;
        //         typewritter(" Required quantity", 50);
        //         Console.WriteLine();
        //         Console.ForegroundColor = ConsoleColor.Cyan;
        //         typewritter($" {postQuota.RoundedQuantity - (postQuota.ApplicantFound+postQuota.ApplicantTransferredToGeneral)}",250);
        //         Console.WriteLine();

        //         postQuota.SearchCount++;
        //         db.SaveChanges();

        //         var applicant =(from a in db.Applicants join m in db.Marks on a.Roll equals m.Roll  
        //                         where a.HasConsidered == false &&
        //                               a.PostName == postQuota.PostName  && 
        //                               (a.Ffq=="Physically Handicapped") 
        //                         orderby m.Total descending
        //                         select a).FirstOrDefault();
        //         var post = db.Posts.Where(d=>d.PostName == postQuota.PostName).Single();
        //         if(applicant == null){
        //             postQuota.ApplicantTransferredToGeneral++;
        //             post.GeneralQuantity++;
        //             db.SaveChanges();

        //             Console.ForegroundColor= ConsoleColor.Red;
        //             typewritter("\tNot found. Transferred to general quota",10);
        //             Console.WriteLine();
        //             Thread.Sleep(500);
        //         }
        //         else
        //         { //applicant found --->
        //             applicant.HasConsidered = true;
        //             db.SaveChanges();

        //             //check his division quota
        //             var district = db.Districts.Where(d=>d.Name == applicant.PermanentDistrict).First();
        //             var divisionQuota = db.DivisionQuota.Where(q=>q.DivisionName == district.Division).Single();
        //             if(divisionQuota.RoundedQuantity > divisionQuota.FoundQuantity){
        //                 var districtQuota = db.DistrictQuota.Where(d=>d.DistrictName == applicant.PermanentDistrict).First();
        //                 if(districtQuota.RoundedQuantity > districtQuota.FoundQuantity){
        //                     divisionQuota.FoundQuantity++;
        //                     districtQuota.FoundQuantity++;
        //                     applicant.IsSelected = true;
        //                     applicant.SelectionRank = db.Applicants.Max(d=>d.SelectionRank) + 1;
                            
        //                     postQuota.ApplicantFound++;
        //                     post.QuotaFoundQuantity++;
        //                     db.SaveChanges();

        //                     Console.ForegroundColor= ConsoleColor.Green;
        //                     typewritter($"\tSelected for {postQuota.PostName} from ",10);
        //                     Console.ForegroundColor= ConsoleColor.White;
        //                     typewritter($" {districtQuota.DistrictName}, {divisionQuota.DivisionName}",100);
        //                     Console.WriteLine();
        //                     Thread.Sleep(500);
        //                 }
        //                 // else{
        //                 //     selectFreedomFighters(db);
        //                 // }
        //             }
        //             // else{
        //             //     selectFreedomFighters(db);
        //             // }
        //              selectHandicapped(db);
        //         } //<--- applicant found
        //     }//<---- postQuota found
        // }

        // static void selectGeneral(result_managerContext db){

        //     Console.ForegroundColor= ConsoleColor.Blue;
        //     typewritter("Searching General candidates  ",10);
        //     Console.ForegroundColor = ConsoleColor.White;
        //     typewritter(".......", 200);
        //     Console.WriteLine();

        //     var post = db.Posts.Where(d=>d.GeneralQuantity > d.GeneralFoundQuantity).FirstOrDefault();
            
        //     //get posts and quota names from post_quota where decimal quantity greater than applicantFound+applicantNotFound
        //     // var postQuota = (from c in db.PostQuota 
        //     //                  where c.RoundedQuantity > (c.ApplicantFound + c.ApplicantTransferredToGeneral) && 
        //     //                        c.QuotaName=="Physically Handicapped" 
        //     //                  orderby c.Id 
        //     //                  select c).FirstOrDefault();
        //     if(post == null){
        //         Console.ForegroundColor = ConsoleColor.White;
        //         typewritter("\tNot applicable",50);
        //         Console.WriteLine();
        //     }
        //     else
        //     { //postQuota found ---->
        //         Console.ForegroundColor = ConsoleColor.Magenta;
        //         typewritter($"\t{post.PostName}-", 250);

        //         Console.ForegroundColor = ConsoleColor.White;
        //         typewritter(" Required quantity", 50);
        //         Console.WriteLine();
        //         Console.ForegroundColor = ConsoleColor.Cyan;
        //         typewritter($" {post.GeneralQuantity - post.GeneralFoundQuantity}",250);
        //         Console.WriteLine();

               
              

        //         var applicant =(from a in db.Applicants join m in db.Marks on a.Roll equals m.Roll  
        //                         where a.HasConsidered == false &&
        //                               a.PostName == post.PostName  && 
        //                               (a.Ffq=="Non Quota") 
        //                         orderby m.Total descending
        //                         select a).FirstOrDefault();
               
        //         if(applicant == null){
        //             Console.ForegroundColor= ConsoleColor.Red;
        //             typewritter("\tNot found.",10);
        //             Console.WriteLine();
        //             Thread.Sleep(500);
        //         }
        //         else
        //         { //applicant found --->
        //             applicant.HasConsidered = true;
        //             db.SaveChanges();

        //             //check his division quota
        //             var district = db.Districts.Where(d=>d.Name == applicant.PermanentDistrict).First();
        //             var divisionQuota = db.DivisionQuota.Where(q=>q.DivisionName == district.Division).Single();
        //             if(divisionQuota.RoundedQuantity > divisionQuota.FoundQuantity){
        //                 var districtQuota = db.DistrictQuota.Where(d=>d.DistrictName == applicant.PermanentDistrict).First();
        //                 if(districtQuota.RoundedQuantity > districtQuota.FoundQuantity){
        //                     divisionQuota.FoundQuantity++;
        //                     districtQuota.FoundQuantity++;
        //                     applicant.IsSelected = true;
        //                     applicant.SelectionRank = db.Applicants.Max(d=>d.SelectionRank) + 1;
        //                     db.SaveChanges();

        //                     Console.ForegroundColor= ConsoleColor.Green;
        //                     typewritter($"\tSelected for {post.PostName} from ",10);
        //                     Console.ForegroundColor= ConsoleColor.White;
        //                     typewritter($" {districtQuota.DistrictName}, {divisionQuota.DivisionName}",100);
        //                     Console.WriteLine();
        //                     Thread.Sleep(500);
        //                 }
        //                 // else{
        //                 //     selectFreedomFighters(db);
        //                 // }
        //             }
        //             // else{
        //             //     selectFreedomFighters(db);
        //             // }
        //              selectGeneral(db);
        //         } //<--- applicant found
        //     }//<---- postQuota found
        // }

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

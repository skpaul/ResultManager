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
    class TempApplicant{
        
        public int ApplicantId { get; set; }
        public string PermanentDistrict { get; set; }
        public int Roll { get; set; }
        public string UserId { get; set; }
        public string PostName { get; set; }
        public double Written { get; set; }
        public double Viva { get; set; }
        public double Total { get; set; }
        
    }
    class Program
    {
        static void Main(string[] args)
        {



            var db = new result_managerContext();

            try
            {
                resetApplicantTable(db); //ok
                resetPostTable(db); //ok
                preparePosts(db);

                truncatePostDistribution(db); //OK
                preparePostDistribution(db); //OK

                DistrictDistributionProcessor.TruncateTable(db); 
                DivisionDistributionProcessor.TruncateTable(db); //OK

                DivisionDistributionProcessor divProcessor = new DivisionDistributionProcessor(db);
                divProcessor.Prepare();
                


                // truncatePostQuotaDivision(db);
                // preparePostQuotaDivision(db);

                // preparePostQuotaDivisionDistrict(db);
                //prepareMarks(db);

                // selectFreedomFighters(db);
                // selectAnsarVDP(db);
                // selectHandicapped(db);
                // selectGeneral(db);

                // var commandText = "TRUNCATE TABLE selected_applicants";
                // db.Database.ExecuteSqlRaw(commandText);
                // selectGeneralApplicants(db);
                // selectQuotaApplicants(db);
                // typewritter("Press any key to exit...", 50);
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
        static void resetApplicantTable(result_managerContext db)
        {
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

        #region posts
        //reset posts table
        static void resetPostTable(result_managerContext db)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            typewritter("Resetting post table...");
            Thread.Sleep(300);
            var commandText = "update posts set totalQuotaPercentage=0, maximumQuotaQuantity=0, quotaFoundQuantity=0, generalQuantity=0, generalFoundQuantity=0";
            db.Database.ExecuteSqlRaw(commandText);
        }



        //This method breakdowns vacancies into totalQuotaPercentage and totalQuotaQuantity.
        static void preparePosts(result_managerContext db)
        {

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

        #endregion

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

    
        //OK


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

        //OK
        #region Temporary
        static void prepareMarks(result_managerContext db)
        {

            Console.WriteLine("Preparing marks ....");
            var commandText = "TRUNCATE TABLE marks";
            db.Database.ExecuteSqlRaw(commandText);
            var applicants = db.Applicants.ToList();
            foreach (var applicant in applicants)
            {
                int written = new Random().Next(1,100);
                int viva = new Random().Next(1, 100);
                int total = written + viva;
                var mark = new Marks()
                {
                    Roll = applicant.Roll,
                    Written = written,
                    Viva = viva,
                    Total = total
                    
                };

                db.Marks.Add(mark);
            }

            db.SaveChanges();

            Console.WriteLine("Marks input completed");
        }
        #endregion

        #region applicant selection

        static void selectGeneralApplicants(result_managerContext db)
        {
            var posts = db.Posts.Where(k=>k.GeneralFoundQuantity < k.GeneralQuantity).OrderBy(d => d.PostId).ToList();
            var districtDistributions = db.DistrictDistribution.ToList();
            var divisionDistributions = db.DivisionDistribution.ToList();

            foreach (var post in posts)
            {
               var applicants = (from a in db.Applicants
                                      join m in db.Marks on a.Roll equals m.Roll
                                      where a.PostName == post.PostName
                                      orderby m.Total descending
                                      select new{
                                          a.ApplicantId, a.PermanentDistrict, a.Roll, a.UserId, a.PostName, m.Written, m.Viva, m.Total
                                      }).ToList();
                    int selectionCount = 0;
                    foreach (var applicant in applicants)
                    {
                        //Get district distribution 
                        var district = districtDistributions.Where(m => m.DistrictName == applicant.PermanentDistrict).First();
                        if (district.FoundQuantity < district.RoundedQuantity)
                        {
                            //Get division distribution
                            var division = divisionDistributions.Where(m => m.DivisionId == district.DivisionId).First();
                            //check whether division quota is available
                            if (division.FoundQuantity < division.RoundedQuantity)
                            {
                                //division quota is ok
                                if (selectionCount < post.GeneralQuantity)
                                {
                                    var selectedApplicant = new SelectedApplicants();
                                    selectedApplicant.ApplicantId = applicant.ApplicantId;
                                    selectedApplicant.Roll = applicant.Roll;
                                    selectedApplicant.UserId = applicant.UserId;
                                    selectedApplicant.PostName = applicant.PostName;
                                    selectedApplicant.SelectionRank = ++selectionCount;
                                    selectedApplicant.SelectionCriteria = "General";
                                    selectedApplicant.PermanentDivision = division.DivisionName;
                                    selectedApplicant.PermanentDistrict = district.DistrictName;
                                    selectedApplicant.Written = applicant.Written;
                                    selectedApplicant.Viva = applicant.Viva;
                                    selectedApplicant.Total = applicant.Total;
                                    division.FoundQuantity++;
                                    district.FoundQuantity++;
                                    post.GeneralFoundQuantity++;
                                    db.SelectedApplicants.Add(selectedApplicant);
                                    db.SaveChanges();
                                }
                            }//division quota check
                        } //district quota check
                    }
            }
            db.SaveChanges();
        }


        static void selectQuotaApplicants(result_managerContext db)
        {
            var districtDistributions = db.DistrictDistribution.ToList();
            var divisionDistributions = db.DivisionDistribution.ToList();
            var quotas = db.Quotas.OrderBy(d => d.Priority).ToList();
            var selectedApplicants = db.SelectedApplicants.ToList();
            List<PostDistribution> posts = new List<PostDistribution>();
            foreach (var quota in quotas)
            {
                posts = (from c in db.PostDistribution
                         where c.RoundedQuantity > (c.ApplicantFound + c.ApplicantTransferredToGeneral) &&
                               c.QuotaName == quota.Name
                         orderby c.Id
                         select c).ToList();

                foreach (var post in posts)
                {
                    List<TempApplicant> applicants = new List<TempApplicant>();
                    if (quota.Name == "Freedom Fighter")
                    {
                        applicants = db.Applicants.Where(d=>d.PostName==post.PostName && (d.Ffq=="Child of Freedom Fighter" || d.Ffq=="Grand Child of Freedom Fighter")).Join(db.Marks,applicant=>applicant.Roll, mark=>mark.Roll,(applicant,mark)=> new TempApplicant{ApplicantId=applicant.ApplicantId, Roll=applicant.Roll,PermanentDistrict=applicant.PermanentDistrict,PostName=applicant.PostName,Total=mark.Total,Viva=mark.Viva,Written=mark.Written,UserId=applicant.UserId}).OrderByDescending(d=>d.Total).ToList();
                        //  applicants = (from a in db.Applicants
                        //                   join m in db.Marks on a.Roll equals m.Roll
                        //                   where a.PostName == post.PostName &&
                        //                       (a.Ffq == "Child of Freedom Fighter" || a.Ffq == "Grand Child of Freedom Fighter")
                        //                   orderby m.Total descending
                        //                   select new TempApplicant()
                        //                   {
                        //                       a.ApplicantId,
                        //                     //   a.PermanentDistrict,
                        //                     //   a.Roll,
                        //                     //   a.UserId,
                        //                     //   a.PostName,
                        //                     //   m.Written,
                        //                     //   m.Viva,
                        //                     //   m.Total
                        //                   }
                        //                 ).ToList();
                    }
                    else
                    {
                         applicants = db.Applicants.Where(d=>d.PostName==post.PostName && d.Ffq== quota.Name).Join(db.Marks,applicant=>applicant.Roll, mark=>mark.Roll,(applicant,mark)=> new TempApplicant{ApplicantId=applicant.ApplicantId, Roll=applicant.Roll,PermanentDistrict=applicant.PermanentDistrict,PostName=applicant.PostName,Total=mark.Total,Viva=mark.Viva,Written=mark.Written,UserId=applicant.UserId}).OrderByDescending(d=>d.Total).ToList();

                        //  applicants = (from a in db.Applicants
                        //                   join m in db.Marks on a.Roll equals m.Roll
                        //                   where a.PostName == post.PostName &&
                        //                         a.Ffq == quota.Name
                        //                   orderby m.Total descending
                        //                   select new
                        //                   {
                        //                       a.ApplicantId,
                        //                       a.PermanentDistrict,
                        //                       a.Roll,
                        //                       a.UserId,
                        //                       a.PostName,
                        //                       m.Written,
                        //                       m.Viva,
                        //                       m.Total
                        //                   }
                        //                   ).ToList();
                    }

                    int selectionCount = 0;
                    foreach (var applicant in applicants)
                    {
                        //Get district distribution 
                        var district = districtDistributions.Where(m => m.DistrictName == applicant.PermanentDistrict).First();
                        if (district.FoundQuantity < district.RoundedQuantity)
                        {
                            //Get division distribution
                            var division = divisionDistributions.Where(m => m.DivisionId == district.DivisionId).First();
                            //check whether division quota is available
                            if (division.FoundQuantity < division.RoundedQuantity)
                            {
                                //division quota is ok
                                if (selectionCount < post.RoundedQuantity)
                                {
                                    var selectedApplicant = new SelectedApplicants();
                                    selectedApplicant.ApplicantId = applicant.ApplicantId;
                                    selectedApplicant.Roll = applicant.Roll;
                                    selectedApplicant.UserId = applicant.UserId;
                                    selectedApplicant.PostName = applicant.PostName;
                                    selectedApplicant.SelectionRank = ++selectionCount;
                                    selectedApplicant.SelectionCriteria = quota.Name;
                                    selectedApplicant.PermanentDivision = division.DivisionName;
                                    selectedApplicant.PermanentDistrict = district.DistrictName;
                                    selectedApplicant.Written = applicant.Written;
                                    selectedApplicant.Viva = applicant.Viva;
                                    selectedApplicant.Total = applicant.Total;
                                    division.FoundQuantity++;
                                    district.FoundQuantity++;
                                    post.ApplicantFound++;
                                    db.SelectedApplicants.Add(selectedApplicant);
                                    db.SaveChanges();
                                }
                            }//division quota check
                        } //district quota check
                    }
                }

            }


            // var posts = db.Posts.Where(k=>k.GeneralFoundQuantity < k.GeneralQuantity).OrderBy(d => d.PostId).ToList();



            db.SaveChanges();
        }
      
        // static void selectFreedomFighters(result_managerContext db)
        // {
        //     Console.ForegroundColor = ConsoleColor.Blue;
        //     typewritter("Searching Freedom Fighter  ", 10);
        //     Console.ForegroundColor = ConsoleColor.White;
        //     typewritter(".......", 200);

        //     Console.WriteLine();

        //     //get posts and quota names from post_quota where decimal quantity greater than applicantFound+applicantNotFound
        //     var postDistribution = (from c in db.PostDistribution
        //                             where c.RoundedQuantity > (c.ApplicantFound + c.ApplicantTransferredToGeneral) &&
        //                                   c.QuotaName == "Freedom Fighter"
        //                             orderby c.Id
        //                             select c).FirstOrDefault();
        //     if (postDistribution == null)
        //     {
        //         Console.ForegroundColor = ConsoleColor.White;
        //         typewritter("\tNot applicable", 50);
        //         Console.WriteLine();
        //     }
        //     else
        //     { //postDistribution found ---->
        //         Console.ForegroundColor = ConsoleColor.Magenta;
        //         typewritter($"\t{ postDistribution.PostName }-", 50);

        //         Console.ForegroundColor = ConsoleColor.White;
        //         typewritter($" Required quantity {postDistribution.RoundedQuantity}", 50);
        //         Console.WriteLine();

        //         postDistribution.SearchCount++;
        //         db.SaveChanges();

        //         var applicant = (from a in db.Applicants
        //                          join m in db.Marks on a.Roll equals m.Roll
        //                          where a.HasConsidered == false &&
        //                                a.PostName == postDistribution.PostName &&
        //                                (a.Ffq == "Child of Freedom Fighter" || a.Ffq == "Grand Child of Freedom Fighter")
        //                          orderby m.Total descending
        //                          select a).FirstOrDefault();

        //         var post = db.Posts.Where(d => d.PostName == postDistribution.PostName).Single();
        //         if (applicant == null)
        //         {
        //             postDistribution.ApplicantTransferredToGeneral++;
        //             post.GeneralQuantity++;
        //             db.SaveChanges();

        //             Console.ForegroundColor = ConsoleColor.Red;
        //             typewritter("\tNot found. Transferred to general quota", 10);
        //             Console.WriteLine();
        //             Thread.Sleep(500);
        //         }
        //         else
        //         { //applicant found --->
        //             applicant.HasConsidered = true;
        //             db.SaveChanges();

        //             //check his division quota
        //             var district = db.Districts.Where(d => d.DistrictName == applicant.PermanentDistrict).First();
        //             var divisionQuota = db.DivisionDistribution.Where(q => q.DivisionName == district.DivisionName).Single();
        //             if (divisionQuota.RoundedQuantity > divisionQuota.FoundQuantity)
        //             {
        //                 var districtQuota = db.DistrictDistribution.Where(d => d.DistrictName == applicant.PermanentDistrict).First();
        //                 if (districtQuota.RoundedQuantity > districtQuota.FoundQuantity)
        //                 {
        //                     divisionQuota.FoundQuantity++;
        //                     districtQuota.FoundQuantity++;
        //                     applicant.IsSelected = true;
        //                     applicant.SelectionRank = db.Applicants.Max(d => d.SelectionRank) + 1;

        //                     postDistribution.ApplicantFound++;
        //                     post.QuotaFoundQuantity++;
        //                     db.SaveChanges();

        //                     Console.ForegroundColor = ConsoleColor.Green;
        //                     typewritter($"\tSelected for {postDistribution.PostName} from", 10);
        //                     Console.ForegroundColor = ConsoleColor.White;
        //                     typewritter($" {districtQuota.DistrictName}, {divisionQuota.DivisionName}", 100);
        //                     Console.WriteLine();
        //                     Thread.Sleep(500);
        //                 }
        //             }
        //             selectFreedomFighters(db);
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

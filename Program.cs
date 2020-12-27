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

namespace ResultManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==================================");
            Console.WriteLine("DIA Data Mining Tool");
            Console.WriteLine("==================================\n");
            Console.WriteLine("Press any key to continue ...");

           // Console.ReadLine();

            var db = new result_managerContext();
            calculatePost(db);
            pickDistQuota(db);
            Console.WriteLine("success");
            Console.ReadLine();
        }

        static void calculatePost(result_managerContext db){
            Console.WriteLine("Calculating posts ...");
            System.Threading.Thread.Sleep(500);

            var posts = db.Posts.ToList();
            foreach (var post in posts)
            {
                Console.WriteLine("Current post- " + post.PostName);
                System.Threading.Thread.Sleep(500);

                int postId = post.PostId;

                int vacancies = post.Vacancies;
                int distPercentage =  post.DistrictQuota;
                 int distQuantity = 0;
                if(distPercentage>0){
                    float d = ((float) distPercentage/100)*vacancies;
                    distQuantity = (int) Math.Floor(d);
                }

                int femalePercentage = post.FemaleQuota;
                int femaleQuantity = 0;
                if(femalePercentage > 0){
                    femaleQuantity =  (femalePercentage/100)*vacancies;
                }

                int freedomFighterPercentage = post.FreedomFighterQuota;
                int freedomFighterQuantity = 0;
                if(freedomFighterPercentage>0){
                    freedomFighterQuantity = (freedomFighterPercentage/100)*vacancies;
                }

                int tribalPercentage = post.TribalQuota;
                int tribalQuantity = 0;
                if(tribalPercentage>0){
                    tribalQuantity = (tribalPercentage/100)*vacancies;
                }

                int generalQuota = vacancies - (distQuantity+femaleQuantity+freedomFighterQuantity+tribalQuantity);

                var postCalculation = new PostCalculation();
                postCalculation.PostId = post.PostId;
                postCalculation.DistQuantity = distQuantity;
                postCalculation.FemaleQuantity = femaleQuantity;
                postCalculation.FreedomFighterQuantity = freedomFighterQuantity;
                postCalculation.TribalQuantity = tribalQuantity;
                postCalculation.GeneralQuota = generalQuota;

               db.PostCalculation.Add(postCalculation);
               db.SaveChanges();

            }
          
          Console.WriteLine("Post calculation completed.");
        }

        static void pickDistQuota(result_managerContext db){
            Console.WriteLine("Picking district quota ...");
            System.Threading.Thread.Sleep(500);

            var post = (from p in db.PostCalculation where p.DistQuantity> (p.DistFound + p.DistTransferred) select new {p.Id, p.PostId}).FirstOrDefault();
            if(post == null){
                //Do nothing.
                Console.WriteLine("...");
                System.Threading.Thread.Sleep(500);
            }
            else{
                /*
                    select 1 candidate who 
                        - applied for this post
                        - claimed district quota
                        - isSelected flag is false
                        - has highest marks in written and viva

                    if applicant found:
                        - set isSelected = true.
                        - distFound++
                    
                    if applicant not found:
                        - distTransferred++
                        - generalQuota
                */
                
                //more posts might be there. 
                pickDistQuota(db); //call recursively
            }
        }
    }
}

//dotnet add package Microsoft.EntityFrameworkCore -v 3.1.10
//dotnet add package Microsoft.EntityFrameworkCore.Tools -v 3.1.10
//dotnet add package MySql.Data -v 8.0.22
//dotnet add package MySql.Data.EntityFrameworkCore -v 8.0.22
//dotnet tool install --global dotnet-ef

//dotnet ef dbcontext scaffold "server=localhost;userid=root;password=;database=result_manager;" MySql.Data.EntityFrameworkCore -o Models


using System;
using ResultManager.Models;
using System.Linq;

namespace ResultManager
{
    class Program
    {
        static void Main(string[] args)
        {

            var db = new result_managerContext();

            var posts = db.Posts.ToList();
            foreach (var post in posts)
            {
                Console.WriteLine(post.PostName);

                int postId = post.PostId;

                int vacancies = post.Vacancies;
                int distPercentage =  post.DistrictQuota;
                 int distQuantity = 0;
                if(distPercentage>0){
                    distQuantity = (distPercentage/100)*vacancies;
                   
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

               db.PostCalculation.Add(postCalculation);
               db.SaveChanges();

            }
          
            Console.ReadLine();
        }
    }
}

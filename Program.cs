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
            double f = 10.51;
            var r = Math.Round(f);
            Console.WriteLine(r);

            var db = new result_managerContext();
            
            try
            {
                
            }
            catch (System.Exception exp)
            {
                
                Console.WriteLine(exp.InnerException.Message);
            }
              //Mymensingh


        //     calculatePost(db);
        //     pickDistQuota(db);
        //     Console.WriteLine("success");
        //     Console.ReadLine();
        }
    }
}

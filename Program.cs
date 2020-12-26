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

            var test = (from c in db.Posts select c).FirstOrDefault();

            Console.WriteLine(test.PostName);
        }
    }
}

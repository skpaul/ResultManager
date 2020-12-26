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

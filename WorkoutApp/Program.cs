using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new WorkoutDB())
            {
                // Create and save a new Blog
                Console.Write("Enter a name for a new User: ");
                var name = Console.ReadLine();   
                Console.Write("Enter a email for a new User: ");
                var email = Console.ReadLine();

                var user = new User(name, email);
                db.Users.Add(user);
                db.SaveChanges();

                // Display all Users from the database
                var query = from b in db.Users
                            select b;

                Console.WriteLine("All users in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine($"{item.UserName}, {item.Email}");
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
            }
    }
}

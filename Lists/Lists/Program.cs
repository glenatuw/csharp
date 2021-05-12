using System;
using System.Collections.Generic;
using System.Linq;

namespace Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "hello" });
            users.Add(new Models.User { Name = "Steve", Password = "steve" });
            users.Add(new Models.User { Name = "Lisa", Password = "hello" });

            var helloPassword = from user in users where user.Password == "hello" select user;
            Console.WriteLine("hello passwords:");
            Console.WriteLine(String.Join("\n", helloPassword));

            users.RemoveAll(user => user.Name.ToLower() == user.Password);
            Console.WriteLine("list after lower case name removes:");
            Console.WriteLine(String.Join("\n", users));

            users.Remove(users.First(user => user.Password == "hello"));
            Console.WriteLine("names and passwords after hello first remove:");
            users.ForEach(user => Console.WriteLine(user.Name + " " + user.Password));

        }
    }
}

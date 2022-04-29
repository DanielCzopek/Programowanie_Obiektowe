
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_6
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>()
            {
                new User {Name = "A", Role = "Teacher", Marks = null },
                new User { Name = "B", Role = "Mod", Marks = null },
                new User {Name = "C", Role = "Teacher", Marks = null},
                new User {Name = "D", Role = "Student", Marks = new int[] {1, 2, 3, 4, 4, 5, 5, 4, 3, 3} },
                new User {Name = "F", Role = "Admin", Marks = null},
                new User {Name = "E", Role = "Student", Marks = new int[] {1, 2, 3, 4, 4, 5, 5, 4, 3, 3} },
                new User {Name = "W", Role = "Student", Marks = new int[] {1, 2, 3, 4, 4, 5, 5, 4, 3, 3} },
                new User {Name = "C", Role = "Mod", Marks = null },
                new User {Name = "F", Role = "Student", Marks = new int[] {1, 2, 3, 4, 4, 5, 5, 4, 3, 3} },
                new User {Name = "G", Role = "Teacher", Marks = null },
                new User {Name = "A", Role = "Student", Marks = new int[] {4, 2, 5, 4, 4, 5, 5, 4, 3, 4} },
                new User {Name = "C", Role = "Student", Marks = new int[] {5, 5, 3, 5, 4, 5, 5, 4, 3, 2} },
                new User {Name = "F", Role = "Student", Marks = new int[] {3, 2, 3, 4, 3, 5, 1, 4, 5, 3} },
                new User {Name = "P", Role = "Student", Marks = new int[] {1, 2, 3, 2, 1, 5, 1, 4, 3, 4} },
                new User {Name = "O", Role = "Student", Marks = new int[] {1, 3, 3, 4, 4, 5, 5, 4, 5, 3} },
                new User {Name = "Z", Role = "Student", Marks = new int[] {2, 2, 3, 5, 4, 5, 5, 4, 3, 3} },

            };
            // 1. Ilość rekordów w tablicy
            //Console.WriteLine(users.Count);
            //Console.WriteLine((from user in users select user).Count());
            // 2. Lista nazw użytkowników
            List<string> names_1 = users.Select(user => user.Name).ToList();
            List<string> names_2 = (from user in users select user.Name).ToList();

            //foreach (string name in names_1)
            //    Console.WriteLine(name);
            //foreach (string name in names_2)
            //    Console.WriteLine(name);

            // 3.  Sortowanie użytkowników po nazwach
            List<User> users_1 = users.OrderBy(user => user.Name).ToList();
            List<User> users_2 = (from user in users orderby user.Name select user).ToList();

            //foreach (User user in users_1)
            //    Console.WriteLine(user.Name);
            //foreach(User user in users_2)
            //    Console.WriteLine(user.Name);

            // 4.Lista dostępnych ról użytkowników

            List<string> rules_1 = users.Select(user => user.Role).Distinct().ToList();
            List<string> rules_2 = (from user in users select user.Role).Distinct().ToList();

            //foreach (string rule in rules_1)
            //    Console.WriteLine(rule);
            //foreach (string rule in rules_2)
            //    Console.WriteLine(rule);

            // 5. Lista pogrupowanych użytkowników po rolach

            var roles_1 = users.GroupBy(user => user.Role)
                                      .Select(group => group).ToList();

            //foreach (var group in roles_1)
            //{
            //    Console.WriteLine(group.Key);

            //    foreach (User user in group)
            //    {
            //        Console.WriteLine("--> " + user.Name);
            //    }
            //}

            var roles_2 = (from user in users group user by user.Role).ToList();

            //foreach (var group in roles_2)
            //{
            //    Console.WriteLine(group.Key);

            //    foreach (User user in group)
            //    {
            //        Console.WriteLine("--> " + user.Name);
            //    }
            //}

            // 6. Ilość rekordów, dla których podano oceny( nie null i więcej niż 0
            Console.WriteLine (users.Count(user => user.Marks is not null && 
            users.Count(user => user.Marks) > 0);
            


        }
    }


    public class User
    {
        public string Name { get; set; }
        public string Role { get; set; } // ADMIN, MODERATOR, TEACHER, STUDENT
        public int Age { get; set; }
        public int[] Marks { get; set; } // zawsze null gdy ADMIN, MODERATOR lub TEACHER
        public DateTime? CreatedAt { get; set; }
        public DateTime? RemovedAt { get; set; }
    }
    //   public IComparer <User>  


}




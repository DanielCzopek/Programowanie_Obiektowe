
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Lab_6
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>()
            {
                new User {Name = "A", Role = "Teacher",Marks = null },
                new User { Name = "B", Role = "Mod", Marks = null },
                new User {Name = "C", Role = "Teacher", Marks = null},
                new User {Name = "D", Role = "Student", Marks = new int[] {1, 2, 3, 4, 4, 5, 5, 4, 3, 3} },
                new User {Name = "F", Role = "Admin", Marks = null},
                new User {Name = "E", Role = "Student", Marks = new int[] {1, 2, 3, 4, 4, 5, 5, 3} },
                new User {Name = "W", Role = "Student", Marks = new int[] {1, 5, 4, 3, 3} },
                new User {Name = "C", Role = "Mod", Marks = null},
                new User {Name = "F", Role = "Student", Marks = new int[] {1, 2, 3, 4, 5, 5, 4, 3, 3} },
                new User {Name = "G", Role = "Teacher", Marks = null},
                new User {Name = "A", Role = "Student", Marks = new int[] {4, 4, 4, 5, 5, 4, 3, 4} },
                new User {Name = "C", Role = "Student", Marks = new int[] {5, 5, 3, 5, 4, 5, 5, 4, 3, 2} },
                new User {Name = "F", Role = "Student", Marks = new int[] {3, 2, 3, 4, 3, 5, 1, 4, 3} },
                new User {Name = "P", Role = "Student", Marks = new int[] { } },
                new User {Name = "O", Role = "Student", Marks = new int[] {4, 5, 5, 4, 5, 3} },
                new User {Name = "Z", Role = "Student", Marks = new int[] {2, 2, 3, 5, 5, 3, 3} },


            };

            ///////////////////////////////////////////////////////////////////////
            ///

            // 1. Ilość rekordów w tablicy
            //Console.WriteLine(users.Count);
            //Console.WriteLine((from user in users select user).Count());

            /////////////////////////////////////////////////////////////////////
            ///

            // 2. Lista nazw użytkowników
            List<string> names_1 = users.Select(user => user.Name).ToList();
            List<string> names_2 = (from user in users select user.Name).ToList();

            //foreach (string name in names_1)
            //    Console.WriteLine(name);
            //foreach (string name in names_2)
            //    Console.WriteLine(name);

            ////////////////////////////////////////////////////////////////////
            ///

            // 3.  Sortowanie użytkowników po nazwach
            List<User> users_1 = users.OrderBy(user => user.Name).ToList();
            List<User> users_2 = (from user in users orderby user.Name select user).ToList();

            //foreach (User user in users_1)
            //    Console.WriteLine(user.Name);
            //foreach(User user in users_2)
            //    Console.WriteLine(user.Name);

            ///////////////////////////////////////////////////////////////////
            ///

            // 4.Lista dostępnych ról użytkowników

            List<string> rules_1 = users.Select(user => user.Role).Distinct().ToList();
            List<string> rules_2 = (from user in users select user.Role).Distinct().ToList();

            //foreach (string rule in rules_1)
            //    Console.WriteLine(rule);
            //foreach (string rule in rules_2)
            //    Console.WriteLine(rule);

            ////////////////////////////////////////////////////////////
            ///

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

            ////////////////////////////////////////////////////////////////////////////////
            ///

            // 6. Ilość rekordów, dla których podano oceny ( nie null i więcej niż 0 )

            var oceny_1 = (users.Count(user => user.Marks is not null));

            var oceny_2 = (from user in users where user.Marks is not null select user.Marks).Count();

            // Console.WriteLine(oceny_1);
            //Console.WriteLine(oceny_2);

            // TODO: Zrobić tak by działało też dla > 0

            /////////////////////////////////////////////////////////////////////////////////////
            ///


            // 7. Suma, ilość i średnia wszystkich ocen studentów

            // var zip = users.Zip((user => user.Marks), (a, b) => (a + b);

            for (int i = 0; i < users.Count; i++)
            {
                int summed =+ users.Select(user => user.Marks).ToArray();
            }

            Console.WriteLine(summed);
          // var zipped = users.Zip(from user in users select user.Marks).ToArray();

            // Console.WriteLine(zipped);
            //foreach (var value in zip)
            //{
            //    Console.WriteLine(value);
            //}

            //Array Summed = Array.Copy(user => user.Marks, users.Capacity, );

            //Array Summed = Array.CreateInstance(typeof(System.Int32), 5);
            //for (int i = Summed.GetLowerBound(0); i <= Summed.GetUpperBound(0); i++)
            //    Summed.SetValue(i + 1, i);

            //Console.WriteLine(Summed);


            // Expression<Func<bool>> whereClauseDynamicSomeTable = t => true;
            //// takie coś w sieci znalazłem może zadziała


            // int[] summed = users.Sum(user => user.Marks);

            // var sum = (users.CopyTo(user => user.Marks is not null);



            //Console.WriteLine(suma_ocen);



            // Console.WriteLine(Suma_ocen_2);

            //TODO: Nie działa

            /////////////////////////////////////////////////////////////////////////////
            ///

            // 8. Najlepsza ocena



            // int Najlepsza_ocena_2 = from user in users select user.Marks.Max();

            //TODO: Naprawić nie działa

            //Console.WriteLine(Najlepsza_ocena_2);

            // 9. Najgorsza ocena 


            // 10. Najlepszego studenta

            // 11.Lista studentów, którzy posiadają najmniej ocen

            // List<string> students_marks_1 = user => user.Marks

            // var count = users.Count(user => user.Marks);

            //  List<string> students_min_Marks = (count user.Marks from user in users where user.Marks ).Count().ToString().ToList();



            // 12. Lista studentów, którzy posiadają najwięcej ocen

            // 13. Lista obiektów zawierających tylko nazwę i średnią ocenę(mapowanie na inny obiekt)

            // 14. Studentów posortowanych od najlepszego

            // 15. Średnią ocenę wszystkich studentów

            // 16. Listę użytkowników pogrupowanych po miesiącach daty utworzenia(np. 2022 - 02, 2022 - 03, 2022 - 04, itp.)

            // 17. Listę użytkowników, którzy nie zostali usunięci(data usunięcia nie została ustawiona)

            // 18. Najnowszego studenta(najnowsza data utworzenia)

        }


    }

    public class User
    {
        public string Name { get; set; }
        public string Role { get; set; } // ADMIN, MODERATOR, TEACHER, STUDENT
        public int Age { get; set; }
        public int[]? Marks { get; set; } // zawsze null gdy ADMIN, MODERATOR lub TEACHER
        public DateTime? CreatedAt { get; set; }
        public DateTime? RemovedAt { get; set; }
    }
}




using System;
using System.Collections.Generic;
using System.Linq;

namespace Laby_6_domowe
{
    class Program
    {

        public static void Main(string[] args)
        {
            List<User> users = new List<User>()
            {
                new User {Name = "A", Role = "Teacher",Marks = null,
                    CreatedAt = new DateTime(2021,1,1) },
                new User { Name = "B", Role = "Mod", Marks = null,
                    CreatedAt = new DateTime(2021,12,20) , RemovedAt = new DateTime(2022,1,15) },
                new User {Name = "C", Role = "Teacher", Marks = null,
                    CreatedAt = new DateTime(2010,6,15)},
                new User {Name = "D", Role = "Student", Marks = new int [] {1, 2, 3, 4, 4, 5, 5, 4, 3, 3},
                    CreatedAt = new DateTime(2022,2,12), RemovedAt = new DateTime(2022,5,5) },
                new User {Name = "F", Role = "Admin", Marks = null,
                    CreatedAt = new DateTime(2016,7,17)},
                new User {Name = "E", Role = "Student", Marks = new int [] {1, 2, 3, 4, 4, 5, 5, 3},
                    CreatedAt = new DateTime(2012,12,12) },
                new User {Name = "W", Role = "Student", Marks = new int [] {1, 5, 4, 3, 3},
                    CreatedAt = new DateTime(2017,3,29) },
                new User {Name = "C", Role = "Mod", Marks = null,
                    CreatedAt = new DateTime(2021,11,1), RemovedAt = new DateTime(2021,11,5)},
                new User {Name = "F", Role = "Student", Marks = new int [] {1, 2, 3, 4, 5, 5, 4, 3, 3},
                    CreatedAt = new DateTime(2020,8,19) },
                new User {Name = "G", Role = "Teacher", Marks = null,
                    CreatedAt = new DateTime(2013,5,13)},
                new User {Name = "A", Role = "Student", Marks = new int [] {4, 4, 4, 5, 5, 4, 3, 4},
                    CreatedAt = new DateTime(2007,7,7), RemovedAt = new DateTime(2008,5,5) },
                new User {Name = "C", Role = "Student", Marks = new int [] {5, 5, 3, 5, 4, 5, 5, 4, 3, 2},
                CreatedAt = new DateTime(2019,1,15), RemovedAt = new DateTime(2020,12,25)},
                new User {Name = "F", Role = "Student", Marks = new int [] {3, 2, 3, 4, 3, 5, 1, 4, 3},
                CreatedAt = new DateTime(2019,1,17)},
                new User {Name = "P", Role = "Student", Marks = new [] { 1 },
                CreatedAt = new DateTime(2002,2,2),RemovedAt = new DateTime(2002,2,3)},
                new User {Name = "O", Role = "Student", Marks = new [] {4, 5, 5, 4, 5, 3},
                CreatedAt = new DateTime(2007,12,29)},
                new User {Name = "Z", Role = "Student", Marks = new [] {2, 2, 3, 5, 5, 3, 3},
                CreatedAt = new DateTime(2022,1,9), RemovedAt = new DateTime(2022,3,5)},
            };

            ///////////////////////////////////////////////////////////////////////
            ///

            //1.Ilość rekordów w tablicy

            Console.WriteLine("1. Ilość rekowrdów w tablicy");

            Console.WriteLine(users.Count);
            Console.WriteLine("--------------------------------");
            Console.WriteLine((from user in users select user).Count());

            /////////////////////////////////////////////////////////////////////
            ///

            // 2. Lista nazw użytkowników

            Console.WriteLine("2. Lista nazw użytkowników");

            List<string> names_1 = users.Select(user => user.Name).ToList();
            List<string> names_2 = (from user in users select user.Name).ToList();

            foreach (string name in names_1)
                Console.WriteLine(name);
            Console.WriteLine("--------------------------------");
            foreach (string name in names_2)
                Console.WriteLine(name);

            ////////////////////////////////////////////////////////////////////
            ///

            // 3.  Sortowanie użytkowników po nazwach

            Console.WriteLine("3. Sortowanie użytkowników po nazwach");

            List<User> users_1 = users.OrderBy(user => user.Name).ToList();
            List<User> users_2 = (from user in users orderby user.Name select user).ToList();

            foreach (User user in users_1)
                Console.WriteLine(user.Name);
            Console.WriteLine("--------------------------------");
            foreach (User user in users_2)
                Console.WriteLine(user.Name);

            ///////////////////////////////////////////////////////////////////
            ///

            // 4.Lista dostępnych ról użytkowników

            Console.WriteLine("4. Lista dostępnych ról użytkowników");

            List<string> rules_1 = users.Select(user => user.Role).Distinct().ToList();
            List<string> rules_2 = (from user in users select user.Role).Distinct().ToList();

            foreach (string rule in rules_1)
                Console.WriteLine(rule);
            Console.WriteLine("--------------------------------");
            foreach (string rule in rules_2)
                Console.WriteLine(rule);

            ////////////////////////////////////////////////////////////
            ///

            // 5. Lista pogrupowanych użytkowników po rolach

            Console.WriteLine("5. Lista pogrupowanych użytkowników po rolach");

            var roles_1 = users.GroupBy(user => user.Role)
                                      .Select(group => group).ToList();

            foreach (var group in roles_1)
            {
                Console.WriteLine(group.Key);

                foreach (User user in group)
                {
                    Console.WriteLine("--> " + user.Name);
                }
            }

            Console.WriteLine("--------------------------------");

            var roles_2 = (from user in users group user by user.Role).ToList();

            foreach (var group in roles_2)
            {
                Console.WriteLine(group.Key);

                foreach (User user in group)
                {
                    Console.WriteLine("--> " + user.Name);
                }
            }

            ////////////////////////////////////////////////////////////////////////////////
            ///

            // 6. Ilość rekordów, dla których podano oceny ( nie null i więcej niż 0 )

            Console.WriteLine("6. Ilość rekordów, dla których podano oceny ( nie null i więcej niż 0 )");

            var Marks_1 = (users.Count(user => user.Marks is not null
            && user.Marks.Length > 0));

            var Marks_2 = (from user in users
                           where user.Marks is not null
        && user.Marks.Length > 0
                           select user.Marks).Count();

            Console.WriteLine(Marks_1);
            Console.WriteLine("--------------------------------");
            Console.WriteLine(Marks_2);

            /////////////////////////////////////////////////////////////////////////////////////
            ///

            // 7. Suma, ilość i średnia wszystkich ocen studentów

            Console.WriteLine("7. Suma, ilość i średnia wszystkich ocen studentów");

            var Sum_1 = users.Where(user => user.Marks is not null
             && user.Marks.Length > 0).Select(user => user.Marks.Sum()).Sum();

            var Sum_2 = (from user in users
                         where user.Marks is not null
      && user.Marks.Length > 0
                         select user.Marks.Sum()).Sum();

            Console.WriteLine(Sum_1);
            Console.WriteLine("--------------------------------");
            Console.WriteLine(Sum_2);

            var Count_1 = users.Where(user => user.Marks is not null
            && user.Marks.Length > 0).Select(user => user.Marks.Count()).Sum();

            var Count_2 = (from user in users
                           where user.Marks is not null
        && user.Marks.Length > 0
                           select user.Marks.Count()).Sum();

            Console.WriteLine(Count_1);
            Console.WriteLine("--------------------------------");
            Console.WriteLine(Count_2);

            var Avr_1 = users.Where(user => user.Marks is not null
            && user.Marks.Length > 0).Select(user => user.Marks.Average()).Average();
            var Avr_2 = (from user in users
                         where user.Marks is not null
      && user.Marks.Length > 0
                         select user.Marks.Average()).Average();

            Console.WriteLine(Avr_1);
            Console.WriteLine("--------------------------------");
            Console.WriteLine(Avr_2);

            /////////////////////////////////////////////////////////////////////////////
            ///

            // 8. Najlepsza ocena

            Console.WriteLine("8. Najlepsza ocena");

            var BestMark_1 = users.Where(user => user.Marks is not null
            && user.Marks.Length > 0).Select(user => user.Marks.Max()).Max();

            var BestMark_2 = (from user in users
                              where user.Marks is not null
           && user.Marks.Length > 0
                              select user.Marks.Max()).Max();

            Console.WriteLine(BestMark_1);
            Console.WriteLine("--------------------------------");
            Console.WriteLine(BestMark_2);

            /////////////////////////////////////////////////////////////////////////////
            ///

            // 9. Najgorsza ocena 

            Console.WriteLine("9. Najgorsza ocena ");

            var WorstMark_1 = users.Where(user => user.Marks is not null
           && user.Marks.Length > 0).Select(user => user.Marks.Min()).Min();

            var WorstMark_2 = (from user in users
                               where user.Marks is not null
            && user.Marks.Length > 0
                               select user.Marks.Min()).Min();

            Console.WriteLine(WorstMark_1);
            Console.WriteLine("--------------------------------");
            Console.WriteLine(WorstMark_2);

            //////////////////////////////////////////////////////////////
            ///

            // 10. Najlepszego studenta

            //Console.WriteLine("10. Najlepszego studenta");

            //var BestStudent_1 = users.OrderBy(user => user.Marks.Average()).Where(user => user.Marks is not null &&
            //user.Marks.Length > 0).Select(user => user.Name);

            ////var Best_Avr_1 = users.Where(user => user.Marks is not null 
            ////&& user.Marks.Length > 0).Select(user => user.Marks.Average).Max();

            //var Best_Avr_2 = (from user in users
            //                  where user.Marks is not null && user.Marks.Length > 0
            //                  select user.Marks.Average()).Max();


            //var BestStudent_2 = (from user in users
            //                     where user.Marks is not null
            //  && user.Marks.Length > 0 && user.Marks.Average().CompareTo(Best_Avr_2) == Best_Avr_2
            //                     select user.Name);


            //Console.WriteLine(Best_Avr_2);
            //Console.WriteLine("--------------------------------");
            //Console.WriteLine(BestStudent_1);
            //Console.WriteLine("--------------------------------");
            //Console.WriteLine(BestStudent_2);

            // TODO: Nie działa

            ////////////////////////////////////////////////////////////////
            ///

            // 11.Lista studentów, którzy posiadają najmniej ocen

            //Console.WriteLine("11. Lista studentów, którzy posiadają najmniej ocen");

            //var Worst_student_list_1 = users.Select(user => user).OrderBy(user => user.Marks.Length).Where(user => user.Marks is not null &&
            //user.Marks.Length > 0);

            //var WorstStudentList_2 = (from user in users
            //                          where user.Marks is not null && user.Marks.Length > 0
            //                          orderby user.Marks.Length
            //                          select user).ToList();

            //foreach (var user in Worst_student_list_1.Take(1))
            //{
            //    Console.WriteLine(user.Name);
            //}
            //Console.WriteLine("--------------------------------");
            //foreach (var user in WorstStudentList_2.Take(1))
            //{
            //    Console.WriteLine(user.Name);
            //}

            ///////////////////////////////////////////////////////////////////
            ///

            // 12. Lista studentów, którzy posiadają najwięcej ocen

            //Console.WriteLine("12. Lista studentów, którzy posiadają najwięcej ocen");

            //var BestStudentList_1 = users.Select(user => user).OrderByDescending(user => user.Marks.Length).Where(user => user.Marks
            //is not null &&
            //user.Marks.Length > 0);

            //var BestStudentList_2 = (from user in users
            //                         where user.Marks is not null && user.Marks.Length > 0
            //                         orderby user.Marks.Length
            //                         descending select user).ToList();

            //foreach (var user in BestStudentList_1.Take(1))
            //{
            //    Console.WriteLine(user.Name);
            //}
            //Console.WriteLine("--------------------------------");
            //foreach (var user in BestStudentList_2.Take(1))
            //{
            //    Console.WriteLine(user.Name);
            //}

            // 13. Lista obiektów zawierających tylko nazwę i średnią ocenę(mapowanie na inny obiekt)

            // 14. Studentów posortowanych od najlepszego

            // 15. Średnią ocenę wszystkich studentów

            Console.WriteLine("15. Średnią ocenę wszystkich studentów");

            var TotalAvr_1 = users.Where(user => user.Marks is not null &&
            user.Marks.Length > 0).Select(user => user.Marks.Average()).Average();

            var TotalAvr_2 = (from user in users
                              where user.Marks is not null && user.Marks.Length > 0
                              select user.Marks.Average()).Average();

            Console.WriteLine(TotalAvr_1);
            Console.WriteLine("--------------------------------");
            Console.WriteLine(TotalAvr_2);

            //////////////////////////////////////////////////////////////
            //

            // 16. Lista użytkowników pogrupowanych po miesiącach daty utworzenia(np. 2022 - 02, 2022 - 03, 2022 - 04, itp.)

            Console.WriteLine("16. Lista użytkowników pogrupowanych po miesiącach daty utworzenia" +
                "(np. 2022 - 02, 2022 - 03, 2022 - 04, itp.)");

            var UserList_1 = users.GroupBy(user => user.CreatedAt).OrderByDescending(user => user.Key);
            Console.WriteLine("Zadanie 16");
            var UserList_2 = (from user in users
                              orderby user.CreatedAt
                              group user by user.CreatedAt);

            foreach (var UsersList_1 in UserList_1)
            {
                Console.WriteLine(UsersList_1.Key.ToString());
                foreach (var user in UsersList_1)
                {
                    Console.WriteLine(user.Name);
                }
            }

            Console.WriteLine();

            foreach (var UsersList_2 in UserList_2)
            {
                Console.WriteLine(UsersList_2.Key.ToString());
                foreach (var user in UsersList_2)
                {
                    Console.WriteLine(user.Name);
                }
            }

            //TODO: Sortuje po roku nie po miesiącach

            ///////////////////////////////////////////////////////////////////
            ///

            // 17. Listę użytkowników, którzy nie zostali usunięci(data usunięcia nie została ustawiona)

            Console.WriteLine("17. Listę użytkowników, którzy nie zostali usunięci" +
                "(data usunięcia nie została ustawiona)");

            var UsersNotRemoved_1 = users.Where(user => user.RemovedAt == null).Select(user => user).ToList();
            var UsersNotRemoved_2 = (from user in users
                                     where user.RemovedAt == null
                                     select user).ToList();

            foreach (var user in UsersNotRemoved_2)
                Console.WriteLine(user.Name);
            Console.WriteLine();
            foreach (var user in UsersNotRemoved_1)
                Console.WriteLine(user.Name);

            /////////////////////////////////////////////////////////////
            ///

            // 18. Najnowszego studenta(najnowsza data utworzenia)

            Console.WriteLine("18. Najnowszego studenta(najnowsza data utworzenia)");

            var NewestStudent_1 = (from user in users
                                   orderby user.CreatedAt descending
                                   select user).ToList();
            var NewestStudent_2 = users.OrderBy(user => user.CreatedAt).Select(user => user).ToList();

            foreach (var user in NewestStudent_1.Take(1))
            {
                Console.WriteLine(user.Name);
            }
            foreach (var user in NewestStudent_2.Take(1))
            {
                Console.WriteLine(user.Name);
            }

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

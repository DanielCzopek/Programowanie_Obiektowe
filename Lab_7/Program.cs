using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace Lab_7
{
    class Program : UserEntity
    {
            public static void Main()
            {
                // Uwaga: zmień `DESKTOP-123ABC\SQLEXPRESS` na nazwę swojego serwera.

                string connectionString = @"Data Source=DESKTOP-123ABC\SQLEXPRESS;Initial Catalog=projectdb;Integrated Security=True";

                using (DataContext dataContext = new DataContext(connectionString))
                {
                    Table<UserEntity> users = dataContext.GetTable<UserEntity>();

                    IQueryable<UserEntity> query = from user in users
                                                   where user.RemovedAt.HasValue == false // user.RemovedAt == null
                                                   select user;

                    foreach (UserEntity user in query)
                        Console.WriteLine("{0} {1}", user.Id, user.Name);
                }
            }
    }
}

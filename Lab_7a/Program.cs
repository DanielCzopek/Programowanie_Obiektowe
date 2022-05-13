using System;
using System.IO;
using System.Text.Json;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

public class Program
{
    public static void Main()
    {
        var user = new User
        {
            Id = 1,
            Name = "Jan Kowalski",
            Age = 30,
        };

        string json = JsonSerializer.Serialize(user);

        Console.WriteLine(json); // {"Id":1,"Name":"Jan Kowalski","Age":30}
    }
}
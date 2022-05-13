using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;


// serialize object to json
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

/////////////////////////////////////////////////////////////////////

// serialize object to xml
public class User2
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

public class Program2
{
    public static void Main()
    {
        var user = new User2
        {
            Id = 1,
            Name = "Jan Kowalski",
            Age = 30
        };

        XmlSerializer serializer = new XmlSerializer(typeof(User2));

        using (MemoryStream s = new MemoryStream())
        {
            serializer.Serialize(s, user);

            string xml = Encoding.UTF8.GetString(s.ToArray());

            Console.WriteLine(xml);  // <?xml version="1.0"?>
                                     // <User xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
                                     //   <Id>1</Id>
                                     //   <Name>Jan Kowalski</Name>
                                     //   <Age>30</Age>
                                     // </User>
        }
    }
}

/////////////////////////////////////////////////////////////////////
///

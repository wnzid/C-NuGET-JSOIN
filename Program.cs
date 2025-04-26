using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
    }

    static void Main(string[] args)
    {
        string filePath = "user.json";

        // 1. Read existing users
        string jsonResponse = File.ReadAllText(filePath);
        List<User> users = JsonConvert.DeserializeObject<List<User>>(jsonResponse);

        // 2. Display existing users
        Console.WriteLine("Current users:");
        foreach (var user in users)
        {
            Console.WriteLine($"{user.Name}, {user.Age}, {user.City}");
        }

        // 3. Add a new user
        User newUser = new User
        {
            Name = "Alice Smith",
            Age = 25,
            City = "London"
        };

        users.Add(newUser);
        Console.WriteLine("\nNew user added!");

        // 4. Save updated list back to JSON file
        string updatedJson = JsonConvert.SerializeObject(users, Formatting.Indented);
        File.WriteAllText(filePath, updatedJson);

        // 5. Show all users again
        Console.WriteLine("\nUpdated user list:");
        foreach (var user in users)
        {
            Console.WriteLine($"{user.Name}, {user.Age}, {user.City}");
        }
        // 6. Read users from XML file
        Console.WriteLine("\nReading users from XML:");
        XMLReader.ReadXML("users.xml");
    }
}
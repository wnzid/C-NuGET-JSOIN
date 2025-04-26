using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

public class Program
{
    public class User
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? City { get; set; }
    }

    public static User CreateUserFromJson(JObject obj)
    {
        string userType = (string)obj["UserType"];

        if (userType == "Admin")
        {
            return new Admin
            {
                Name = (string?)obj["Name"],
                Age = (int)obj["Age"],
                City = (string?)obj["City"],
                AdminRole = (string?)obj["AdminRole"]
            };
        }
        else
        {
            return new RegularUser
            {
                Name = (string?)obj["Name"],
                Age = (int)obj["Age"],
                City = (string?)obj["City"],
                Membership = (string?)obj["Membership"]
            };
        }
    }

    static void Main(string[] args)
    {
        string filePath = "user.json";

        // 1. Read existing users from JSON
        string jsonResponse = File.ReadAllText(filePath);
        List<User> users = JsonConvert.DeserializeObject<List<User>>(jsonResponse);

        // 2. Display current users
        Console.WriteLine("Current users:");
        foreach (var user in users)
        {
            Console.WriteLine($"{user.Name}, {user.Age}, {user.City}");
        }

        // 3. Add new user
        User newUser = new User
        {
            Name = "Alice Smith",
            Age = 25,
            City = "London"
        };

        users.Add(newUser);
        Console.WriteLine("\nNew user added!");

        // 4. Save updated list
        string updatedJson = JsonConvert.SerializeObject(users, Formatting.Indented);
        File.WriteAllText(filePath, updatedJson);

        // 5. Show updated list
        Console.WriteLine("\nUpdated user list:");
        foreach (var user in users)
        {
            Console.WriteLine($"{user.Name}, {user.Age}, {user.City}");
        }

        // 6. Read users from XML file
        Console.WriteLine("\nReading users from XML:");
        XMLReader.ReadXML("users.xml");


        Admin adminUser = new Admin
        {
            Name = "Admin John",
            Age = 40,
            City = "Paris",
            AdminRole = "SuperAdmin"
        };

        RegularUser regularUser = new RegularUser
        {
            Name = "Regular Jane",
            Age = 22,
            City = "Berlin",
            Membership = "Gold"
        };

        Console.WriteLine($"\nAdmin User:");
        Console.WriteLine($"Name: {adminUser.Name}, Age: {adminUser.Age}, City: {adminUser.City}, Role: {adminUser.AdminRole}");

        Console.WriteLine($"\nRegular User:");
        Console.WriteLine($"Name: {regularUser.Name}, Age: {regularUser.Age}, City: {regularUser.City}, Membership: {regularUser.Membership}");

        Console.WriteLine("\nReading users from users_with_types.json:");

        string typeJson = File.ReadAllText("users_with_types.json");
        JArray userArray = JArray.Parse(typeJson);

        foreach (var item in userArray)
        {
            var user = CreateUserFromJson((JObject)item);

            Console.WriteLine($"\nName: {user.Name}, Age: {user.Age}, City: {user.City}");

            if (user is Admin admin)
            {
                Console.WriteLine($"Type: Admin, Role: {admin.AdminRole}");
            }
            else if (user is RegularUser regular)
            {
                Console.WriteLine($"Type: User, Membership: {regular.Membership}");
            }
        }
    }
}

using Newtonsoft.Json;
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

    static void Main(string[] args)
    {
        string filePath = "user.json";

        // 1. Read existing users from the JSON file
        string jsonResponse = File.ReadAllText(filePath);
        List<User> users = JsonConvert.DeserializeObject<List<User>>(jsonResponse);

        // 2. Display current users
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

        // 4. Save the updated user list back to the JSON file
        string updatedJson = JsonConvert.SerializeObject(users, Formatting.Indented);
        File.WriteAllText(filePath, updatedJson);

        // 5. Show updated user list
        Console.WriteLine("\nUpdated user list:");
        foreach (var user in users)
        {
            Console.WriteLine($"{user.Name}, {user.Age}, {user.City}");
        }

        // 6. Read users from XML file
        Console.WriteLine("\nReading users from XML:");
        XMLReader.ReadXML("users.xml");

        // Testing Admin and RegularUser classes
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
    }
}

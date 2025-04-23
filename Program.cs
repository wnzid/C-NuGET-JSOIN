using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    // Define a class to match the JSON structure
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
    }

    static void Main(string[] args)
    {
        // Path to the local JSON file
        string filePath = "user.json";

        // Read the JSON data from the file
        string jsonResponse = File.ReadAllText(filePath);

        // Deserialize the JSON into a list of User objects
        List<User> users = JsonConvert.DeserializeObject<List<User>>(jsonResponse);

        // Display each user's information
        Console.WriteLine("Users from JSON file:");
        foreach (var user in users)
        {
            Console.WriteLine($"Name: {user.Name}");
            Console.WriteLine($"Age: {user.Age}");
            Console.WriteLine($"City: {user.City}");
            Console.WriteLine();
        }
    }
}
using Newtonsoft.Json;
using System;
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

        // Deserialize the JSON into a C# object
        User user = JsonConvert.DeserializeObject<User>(jsonResponse);

        // Display the user's information
        Console.WriteLine($"Name: {user.Name}");
        Console.WriteLine($"Age: {user.Age}");
        Console.WriteLine($"City: {user.City}");
    }
}
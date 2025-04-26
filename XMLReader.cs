using System;
using System.Xml;

public class XMLReader
{
    public static void ReadXML(string path)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(path);

        foreach (XmlNode node in doc.DocumentElement)
        {
            string name = node["Name"]?.InnerText;
            string age = node["Age"]?.InnerText;

            Console.WriteLine($"[XML] Name: {name}, Age: {age}");
        }
    }
}

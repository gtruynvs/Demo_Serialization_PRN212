using System.Xml.Serialization;

namespace Demo_XMLSerializer_01
{

    [XmlRoot("Candidate")]
    public class Person
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Age")]
        public int Age { get; set; }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person
            {
                Name = "John Doe",
                Age = 25
            };
            var xs = new XmlSerializer(typeof(Person));
            using Stream s1 = File.Create("person.xml");
            xs.Serialize(s1, p);
            s1.Close();

            using Stream s2 = File.OpenRead("person.xml");
            var p2 = (Person)xs.Deserialize(s2);
            Console.WriteLine("=====Person info=====");
            Console.WriteLine($"Name: {p2.Name}, Age: {p2.Age}");
            Console.WriteLine("=====Person.xml=====");
            Console.WriteLine(File.ReadAllText("person.xml"));
            s2.Close();
            Console.ReadLine();
        }
    }
}

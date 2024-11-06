using System.Xml.Serialization;

namespace Demo_XMLSerializer_02
{
    public class Program
    {
        static void Main(string[] args)
        {
            string filename = "person.xml";
            var p = new List<Person> { 
                new Person(30000M){ FirstName = "John", LastName = "Doe", DOB = new DateTime(1970, 1, 1) },
                new Person(40000M){ FirstName = "Jane", LastName = "Doe", DOB = new DateTime(1975, 1, 1), Children = new HashSet<Person>{ new Person(0M) {FirstName = "Sally", LastName = "Cox", DOB = new DateTime(2000, 1, 1) } } }
                };
            var xs = new XmlSerializer(typeof(List<Person>));
            using FileStream fs = File.Create(filename);
            xs.Serialize(fs, p);
            Console.WriteLine("Written {0:N0} byte of XML to {1}", new FileInfo(filename).Length,filename);
            fs.Close();
            Console.WriteLine(new string('*',30));
            Console.WriteLine(File.ReadAllText(filename));
            Console.WriteLine(new string('*', 30));
            using FileStream fs2 = File.OpenRead(filename);
            var p2 = (List<Person>)xs.Deserialize(fs2);
            foreach (var i in p2)
            {
                Console.WriteLine($"{i.LastName} has" + $" {i.Children?.Count ?? 0}");
            }
            fs2.Close();
            Console.ReadLine();
        }
    }
}

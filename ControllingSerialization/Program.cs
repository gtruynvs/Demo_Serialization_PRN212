using System.Text.Json;

namespace ControllingSerialization
{
    public class Program
    {
        static void Main(string[] args)
        {
            var emp1 = new Employee(1000M);
            emp1.Name = "Jack";
            emp1.Email = "j97@gmail.com";
            var op = new JsonSerializerOptions {
                WriteIndented = true,
            };
            Console.WriteLine("*****Serialize*****");
            var json = JsonSerializer.Serialize(emp1, op);
            Console.WriteLine(json);
            Console.WriteLine("*****Deserialize*****");
            var emp2 = JsonSerializer.Deserialize<Employee>(json);
            Console.WriteLine($"Name: {emp2.Name}, Salary: {emp2.Salary}");
            Console.ReadLine();
        }
    }
}

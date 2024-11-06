using System.Text.Json;

namespace JSONSerialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string json = @"{
                ""FullName"": ""John Doe"",
                ""Email"": ""jay97@123.com"",
                ""Salary"": 10000,
            }";

            var options = new JsonSerializerOptions()
            {
                WriteIndented = true,
                ReadCommentHandling = JsonCommentHandling.Skip,
                AllowTrailingCommas = true
            };

            var employee = JsonSerializer.Deserialize<Employee>(json, options);
            Console.WriteLine($"Name: {employee.Name}, Email: {employee.Email}," + $" Salary: {employee.Salary}");
            Console.ReadLine();
        }
    }
}

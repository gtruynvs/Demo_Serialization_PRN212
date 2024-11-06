using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_XMLSerializer_02
{
    public class Person
    {
        public Person()
        {
        }
        public Person(decimal initialSalary) => Salary = initialSalary;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public HashSet<Person> Children { get; set; }
       
        public decimal Salary { get; set; }
    }
}

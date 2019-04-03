using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task
{
    [Serializable]
    public class Person
    {
        public string Id { get; set; }
        public virtual double HourRate { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public double BaseHourRate { get; set; }
        public decimal Salary { get; set; }
        public int Age { get; set; }
        public Person(string Id, string FirstName, string LastName, double BaseHourRate, int Age, decimal Salary)
        {
            this.Id = Id;
            this.Salary = Salary;
            this.Age = Age;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.BaseHourRate = BaseHourRate;
        }
        public Person() { }
    }
}

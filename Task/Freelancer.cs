using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class Freelancer : Person
    {
        public Freelancer(string Id, string FirstName, string LastName, double BaseHourRate, int Age, int Salary) : base(Id, FirstName, LastName, BaseHourRate, Age, Salary) { }
        public override double HourRate { get => BaseHourRate * 1.5; set { } }
    }
}

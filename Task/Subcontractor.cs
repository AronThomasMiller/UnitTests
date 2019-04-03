using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class Subcontractor : Person
    {
        public Subcontractor(string Id, string FirstName, string LastName, double BaseHourRate, int Age, int Salary) : base(Id, FirstName, LastName, BaseHourRate, Age, Salary) { }
        public override double HourRate { get => BaseHourRate * 2.2; set { } }
    }
}

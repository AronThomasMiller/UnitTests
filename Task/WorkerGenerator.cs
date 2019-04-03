using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task
{
    public class WorkerGenerator
    {
        public string RandomGuid()
        {
            Guid guidId = Guid.NewGuid();
            return guidId.ToString();
        }
        public string RandomFirstName(Random rand)
        {
            string[] firstNames = { "aaron", "abdul", "abe", "abel", "abraham", "adam", "adan", "adolfo", "adolph", "adrian", "abby", "abigail", "adele", "adrian" };
            return firstNames[rand.Next(0, firstNames.Length - 1)];
        }
        public string RandomLastName(Random rand)
        {
            string[] lastNames = { "abbott", "acosta", "adams", "adkins", "aguilar" };
            return lastNames[rand.Next(0, lastNames.Length - 1)];
        }
        public int RandomHourRate(Random rand)
        {
            return rand.Next(100);
        }
        public int RandomAge(Random rand)
        {
            return rand.Next(90);
        }
        public int RandomSalary(Random rand)
        {
            return rand.Next(10000);
        }
        public List<Person> Generate(int amount)
        {
            List<Person> people = new List<Person>();
            for (int i = 0; i < amount; i++)
            {
                Random rand = new Random();
                Person obj = new Person(RandomGuid(), RandomFirstName(rand), RandomLastName(rand), RandomHourRate(rand), RandomAge(rand), RandomSalary(rand));
                people.Add(obj);
                Console.WriteLine($"Name {obj.FirstName} {obj.LastName}.");
                Thread.Sleep(100);
                Console.WriteLine();
            }
            return people;
        }
    }
}

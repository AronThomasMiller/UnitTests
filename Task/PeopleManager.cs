using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Task
{
    public class PeopleManager
    {
        string path = @"C:\Users\AronThomasMiller\source\repos\Task\Task\bin\Debug\people.xml";
        public IPersonReader PersonReader { get; set; }
        public IPersonWriter PersonWriter { get; set; }

        public PeopleManager()
        {
        }

        public PeopleManager(IPersonReader personReader, IPersonWriter personWriter)
        {
            PersonReader = personReader;
            PersonWriter = personWriter;
        }

        public List<Person> AddPeople(List<Person> people, List<Person> peopleToAdd)
        {
            foreach (var p in peopleToAdd)
            {
                people.Add(p);
            }
            return people;
        }

        public List<Person> AddPerson(Person person, List<Person> people)
        {
            people.Add(person);
            return people;
        }

        public Person UpdatePerson(string Id, string FirstName, string LastName , Person personToUpdate)
        {
            personToUpdate.Id = Id;
            personToUpdate.FirstName = FirstName;
            personToUpdate.LastName = LastName;
            return personToUpdate;
        }
        public List<Person> Delete(Person person, List<Person> people)
        {
            people.Remove(person);
            return people;
        }
        public List<Person> ByAge(List<Person> people , int min, int max)
        {
            List<Person> newpeople = new List<Person>();
            foreach (var p in people)
            {
                if (p.Age > min && p.Age < max)
                {
                    newpeople.Add(p);
                }
            }
            return newpeople;
        }
        public List<Person> BySalary(List<Person> people, int minSalary, int maxSalary)
        {
            List<Person> newpeople = new List<Person>();
            foreach (var p in people)
            {
                if (p.Salary > minSalary && p.Salary < maxSalary)
                {
                    newpeople.Add(p);
                }
            }
            return newpeople;
        }
    }
}



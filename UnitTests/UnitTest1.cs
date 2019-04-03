using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Task;
using Moq;
using NUnit.Framework.Internal;
using System.Diagnostics;
using System.Xml;
using System.Threading;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void AddPeopleTest()
        {
            Person p = new Person("asaqqwedsa12", "Anton", "Duduk", 20, 30, 500);
            Person p1 = new Person("sadasda121321", "Rezakiri", "Abdul", 50, 44, 800);
            Person p2 = new Person("asklpqwekpkewqsalm22", "Aslam", "Salam", 20, 20, 400);
            Person p3 = new Person("asdasqwqqwcbvxz111", "Goreh", "Zirov", 33, 70, 600);
            List<Person> people = new List<Person>();
            List<Person> peopleToAdd = new List<Person>();
            people.Add(p);
            people.Add(p1);
            peopleToAdd.Add(p2);
            peopleToAdd.Add(p3);
            PeopleManager peopleManager = new PeopleManager();
            var actResult = peopleManager.AddPeople(people, peopleToAdd);
            foreach (var person in peopleToAdd)
            {
                people.Add(person);
            }
            Assert.AreEqual(people, actResult, "Adding list to list");
        }

        [Test]
        public void AddPersonTest()
        {
            Person p = new Person("asaqqwedsa12", "Anton", "Duduk", 20, 30, 500);
            Person p1 = new Person("sadasda121321", "Rezakiri", "Abdul", 50, 44, 800);
            Person p2 = new Person("asklpqwekpkewqsalm22", "Aslam", "Salam", 20, 20, 400);
            List<Person> list = new List<Person>();
            List<Person> expectedResult = new List<Person>();
            expectedResult.Add(p);
            expectedResult.Add(p1);
            expectedResult.Add(p2);
            list.Add(p);
            list.Add(p1);
            list.Add(p2);
            Person person = new Person("asdasqwqqwcbvxz111", "Goreh", "Zirov", 33, 70, 600);
            expectedResult.Add(person);
            PeopleManager peopleManager = new PeopleManager();
            var actResult = peopleManager.AddPerson(person, list);
            Assert.AreEqual(expectedResult, actResult, "Adding Person to list");
        }
        [Test]
        public void DeletePersonTest()
        {
            Person p = new Person("asaqqwedsa12", "Anton", "Duduk", 20, 30, 500);
            Person p1 = new Person("sadasda121321", "Rezakiri", "Abdul", 50, 44, 800);
            Person p2 = new Person("asklpqwekpkewqsalm22", "Aslam", "Salam", 20, 20, 400);
            List<Person> list = new List<Person>();
            List<Person> expectedResult = new List<Person>();
            expectedResult.Add(p);
            expectedResult.Add(p1);
            expectedResult.Add(p2);
            list.Add(p);
            list.Add(p1);
            list.Add(p2);
            PeopleManager peopleManager = new PeopleManager();
            var actResult = peopleManager.Delete(p, list);
            expectedResult.Remove(p);
            Assert.AreEqual(expectedResult, actResult, "Deleting Person from list");
        }

        [Test]
        public void UpdatePersonTest()
        {
            Person expectedResult = new Person("asaqqwedsa12", "Anton", "Duduk", 20, 30, 500);
            Person person = new Person("sadasda121321", "Rezakiri", "Abdul", 50, 44, 800);
            PeopleManager peopleManager = new PeopleManager();
            var actualPerson = peopleManager.UpdatePerson(expectedResult.Id, expectedResult.FirstName, expectedResult.LastName, person);
            Assert.AreEqual(expectedResult.Id, actualPerson.Id, "Comparing Person Id");
            Assert.AreEqual(expectedResult.LastName, actualPerson.LastName, "Comparing Person LastName");
            Assert.AreEqual(expectedResult.FirstName, actualPerson.FirstName, "Comparing Person FirstName");
        }

        [Test]
        public void ByAgeTest()
        {
            Person p = new Person("asaqqwedsa12", "Anton", "Duduk", 20, 30, 500);
            Person p1 = new Person("sadasda121321", "Rezakiri", "Abdul", 50, 44, 800);
            Person p2 = new Person("asklpqwekpkewqsalm22", "Aslam", "Salam", 20, 20, 400);
            Person p3 = new Person("asdasqwqqwcbvxz111", "Goreh", "Zirov", 33, 70, 600);
            List<Person> list = new List<Person>();
            List<Person> expectedResult = new List<Person>();
            list.Add(p);
            list.Add(p1);
            list.Add(p2);
            list.Add(p3);
            PeopleManager peopleManager = new PeopleManager();
            var actualResult = peopleManager.ByAge(list, 21, 69);

            foreach (var person in list)
            {
                if (person.Age > 21 && person.Age < 69)
                {
                    expectedResult.Add(person);
                }
            }
            Assert.AreEqual(expectedResult, actualResult , "Selecting people between min age and max age");
        }

        [Test]
        public void BySalaryTest()
        {
            Person p = new Person("asaqqwedsa12", "Anton", "Duduk", 20, 30, 500);
            Person p1 = new Person("sadasda121321", "Rezakiri", "Abdul", 50, 44, 800);
            Person p2 = new Person("asklpqwekpkewqsalm22", "Aslam", "Salam", 20, 20, 400);
            Person p3 = new Person("asdasqwqqwcbvxz111", "Goreh", "Zirov", 33, 70, 600);
            List<Person> list = new List<Person>();
            List<Person> expectedResult = new List<Person>();
            list.Add(p);
            list.Add(p1);
            list.Add(p2);
            list.Add(p3);
            PeopleManager peopleManager = new PeopleManager();
            var actualResult = peopleManager.BySalary(list, 401, 799);
            foreach (var person in list)
            {
                if (person.Salary > 401 && person.Salary < 799)
                {
                    expectedResult.Add(person);
                }
            }
            Assert.AreEqual(expectedResult, actualResult, "Selecting people between min salary and max salary");
        }
    }
}
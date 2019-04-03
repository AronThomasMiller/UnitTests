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
    public class XmlPersonsReader : IPersonReader
    {
        string path = @"C:\Users\AronThomasMiller\source\repos\Task\Task\bin\Debug\people.xml";
        public List<Person> GetAll()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Person));
            List<Person> newpeople = new List<Person>();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                newpeople = (List<Person>)formatter.Deserialize(fs);
            }
            return newpeople;
        }

        public Person GetAllById(string id)
        {
            Person person = new Person();
            XmlSerializer formatter = new XmlSerializer(typeof(List<Person>));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                List<Person> newpeople = (List<Person>)formatter.Deserialize(fs);

                foreach (Person p in newpeople)
                {
                    if (p.Id == id)
                    {
                        person = p;
                        Console.WriteLine($"Id : {p.Id} Name: {p.FirstName} {p.LastName}");
                    }
                }
            }
            return person;
        }
    }
}

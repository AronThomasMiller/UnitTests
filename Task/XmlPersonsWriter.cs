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
    public class XmlPersonsWriter : IPersonWriter
    {
        string path = @"C:\Users\AronThomasMiller\source\repos\Task\Task\bin\Debug\people.xml";
        public void AddPeople(List<Person> people)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Person>));
            XmlDocument xmlDocument = new XmlDocument();
            if (new FileInfo(path).Length == 0)
            {
                XmlNode xmlNode = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null);
                xmlDocument.AppendChild(xmlNode);
                XmlNode rootNode = xmlDocument.CreateElement("PeopleList");
                xmlDocument.AppendChild(rootNode);
                xmlDocument.Save(path);
            }
            xmlDocument.Load(path);
            var root = xmlDocument.DocumentElement;
            foreach (var p in people)
            {
                var element = xmlDocument.CreateElement("Person");
                var id = xmlDocument.CreateElement("Id");
                id.InnerText = p.Id;
                element.AppendChild(id);
                var firstName = xmlDocument.CreateElement("FirstName");
                firstName.InnerText = p.FirstName;
                element.AppendChild(firstName);
                var lastName = xmlDocument.CreateElement("LastName");
                lastName.InnerText = p.LastName;
                element.AppendChild(lastName);
                var age = xmlDocument.CreateElement("Age");
                age.InnerText = p.Age.ToString();
                element.AppendChild(age);
                var salary = xmlDocument.CreateElement("Salary");
                salary.InnerText = p.Salary.ToString();
                element.AppendChild(salary);
                var baseHourRate = xmlDocument.CreateElement("BaseHourRate");
                baseHourRate.InnerText = p.BaseHourRate.ToString();
                element.AppendChild(baseHourRate);
                root.AppendChild(element);
            }
            xmlDocument.Save(path);
        }

        public List<Person> AddPerson(Person person)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Person>));
            XmlDocument xmlDocument = new XmlDocument();
            if (new FileInfo(path).Length == 0)
            {
                XmlNode xmlNode = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null);
                xmlDocument.AppendChild(xmlNode);
                XmlNode rootNode = xmlDocument.CreateElement("PeopleList");
                xmlDocument.AppendChild(rootNode);
                xmlDocument.Save(path);
            }
            xmlDocument.Load(path);
            var root = xmlDocument.DocumentElement;
            var element = xmlDocument.CreateElement("Person");
            var id = xmlDocument.CreateElement("Id");
            id.InnerText = person.Id;
            element.AppendChild(id);
            var firstName = xmlDocument.CreateElement("FirstName");
            firstName.InnerText = person.FirstName;
            element.AppendChild(firstName);
            var lastName = xmlDocument.CreateElement("LastName");
            lastName.InnerText = person.LastName;
            element.AppendChild(lastName);
            var age = xmlDocument.CreateElement("Age");
            age.InnerText = person.Age.ToString();
            element.AppendChild(age);
            var salary = xmlDocument.CreateElement("Salary");
            salary.InnerText = person.Salary.ToString();
            element.AppendChild(salary);
            var baseHourRate = xmlDocument.CreateElement("BaseHourRate");
            baseHourRate.InnerText = person.BaseHourRate.ToString();
            element.AppendChild(baseHourRate);
            root.AppendChild(element);
            xmlDocument.Save(path);
            XmlSerializer formatter = new XmlSerializer(typeof(Person));
            List<Person> newpeople = new List<Person>();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                newpeople = (List<Person>)formatter.Deserialize(fs);
            }
            return newpeople;
        }

        public List<Person> Delete(string Id)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Person));
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(path);
            XmlNode rootNode = xmlDocument.DocumentElement;
            Person person = new Person();
            XmlNodeList xmlNodeList = rootNode.ChildNodes;
            foreach (XmlNode xmlNode in xmlNodeList)
            {
                if (Id == xmlNode["Id"].InnerText)
                {
                    rootNode.RemoveChild(xmlNode);
                    xmlDocument.Save(path);
                }
            }
            List<Person> newpeople = new List<Person>();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                newpeople = (List<Person>)formatter.Deserialize(fs);
            }
            return newpeople;
        }

        public void Update(string Id, string NewFirstName, string NewLastName)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Person));
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(path);
            XmlNodeList xmlNodeList = xmlDocument.DocumentElement.ChildNodes;
            foreach (XmlNode person in xmlNodeList)
            {
                if (Id == person["Id"].InnerText)
                {
                    person["FirstName"].InnerText = NewFirstName;
                    person["LastName"].InnerText = NewLastName;
                    xmlDocument.Save(path);
                }
            }
        }
    }
}

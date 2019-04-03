using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class JsonPersonsReader : IPersonReader
    {
        public List<Person> GetAll()
        {
            string Json = "[{'FirstName': 'Tom' ,'LastName': 'Cruz' },{ 'FirstName': 'Anton' ,'LastName': 'Zill'}]";
            List<Person> deserializedProduct = JsonConvert.DeserializeObject<List<Person>>(Json);
            foreach (Person p in deserializedProduct)
            {
                Console.WriteLine($"Id : {p.Id} Name: {p.FirstName} {p.LastName}");
            }
            return deserializedProduct;
        }
        public Person GetAllById(string id)
        {
            string Json = "[{'FirstName': 'Tom' ,'LastName': 'Cruz' },{ 'FirstName': 'Anton' ,'LastName': 'Zill'}]";

            List<Person> deserializedProduct = JsonConvert.DeserializeObject<List<Person>>(Json);
            Person person = new Person();

            foreach (Person p in deserializedProduct)
            {
                if (p.Id == id)
                {
                    person = p;
                    Console.WriteLine($"Id : {p.Id} Name: {p.FirstName} {p.LastName}");
                }
            }
            return person;
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class JsonPersonsWriter : IPersonWriter
    {
        public void AddPeople(List<Person> people)
        {
            string Json = "[{'FirstName': 'Tom' ,'LastName': 'Cruz' },{ 'FirstName': 'Anton' ,'LastName': 'Zill'}]";
            List<Person> deserializedProduct = JsonConvert.DeserializeObject<List<Person>>(Json);
            foreach (var person in people)
            {
                deserializedProduct.Add(person);
            }
            string output = JsonConvert.SerializeObject(deserializedProduct);
        }

        public List<Person> Delete(string Id)
        {
            string Json = "[{'FirstName': 'Tom' ,'LastName': 'Cruz' },{ 'FirstName': 'Anton' ,'LastName': 'Zill'}]";
            List<Person> deserializedProduct = JsonConvert.DeserializeObject<List<Person>>(Json);
            var itemToDelete = deserializedProduct.Where(x => x.Id == Id).Select(x => x).First();
            deserializedProduct.Remove(itemToDelete);
            string output = JsonConvert.SerializeObject(deserializedProduct);
            List<Person> resultProduct = JsonConvert.DeserializeObject<List<Person>>(Json);
            return resultProduct;
        }

        public void Update(string Id, string NewFirstName, string NewLastName)
        {
            string Json = "[{'FirstName': 'Tom' ,'LastName': 'Cruz' },{ 'FirstName': 'Anton' ,'LastName': 'Zill'}]";
            Person p = new Person();
            List<Person> deserializedProduct = JsonConvert.DeserializeObject<List<Person>>(Json);
            foreach (var person in deserializedProduct)
            {
                if (person.Id == Id)
                {
                    person.FirstName = NewFirstName;
                    person.LastName = NewLastName;
                    p = person;
                }
            }
            string output = JsonConvert.SerializeObject(deserializedProduct);
        }

        List<Person> IPersonWriter.AddPerson(Person person)
        {
            string Json = "[{'FirstName': 'Tom' ,'LastName': 'Cruz' },{ 'FirstName': 'Anton' ,'LastName': 'Zill'}]";
            List<Person> deserializedProduct = JsonConvert.DeserializeObject<List<Person>>(Json);
            deserializedProduct.Add(person);
            string output = JsonConvert.SerializeObject(deserializedProduct);
            List<Person> resultProduct = JsonConvert.DeserializeObject<List<Person>>(Json);
            return resultProduct;
        }
    }
}

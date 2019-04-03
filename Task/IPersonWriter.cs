using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public interface IPersonWriter
    {
        void Update(string Id, string NewFirstName, string NewLastName);
        List<Person> Delete(string Id);
        void AddPeople(List<Person> people);
        List<Person> AddPerson(Person person);
    }
}

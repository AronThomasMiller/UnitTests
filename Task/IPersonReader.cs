using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public interface IPersonReader
    {
        List<Person> GetAll();
        Person GetAllById(string id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBlogProject.Test
{
    public abstract class Person
    {
        public int Id { get; set; }
        public string PersonName { get; set; }

        List<Person> personList = new List<Person>();

        public Person Add(Person person)
        {
            personList.Add(person);

            return person;
        }
        public abstract void abstractMethod();
       void test() { }
    }
}

using System.Collections.Generic;

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

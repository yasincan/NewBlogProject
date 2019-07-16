using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NewBlogProject.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Developer();
            
            Console.WriteLine("Test");

            Utilities utilities = new Utilities();
            List<Test> people = utilities.BuildList<Test>(new Test(), new Test());

            foreach (var item in people)
            {
                Console.WriteLine(item.Price);
            }
            var computerName=Dns.GetHostName();
            Console.WriteLine(Dns.GetHostByName(computerName).AddressList[2].ToString());

            Test test = new Test();
            Console.WriteLine(test.IsValid);

        }
        class Utilities
        {
            internal List<Type> BuildList<Type>(params Type[] item)
            {
                return new List<Type>(item);
            }
          
        }
        
        class Test
        {
            public int ID { get; set; }
            public string TestName { get; set; }
            public decimal Price { get; set; }

            public bool IsValid =>
                !string.IsNullOrEmpty(TestName) &&
                Price != 0;
        }
    }
}
